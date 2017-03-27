using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using System.Reflection;

namespace yysgl.forms
{
	public partial class ImageDetailPage : ContentPage
	{
		async void OnLongPress(object sender, System.EventArgs e)
		{
			var action = await DisplayActionSheet("图片操作", "取消", null, "保存图片");
			switch (action)
			{
				case "保存图片":
					await SaveSource(ResourceID);
					break;
				default:
					break;
			}
		}

		public ImageDetailPage(string resourceID)
		{
			InitializeComponent();
			this.ResourceID = resourceID;
			image.Source = ImageSource.FromResource(ResourceID);

			Title = "预览大图";

			ToolbarItems.Add(new ToolbarItem("保存", "", async () =>
			{
				await SaveSource(ResourceID);
			}));
		}

		public string ResourceID
		{
			get;
			set;
		}

		private async Task SaveSource(string resourceID)
		{
			byte[] byteData;

			var assembly = typeof(ImageDetailPage).GetTypeInfo().Assembly;

			using (var stream = assembly.GetManifestResourceStream(resourceID))
			{
				using (MemoryStream ms = new MemoryStream())
				{
					stream.CopyTo(ms);
					byteData = ms.ToArray();
				}
			}

			DependencyService.Get<IPicture>().SavePictureToDisk(DateTime.Now.ToString("yyyyMMddHHmmss"), byteData);
			await DisplayAlert("提示", "图片保存成功", "确定");
		}
	}
}
