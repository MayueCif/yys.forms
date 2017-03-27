using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace yysgl.forms
{
	public interface IPlatformFIle
	{
		void Save(string fileName, byte[] data);

		bool Exists(string fileName);

		void Delete(string fileName);

		Task<IEnumerable<string>> GetFilesAsync();

	}
}
