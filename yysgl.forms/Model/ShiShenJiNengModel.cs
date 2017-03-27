using System;
using SQLite;

namespace yysgl.forms
{
	[Table("ShiShenJiNeng")]
	public class ShiShenJiNengModel : BaseModel
	{

		/// <summary>
		/// 技能消耗
		/// </summary>
		/// <value>The consume.</value>
		public int Consume
		{
			get;
			set;
		}

		/// <summary>
		/// 技能效果
		/// </summary>
		/// <value>The effect.</value>
		public string Effect
		{
			get;
			set;
		}

		/// <summary>
		/// 技能升级效果
		/// </summary>
		/// <value>The upgrade effect.</value>
		public string UpgradeEffect
		{
			get;
			set;
		}

		public int ShiShenID
		{
			get;
			set;
		}

		public int IconID
		{
			get;
			set;
		}

		public string Icon
		{
			get;
			set;
		}

	}
}
