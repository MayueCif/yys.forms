using System;
using Xamarin.Forms;

namespace yysgl.forms
{
	public class HeaderFlagConverter : TypeConverter
	{

		public override object ConvertFromInvariantString(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new InvalidOperationException(string.Format("the value to convert {0} cannot be null or empty", typeof(HeaderFlag)));
			}
			value = value.Trim();
			try
			{
				return Enum.Parse(typeof(HeaderFlag), value);
			}
			catch
			{
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(HeaderFlag)));
			}
		}
	}
}
