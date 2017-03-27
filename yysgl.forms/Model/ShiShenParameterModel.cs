using System;
using SQLite;

namespace yysgl.forms
{
	[Table("ShiShenParameter")]
	public class ShiShenParameterModel
	{

		/// <summary>
		/// 图片
		/// </summary>
		/// <value>The head image.</value>
		public string HeadImage
		{
			get;
			set;
		}

		/// <summary>
		/// 攻击评分
		/// </summary>
		/// <value>The attack score.</value>
		public string AttackScore
		{
			get;
			set;
		}

		/// <summary>
		/// 攻击
		/// </summary>
		/// <value>The attack.</value>
		[MaxLength(2)]
		public string Attack
		{
			get;
			set;
		}

		public string AttackView
		{
			get
			{
				return $"{AttackScore}({Attack})";
			}
		}

		/// <summary>
		/// 生命评分
		/// </summary>
		/// <value>The life score.</value>
		public string LifeScore
		{
			get;
			set;
		}

		/// <summary>
		/// 生命
		/// </summary>
		/// <value>The life.</value>
		[MaxLength(2)]
		public string Life
		{
			get;
			set;
		}

		public string LifeView
		{
			get
			{
				return $"{LifeScore}({Life})";
			}
		}

		/// <summary>
		/// 防御评分
		/// </summary>
		/// <value>The defense score.</value>
		public string DefenseScore
		{
			get;
			set;
		}

		/// <summary>
		/// 防御
		/// </summary>
		/// <value>The defense.</value>
		[MaxLength(2)]
		public string Defense
		{
			get;
			set;
		}

		public string DefenseView
		{
			get
			{
				return $"{DefenseScore}({Defense})";
			}
		}

		/// <summary>
		/// 速度评分
		/// </summary>
		/// <value>The speed score.</value>
		public string SpeedScore
		{
			get;
			set;
		}

		/// <summary>
		/// 速度
		/// </summary>
		/// <value>The speed.</value>
		[MaxLength(2)]
		public string Speed
		{
			get;
			set;
		}

		public string SpeedView
		{
			get
			{
				return $"{SpeedScore}({Speed})";
			}
		}

		/// <summary>
		/// 暴击评分
		/// </summary>
		/// <value>The crit score.</value>
		public string CritScore
		{
			get;
			set;
		}

		/// <summary>
		/// 暴击
		/// </summary>
		/// <value>The crit.</value>
		[MaxLength(2)]
		public string Crit
		{
			get;
			set;
		}

		public string CritView
		{
			get
			{
				return $"{CritScore}({float.Parse(Crit) * 100}%)";
			}
		}

		public int ShiShenID
		{
			get;
			set;
		}

	}
}
