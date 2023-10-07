﻿// Ignore Spelling: Defs Serv

namespace BestChat.IRC.Data.Defs
{
	public enum ChanServOpts
	{
		[Util.Attr.LocalizedDesc("strChanServOptUnknown", "Available, but type unknown",
			"strChanServOptUnknownTooltip", "Select this if the network has a " +
			"ChanServ, but you don't know much about it", typeof(ChanServOpts))]
		unknown,

		[Util.Attr.LocalizedDesc("strChanServOptAtTheme", "AtTheme",
			"strChanServOptAtThemeTooltip", "ChanServ is implemented by AtTheme.  " +
			"Only select this if you're sure that's what they use.", typeof(ChanServOpts))]
		atTheme,
	}
}