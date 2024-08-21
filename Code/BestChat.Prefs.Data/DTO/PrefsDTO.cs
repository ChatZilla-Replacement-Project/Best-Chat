// Ignore Spelling: Prefs DTO Conf

namespace BestChat.Prefs.Data.DTO
{
	public record PrefsDTO(PrefsDTO.GlobalDTO Global)
	{
		public record GlobalDTO(GlobalDTO.GeneralDTO General, GlobalDTO.AppearanceDTO Appearance, GlobalDTO.PluginsDTO Plugins)
		{
			public record AppearanceDTO(AppearanceDTO.ConfModeDTO ConfMode, AppearanceDTO.FontDTO Font, AppearanceDTO.TimeStampDTO TimeStamp,
				AppearanceDTO.UserListDTO UserList)
			{
				public record ConfModeDTO(bool ConfModeEnabled = false, int UserLimitBeforeTrigger = 150, bool ActionsCollapsed = false, bool
					MsgsCollapsed = false);

				public record FontDTO(string NormalFamily = "Times New Roman", string FixedWidthFamily = "Courier New", int FontSize = 12, System
					.Windows.FontWeight? Weight = null);

				public record TimeStampDTO(bool Show = true, string Fmt = "G");

				public record UserListDTO(Prefs.GlobalPrefs.AppearancePrefs.UserListPrefs.Locations Loc = Prefs.GlobalPrefs.AppearancePrefs
					.UserListPrefs.Locations.left, Prefs.GlobalPrefs.AppearancePrefs.UserListPrefs.WaysToShowModes HowToShowModes = Prefs.GlobalPrefs
					.AppearancePrefs.UserListPrefs.WaysToShowModes.symbols, bool SortByMode = true);
			}

			public record PluginsDTO(PluginsDTO.ExtDTO Ext)
			{
				public record ExtDTO(ExtDTO.WhereToLookDTO WhereToLook, ExtDTO.ScriptEntryDTO[]? Scripts = null, ExtDTO.ProgramEntryDTO[]? Programs
					= null)
				{
					public record WhereToLookDTO(string[]? Paths = null, bool IncludeSysPaths = true);

					public record ScriptEntryDTO(string FileNameExtOrMask, string? ProgramNeeded, string ParamsToPass, bool Enabled);

					public record ProgramEntryDTO(string Name, string Program, string ParamsToPass, bool Enabled);
				}
			}

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