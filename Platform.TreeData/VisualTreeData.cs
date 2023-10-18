// Ignore Spelling: dieable Ctrl

namespace BestChat.Platform.TreeData
{
	public sealed class VisualTreeData : System.Windows.DependencyObject
	{
		#region Constructors & Deconstructors
			public VisualTreeData(in DMakeCtrl funcCtrlMaker, in IItemInfo itemUs, in string
				strLocalizedName, in string strLocalizedLongDesc, in IChildOwner? ownerOfChildren = null)
			{
				UI = funcCtrlMaker(itemUs);
				LocalizedName = strLocalizedName;
				LocalizedLongDesc = strLocalizedLongDesc;
				this.ownerOfChildren = ownerOfChildren;

				if(ownerOfChildren != null)
				{
					ownerOfChildren.CollectionChanged += OnSrcCollectionChanged;

					foreach(IItemInfo itemCur in ownerOfChildren.Children)
					{
						itemCur.evtDieing += OnChildDieing;

						VisualTreeData vtdChild = itemCur is IChildOwner ownerOfGrandChildren ? new
							(funcCtrlMaker, itemCur, ownerOfGrandChildren.LocalizedName, ownerOfGrandChildren
							.LocalizedLongDesc, ownerOfGrandChildren) : new(funcCtrlMaker, itemCur,
							itemCur.LocalizedName, itemCur.LocalizedLongDesc);
					}
				}
			}
		#endregion

		#region Delegates
			public delegate System.Windows.Controls.UserControl DMakeCtrl(IItemInfo item);
		#endregion

		#region Constants
			#region Dependency Properties
				public static readonly System.Windows.DependencyProperty CtrlMakerProperty = System.Windows
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
			private readonly System.Collections.Generic.Dictionary<Common.IDieable, VisualTreeData>
				mapDieableToVisualTreeDataInstance = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<VisualTreeData> ocChildren =
				new();

			public readonly IChildOwner? ownerOfChildren;
		#endregion

		#region Properties
			public System.Windows.Controls.UserControl UI
			{
				get;
			}

			public string LocalizedName
			{
				get;
			}

			public string LocalizedLongDesc
			{
				get;
			}

			public System.Collections.Generic.IEnumerable<VisualTreeData> Children => ocChildren;

			public string Icon => ownerOfChildren == null ? "" : ownerOfChildren.Icon;
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