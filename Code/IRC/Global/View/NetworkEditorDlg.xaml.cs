// Ignore Spelling: enet IRC eunet

namespace BestChat.IRC.Global.View
{
	using Util.Ext;

	/// <summary>
	/// Interaction logic for NetworkEditorDlg.xaml
	/// </summary>
	public partial class NetworkEditorDlg : System.Windows.Window, System.ComponentModel.INotifyPropertyChanged
	{
		#region Constructors & Deconstructors
			public NetworkEditorDlg(in bool bEditMode, in Data.Defs.UserNetwork.Editable eunetWhatToEdit)
			{
				this.bEditMode = bEditMode;
				eunetWhatsBeingEdited = eunetWhatToEdit;

				InitializeComponent();

				DataContext = eunetWhatsBeingEdited;

				strNameValPriorToEditing = eunetWhatsBeingEdited.Name;

				UpdateTitle();
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
			public static readonly System.Windows.DependencyProperty CanSaveProperty = System.Windows
				.DependencyProperty.Register(nameof(CanSave), typeof(bool), typeof(NetworkEditorDlg));

			public static readonly System.Windows.DependencyProperty ValidationErrorMsgProperty = System.Windows
				.DependencyProperty.Register(nameof(ValidationErrorMsg), typeof(string),
				typeof(NetworkEditorDlg));

			public static readonly System.Windows.DependencyProperty NameTextBoxStyleProperty = System.Windows
				.DependencyProperty.Register(nameof(NameTextBoxStyle), typeof(System.Windows.Style),
				typeof(NetworkEditorDlg));
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly Data.Defs.UserNetwork.Editable eunetWhatsBeingEdited;

			public readonly string strNameValPriorToEditing;

			public readonly bool bEditMode;
		#endregion

		#region Properties
			public bool CanSave => !eunetWhatsBeingEdited.Name.IsEmpty() && !Data.NetworkMgr.mgr.AllItems
				.ContainsKey(eunetWhatsBeingEdited.Name) && Data.NetworkMgr.mgr.AllItems[eunetWhatsBeingEdited
				.Name] != eunetWhatsBeingEdited.unetOriginal && eunetWhatsBeingEdited.AllUnsortedServers.Count >
				0;

			public string ValidationErrorMsg => eunetWhatsBeingEdited.Name.IsEmpty() ? View.Resources
				.strValidationNameBlank : !Data.NetworkMgr.mgr.AllItems.ContainsKey(eunetWhatsBeingEdited.Name) &&
				Data.NetworkMgr.mgr.AllItems[eunetWhatsBeingEdited.Name] != eunetWhatsBeingEdited.unetOriginal ?
				View.Resources.strValidationNameTaken : eunetWhatsBeingEdited.AllUnsortedServers.Count == 0 ? View
				.Resources.strValidationEnterAtLeastOneDomainName : "";

			public System.Windows.Style NameTextBoxStyle => (System.Windows.Style)System.Windows.Application
				.Current.Resources[!eunetWhatsBeingEdited.Name.IsEmpty() && !Data.NetworkMgr.mgr.AllItems
				.ContainsKey(eunetWhatsBeingEdited.Name) && Data.NetworkMgr.mgr.AllItems[eunetWhatsBeingEdited
				.Name] != eunetWhatsBeingEdited.unetOriginal ? "TextBoxWithInvalidCtnts" : typeof(System.Windows
				.Controls.Primitives.TextBoxBase)];
		#endregion

		#region Methods
			private void UpdateTitle() => Title = bEditMode ? View.Resources.strNetworkEditorEditingTitle
				.Fmt(eunetWhatsBeingEdited.Name, strNameValPriorToEditing) : View.Resources.strNetworkEditorAddingTitle;
		#endregion

		#region Event Handlers
			private void OnHomePageLinkClicked(object objSender, System.Windows.RoutedEventArgs e)
			{
				if(objSender is not System.Windows.Controls.Button)
					throw new System.InvalidProgramException("For some reason, sender of the clicked event for a " +
						"homepage isn't a button.");

				System.Windows.Controls.Button btnSender = (System.Windows.Controls.Button)objSender;

				if(btnSender.DataContext is not Data.Defs.Network)
					throw new System.InvalidProgramException("For some reason, the sender of the clicked event for a " +
						"homepage doesn't have a network for its data context.");

				System.Uri? uriRequestedHomepage = ((Data.Defs.Network)btnSender.DataContext).Homepage;

				if(uriRequestedHomepage != null)
					using(System.Diagnostics.Process process = new System.Diagnostics.Process()
					{
						StartInfo = new System.Diagnostics.ProcessStartInfo()
						{
							UseShellExecute = true,
							FileName = uriRequestedHomepage.AbsoluteUri,
						}
					})
					{
						process.Start();
					}
			}

			private void OnNameChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
			{
				PropertyChanged?.Invoke(this, new(nameof(CanSave)));
				PropertyChanged?.Invoke(this, new(nameof(ValidationErrorMsg)));

				UpdateTitle();
			}

			private void OnHomepageChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
			{
				PropertyChanged?.Invoke(this, new(nameof(CanSave)));
				PropertyChanged?.Invoke(this, new(nameof(ValidationErrorMsg)));
			}

			private void OnAddDomain(object sender, System.Windows.RoutedEventArgs e)
			{
				ServerDomainEditorDlg dlg = new(false, eunetWhatsBeingEdited
					.GetBlankNewServerDomain())
				{
					Owner = this,
				};

				if(dlg.ShowDialog() == true)
				{
					eunetWhatsBeingEdited.AddServerDomain(dlg.eserverToEdit);

					PropertyChanged?.Invoke(this, new(nameof(CanSave)));
					PropertyChanged?.Invoke(this, new(nameof(ValidationErrorMsg)));
				}
			}

			private void OnEditDomain(object sender, System.Windows.RoutedEventArgs e)
			{
				ServerDomainEditorDlg dlg = new(true, ((Data.Defs
					.ServerInfo)dgServerDomains.SelectedValue).MakeEditableVersion(eunetWhatsBeingEdited))
				{
				 Owner = this,
				};

				if(dlg.ShowDialog() == true)
					dlg.eserverToEdit.Save();
			}

			private void OnDelDomain(object sender, System.Windows.RoutedEventArgs e)
			{
				if(System.Windows.MessageBox.Show(View.Resources.strDelServerDomainAreYouSure, View.Resources
					.strDelServerDomainAreYouSureTitle, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage
					.Question, System.Windows.MessageBoxResult.No) == System.Windows.MessageBoxResult.Yes)
				{
					eunetWhatsBeingEdited.DelServerDomain((Data.Defs.ServerInfo)dgServerDomains.SelectedValue);

					PropertyChanged?.Invoke(this, new(nameof(CanSave)));
					PropertyChanged?.Invoke(this, new(nameof(ValidationErrorMsg)));
				}
			}

			private void OnCancel(object sender, System.Windows.RoutedEventArgs e)
			{
				if(eunetWhatsBeingEdited.WereChangesMade && System.Windows.MessageBox.Show(View.Resources
					.strNetworkEditorCancelChanges, View.Resources.strNetworkEditorCancelChangesTitle, System.Windows
					.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question, System.Windows.MessageBoxResult.No) ==
					System.Windows.MessageBoxResult.Yes)
				{
					DialogResult = false;

					Close();
				}
			}

			private void OnOK(object sender, System.Windows.RoutedEventArgs e)
			{
				DialogResult = true;

				Close();
			}

			private void OnMoveDomainUp(object sender, System.Windows.RoutedEventArgs e) => eunetWhatsBeingEdited
				.MoveServerUpSearchList((Data.Defs.ServerInfo)dgServerDomains.SelectedValue);

			private void OnMoveDomainDown(object sender, System.Windows.RoutedEventArgs e) => eunetWhatsBeingEdited
				.MoveServerDownSearchList((Data.Defs.ServerInfo)dgServerDomains.SelectedValue);

			private void OnReset(object sender, System.Windows.RoutedEventArgs e) => eunetWhatsBeingEdited
				.ResetServerDomainList();
		#endregion
	}
}