// Ignore Spelling: prefs

using System.ComponentModel;

namespace BestChat.Prefs.Data
{
	public class Prefs : Platform.Prefs.Data.AbstractMgr
	{
		#region Constructors & Deconstructors
			internal Prefs()
			{
				fileOurSettings = new(System.IO.Path.Combine(((Platform.DataLoc.IDataLocProvider)System
					.Windows.Application.Current).LocalDataLoc.FullName, "settings.json"));

				DTO.PrefsDTO? dto = fileOurSettings.Exists ? System.Text.Json.JsonSerializer.Deserialize<DTO
					.PrefsDTO>(fileOurSettings.OpenText().ReadToEnd(), jsoStandard) : null;

				global = dto == null ? new(this) : new(this, dto.Global);
				global.evtDirtyChanged += OnChildMgrDirtyChanged;

				mapMgrsForProtolsByName[IRC.Protocol_Module.ProtocolDef.instance.Name] = IRC.Protocol_Module
					.ProtocolDef.instance.ProtocolMgrForRootPrefObj ?? throw new System
					.InvalidProgramException("The app should've initialized the IRC protocol module, but " +
					"doesn't seem to have done so.");
			}

			static Prefs()
			{
				if(System.Windows.Application.Current is not Platform.DataLoc.IDataLocProvider)
					throw new System.InvalidProgramException("Applications using BestChat's preference " +
						"manager must implement BestChat.Platform.DataLoc.IDataLocProvider");

				instance = new();
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
			public class GlobalPrefs : Platform.Prefs.Data.AbstractChildMgr
			{
				#region Constructors & Deconstructors
					public GlobalPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Global",
						Resources.strGlobalName, Resources.strGlobalNameToolTipText)
					{
						general = new(this);
						general.evtDirtyChanged += OnChildMgrDirtyChanged;
					}

					internal GlobalPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO dto) :
						base(mgrParent, "Global", Resources.strGlobalName, Resources
						.strGlobalNameToolTipText)
					{
						general = new(this, dto.General);
						general.evtDirtyChanged += OnChildMgrDirtyChanged;
					}
				#endregion

				#region Delegates
				#endregion

				#region Events
					public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
			#endregion

				#region Constants
				#endregion

				#region Helper Types
					public class AppearancePrefs : Platform.Prefs.Data.AbstractChildMgr
					{
						#region Constructors & Deconstructors
							public AppearancePrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Appearance", Resources
								.strGlobalAppearancePageTitle, Resources.strGlobalAppearancePageDesc)
							{
								confMode = new(this);	
								font = new(this);
								timestamp = new(this);
							}
						#endregion

						#region Delegates
						#endregion

						#region Events
							public override event PropertyChangedEventHandler? PropertyChanged;
						#endregion

						#region Constants
						#endregion

						#region Helper Types
							public class ConfModePrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public ConfModePrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Conference Mode", Resources
										.strGlobalAppearanceConfModeTitle, Resources.strGlobalAppearanceConfModeDesc)
									{
										confModeEnabled = new(this, "Conference Mode Enabled?", Resources.strGlobalAppearanceConfModeEnabledTitle,
											Resources.strGlobalAppearanceConfModeEnabledDesc, false);
										userLimitBeforeTrigger = new(this, "User Limit Before Trigger", Resources.strGlobalAppearanceConfModeLimitTitle,
											Resources.strGlobalAppearanceConfModeLimitDesc, 20, iMinVal: 2);
										actionsCollapsed = new(this, "Collapse Actions When Collapsing Messages", Resources
											.strGlobalAppearanceConfModeCollapseActionsTitle, Resources.strGlobalAppearanceConfModeCollapseActionsDesc, false);
										msgsCollapsed = new(this, "Collapse Messages?", Resources.strGlobalAppearanceConfModeCollapseMsgsTitle,
											Resources.strGlobalAppearanceConfModeCollapseMsgsDesc, false);
									}
								#endregion

								#region Delegates
								#endregion

								#region Events
									public override event PropertyChangedEventHandler? PropertyChanged;
								#endregion

								#region Constants
								#endregion

								#region Helper Types
								#endregion

								#region Members
									private readonly Platform.Prefs.Data.Item<bool> confModeEnabled;

									private readonly Platform.Prefs.Data.IntItem userLimitBeforeTrigger;

									private readonly Platform.Prefs.Data.Item<bool> actionsCollapsed;

									private readonly Platform.Prefs.Data.Item<bool> msgsCollapsed;
								#endregion

								#region Properties
									public Platform.Prefs.Data.Item<bool> ConfModeEnabled => confModeEnabled;

									public Platform.Prefs.Data.IntItem UserLimitBeforeTrigger => userLimitBeforeTrigger;

									public Platform.Prefs.Data.Item<bool> ActionsCollapsed => actionsCollapsed;

									public Platform.Prefs.Data.Item<bool> MsgsCollapsed => msgsCollapsed;
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
								#endregion
							}

							public class FontPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public FontPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Font", Resources
										.strGlobalAppearanceFontTitle, Resources.strGlobalAppearanceFontDesc)
									{
										normalFamily = new(this, "Normal Family", Resources.strGlobalAppearanceFontNormalFamilyTitle,
											Resources.strGlobalAppearanceFontNormalFamilyDesc, "Times New Roman");

										fixedWidthFamily = new(this, "Fixed Width Family", Resources
											.strGlobalAppearanceFontFixedWidthFamilyTitle, Resources.strGlobalAppearanceFontFixedWidthFamilyDesc,
											"Courier New");

										fontsize = new(this, "Font Size", Resources.strGlobalAppearanceFontSizeTitle, Resources
											.strGlobalAppearanceFontSizeDesc, 12, iMaxVal: 50, iMinVal: 8);

										weight = new(this, "Font Weight", Resources.strGlobalAppearanceFontWeightTitle, Resources
											.strGlobalAppearanceFontWeightTitle, System.Windows.FontWeights.Normal);
									}
								#endregion

								#region Delegates
								#endregion

								#region Events
									public override event PropertyChangedEventHandler? PropertyChanged;
								#endregion

								#region Constants
								#endregion

								#region Helper Types
								#endregion

								#region Members
									private readonly Platform.Prefs.Data.Item<string> normalFamily;

									private readonly Platform.Prefs.Data.Item<string> fixedWidthFamily;

									private readonly Platform.Prefs.Data.IntItem fontsize;

									private readonly Platform.Prefs.Data.Item<System.Windows.FontWeight> weight;
								#endregion

								#region Properties
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
								#endregion
							}

							public class TimeStampPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public TimeStampPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Time Stamp", Resources
										.strGlobalAppearanceTimeStampTitle, Resources.strGlobalAppearanceTimeStampDesc)
									{
										show = new(this, "Show the time stamp", Resources.strGlobalAppearanceTimeStampShowTitle, Resources
											.strGlobalAppearanceTimeStampShowDesc, true);

										fmt = new(this, "Format", Resources.strGlobalAppearanceTimeStampFmtTitle, Resources
											.strGlobalAppearanceTimeStampFmtDesc, "");
									}
								#endregion

								#region Delegates
								#endregion

								#region Events
									public override event PropertyChangedEventHandler? PropertyChanged;
								#endregion

								#region Constants
								#endregion

								#region Helper Types
								#endregion

								#region Members
									private readonly Platform.Prefs.Data.Item<bool> show;

									private readonly Platform.Prefs.Data.Item<string> fmt;
								#endregion

								#region Properties
									public Platform.Prefs.Data.Item<bool> Show => show;

									public Platform.Prefs.Data.Item<string> Fmt => fmt;
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
								#endregion
							}

							public class UserListPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public UserListPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Time Stamp", Resources
										.strGlobalAppearanceUserListLocTitle, Resources.strGlobalAppearanceUserListLocDesc)
									{
									}
								#endregion

								#region Delegates
								#endregion

								#region Events
									public override event PropertyChangedEventHandler? PropertyChanged;
								#endregion

								#region Constants
								#endregion

								#region Helper Types
									public enum Location : byte
									{
										[Util.Attr.LocalizedDesc(nameof(Resources.strGlobalAppearanceUserListLeftTitle), nameof(Resources
											.strGlobalAppearanceUserListLeftDesc), "Left", "Places the user list on the left side of" +
											" the client area.", typeof(Location))]
										left = 0,

										[Util.Attr.LocalizedDesc(nameof(Resources.strGlobalAppearanceUserListRightTitle), nameof(Resources
											.strGlobalAppearanceUserListRightDesc), "Left", "Places the user list on the right side " +
											"of the client area.", typeof(Location))]
										right = 1,
									}

									public enum WaysToShowModes
									{
										symbols,
										coloredDiscs,
										hidden,
									}
								#endregion

								#region Members
								#endregion

								#region Properties
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
								#endregion
							}
						#endregion

						#region Members
							private readonly ConfModePrefs confMode;

							private readonly FontPrefs font;

							private readonly TimeStampPrefs timestamp;
						#endregion

						#region Properties
							public ConfModePrefs ConfMode => confMode;

							public FontPrefs Font => font;

							public TimeStampPrefs TimeStamp => timestamp;
						#endregion

						#region Methods
						#endregion

						#region Event Handlers
						#endregion
					}

					public class GeneralPrefs : Platform.Prefs.Data.AbstractChildMgr
					{
						#region Constructors & Deconstructors
							public GeneralPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "General", Resources.strGlobalGeneralName,
								Resources.strGlobalGeneralToolTipText)
							{
								conn = new(this);
								conn.evtDirtyChanged += OnChildMgrDirtyChanged;
							}

							internal GeneralPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.GeneralDTO dto) :
								base(mgrParent, "General", Resources.strGlobalGeneralName, Resources
								.strGlobalGeneralToolTipText)
							{
								conn = new(this, dto.Conn);
								conn.evtDirtyChanged += OnChildMgrDirtyChanged;
							}
						#endregion

						#region Delegates
						#endregion

						#region Events
							public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
						#endregion

						#region Constants
						#endregion

						#region Helper Types
							public class ConnPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public ConnPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent,
										"Connection", Resources.strGlobalName, Resources
										.strGlobalNameToolTipText)
									{
										itemEnableIndent = new(this, "Enable Ident",
											Resources.strGlobalGeneralConnEnableIdentName, Resources
											.strGlobalGeneralConnEnableIdentToolTipText, true);
										itemEnableIndent.evtDirtyChanged += OnChildDirtyChanged;

										itemAutoReconnect = new(this, "Auto Reconnect", Resources
											.strGlobalGeneralConnAutoReconnectName, Resources
											.strGlobalGeneralConnAutoReconnectToolTipText, true);
										itemAutoReconnect.evtDirtyChanged += OnChildDirtyChanged;

										itemRejoinAfterKick = new(this, "Rejoin After Kick", Resources
											.strGlobalGeneralConnRejoinAfterKickName, Resources
											.strGlobalGeneralConnRejoinAfterKickToolTipText, true);
										itemRejoinAfterKick.evtDirtyChanged += OnChildDirtyChanged;

										itemCharEncoding = new(this, "Character Encoding", Resources
											.strGlobalGeneralConnCharEncodingName, Resources
											.strGlobalGeneralConnCharEncodingToolTipName, "UTF-8");
										itemCharEncoding.evtDirtyChanged += OnChildDirtyChanged;

										itemUnlimitedAttempts = new(this, "Unlimited Reconnection " +
											"Attempts", Resources.strGlobalGeneralConnUnlimitedAttemptsName, Resources
											.strGlobalGeneralConnUnlimitedAttemptsToolTipText, true);
										itemUnlimitedAttempts.evtDirtyChanged += OnChildDirtyChanged;

										itemMaxAttempts = new(this, "Maximum Attempts to Reconnect",
											Resources.strGlobalGeneralConnMaxAttemptsName, Resources
											.strGlobalGeneralConnMaxAttemptsToolTipText, 1, iMinVal: 1);
										itemMaxAttempts.evtDirtyChanged += OnChildDirtyChanged;

										itemDefQuitMsg = new(this, "Default Quit message", Resources
											.strGlobalGeneralConnDefQuitMsgName, Resources
											.strGlobalGeneralConnDefQuitMsgToolTipText, Resources.strDefQuitMsg);
										itemDefQuitMsg.evtDirtyChanged += OnChildDirtyChanged;
									}

									internal ConnPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.GeneralDTO
										.ConnDTO dto) : base(mgrParent, "Connection", Resources.strGlobalName,
										Resources.strGlobalNameToolTipText)
									{
										itemEnableIndent = new(this, "Enable Ident",
											Resources.strGlobalGeneralConnEnableIdentName, Resources
											.strGlobalGeneralConnEnableIdentToolTipText, true, dto.IsIndentEnabled);
										itemEnableIndent.evtDirtyChanged += OnChildDirtyChanged;

										itemAutoReconnect = new(this, "Auto Reconnect", Resources
											.strGlobalGeneralConnAutoReconnectName, Resources
											.strGlobalGeneralConnAutoReconnectToolTipText, true, dto
											.IsAutoReconnectEnabled);
										itemAutoReconnect.evtDirtyChanged += OnChildDirtyChanged;

										itemRejoinAfterKick = new(this, "Rejoin After Kick", Resources
											.strGlobalGeneralConnRejoinAfterKickName, Resources
											.strGlobalGeneralConnRejoinAfterKickToolTipText, true, dto
											.IsRejoinAfterKickEnabled);
										itemRejoinAfterKick.evtDirtyChanged += OnChildDirtyChanged;

										itemCharEncoding = new(this, "Character Encoding", Resources
											.strGlobalGeneralConnCharEncodingName, Resources
											.strGlobalGeneralConnCharEncodingToolTipName, "UTF-8", dto.CharEncoding);
										itemCharEncoding.evtDirtyChanged += OnChildDirtyChanged;

										itemUnlimitedAttempts = new(this, "Unlimited Reconnection " +
											"Attempts", Resources.strGlobalGeneralConnUnlimitedAttemptsName, Resources
											.strGlobalGeneralConnUnlimitedAttemptsToolTipText, true, dto
											.IsUnlimitedAttemptsOn);
										itemUnlimitedAttempts.evtDirtyChanged += OnChildDirtyChanged;

										itemMaxAttempts = new(this, "Maximum Attempts to Reconnect",
											Resources.strGlobalGeneralConnMaxAttemptsName, Resources
											.strGlobalGeneralConnMaxAttemptsToolTipText, 1, iMinVal: 1, iCurVal: dto
											.MaxAttempts);
										itemMaxAttempts.evtDirtyChanged += OnChildDirtyChanged;

										itemDefQuitMsg = new(this, "Default Quit message", Resources
											.strGlobalGeneralConnDefQuitMsgName, Resources
											.strGlobalGeneralConnDefQuitMsgToolTipText, Resources.strDefQuitMsg, dto.DefQuitMsg
											?? Resources.strDefQuitMsg);
										itemDefQuitMsg.evtDirtyChanged += OnChildDirtyChanged;
									}
								#endregion

								#region Delegates
								#endregion

								#region Events
									public override event System.ComponentModel.PropertyChangedEventHandler?
										PropertyChanged;
								#endregion

								#region Constants
								#endregion

								#region Helper Types
								#endregion

								#region Members
									public readonly Platform.Prefs.Data.Item<bool> itemEnableIndent;
									public readonly Platform.Prefs.Data.Item<bool> itemAutoReconnect;
									public readonly Platform.Prefs.Data.Item<bool> itemRejoinAfterKick;
									public readonly Platform.Prefs.Data.Item<string> itemCharEncoding;
									public readonly Platform.Prefs.Data.Item<bool> itemUnlimitedAttempts;
									public readonly Platform.Prefs.Data.IntItem itemMaxAttempts;
									public readonly Platform.Prefs.Data.Item<string> itemDefQuitMsg;
									// TODO: Add proxy once we know what we're doing with that.
								#endregion

								#region Properties
									public Platform.Prefs.Data.Item<bool> EnableIdent => itemEnableIndent;

									public Platform.Prefs.Data.Item<bool> AutoReconnect => itemAutoReconnect;

									public Platform.Prefs.Data.Item<bool> RejoinAfterKick => itemRejoinAfterKick;

									public Platform.Prefs.Data.Item<string> CharEncoding => itemCharEncoding;

									public Platform.Prefs.Data.Item<bool> UnlimitedAttempts => itemUnlimitedAttempts;

									public Platform.Prefs.Data.IntItem MaxAttempts => itemMaxAttempts;

									public Platform.Prefs.Data.Item<string> DefQuitMsg => itemDefQuitMsg;
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
									private void OnChildDirtyChanged(Platform.Prefs.Data.AbstractMgr mgrSender, bool
										bIsNowDirty)
									{
										if(bIsNowDirty)
											MakeDirty();
									}

									private void OnChildDirtyChanged(Platform.Prefs.Data.ItemBase mgrSender, bool
										bIsNowDirty)
									{
										if(bIsNowDirty)
											MakeDirty();
									}
								#endregion
							}
						#endregion

						#region Members
							public readonly ConnPrefs conn;
						#endregion

						#region Properties
							public ConnPrefs Conn => conn;
						#endregion

						#region Methods
						#endregion

						#region Event Handlers
							private void OnChildMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr mgrSender, bool bIsNowDirty)
							{
								if(bIsNowDirty)
									MakeDirty();
							}
						#endregion
					}

				#endregion

				#region Members
					public readonly GeneralPrefs general;
				#endregion

				#region Properties
					public GeneralPrefs General => general;
				#endregion

				#region Methods
				#endregion

				#region Event Handlers
					private void OnChildMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr mgrSender, bool bIsNowDirty)
					{
						if(bIsNowDirty)
							MakeDirty();
					}
				#endregion
			}
		#endregion

		#region Members
			public readonly GlobalPrefs global;


			public static readonly Prefs instance;
		#endregion

		#region Properties
			public GlobalPrefs Global => global;

			private readonly System.Collections.Generic.SortedDictionary<string, Platform.Prefs.Data
				.AbstractChildMgr> mapMgrsForProtolsByName = new();


			public static Prefs Instance => instance;


			public readonly System.IO.FileInfo fileOurSettings;
		#endregion

		#region Methods
			public void Save()
			{
				using(System.IO.FileStream stream = fileOurSettings.OpenWrite())
				{
					System.Text.Json.JsonSerializer.Serialize(stream, ToTupleList(), jsoStandard);
				}
			}
		#endregion

		#region Event Handlers
			private void OnChildMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr mgrSender, bool bIsNowDirty)
			{
				if(bIsNowDirty)
					MakeDirty();
			}
		#endregion
	}
}