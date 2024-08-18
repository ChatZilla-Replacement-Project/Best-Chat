// Ignore Spelling: Ctrls

namespace BestChat.GUI.Ctrls
{
	/// <summary>
	/// Interaction logic for CardConversationEventView.xaml
	/// </summary>
	public partial class CardConversationEventView : System.Windows.Controls.UserControl
	{
		#region Constructors & Deconstructors
			public CardConversationEventView() => InitializeComponent();
		#endregion

		#region Constants
			#region Dependency Properties
				[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles",
					Justification = "WPF dependency property names act more like names for actual properties even "
					+ "though they're just static members.")]
				public static readonly System.Windows.DependencyProperty IsSenderLocalProperty = System.Windows
					.DependencyProperty.Register(nameof(IsSenderLocal), typeof(bool),
					typeof(CardConversationEventView), new(false,
					OnIsSenderLocalPropChanged));
			#endregion
		#endregion

		#region Helper Types
			private class TemplateSelector : System.Windows.Controls.DataTemplateSelector
			{
				public TemplateSelector()
				{
				}

				public override System.Windows.DataTemplate SelectTemplate(object objItem, System.Windows
					.DependencyObject doContainer) => objItem is char ? Templates.instance.CharIcon : objItem
					is System.Windows.Media.ImageSource ? Templates.instance.ImgIcon : throw new System
					.InvalidProgramException("Unsupported type with no matching template");
			}
		#endregion

		#region Properties
			public bool IsSenderLocal
			{
				get => (bool)GetValue(IsSenderLocalProperty);

				set => SetValue(IsSenderLocalProperty, value);
			}
		#endregion

		#region Methods
			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				ccIcon.ContentTemplateSelector = new TemplateSelector();
			}
		#endregion

		#region Event Handlers
			private static void OnIsSenderLocalPropChanged(System.Windows.DependencyObject doSender, System
				.Windows.DependencyPropertyChangedEventArgs ea)
			{
				if(doSender is CardConversationEventView ccev)
					ccev.HorizontalContentAlignment = ccev.IsSenderLocal ? System.Windows.HorizontalAlignment.Right
						: System.Windows.HorizontalAlignment.Left;
			}

			protected void OnSizeChanged(object objSender, System.Windows.SizeChangedEventArgs e) => textDescOfEvent.MaxWidth =
				e.NewSize.Width * .8;
		#endregion
	}
}