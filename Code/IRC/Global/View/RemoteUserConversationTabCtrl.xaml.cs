// Ignore Spelling: Ctrl

namespace BestChat.IRC.Global.View
{
	/// <summary>
	/// Interaction logic for RemoteUserConversationTabCtrl.xaml
	/// </summary>
	public partial class RemoteUserConversationTabCtrl : Ctrls.AbstractConversationTabCtrl
	{
		public RemoteUserConversationTabCtrl(Data.ConversationWithRemoteUser ru) : base(ru, ru
			.LocalizedLongDesc) => InitializeComponent();

		public override bool ShouldModeBarBeShown => false;
	}
}