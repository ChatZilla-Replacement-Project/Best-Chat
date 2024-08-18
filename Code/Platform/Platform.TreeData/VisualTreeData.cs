// Ignore Spelling: dieable Ctrl

namespace BestChat.Platform.TreeData
{
	public sealed class VisualTreeData : System.Windows.DependencyObject
	{
		#region Constructors & Deconstructors
			public VisualTreeData(in DMakeCtrl funcCtrlMaker, in IItemInfo itemUs)
			{
				this.itemUs = itemUs;
				UI = funcCtrlMaker(itemUs);
				LocalizedName = itemUs.LocalizedName;
				LocalizedLongDesc = itemUs.LocalizedLongDesc;
				IChildOwner? ownerOfChildren = itemUs is IChildOwner owner ? (IChildOwner)itemUs : null;
				Icon = itemUs.Icon;

				if(ownerOfChildren != null)
				{
					ownerOfChildren.CollectionChanged += OnSrcCollectionChanged;

					foreach(IItemInfo itemCur in ownerOfChildren.Children)
					{
						itemCur.evtDieing += OnChildDieing;

						ocChildren.Add(new(funcCtrlMaker, itemCur));
					}
				}

				Children = ocChildren;
			}
		#endregion

		#region Delegates
			public delegate System.Windows.Controls.UserControl? DMakeCtrl(IItemInfo item);
		#endregion

		#region Constants
			#region Dependency Properties
				public static readonly System.Windows.DependencyProperty UIProperty = System.Windows
					.DependencyProperty.Register(nameof(UI), typeof(System.Windows.Controls.UserControl),
					typeof(VisualTreeData));

				public static readonly System.Windows.DependencyProperty LocalizedNameProperty = System.Windows
					.DependencyProperty.Register(nameof(LocalizedName), typeof(string), typeof(VisualTreeData));

				public static readonly System.Windows.DependencyProperty LocalizedLongDescProperty = System
					.Windows.DependencyProperty.Register(nameof(LocalizedLongDesc), typeof(string),
					typeof(VisualTreeData));

				public static readonly System.Windows.DependencyProperty ChildrenProperty = System.Windows
					.DependencyProperty.Register(nameof(Children), typeof(System.Collections.Generic
					.IEnumerable<VisualTreeData>), typeof(VisualTreeData));

				public static readonly System.Windows.DependencyProperty IconProperty = System.Windows
					.DependencyProperty.Register(nameof(Icon), typeof(string), typeof(VisualTreeData));
			#endregion

			#region Routed Events
			#endregion
		#endregion

		#region Helper Types
			public interface IItemInfo : Common.IDieable
			{
				string LocalizedName
				{
					get;
				}

				string LocalizedLongDesc
				{
					get;
				}

				string Icon
				{
					get;
				}
			}

			public interface IChildOwner : IItemInfo, System.Collections.Specialized.INotifyCollectionChanged
			{
				System.Collections.Generic.IEnumerable<IItemInfo> Children
				{
					get;
				}
			}
		#endregion

		#region Members
			private static readonly System.Collections.Generic.Dictionary<Prefs.Data.AbstractMgr, System.Type> mapDataMgrToCtrlType =
				new();

			public readonly IItemInfo itemUs;

			private readonly System.Collections.Generic.Dictionary<Common.IDieable, VisualTreeData>
				mapDieableToVisualTreeDataInstance = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<VisualTreeData> ocChildren =
				new();
		#endregion

		#region Properties
			public System.Windows.Controls.UserControl? UI
			{
				get => (System.Windows.Controls.UserControl)GetValue(UIProperty);

				init => SetValue(UIProperty, value);
			}

			public string LocalizedName
			{
				get => (string)GetValue(LocalizedNameProperty);

				init => SetValue(LocalizedNameProperty, value);
			}

			public string LocalizedLongDesc
			{
				get => (string)GetValue(LocalizedLongDescProperty);

				init => SetValue(LocalizedLongDescProperty, value);
			}

			public System.Collections.Specialized.INotifyCollectionChanged Children
			{
				get => ocChildren;

				init => SetValue(ChildrenProperty, value);
			}

			public string Icon
			{
				get => (string)GetValue(IconProperty);

				init => SetValue(IconProperty, value);
			}
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
			private void OnSrcCollectionChanged(object? objSender, System.Collections.Specialized
				.NotifyCollectionChangedEventArgs e) => throw new System.NotImplementedException();
	
			private void OnChildDieing(Common.IDieable dieing)
			{
				if(mapDieableToVisualTreeDataInstance.ContainsKey(dieing))
					ocChildren.Remove(mapDieableToVisualTreeDataInstance[dieing]);

				mapDieableToVisualTreeDataInstance.Remove(dieing);
			}
		#endregion
	}
}