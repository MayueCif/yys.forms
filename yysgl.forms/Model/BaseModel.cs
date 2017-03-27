using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace yysgl.forms
{
	public class BaseModel : INotifyPropertyChanged
	{
		//AutoIncrement
		[PrimaryKey, Column("ID")]
		public int ID

		{
			get;
			set;
		}

		[Column("Name")]
		public string Name
		{
			get;
			set;
		}

		public event PropertyChangedEventHandler PropertyChanged;


		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
		{
			if (Object.Equals(storage, value))
				return false;

			storage = value;
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
			return true;
		}

	}
}
