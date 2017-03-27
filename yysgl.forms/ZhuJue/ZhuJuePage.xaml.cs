using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;

namespace yysgl.forms
{
	public partial class ZhuJuePage : ContentPage
	{
		public ZhuJuePage()
		{

			InitializeComponent();

			var assembly = GetType().GetTypeInfo().Assembly;
			var stream = assembly.GetManifestResourceStream("yysgl.forms.Resource.zhujue.json");

			var zhuJueJson = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				zhuJueJson = reader.ReadToEnd();
			}

			ZhuJueSource = JsonConvert.DeserializeObject<List<ZhuJueModel>>(zhuJueJson);

			OpenVideoPlayer = new Command((arg) =>
			{
				var page = new ViewPlayerPage(arg.ToString());
				page.Title = "视频播放";
				Navigation.PushAsync(page);
			});

			OpenJianjie = new Command((arg) =>
			{
				var zhujue = ZhuJueSource.Where(z => z.ID == (int)arg).FirstOrDefault();
				if (zhujue == null)
				{
					DisplayAlert("提示", "主角ID参数异常", "确定");
					return;
				}
				Navigation.PushAsync(new ZhuJueJianJiePage(zhujue));
			});

			OpenJiNeng = new Command((arg) =>
			{
				var zhujue = ZhuJueSource.Where(z => z.ID == (int)arg).FirstOrDefault();
				if (zhujue == null)
				{
					DisplayAlert("提示", "主角ID参数异常", "确定");
					return;
				}
				Navigation.PushAsync(new ZhuJueJiNengPage(zhujue));
			});

			BindingContext = this;
		}

		public ICommand OpenVideoPlayer
		{
			get;
			set;
		}

		public ICommand OpenJianjie
		{
			get;
			set;
		}

		public ICommand OpenJiNeng
		{
			get;
			set;
		}

		public List<ZhuJueModel> ZhuJueSource
		{
			get;
			set;
		} = new List<ZhuJueModel>();

	}
}
