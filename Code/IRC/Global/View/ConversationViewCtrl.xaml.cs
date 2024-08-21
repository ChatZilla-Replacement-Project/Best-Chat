// Ignore Spelling: Ctrls Ctrl gvc

namespace BestChat.IRC.Global.View
{
	public partial class ConversationViewCtrl : GUI.Ctrls.AbstractVisualConversationCtrl, System
		.ComponentModel.INotifyPropertyChanged
	{
        #region Constructors & Deconstructors
        public ConversationViewCtrl(in Platform.Conversations.IGroupViewOrConversation gvc) : base(gvc) =>
			InitializeComponent();
        #endregion

        #region Delegates
        #endregion

        #region Events
        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
			public static readonly System.Windows.DependencyProperty ShouldModeBarBeShownProperty = System
				.Windows.DependencyProperty.Register(nameof(ShouldModeBarBeShown), typeof(bool),
				typeof(ConversationViewCtrl));
		#endregion

		#region Helper Types
			private class TemplateSelector : System.Windows.Controls.DataTemplateSelector
			{
				public TemplateSelector()
				{
				}

				public override System.Windows.DataTemplate? SelectTemplate(object objItem, System.Windows
					.DependencyObject doContainer) => objItem is Data.Defs.TwoWayMode mode ? mode.AllParamsByName
					.Count > 0 ? dtempModeWithParam : dtempModeWithOutParam : objItem is Data.Defs.TwoWayMode.Param
					param ? param.mpDef.Type switch
					{
						Data.Defs.ModeParam.Types.@string => param.mpDef.PostFixLabel == null ?
							dtempModeStrParamWithOutPostFix : dtempModeStrParamWithPostFix,
						Data.Defs.ModeParam.Types.number => param.mpDef.PostFixLabel == null ?
							dtempModeIntParamWithOutPostFix : dtempModeIntParamWithPostFix,
						Data.Defs.ModeParam.Types.chanName => param.mpDef.PostFixLabel == null ?
							dtempModeChanParamWithOutPostFix : dtempModeChanParamWithPostFix,
						_ => throw new Util.Exceptions.UnknownOrInvalidEnum<Data.Defs.ModeParam.Types>(param.mpDef
							.Type, "While selecting a template for a mode."),
					} : throw new System.InvalidProgramException("Unknown object type in the list of modes");
			}
		#endregion

		#region Members
			private static System.Windows.DataTemplate? dtempModeWithOutParam;
			private static System.Windows.DataTemplate? dtempModeWithParam;


			private static System.Windows.DataTemplate? dtempModeIntParamWithOutPostFix;
			private static System.Windows.DataTemplate? dtempModeIntParamWithPostFix;

			private static System.Windows.DataTemplate? dtempModeStrParamWithOutPostFix;
			private static System.Windows.DataTemplate? dtempModeStrParamWithPostFix;

			private static System.Windows.DataTemplate? dtempModeChanParamWithOutPostFix;
			private static System.Windows.DataTemplate? dtempModeChanParamWithPostFix;
		#endregion

		#region Properties
		public bool ShouldModeBarBeShown => chkModes.IsChecked == true && gvc is Data.Chan;
		#endregion

		#region Methods
			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				dtempModeWithOutParam ??= (System.Windows.DataTemplate)Resources["ModeWithOutParam"];
				dtempModeWithParam ??= (System.Windows.DataTemplate)Resources["ModeWithParam"];


				dtempModeIntParamWithOutPostFix ??= (System.Windows
					.DataTemplate)Resources["ModeIntParamWithOutPostFix"];
				dtempModeIntParamWithPostFix ??= (System.Windows
					.DataTemplate)Resources["ModeIntParamWithPostFix"];

				dtempModeStrParamWithOutPostFix ??= (System.Windows
					.DataTemplate)Resources["ModeStrParamWithOutPostFix"];
				dtempModeStrParamWithPostFix ??= (System.Windows
					.DataTemplate)Resources["ModeStrParamWithPostFix"];

				dtempModeChanParamWithOutPostFix ??= (System.Windows
					.DataTemplate)Resources["ModeChanParamWithOutPostFix"];
				dtempModeChanParamWithPostFix ??= (System.Windows
					.DataTemplate)Resources["ModeChanParamWithPostFix"];

				if(gvc is Data.Chan chan)
				{
					icModeBar.ItemTemplateSelector = new TemplateSelector();
					icModeBar.ItemsSource = chan.AllModesOnChan.Values;
				}
				else
					gridTopicBar.Visibility = System.Windows.Visibility.Hidden;
			}
		#endregion

		#region Event Handlers
			private void OnModesCheckedChanged(object sender, System.Windows.RoutedEventArgs e) =>
				PropertyChanged?.Invoke(this, new(nameof(ShouldModeBarBeShown)));
		#endregion
	}
}