using System;
using SQLite;

namespace yysgl.forms
{
	[Table("ShiShen")]
	public class ShiShenModel : BaseModel
	{
		public string Image
		{
			get;
			set;
		}

		/// <summary>
		/// 稀有度
		/// </summary>
		/// <value>The rarity.</value>
		public string Rarity
		{
			get;
			set;
		}

		/// <summary>
		/// 声优
		/// </summary>
		/// <value>The cv.</value>
		public string CV
		{
			get;
			set;
		}

		/// <summary>
		/// 中文传记
		/// </summary>
		/// <value>The chinese biography.</value>
		public string ChineseBiography
		{
			get;
			set;
		}

		/// <summary>
		/// 觉醒提升
		/// </summary>
		/// <value>The awake increase.</value>
		public string AwakeIncrease
		{
			get;
			set;
		}

		/// <summary>
		/// 觉醒前参数
		/// </summary>
		/// <value>The before awake.</value>
		public int BeforeAwakeID
		{
			get;
			set;
		}

		/// <summary>
		/// 觉醒后参数
		/// </summary>
		/// <value>The after awake.</value>
		public int AfterAwakeID
		{
			get;
			set;
		}
	}
}
