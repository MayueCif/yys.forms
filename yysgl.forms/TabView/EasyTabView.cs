using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace yysgl.forms
{
	/// <summary>
	/// Easy tab view.
	/// </summary>
	[ContentProperty("TabContents")]
	public class EasyTabView : Grid, IDisposable
	{

		const int ROW_COUNT = 3;
		TapGestureRecognizer tapRecognizer;

		//https://chaseflorell.github.io/xamarin/2015/03/14/xamarinforms-gridview/
		public EasyTabView()
		{
			//var tabLabelStyle = new Style(typeof(Label))
			//{
			//	Setters = {
			//		new Setter {Property = Label.VerticalOptionsProperty,Value= LayoutOptions.Center},
			//		new Setter {Property = Label.HorizontalOptionsProperty,Value= LayoutOptions.Center}
			//	}
			//};
			if (TabHeaders.Count != TabContents.Count)
			{
				throw new Exception("TabHeaders Count Must Equal TabContents Count");
			}
			tapRecognizer = new TapGestureRecognizer();
			tapRecognizer.Tapped += TapEventHandler;

		}


		public void Init()
		{

			//if (ColumnDefinitions.Any())
			//{
			//	ColumnDefinitions.Clear();
			//}
			//if (RowDefinitions.Any())
			//{
			//	RowDefinitions.Clear();
			//}

			foreach (var tabHeader in TabHeaders)
			{
				ColumnDefinitions.Add(new ColumnDefinition()
				{
					Width = GridLength.Star
				});
			}

			if (HeaderFlag == HeaderFlag.Top)
			{
				RowDefinitions = new RowDefinitionCollection() {
					//头
					new RowDefinition()
					{
						Height = GridLength.Auto
					},
					//指示标示
					new RowDefinition()
					{
						Height = IndicatorHeight
					},
					//内容
					new RowDefinition()
					{
						Height = GridLength.Star
					}

				};
			}
			//else if (HeaderFlag == HeaderFlag.Bottom)
			//{
			//	RowDefinitions = new RowDefinitionCollection() {
			//		//内容
			//		new RowDefinition()
			//		{
			//			Height = GridLength.Star
			//		},
			//		//指示标示
			//		new RowDefinition()
			//		{
			//			Height = IndicatorHeight
			//		},
			//		//头
			//		new RowDefinition()
			//		{
			//			Height = GridLength.Auto
			//		}
			//	};
			//}


			this.BatchBegin();
			// 设置TabHeaders 显示
			for (int i = 0; i < TabHeaders.Count; i++)
			{
				//SetRow(TabHeaders[i], 0);
				//SetColumn(TabHeaders[i], i);
				TabHeaders[i].GestureRecognizers.Add(tapRecognizer);
				Children.Add(TabHeaders[i], i, 0);
			}
			//设置指示器
			var indicatorView = new BoxView();
			indicatorView.Color = SelectedColor;
			Children.Add(indicatorView, SelectedIndex, 1);
			//设置TabContents 显示
			for (int i = 0; i < TabContents.Count; i++)
			{
				TabContents[i].IsVisible = SelectedIndex == i;
				Children.Add(TabContents[i], 0, TabContents.Count, 2, 3);
			}
			this.BatchCommit();

#warning 构造函数中添加后不显示

		}

		public int SelectedIndex
		{
			get;
		}

		public static readonly BindableProperty SelectedColorProperty =
			BindableProperty.Create("SelectedColor", typeof(Color), typeof(EasyTabView), Color.Blue);

		public static readonly BindableProperty TabHeadersProperty =
			BindableProperty.Create("TabHeaders", typeof(IList<View>), typeof(EasyTabView), new List<View>());

		public static readonly BindableProperty TabContentsProperty =
			BindableProperty.Create("TabContents", typeof(IList<View>), typeof(EasyTabView), new List<View>());

		public static readonly BindableProperty IndicatorHeightProperty =
			BindableProperty.Create("IndicatorHeight", typeof(float), typeof(EasyTabView), 2f);

		public static readonly BindableProperty HeaderFlagProperty =
			BindableProperty.Create("HeaderFlag", typeof(HeaderFlag), typeof(EasyTabView), HeaderFlag.Top);


		public Color SelectedColor
		{
			get
			{
				return (Color)GetValue(SelectedColorProperty);
			}
			set
			{
				SetValue(SelectedColorProperty, value);
			}
		}

		public float IndicatorHeight
		{
			get
			{
				return (float)GetValue(IndicatorHeightProperty);
			}
			set
			{
				SetValue(IndicatorHeightProperty, value);
			}
		}


		public IList<View> TabHeaders
		{
			get
			{
				return (IList<View>)GetValue(TabHeadersProperty);
			}
			set
			{
				SetValue(TabHeadersProperty, value);
			}
		}

		[TypeConverter(typeof(HeaderFlagConverter))]
		public HeaderFlag HeaderFlag
		{
			get
			{
				return (HeaderFlag)GetValue(HeaderFlagProperty);
			}
			set
			{
				SetValue(HeaderFlagProperty, value);
			}
		}


		public IList<View> TabContents
		{
			get
			{
				return (IList<View>)GetValue(TabContentsProperty);
			}
			set
			{
				SetValue(TabContentsProperty, value);
			}
		}


		protected override void OnAdded(View view)
		{
			base.OnAdded(view);
		}

		void TapEventHandler(object sender, EventArgs e)
		{

		}

		protected override void OnRemoved(View view)
		{
			base.OnRemoved(view);
		}

		public void Dispose()
		{
			for (int i = 0; i < TabHeaders.Count; i++)
			{
				TabHeaders[i].GestureRecognizers.Remove(tapRecognizer);
			}
			tapRecognizer.Tapped -= TapEventHandler;
			tapRecognizer = null;
		}

		public event EventHandler<TabViewEventArgs> SelectedChanged;

		public event EventHandler<TabViewEventArgs> SelectedChanging;

	}
}

