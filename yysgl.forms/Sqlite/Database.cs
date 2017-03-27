using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace yysgl.forms
{
	public class Database
	{

		//参考
		//https://wolfprogrammer.com/2016/09/10/adding-a-sqlite-database-to-xamarin-forms/
		//http://arteksoftware.com/deploying-a-database-file-with-a-xamarin-forms-app/

		static object locker = new object();
		ISQLiteService SQLite
		{
			get
			{
				return DependencyService.Get<ISQLiteService>();
			}
		}
		readonly SQLiteConnection connection;
		readonly string DatabaseName;

		public Database(string databaseName)
		{
			DatabaseName = databaseName;
			connection = SQLite.GetConnection(DatabaseName);
		}

		public void CreateTable<T>()
		{
			lock (locker)
			{
				connection.CreateTable<T>();
			}
		}

		public long GetSize()
		{
			return SQLite.GetSize(DatabaseName);
		}

		public int SaveItem<T>(T item)
		{
			lock (locker)
			{
				var id = ((BaseModel)(object)item).ID;
				if (id != 0)
				{
					connection.Update(item);
					return id;
				}
				else {
					return connection.Insert(item);
				}
			}
		}

		public void ExecuteQuery(string query, object[] args)
		{
			lock (locker)
			{
				connection.Execute(query, args);
			}
		}

		public List<T> Query<T>(string query, params object[] args) where T : new()
		{
			lock (locker)
			{
				return connection.Query<T>(query, args);
			}
		}

		public IEnumerable<T> GetItems<T>() where T : new()
		{
			lock (locker)
			{
				return (from i in connection.Table<T>() select i).ToList();
			}
		}

		public int DeleteItem<T>(int id)
		{
			lock (locker)
			{
				return connection.Delete<T>(id);
			}
		}

		public int DeleteAll<T>()
		{
			lock (locker)
			{
				return connection.DeleteAll<T>();
			}
		}
	}
}
