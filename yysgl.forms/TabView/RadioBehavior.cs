using System.Collections.Generic;
using Xamarin.Forms;

namespace yysgl.forms
{
	public class RadioBehavior : Behavior<View>
	{
		static List<RadioBehavior> defaultGroup = new List<RadioBehavior>();
		static Dictionary<string, List<RadioBehavior>> radioGroups = new Dictionary<string, List<RadioBehavior>>();


		public RadioBehavior()
		{
			defaultGroup.Add(this);
		}

		public static readonly BindableProperty GroupNameProperty =
			BindableProperty.Create("GroupName", typeof(string), typeof(RadioBehavior), string.Empty,
									propertyChanged: (bindable, oldValue, newValue) =>
									{
										var behavior = (RadioBehavior)bindable;
										var oldGroupName = (string)oldValue;
										var newGroupName = (string)newValue;
										if (string.IsNullOrEmpty(oldGroupName))
										{
											defaultGroup.Remove(behavior);
										}
										else
										{
											var behaviors = radioGroups[oldGroupName];
											behaviors.Remove(behavior);
											if (behaviors.Count == 0)
											{
												radioGroups.Remove(oldGroupName);
											}
										}

										if (string.IsNullOrEmpty(newGroupName))
										{
											defaultGroup.Add(behavior);
										}
										else
										{
											List<RadioBehavior> behaviors = null;
											if (radioGroups.ContainsKey(newGroupName))
											{
												behaviors = radioGroups[newGroupName];
											}
											else
											{

												behaviors = new List<RadioBehavior>();
												radioGroups.Add(newGroupName, behaviors);
											}
											behaviors.Add(behavior);
										}
									});

		public string GroupName
		{
			get { return (string)GetValue(GroupNameProperty); }
			set { SetValue(GroupNameProperty, value); }
		}

		public static readonly BindableProperty IsCheckedProperty =
			BindableProperty.Create("IsChecked", typeof(bool), typeof(RadioBehavior), false, propertyChanged: OnIsCheckedChanged);


		public bool IsChecked
		{
			get { return (bool)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}

		static void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var behavior = (RadioBehavior)bindable;
			if ((bool)newValue)
			{
				string groupName = behavior.GroupName;
				List<RadioBehavior> behaviors = null;
				if (string.IsNullOrEmpty(groupName))
				{
					behaviors = defaultGroup;
				}
				else
				{
					behaviors = radioGroups[groupName];
				}

				foreach (var otherBehavior in behaviors)
				{
					if (otherBehavior != behavior)
					{
						otherBehavior.IsChecked = false;
					}
				}
			}
		}

	}
}
