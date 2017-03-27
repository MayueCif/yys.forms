using System;
using System.Collections.Generic;

namespace yysgl.forms
{
	public class ZhuJueModel : BaseModel
	{

		public List<string> Summary
		{
			get;
			set;
		}

		public string CV
		{
			get;
			set;
		}

		public string Image
		{
			get;
			set;
		}

		public string Video
		{
			get;
			set;
		}

		public List<ZhuJueJiNengModel> Skills
		{
			get;
			set;
		}
	}
}
