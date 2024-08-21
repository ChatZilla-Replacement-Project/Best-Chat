// Ignore Spelling: Prefs DTO

namespace BestChat.IRC.Prefs.Data.DTO
{
	public record IrcDTO(IrcDTO.GlobalDTO Global)
	{
		public record GlobalDTO(GlobalDTO.AliasDTO[]? Aliases = null)
		{
			public record AliasDTO(string Name, string Cmd);
		}
	}
}