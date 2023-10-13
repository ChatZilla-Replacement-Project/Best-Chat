// Ignore Spelling: Defs DTO

namespace BestChat.IRC.Data.Defs.DTO
{
	public record ChanModeDTO
	(
		char Mode,
		LocalizedTextDTO[] LocalizedDesc,
		string DefaultDesc,
		bool NotAlwaysAvailable,
		ModeParamDTO[] Parameters,
		string FmtAsSentToNetwork
	);
}