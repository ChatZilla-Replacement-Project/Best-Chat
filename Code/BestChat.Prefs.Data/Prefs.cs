// Ignore Spelling: prefs

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