using System;
using System.Windows.Input;

namespace yysgl.forms
{
	public class MusicModel : BaseModel
	{

		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// 歌曲时长 毫秒
		/// </summary>
		/// <value>The duration.</value>
		public int Duration
		{
			get;
			set;
		}

		/// <summary>
		/// 艺术家
		/// </summary>
		/// <value>The artist.</value>
		public string Artist
		{
			get;
			set;
		}

		/// <summary>
		/// 专辑
		/// </summary>
		/// <value>The album.</value>
		public string Album
		{
			get;
			set;
		}

		private int state;

		public int State
		{
			get
			{
				return state;
			}
			set
			{
				SetProperty<int>(ref state, value);
			}
		}

	}
}
