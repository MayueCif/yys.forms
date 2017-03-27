using System;
using SQLite;

namespace yysgl.forms
{
	public interface ISQLiteService
	{
		SQLiteConnection GetConnection(string databaseName);
		long GetSize(string databaseName);
	}
}
