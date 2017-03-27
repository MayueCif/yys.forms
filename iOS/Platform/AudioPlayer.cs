using System;
using AVFoundation;
using CoreMedia;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.iOS.AudioPlayer))]
namespace yysgl.forms.iOS
{
	public class AudioPlayer : IAudioPlayer
	{
		//http://www.jianshu.com/p/32b932f44c9b/comments/1772685
		AVPlayer player;

		public AudioPlayer()
		{
			player = new AVPlayer();
			//NSNotificationCenter.defaultCenter().addObserver(self, selector: "playerDidFinishPlaying:",
			//name: AVPlayerItemDidPlayToEndTimeNotification, object: videoPlayer.currentItem)
			//监听AVPlayer播放完成
			NSNotificationCenter.DefaultCenter.AddObserver((NSString)"AVPlayerItemDidPlayToEndTimeNotification", (obj) =>
			{
				if (Completed != null)
				{
					Completed(this, new EventArgs());
				}
			}, player.CurrentItem);
		}

		public event EventHandler Completed;

		public int GetCurrentDuration()
		{
			//return (int)player.CurrentItem.CurrentTime.Seconds;
			return (int)player.CurrentTime.Seconds;
		}

		public bool GetPalyState()
		{
			//AVPlayer doesn't have an isPlaying property. Use the rate property (0.0 means stopped, 1.0 playing).
			return player.Rate == 1.0;
		}

		public int GetTotalDuration()
		{
			if (player.CurrentItem == null)
			{
				return 0;
			}
			return (int)player.CurrentItem.Asset.Duration.Seconds;
		}

		public void Pause()
		{
			if (player != null)
			{
				player.Pause();
			}
		}

		public void PlayNet(string url)
		{
			player = new AVPlayer(new NSUrl(url));
			player.Play();
		}

		private const int NSEC_PER_SEC = 1000000000;

		public void Seek(int second)
		{
#warning 未测试
			player.Seek(CMTime.FromSeconds(second, NSEC_PER_SEC));
		}

		public void Start()
		{
			if (player != null)
			{
				player.Play();
			}
		}

		public void Stop()
		{
			//AVPlayer does not have a method named stop. You can pause or set rate to 0.0.
			//If you dont want to set the av player to nil, a better approach might be
			if (player != null)
			{
				player.Pause();
				//player.SetRate();
				player.ReplaceCurrentItemWithPlayerItem(null);
			}
		}
	}
}
