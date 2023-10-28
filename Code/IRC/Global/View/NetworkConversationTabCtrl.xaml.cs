// Ignore Spelling: Ctrl

namespace BestChat.IRC.Global.View
{
	/// <summary>
	/// Interaction logic for NetworkConversationTabCtrl.xaml
	/// </summary>
	public partial class NetworkConversationTabCtrl : Ctrls.AbstractConversationTabCtrl
	{
		public NetworkConversationTabCtrl(Data.ActiveNetwork anetUs) : base(anetUs, anetUs.LocalizedLongDesc)
			=> InitializeComponent();

		public override bool ShouldModeBarBeShown => false;
	}
}