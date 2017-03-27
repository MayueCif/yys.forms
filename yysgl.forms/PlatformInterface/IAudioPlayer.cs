using System;
namespace yysgl.forms
{
	public interface IAudioPlayer
	{
		void PlayNet(string url);

		void Start();

		void Pause();

		void Stop();

		int GetTotalDuration();

		int GetCurrentDuration();

		bool GetPalyState();

		void Seek(int second);

		//定义事件
		event EventHandler Completed;
	}
}
