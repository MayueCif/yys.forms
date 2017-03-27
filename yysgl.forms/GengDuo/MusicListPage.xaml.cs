using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class MusicListPage : ContentPage
	{
		//http://moonlib.com/606.html api说明
		string playListUrl = "http://music.163.com/api/playlist/detail?id=486219577";
		int CurrentPlayIndex = -1;
		int PlayState;

		public ICommand PreviousCommand
		{
			get;
			set;
		}

		public ICommand PlayOrPauseCommand
		{
			get;
			set;
		}

		public ICommand NextCommand
		{
			get;
			set;
		}

		void SliderValueChanged(object sender, ValueChangedEventArgs e)
		{

		}

		IAudioPlayer audioPlayer;


		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				(sender as ListView).SelectedItem = null;
				var model = e.SelectedItem as MusicModel;
				if (MusicSource.IndexOf(model) == CurrentPlayIndex)
				{
					return;
				}
				model.State = 1;
				PlayItem(model);
			}
		}

		void PlayItem(MusicModel item)
		{
			CurrentPlayIndex = MusicSource.IndexOf(item);
			currentName.Text = "当前正在播放歌曲:" + item.Name;
			if (audioPlayer.GetPalyState())
			{
				audioPlayer.Stop();
			}
			audioPlayer.PlayNet(item.Url);
			audioPlayer.Completed += (sender, e) =>
			{
				playImage.Source = new FileImageSource()
				{
					File = "play.png"
				};
				PlayState = -1;
				CurrentPlayIndex = -1;
				currentName.Text = "当前无正在播放歌曲";
			};
			playImage.Source = new FileImageSource()
			{
				File = "pause.png"
			};
			PlayState = 1;
			totalTime.Text = $"{ audioPlayer.GetTotalDuration() / 60:d2}:{audioPlayer.GetTotalDuration() % 60:d2}";
			Device.StartTimer(new TimeSpan(1000), () =>
			{
				progress.Progress = audioPlayer.GetCurrentDuration() * 1.0f / audioPlayer.GetTotalDuration();
				currentTime.Text = $"{audioPlayer.GetCurrentDuration() / 60:d2}:{audioPlayer.GetCurrentDuration() % 60:d2}";
				return audioPlayer.GetPalyState();
			});
		}

		public MusicListPage()
		{
			InitializeComponent();

			if (!CrossConnectivity.Current.IsConnected)
			{
				return;
			}

			audioPlayer = DependencyService.Get<IAudioPlayer>();

			var loading = UserDialogs.Instance.Loading("获取解析音乐列表");
			Task.Factory.StartNew(() => LoadMusic(playListUrl));
			loading.Hide();

			PreviousCommand = new Command(() =>
			{
				if (CurrentPlayIndex < 0)
				{
					return;
				}
				if (--CurrentPlayIndex < 0)
				{
					CurrentPlayIndex = MusicSource.Count - 1;
				}
				PlayItem(MusicSource[CurrentPlayIndex]);
			});

			PlayOrPauseCommand = new Command(() =>
			{
				if (PlayState == 0)
				{
					return;
				}

				if (PlayState > 0)//正在播放
				{
					playImage.Source = new FileImageSource()
					{
						File = "play.png"
					};
					audioPlayer.Pause();
					PlayState = -1;
				}
				else
				{
					playImage.Source = new FileImageSource()
					{
						File = "pause.png"
					};
					audioPlayer.Start();
					PlayState = 1;
				}
			});

			NextCommand = new Command(() =>
			{
				if (CurrentPlayIndex < 0)
				{
					return;
				}
				if (++CurrentPlayIndex >= MusicSource.Count)
				{
					CurrentPlayIndex = 0;
				}
				PlayItem(MusicSource[CurrentPlayIndex]);
			});

			BindingContext = this;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!CrossConnectivity.Current.IsConnected)
			{
				UserDialogs.Instance.ShowError("网路连接异常！" + Environment.NewLine + "请检查网络连接");
			}

		}


		public ObservableCollection<MusicModel> MusicSource
		{
			get;
			set;
		} = new ObservableCollection<MusicModel>();


		protected override void OnDisappearing()
		{
			if (audioPlayer != null)
			{
				audioPlayer.Stop();
				audioPlayer = null;
			}
		}


		private async Task LoadMusic(string url)
		{
			var response = new HttpClient(new NativeMessageHandler()).GetAsync(url).Result;
			if (response.IsSuccessStatusCode)
			{
				var data = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
				if (data["code"].ToString() == "200")
				{
					//data["result"]["creator"] 表示专辑所有人
					//var name = data["result"]["name"].ToString(); //歌单名称
					//var coverImgUrl = data["result"]["coverImgUrl"].ToString();//歌单图片
					var tracks = JArray.Parse(data["result"]["tracks"].ToString());
					foreach (var track in tracks)
					{
						MusicSource.Add(new MusicModel()
						{
							Name = track["name"].ToString(),
							Url = track["mp3Url"].ToString(),//低音质音乐连接
							Duration = int.Parse(track["duration"].ToString()),
							Artist = track["artists"][0]["name"].ToString(),
							Album = track["album"]["name"].ToString()
						});
					}
				}
				else
				{
					await DisplayAlert("错误", data["msg"].ToString(), "确定");
				}
			}
			else
			{
				await DisplayAlert("错误", $"服务器{(int)response.StatusCode}错误", "确定");
			}
		}

	}

}
