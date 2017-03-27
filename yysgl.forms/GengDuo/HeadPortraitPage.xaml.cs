using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class HeadPortraitPage : ContentPage
	{
		async void OnFlowItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e.Item != null)
			{

				var model = e.Item as ResourceImageModel;
				//DisplayAlert("分享", model.Url, "确定");
				await Navigation.PushAsync(new ImageDetailPage(model.ResourceID));

			}
		}

		readonly string[] HeadPortraitArrary =
						  { "xiaobai", "yanmo","yingcao","yuanboya","huyao",
			"jiaotu","jiutuntongzi","panguan","qingming","cimutongzi","datiangou","guhuoniao",
			"guishibai","guishihei","shenyue","huangchuanzhizhu","qingxingdeng","babaibiqiuni"
		};

		//没有注意图片格式 导致现在有两种格式的图片。。。
		readonly string[] HeadPortraitArrary2 = {
			"baobao","chuia","chunfei","dantiao","didi","feizhou","gouyu","guixia","gun","henai",
			"jiehuo","nisang","ouqi","qinren","qiuzhang","rengdiao","ssr","xiayige"
		};

		public HeadPortraitPage()
		{
			InitializeComponent();

			for (int i = 0; i < HeadPortraitArrary.Length; i++)
			{
				ImageSourceList.Add(new ResourceImageModel()
				{
					//Name = HeadPortraitArrary[i]
					ResourceID = $"yysgl.forms.Resource.{HeadPortraitArrary[i]}.jpg",
					Source = ImageSource.FromResource($"yysgl.forms.Resource.{HeadPortraitArrary[i]}.jpg")
				});
			}

			for (int i = 0; i < HeadPortraitArrary2.Length; i++)
			{
				ImageSourceList.Add(new ResourceImageModel()
				{
					//Name = HeadPortraitArrary[i],
					ResourceID = $"yysgl.forms.Resource.{HeadPortraitArrary2[i]}.png",
					Source = ImageSource.FromResource($"yysgl.forms.Resource.{HeadPortraitArrary2[i]}.png")
				});
			}


			ItemTappedCommand = new Command(() =>
			{

			});

			BindingContext = this;

			Title = "游戏头像";
		}

		public List<ResourceImageModel> ImageSourceList
		{
			get;
			set;
		} = new List<ResourceImageModel>();


		public ICommand ItemTappedCommand
		{
			get;
			set;
		}
	}
}
