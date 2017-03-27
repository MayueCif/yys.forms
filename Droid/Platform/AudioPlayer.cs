using System;
using Android.Media;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.Droid.AudioPlayer))]
namespace yysgl.forms.Droid
{
	public class AudioPlayer : IAudioPlayer
	{
		MediaPlayer mediaPlayer; // 媒体播放器

		public event EventHandler Completed;

		public AudioPlayer()
		{
			mediaPlayer = new MediaPlayer();
			mediaPlayer.SetAudioStreamType(Stream.Music);
			mediaPlayer.Completion += (sender, e) =>
			{
				if (Completed != null)
				{
					Completed(this, e);
				}
			};
		}

		public int GetCurrentDuration()
		{
			return mediaPlayer.CurrentPosition / 1000;
		}

		public bool GetPalyState()
		{
			return mediaPlayer.IsPlaying;
		}

		public int GetTotalDuration()
		{
			return mediaPlayer.Duration / 1000;
		}

		public void Pause()
		{
			if (mediaPlayer != null)
			{
				mediaPlayer.Pause();
			}
		}

		public void Start()
		{
			if (mediaPlayer != null)
			{
				mediaPlayer.Start();
			}
		}

		public void PlayNet(string url)
		{
			//恢复初始状态
			mediaPlayer.Reset();
			mediaPlayer.SetDataSource(url);
			mediaPlayer.Prepared += (sender, e) =>
			{
				mediaPlayer.Start();
			};
			mediaPlayer.Prepare();

		}

		public void Seek(int second)
		{
			mediaPlayer.SeekTo(second);
		}

		public void Stop()
		{
			if (mediaPlayer != null && mediaPlayer.IsPlaying)
			{
				mediaPlayer.Stop();
			}
		}
	}
}
