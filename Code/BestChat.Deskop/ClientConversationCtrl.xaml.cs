// Ignore Spelling: Ctrl

namespace BestChat.Desktop
{
	/// <summary>
	/// Interaction logic for ClientConversationCtrl.xaml
	/// </summary>
	public partial class ClientConversationCtrl : GUI.Ctrls.AbstractVisualConversationCtrl
	{
		public ClientConversationCtrl() : base(ClientConversation.ClientConversation.instance)
		{
			InitializeComponent();
		}
	}
}