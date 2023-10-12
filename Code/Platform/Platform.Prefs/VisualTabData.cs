// Ignore Spelling: Prefs Ctrl

namespace BestChat.Platform.Prefs
{
	public class VisualTabCtrl : System.Windows.Controls.UserControl
	{
		public VisualTabCtrl(in string strName, in string strHelpText, ChildMgr mgrUs)
		{
			this.strName = strName;
			this.strHelpText = strHelpText;
			this.mgrUs = mgrUs;
		}

		public readonly string strName;
		public readonly string strHelpText;

		public new string Name => strName;

		public string HelpText => strHelpText;


		public readonly ChildMgr mgrUs;

		public ChildMgr OurMgr => mgrUs;
	}
}