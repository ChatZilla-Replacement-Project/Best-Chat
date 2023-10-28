﻿// Ignore Spelling: Prefs dnet

namespace BestChat.IRC.Data.Prefs
{
	using Util.Ext;

	public class ChanPrefs : Platform.Prefs.Data.AbstractChildMgr
	{
		#region Constructors & Deconstructors
			internal ChanPrefs(Defs.Network dnetUs) : base(PrefsMgr.Mgr, dnetUs.Name, dnetUs.Name, Resources
				.strPrefsForNetwork.Fmt(dnetUs.Name)) => this.dnetUs = dnetUs;
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly Defs.Network dnetUs;
		#endregion

		#region Properties
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}