using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Xamarin.Forms;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Plugin.Connectivity;
using ModernHttpClient;

namespace yysgl.forms
{
	public partial class GongLueContentPage : ContentPage
	{
		IProgressDialog loading;
		public GongLueContentPage(string url, string title)
		{
			InitializeComponent();
			Title = title;
			if (CrossConnectivity.Current.IsConnected)
			{
				loading = UserDialogs.Instance.Loading("获取并解析内容");
				Task.Run(() => this.LoadContent(url)).Wait();
				loading.Hide();
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!CrossConnectivity.Current.IsConnected)
			{
				UserDialogs.Instance.ShowError("网路连接异常！" + Environment.NewLine + "请检查网络连接");
			}
		}

		private async Task LoadContent(string url)
		{
			if (!url.StartsWith("http", StringComparison.CurrentCulture))
			{
				url = url.Replace("//", "");
				url = "http://" + url;
			}
			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(await new HttpClient(new NativeMessageHandler()).GetAsync(url).Result.Content.ReadAsStringAsync());
			var node = htmlDocument.GetElementbyId("NIE-art");
			//var contentHtml1 = node.Descendants("div").Where(d => d.GetAttributeValue("class", "") == "artText").First().InnerHtml;
			var contentHtml = node.Descendants("div").Where(d => d.GetAttributeValue("class", "") == "artText").First().OuterHtml;
			StringBuilder sb = new StringBuilder();
			sb.Append("<html><!--STATUS OK-->");
			sb.Append("<head>");
			sb.Append("<meta name=\"referrer\" content=\"always\" />");
			sb.Append("<meta charset='utf-8' />");
			sb.Append("<meta name=\"viewport\" content=\"width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no\"/>");
			sb.Append("<meta http-equiv=\"x-dns-prefetch-control\" content=\"on\"> ");
			sb.Append("<meta name=\"format-detection\" content=\"telephone=no\">");
			sb.Append("<style type = \"text/css\" >");
			sb.Append("img { max-width:100%;height:auto;}");
			sb.Append("</style>");
			sb.Append("</head>");
			sb.Append("<body>");
			sb.Append(contentHtml);
			sb.Append("</body>");
			sb.Append("</html>");
			webView.Source = new HtmlWebViewSource()
			{
				Html = sb.ToString()
			};
		}
	}
}
