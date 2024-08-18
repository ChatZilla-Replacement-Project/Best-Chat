// Ignore Spelling: Ctnts evt revt Ctnt Ctrls

using System;

namespace BestChat.GUI.Ctrls
{
	/// <summary>
	/// Interaction logic for DropMenuBtn.xaml
	/// </summary>
	public partial class DropMenuBtn : System.Windows.Controls.UserControl
	{
		#region Constructors & Deconstructors
			public DropMenuBtn()
			{
				InitializeComponent();
			}
		#endregion

		#region Delegates
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "The standard for " +
				"dependency properties requires the identifier match the associated property")]
			public delegate void DGeneralRoutedEvtHandler<EvtArgsInnerType>
				(System.Windows.DependencyObject doSender, WrapperForRoutedEvtToParentArgs<EvtArgsInnerType> e)
					where EvtArgsInnerType : System.Windows.RoutedEventArgs;

			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "The standard for " +
				"dependency properties requires the identifier match the associated property")]
			public delegate void DMenuOpeningHandler(System.Windows.DependencyObject doSender, MenuOpeningEvtArgs e);
		#endregion

		#region Events
			[System.ComponentModel.Category("Mouse")]
			[System.ComponentModel.Description("Indicates the mouse is now over the left button")]
			public event DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs> evtLeftBtnMouseEnter
			{
				add => AddHandler(evtLeftBtnMouseEnterEvent, value);

				remove => RemoveHandler(evtLeftBtnMouseEnterEvent, value);
			}

			[System.ComponentModel.Category("Mouse")]
			[System.ComponentModel.Description("Indicates the user clicked the left button")]
			public event DGeneralRoutedEvtHandler<System.Windows.RoutedEventArgs> evtLeftBtnMouseClicked
			{
				add => RemoveHandler(evtLeftBtnMouseClickedEvent, value);

				remove => RemoveHandler(evtLeftBtnMouseClickedEvent, value);
			}

			[System.ComponentModel.Category("Mouse")]
			[System.ComponentModel.Description("Indicates the mouse was over the left button, but is no longer inside the left button")]
			public event DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs> evtLeftBtnMouseLeave
			{
				add => AddHandler(evtLeftBtnMouseLeaveEvent, value);

				remove => RemoveHandler(evtLeftBtnMouseLeaveEvent, value);
			}

			[System.ComponentModel.Category("Mouse")]
			[System.ComponentModel.Description("Indicates the mouse is now over the drop button")]
			public event DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs> evtDropBtnMouseEnter
			{
				add => AddHandler(evtDropBtnMouseEnterEvent, value);

				remove => RemoveHandler(evtDropBtnMouseEnterEvent, value);
			}

			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("Indicates the user is trying to open the drop menu.  Set Handled to true to prevent that.")]
			public event DMenuOpeningHandler evtMenuOpening
			{
				add => AddHandler(evtMenuOpeningEvent, value);

				remove => RemoveHandler(evtMenuOpeningEvent, value);
			}

			[System.ComponentModel.Category("Mouse")]
			[System.ComponentModel.Description("Indicates the mouse was over the drop button, but is no longer inside the drop button")]
			public event DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs> evtDropBtnMouseLeave
			{
				add => AddHandler(evtDropBtnMouseLeaveEvent, value);

				remove => RemoveHandler(evtDropBtnMouseLeaveEvent, value);
			}
		#endregion

		#region Constants
			public const string strDropBtnIcon = "▼";

			public struct PropNames
			{
				public const string strMenu = nameof(Menu);
				public const string strCtnts = nameof(Ctnts);
				public const string strShowLeftBtn = nameof(ShowLeftBtn);
			}

			#region Dependency Properties
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "The standard for " +
				"dependency properties requires the identifier match the associated property")]
				public static readonly System.Windows.DependencyProperty MenuProperty = System.Windows.DependencyProperty
					.Register(PropNames.strMenu, typeof(System.Windows.Controls.ContextMenu), typeof(DropMenuBtn), new
					System.Windows.UIPropertyMetadata(null, OnMenuPropChanged, null,
					true));

			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "The standard for " +
				"dependency properties requires the identifier match the associated property")]
				public static readonly System.Windows.DependencyProperty CtntsProperty = System.Windows.DependencyProperty
					.Register(PropNames.strCtnts, typeof(object), typeof(DropMenuBtn), new System.Windows.UIPropertyMetadata(null,
					OnCtntsPropChanged, null, true));

			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "The standard for " +
				"dependency properties requires the identifier match the associated property")]
				public static readonly System.Windows.DependencyProperty ShowLeftBtnProperty = System.Windows
					.DependencyProperty.Register(PropNames.strShowLeftBtn, typeof(bool), typeof(DropMenuBtn), new
					System.Windows.UIPropertyMetadata(false, OnShowLeftBtnPropChanged, null, true));
			#endregion

			#region Routed Events
				public static readonly System.Windows.RoutedEvent evtLeftBtnMouseEnterEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtLeftBtnMouseEnter), System.Windows.RoutingStrategy.Bubble,
					typeof(DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs>), typeof(DropMenuBtn));

				public static readonly System.Windows.RoutedEvent evtLeftBtnMouseClickedEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtLeftBtnMouseClicked), System.Windows.RoutingStrategy.Bubble,
					typeof(DGeneralRoutedEvtHandler<System.Windows.Input.MouseButtonEventArgs>), typeof(DropMenuBtn));

				public static readonly System.Windows.RoutedEvent evtLeftBtnMouseLeaveEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtLeftBtnMouseLeave), System.Windows.RoutingStrategy.Bubble,
					typeof(DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs>), typeof(DropMenuBtn));

				public static readonly System.Windows.RoutedEvent evtDropBtnMouseEnterEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtDropBtnMouseEnter), System.Windows.RoutingStrategy.Bubble,
					typeof(DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs>), typeof(DropMenuBtn));

				public static readonly System.Windows.RoutedEvent evtMenuOpeningEvent = System.Windows.EventManager
				.RegisterRoutedEvent(nameof(evtMenuOpening), System.Windows.RoutingStrategy.Bubble,
				typeof(DMenuOpeningHandler), typeof(DropMenuBtn));

				public static readonly System.Windows.RoutedEvent evtDropBtnMouseLeaveEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtDropBtnMouseLeave), System.Windows.RoutingStrategy.Bubble,
					typeof(DGeneralRoutedEvtHandler<System.Windows.Input.MouseEventArgs>), typeof(DropMenuBtn));
			#endregion
		#endregion

		#region Helper Types
			public sealed class WrapperForRoutedEvtToParentArgs<EvtArgsInnerType> : System.Windows.RoutedEventArgs
				where EvtArgsInnerType : System.Windows.RoutedEventArgs
			{
				public WrapperForRoutedEvtToParentArgs(System.Windows.RoutedEvent revtToSend, DropMenuBtn mbSender,
					EvtArgsInnerType inner) : base(revtToSend, mbSender) => this.inner = inner;

				public readonly EvtArgsInnerType inner;
			}

			public sealed class MenuOpeningEvtArgs : System.Windows.RoutedEventArgs
			{
				public MenuOpeningEvtArgs(System.Windows.RoutedEvent revtToSend, DropMenuBtn mbSender, System
					.Windows.RoutedEventArgs inner) : base(revtToSend, mbSender) => this.inner = inner;

				private readonly System.Windows.RoutedEventArgs inner;

				public new bool Handled
				{
					get => inner.Handled;

					set => inner.Handled = value;
				}
			}
		#endregion

		#region Members
		#endregion

		#region Properties
			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("This is the menu that's shown when the user clicks the drop down button.")]
			public System.Windows.Controls.ContextMenu? Menu
			{
				get => (System.Windows.Controls.ContextMenu)GetValue(MenuProperty);

				set => SetValue(MenuProperty, value);
			}

			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("The contents of the control.  Use this instead of the normal Contents property as that's " +
				"used internally.")]
			public object? Ctnts
			{
				get => GetValue(CtntsProperty);

				set => SetValue(CtntsProperty, value);
			}

			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("Set to true if you want both halves of the button (making it a split button) or false if " +
				"you don't need it (making the button a simply dropdown.")]
			public bool ShowLeftBtn
			{
				get => (bool)GetValue(ShowLeftBtnProperty);

				set => SetValue(ShowLeftBtnProperty, value);
			}
		#endregion

		#region Methods
			protected override void OnInitialized(EventArgs e)
			{
				base.OnInitialized(e);

				OnCtntsPropChanged(this, new(CtntsProperty, null, null));
				OnShowLeftBtnPropChanged(this, new(ShowLeftBtnProperty, false, false));
				DataContextChanged += (sender, args) =>
				{
					if(Menu != null)
						Menu.DataContext = DataContext;
				};
			}

			private void AddBinding()
			{
				if(Menu != null)
				{
					System.Windows.Data.Binding binding = new("IsOpen")
					{
						Source = Menu,
						NotifyOnSourceUpdated = true,
						NotifyOnTargetUpdated = true,
						Mode = System.Windows.Data.BindingMode.TwoWay,
					};
					chkDrop.SetBinding(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty, binding);
				}
			}

			private string GetDropBtnCtnts() => (Ctnts == null && ShowLeftBtn ? "" : Ctnts + " ") + strDropBtnIcon;
		#endregion

		#region Event Handlers
			private static void OnMenuPropChanged(System.Windows.DependencyObject doChangeParent, System.Windows
				.DependencyPropertyChangedEventArgs e)
			{
				DropMenuBtn mbChangeParent = (DropMenuBtn)doChangeParent;
				if(mbChangeParent.Menu != null)
				{
					mbChangeParent.AddBinding();
					mbChangeParent.Menu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
					mbChangeParent.Menu.PlacementTarget = mbChangeParent.chkDrop;
				}
			}

			private static void OnCtntsPropChanged(System.Windows.DependencyObject doChanged, System.Windows.DependencyPropertyChangedEventArgs e)
			{
				DropMenuBtn mbChanged = (DropMenuBtn)doChanged;
				if(mbChanged.ShowLeftBtn)
					mbChanged.btnLeft.Content = mbChanged.Ctnts;
				else
					mbChanged.chkDrop.Content = mbChanged.GetDropBtnCtnts();
			}

			private static void OnShowLeftBtnPropChanged(System.Windows.DependencyObject doChanged, System.Windows
				.DependencyPropertyChangedEventArgs e)
			{
				DropMenuBtn mbChanged = (DropMenuBtn)doChanged;
				mbChanged.btnLeft.Visibility = mbChanged.ShowLeftBtn ? System.Windows.Visibility.Visible : System.Windows
					.Visibility.Collapsed;

				if(mbChanged.ShowLeftBtn)
					mbChanged.btnLeft.Content = mbChanged.Ctnts;
				else
					mbChanged.chkDrop.Content = mbChanged.GetDropBtnCtnts();
			}

			private void OnLeftBtnMouseEnterInternal(object sender, System.Windows.Input.MouseEventArgs e) =>
				RaiseEvent(new WrapperForRoutedEvtToParentArgs<System.Windows.Input
				.MouseEventArgs>(evtLeftBtnMouseEnterEvent, this, e));

			private void OnLeftBtnClickedInternal(object sender, System.Windows.RoutedEventArgs e) => RaiseEvent(new
				WrapperForRoutedEvtToParentArgs<System.Windows.RoutedEventArgs>(evtLeftBtnMouseClickedEvent, this, e));

			private void OnLeftBtnMouseLeaveInternal(object sender, System.Windows.Input.MouseEventArgs e) =>
				RaiseEvent(new WrapperForRoutedEvtToParentArgs<System.Windows.Input
				.MouseEventArgs>(evtLeftBtnMouseLeaveEvent, this, e));

			private void OnDropBtnMouseEnterInternal(object sender, System.Windows.Input.MouseEventArgs e) =>
				RaiseEvent(new WrapperForRoutedEvtToParentArgs<System.Windows.Input
				.MouseEventArgs>(evtDropBtnMouseEnterEvent, this, e));

			private void OnDropBtnMouseLeaveInternal(object sender, System.Windows.Input.MouseEventArgs e) =>
				RaiseEvent(new WrapperForRoutedEvtToParentArgs<System.Windows.Input
				.MouseEventArgs>(evtDropBtnMouseLeaveEvent, this, e));

			private void OnRightCheckedChanged(object sender, System.Windows.RoutedEventArgs e)
			{
				RaiseEvent(new MenuOpeningEvtArgs(evtMenuOpeningEvent, this, e));

				if(!e.Handled && Menu != null)
					Menu.IsOpen = true;
			}
		#endregion
	}
}