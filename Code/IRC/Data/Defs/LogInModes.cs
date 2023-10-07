// Ignore Spelling: IRC Defs

namespace BestChat.IRC.Data.Defs
{
	public enum LogInModes
	{
		[Util.Attr.LocalizedDesc("strManual", "Log in manually", "", "",
			typeof(LogInModes))]
		manual,

		[Util.Attr.LocalizedDesc("strSASL", "Use SASL", "", "",
			typeof(LogInModes))]
		sasl,

		[Util.Attr.LocalizedDesc("strNickServ", "Attempt to use NickServ (Requires a network that " +
			"provides NickServ)", "", "", typeof(LogInModes))]
		nickServ,
	}
}