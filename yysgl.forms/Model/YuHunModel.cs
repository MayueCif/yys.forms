using System;
using SQLite;
using Xamarin.Forms;

namespace yysgl.forms
{
	[Table("YuHun")]
	public class YuHunModel : BaseModel
	{

		public string Type
		{
			get;
			set;
		}

		public string Image
		{
			get;
			set;
		}

		public ImageSource ImageSource
		{
			get
			{
				return ImageSource.FromResource(Image);
			}
		}

		public string Result2
		{
			get;
			set;
		}

		public string Result4
		{
			get;
			set;
		}

		public string GetWay
		{
			get;
			set;
		}

		//官网ID目前为空
		public int OfficialID
		{
			get;
			set;
		}
	}
}
