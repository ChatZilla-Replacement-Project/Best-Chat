// Ignore Spelling: userver IRC eserver

namespace BestChat.IRC.General.View
{
	/// <summary>
	/// Interaction logic for ServerDomainEditorDlg.xaml
	/// </summary>
	public partial class ServerDomainEditorDlg : System.Windows.Window
	{
		#region Constructors & Deconstructors
			public ServerDomainEditorDlg(in bool bUseEditMode, Data.Defs.ServerInfo.Editable eserverToEdit)
			{
				InitializeComponent();

				bModeIsEditing = bUseEditMode;

				this.eserverToEdit = eserverToEdit;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly bool bModeIsEditing;

			public readonly Data.Defs.ServerInfo.Editable eserverToEdit;
		#endregion

		#region Properties
			public bool ModeIsEditing => bModeIsEditing;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}