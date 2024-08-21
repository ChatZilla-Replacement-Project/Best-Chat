// Ignore Spelling: IRC Ctrls

using System;

namespace BestChat.IRC.General.Ctrls
{
	public class NetworkLogInModesComboBox : GUI.Ctrls.EnumComboBox<Data.Defs.LogInModes>
	{
		public NetworkLogInModesComboBox()
		{
		}

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);

			IsEditable = false;
			IsReadOnly = true;
		}
	}
}