using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class ZhuJueJiNengItemView : ContentView
	{
		public ZhuJueJiNengItemView()
		{
			InitializeComponent();
		}

		public BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(ZhuJueJiNengItemView), string.Empty);

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(string), typeof(ZhuJueJiNengItemView), string.Empty);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public BindableProperty DescribeProperty = BindableProperty.Create("Describe", typeof(string), typeof(ZhuJueJiNengItemView), string.Empty);

		public string Describe
		{
			get { return (string)GetValue(DescribeProperty); }
			set { SetValue(DescribeProperty, value); }
		}

		public BindableProperty UpGradeProperty = BindableProperty.Create("UpGrade", typeof(List<string>), typeof(ZhuJueJiNengItemView), new List<string>());

		public List<string> UpGrade
		{
			get { return (List<string>)GetValue(UpGradeProperty); }
			set { SetValue(UpGradeProperty, value); }
		}


		protected override void OnPropertyChanged(string propertyName)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == TitleProperty.PropertyName)
			{
				title.Text = Title;
			}
			if (propertyName == ImageProperty.PropertyName)
			{
				image.Source = Image;
			}
			if (propertyName == DescribeProperty.PropertyName)
			{
				describe.Text = Describe;
			}
			if (propertyName == UpGradeProperty.PropertyName)
			{
				foreach (var item in UpGrade)
				{
					upGradeStack.Children.Add(new Label()
					{
						Text = item,
						FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
					});
				}
			}
		}

	}
}
