// Ignore Spelling: Prefs DTO

namespace BestChat.Prefs.Data.DTO
{
	public record PrefsDTO(PrefsDTO.GlobalDTO Global)
	{
		public record GlobalDTO(GlobalDTO.GeneralDTO General)
		{
			public record GeneralDTO(GeneralDTO.ConnDTO Conn)
			{
				public record ConnDTO(bool IsIndentEnabled = true, bool IsAutoReconnectEnabled = true, bool
					IsRejoinAfterKickEnabled = true, string CharEncoding = "UTF-8", bool IsUnlimitedAttemptsOn =
					true, int MaxAttempts = 1, string? DefQuitMsg = null)
				{
				}
			}
		}
	}
}