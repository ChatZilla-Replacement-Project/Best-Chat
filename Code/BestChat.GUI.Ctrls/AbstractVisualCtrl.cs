// Ignore Spelling: Ctrls Ctrl Ctnts Hdr

using System;

namespace BestChat.GUI.Ctrls
{
	[System.Windows.Markup.ContentProperty(nameof(Ctnts))]
	/// <summary>
	/// Interaction logic for NewAbstractVisualTabCtrl.xaml
	/// </summary>
	public abstract class AbstractVisualCtrl : System.Windows.Controls.UserControl
	{
		#region Constructors & Deconstructors
			public AbstractVisualCtrl(in string strLocalizedShortName, in string strLocalizedLongDesc)
			{
				LocalizedShortName = strLocalizedShortName;

				LocalizedLongDesc = strLocalizedLongDesc;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
			#region Dependency Properties
				[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles",
					Justification = "WPF dependency property names act more like names for actual properties even " +
					"though they're just static members.")]
				public static readonly System.Windows.DependencyProperty HdrProperty = System.Windows
					.DependencyProperty.Register(nameof(Hdr), typeof(System.Windows.FrameworkElement),
					typeof(AbstractVisualCtrl), new System.Windows.UIPropertyMetadata(null,
					OnHdrPropChanged, null, true));

				[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles",
					Justification = "WPF dependency property names act more like names for actual properties even " +
					"though they're just static members.")]
				public static readonly System.Windows.DependencyProperty CtntsProperty = System.Windows
					.DependencyProperty.Register(nameof(Ctnts), typeof(System.Windows.FrameworkElement),
					typeof(AbstractVisualCtrl), new System.Windows.UIPropertyMetadata(null,
					OnCtntsPropChanged, null, true));
			#endregion

			#region Routed Events
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private readonly System.Windows.Controls.DockPanel dock = new();

			private readonly System.Windows.Controls.ContentControl ccHdr = new();

			private readonly System.Windows.Controls.ScrollViewer svCtnts = new();
		#endregion

		#region Properties
			public string LocalizedShortName
			{
				get;

				private init;
			}

			public string LocalizedLongDesc
			{
				get;

				private init;
			}

			public System.Windows.FrameworkElement? Hdr
			{
				get => (System.Windows.FrameworkElement?)GetValue(HdrProperty);

				set => SetValue(HdrProperty, value);
			}

			public System.Windows.FrameworkElement? Ctnts
			{
				get => (System.Windows.FrameworkElement?)GetValue(CtntsProperty);

				set => SetValue(CtntsProperty, value);
			}
		#endregion

		#region Methods
			protected override void OnInitialized(EventArgs e)
			{
				base.OnInitialized(e);

				Content = dock;

				dock.Children.Add(ccHdr);
				System.Windows.Controls.DockPanel.SetDock(ccHdr, System.Windows.Controls.Dock.Top);

				dock.Children.Add(svCtnts);
			}
		#endregion

		#region Event Handlers
			private static void OnHdrPropChanged(System.Windows.DependencyObject doSender, System.Windows
				.DependencyPropertyChangedEventArgs ea)
			{
				if(doSender is AbstractVisualCtrl avtcSender && avtcSender.ccHdr.Content != avtcSender
						.Hdr)
				{
					avtcSender.ccHdr.Content = avtcSender.Hdr;

					avtcSender.ccHdr.Visibility = avtcSender.Hdr == null ? System.Windows.Visibility.Collapsed :
						System.Windows.Visibility.Visible;
				}
			}

			private static void OnCtntsPropChanged(System.Windows.DependencyObject doSender, System.Windows
				.DependencyPropertyChangedEventArgs ea)
			{
				if(doSender is AbstractVisualCtrl avtcSender && avtcSender.svCtnts.Content != avtcSender
						.Ctnts)
					avtcSender.svCtnts.Content = avtcSender.Ctnts;
			}
		#endregion
	}
}