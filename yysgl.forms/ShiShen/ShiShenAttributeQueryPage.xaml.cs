using System;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace yysgl.forms
{
	public partial class ShiShenAttributeQueryPage : ContentPage
	{
		void OnClicked(object sender, EventArgs e)
		{
			MessagingCenter.Subscribe<ShiShenLevelListPage, LevelModel>(this, App.LevelSelectMessageKey, async (obj, ed) =>
			  {
				  //MessagingCenter.Unsubscribe<ShiShenLevelListPage, LevelModel>(this, App.LevelSelectMessageKey);
				  if (CrossConnectivity.Current.IsConnected)
				  {
					  var awake = 0;
					  if (switchAwake.IsToggled)
					  {
						  awake = 1;
					  }
					(sender as Button).Text = $"{ed.Star} 星 {ed.Level} 级";
					  await CatchData(heroID, awake, ed.Level, ed.Star);
				  }
				  else
				  {
					  await DisplayAlert("网络错误", "请检查网络连接!", "确定");
				  }

			  });
			Navigation.PushAsync(new ShiShenLevelListPage());
		}

		readonly string url = "https://g37simulator.webapp.163.com/get_hero_attr";
		int heroID;

		public ShiShenAttributeQueryPage(int heroID)
		{
			InitializeComponent();
			this.heroID = heroID;
		}

		private async Task CatchData(int heroid, int awake, int level, int star)
		{
			indicator.IsRunning = true;
			var builder = new UriBuilder(url);
			//heroid 式神ID awake 状态0表示觉醒前 1表示觉醒后 level 式神等级 star 式神星级
			builder.Query = $"heroid={heroID}&awake={awake}&level={level}&star={star}";

			//android OkHttpNetworkHandler
			var client = new HttpClient();
			//client.DefaultRequestHeaders.Add("User-Agent", "");
			var response = await client.GetAsync(builder.ToString());
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<dynamic>(content);
				girdParameter.IsVisible = true;
				attack.Text = result["data"]["attack"].ToString();//攻击
				defense.Text = result["data"]["defense"].ToString();//防御
				life.Text = result["data"]["maxHp"].ToString();//生命
				speed.Text = result["data"]["speed"].ToString();//速度
				crit.Text = $"{float.Parse(result["data"]["critRate"].ToString()) * 100}%";//暴击
			}
			else
			{
				await DisplayAlert("错误", $"服务器{(int)response.StatusCode}错误", "确定");
			}
			indicator.IsRunning = false;
		}

	}
}
