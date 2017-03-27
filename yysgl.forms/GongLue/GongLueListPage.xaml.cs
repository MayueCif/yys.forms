using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Xamarin.Forms;
using System.Linq;
using Acr.UserDialogs;
using System.Collections.ObjectModel;
using Plugin.Connectivity;
using ModernHttpClient;

namespace yysgl.forms
{
	public partial class GongLueListPage : ContentPage
	{
		IProgressDialog loading;
		int pageIndex = 1;
		string url;
		public GongLueListPage(string url, string title)
		{
			InitializeComponent();
			BindingContext = this;
			Title = title;
			this.url = url;

			if (CrossConnectivity.Current.IsConnected)
			{
				loading = UserDialogs.Instance.Loading("加载数据列表");
				//using (this.Dialogs.Loading("Loading (No Cancel)"))
				//	await Task.Delay(TimeSpan.FromSeconds(3));
				Task.Run(() => this.LoadData(url)).Wait();
				loading.Hide();
				//var task = Task.Factory.StartNew(() => this.LoadData(url));
				//task.ContinueWith((t) => { loading.Hide(); });
				//task.Start();
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!CrossConnectivity.Current.IsConnected)
			{
				footer.IsVisible = false;
				UserDialogs.Instance.ShowError("网路连接异常！" + Environment.NewLine + "请检查网络连接");
			}
		}

		private async Task LoadData(string url)
		{
			var htmlDocument = new HtmlDocument();
			//https://github.com/paulcbetts/ModernHttpClient
			htmlDocument.LoadHtml(await new HttpClient(new NativeMessageHandler()).GetAsync(url).Result.Content.ReadAsStringAsync());
			var node = htmlDocument.GetElementbyId("Jlist");
			if (node == null)
			{
				footer.IsVisible = false;
				await DisplayAlert("提示", "没有更多内容了", "确定");
				return;
			}
			foreach (var item in node.Descendants("div").Where(d => d.GetAttributeValue("class", "") == "item"))
			{

				var pElements = item.Descendants("p");
				var title = pElements.Where(p => p.GetAttributeValue("class", "") == "p-tit").First().InnerText;
				//var message = pElements.Where(p => p.GetAttributeValue("class", "") == "p-mess").First().InnerText;
				var data = title.Split(' ');
				var _url = item.Descendants("a").First().GetAttributeValue("href", "");

				//fix Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: Invalid update: invalid number of rows in section 0.  
				//The number of rows contained in an existing section after the update (1) must be equal to the number of rows contained in that section before the update (15), 
				//plus or minus the number of rows inserted or deleted from that section (1 inserted, 0 deleted) and plus or minus the number of rows moved into or out of that section (0 moved in, 0 moved out).
				Device.BeginInvokeOnMainThread(() =>
				{
					Source.Add(new GongLueTextCellModel()
					{
						Title = data[1],
						Detail = data[0],
						Url = _url
					});
				});

			}
		}

		private async Task LoadMore(int index)
		{
			var _url = url.Replace("index", "index" + "_" + index);
			await LoadData(_url);
		}

		public ObservableCollection<GongLueTextCellModel> Source
		{
			get;
			set;
		} = new ObservableCollection<GongLueTextCellModel>();

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				var model = e.SelectedItem as GongLueTextCellModel;
				Navigation.PushAsync(new GongLueContentPage(model.Url, model.Title));
				(sender as ListView).SelectedItem = null;
			}
		}

		async void LoadMoreTapped(object sender, EventArgs e)
		{
			await LoadMore(++pageIndex);
		}
	}
}
