namespace BestChat.Prefs.Ctrls
{
	/// <summary>
	/// Interaction logic for Global.xaml
	/// </summary>
	public partial class Global : Platform.Prefs.VisualTabCtrl
	{
		#region Constructors & Deconstructors
			public Global() : base(Ctrls.Resources.strGlobalName, Ctrls.Resources.strGlobalNameToolTipText, Data
				.Prefs.Instance.Global) => InitializeComponent();
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
		#endregion

		#region Properties
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}