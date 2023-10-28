// Ignore Spelling: Ctrl

namespace BestChat.IRC.Global.View
{
	/// <summary>
	/// Interaction logic for ChanConversationTabCtrl.xaml
	/// </summary>
	public partial class ChanConversationTabCtrl : Ctrls.AbstractConversationTabCtrl
	{
		public ChanConversationTabCtrl(Data.Chan chanUs) : base(chanUs, chanUs.LocalizedLongDesc) =>
			InitializeComponent();

		public override bool ShouldModeBarBeShown => true;
	}
}