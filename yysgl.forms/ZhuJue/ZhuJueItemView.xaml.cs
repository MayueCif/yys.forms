using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class ZhuJueItemView : ContentView
	{

		public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(ZhuJueItemView), default(string), propertyChanged: (bindable, oldValue, newValue) =>
		{
			//(bindable as ZhuJueItemView).Title = newValue.ToString();
		});

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(string), typeof(ZhuJueItemView), string.Empty);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public static readonly BindableProperty CommandButton1Property =
			BindableProperty.Create("CommandButton1", typeof(ICommand), typeof(ZhuJueItemView), default(Command));

		public ICommand CommandButton1
		{
			get { return (ICommand)GetValue(CommandButton1Property); }
			set { SetValue(CommandButton1Property, value); }
		}

		public static readonly BindableProperty CommandButton2Property =
			BindableProperty.Create("CommandButton2", typeof(ICommand), typeof(ZhuJueItemView), default(Command));

		public ICommand CommandButton2
		{
			get { return (ICommand)GetValue(CommandButton2Property); }
			set { SetValue(CommandButton2Property, value); }
		}

		public static readonly BindableProperty CommandButton3Property =
			BindableProperty.Create("CommandButton3", typeof(ICommand), typeof(ZhuJueItemView), default(Command));

		public ICommand CommandButton3
		{
			get { return (ICommand)GetValue(CommandButton3Property); }
			set { SetValue(CommandButton3Property, value); }
		}

		public static readonly BindableProperty CommandParameterButton1Property =
			BindableProperty.Create("CommandParameterButton1", typeof(Object), typeof(ZhuJueItemView), null);

		public Object CommandParameterButton1
		{
			get { return (Object)GetValue(CommandParameterButton1Property); }
			set { SetValue(CommandParameterButton1Property, value); }
		}

		public static readonly BindableProperty CommandParameterButton2Property =
			BindableProperty.Create("CommandParameterButton2", typeof(Object), typeof(ZhuJueItemView), null);

		public Object CommandParameterButton2
		{
			get { return (Object)GetValue(CommandParameterButton2Property); }
			set { SetValue(CommandParameterButton2Property, value); }
		}

		public static readonly BindableProperty CommandParameterButton3Property =
			BindableProperty.Create("CommandParameterButton3", typeof(Object), typeof(ZhuJueItemView), null);

		public Object CommandParameterButton3
		{
			get { return (Object)GetValue(CommandParameterButton3Property); }
			set { SetValue(CommandParameterButton3Property, value); }
		}


		public ZhuJueItemView()
		{

			InitializeComponent();
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
			if (propertyName == CommandButton3Property.PropertyName)
			{
				button3.Command = CommandButton3;
			}

			if (propertyName == CommandButton2Property.PropertyName)
			{
				button2.Command = CommandButton2;
			}

			if (propertyName == CommandButton1Property.PropertyName)
			{
				button1.Command = CommandButton1;
			}

			if (propertyName == CommandParameterButton3Property.PropertyName)
			{
				button3.CommandParameter = CommandParameterButton3;
			}

			if (propertyName == CommandParameterButton1Property.PropertyName)
			{
				button1.CommandParameter = CommandParameterButton1;
			}

			if (propertyName == CommandParameterButton2Property.PropertyName)
			{
				button2.CommandParameter = CommandParameterButton2;
			}

		}
	}
}
