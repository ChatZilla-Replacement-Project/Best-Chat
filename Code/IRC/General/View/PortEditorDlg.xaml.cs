// Ignore Spelling: usset Ssl

using System.Linq;

namespace BestChat.IRC.General.View
{
	/// <summary>
	/// Interaction logic for PortEditorDlg.xaml
	/// </summary>
	public partial class PortEditorDlg : System.Windows.Window
	{
		#region Constructors & Deconstructors
			public PortEditorDlg(in System.Collections.Generic.IReadOnlySet<ushort> ussetPortsInUse, in System
				.Collections.Generic.IReadOnlySet<ushort> ussetSslPortsInUse, in ushort usVal, in bool
				bModeIsEdit, in bool bEditingSslPort, in System.Windows.Window wndOwner)
			{
				this.ussetPortsInUse = ussetPortsInUse;
				this.ussetSslPortsInUse = ussetSslPortsInUse;
				this.usVal = usVal;
				this.bModeIsEdit = bModeIsEdit;
				this.bEditingSslPort = bEditingSslPort;

				InitializeComponent();

				Owner = wndOwner;

				Title = bModeIsEdit ? bEditingSslPort ? View.Resources.strPortEditorTitleSslEditingMode : View
					.Resources.strPortEditorTitleEditingMode : bEditingSslPort ? View.Resources
					.strPortEditorTitleSslAddingMode : View.Resources.strPortEditorTitleAddingMode;

				iudPortNum.Value = usVal;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
			public static readonly System.Windows.DependencyProperty UnavailablePortsProperty = System.Windows
				.DependencyProperty.Register(nameof(UnavailablePorts), typeof(System.Collections.Generic
				.IReadOnlySet<ushort>), typeof(PortEditorDlg));
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private readonly System.Collections.Generic.IReadOnlySet<ushort> ussetPortsInUse;
			private readonly System.Collections.Generic.IReadOnlySet<ushort> ussetSslPortsInUse;
			private ushort usVal;
			private readonly bool bModeIsEdit;
			private readonly bool bEditingSslPort;
		#endregion

		#region Properties
			public System.Collections.Generic.IReadOnlySet<ushort> UnavailablePorts => ussetPortsInUse
				.Union(ussetSslPortsInUse).Order().ToHashSet();

			public ushort Val => usVal;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
			private void OnOkClicked(object sender, System.Windows.RoutedEventArgs e)
			{
				usVal = (ushort)iudPortNum.Value;

				DialogResult = true;
			}

			private void OnCancelClicked(object sender, System.Windows.RoutedEventArgs e)
			{
				if(System.Windows.MessageBox.Show(View.Resources.strCancelEditingPortAreYouSure, View.Resources
					.strCancelEditingPortTitle, System.Windows.MessageBoxButton.YesNo, System.Windows
					.MessageBoxImage.Question, System.Windows.MessageBoxResult.No) == System.Windows
					.MessageBoxResult.Yes)
				{
					DialogResult = false;

					Close();
				}
			}
		#endregion
	}
}