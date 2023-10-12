// Ignore Spelling: prefs

namespace BestChat.Prefs.Data
{
	public class Prefs : Platform.Prefs.Mgr
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
			public class GlobalPrefs : Platform.Prefs.ChildMgr
			{
				#region Constructors & Deconstructors
					public GlobalPrefs(Platform.Prefs.Mgr mgrParent) : base(mgrParent, "Global",
						Resources.strGlobalName, Resources.strGlobalNameToolTipText)
					{
						general = new(this);
						general.evtDirtyChanged += OnChildMgrDirtyChanged;
					}

					internal GlobalPrefs(Platform.Prefs.Mgr mgrParent, DTO.PrefsDTO.GlobalDTO dto) :
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
					public class GeneralPrefs : Platform.Prefs.ChildMgr
					{
						#region Constructors & Deconstructors
							public GeneralPrefs(Platform.Prefs.Mgr mgrParent) : base(mgrParent, "General", Resources.strGlobalGeneralName,
								Resources.strGlobalGeneralToolTipText)
							{
								conn = new(this);
								conn.evtDirtyChanged += OnChildMgrDirtyChanged;
							}

							internal GeneralPrefs(Platform.Prefs.Mgr mgrParent, DTO.PrefsDTO.GlobalDTO.GeneralDTO dto) :
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
							public class ConnPrefs : Platform.Prefs.ChildMgr
							{
								#region Constructors & Deconstructors
									public ConnPrefs(Platform.Prefs.Mgr mgrParent) : base(mgrParent,
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

									internal ConnPrefs(Platform.Prefs.Mgr mgrParent, DTO.PrefsDTO.GlobalDTO.GeneralDTO
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
											.strGlobalGeneralConnMaxAttemptsToolTipText, 1, iMinVal: 1, iValCur: dto
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
									public readonly Platform.Prefs.Item<bool> itemEnableIndent;
									public readonly Platform.Prefs.Item<bool> itemAutoReconnect;
									public readonly Platform.Prefs.Item<bool> itemRejoinAfterKick;
									public readonly Platform.Prefs.Item<string> itemCharEncoding;
									public readonly Platform.Prefs.Item<bool> itemUnlimitedAttempts;
									public readonly Platform.Prefs.IntItem itemMaxAttempts;
									public readonly Platform.Prefs.Item<string> itemDefQuitMsg;
									// TODO: Add proxy once we know what we're doing with that.
								#endregion

								#region Properties
									public Platform.Prefs.Item<bool> EnableIdent => itemEnableIndent;

									public Platform.Prefs.Item<bool> AutoReconnect => itemAutoReconnect;

									public Platform.Prefs.Item<bool> RejoinAfterKick => itemRejoinAfterKick;

									public Platform.Prefs.Item<string> CharEncoding => itemCharEncoding;

									public Platform.Prefs.Item<bool> UnlimitedAttempts => itemUnlimitedAttempts;

									public Platform.Prefs.IntItem MaxAttempts => itemMaxAttempts;

									public Platform.Prefs.Item<string> DefQuitMsg => itemDefQuitMsg;
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
									private void OnChildDirtyChanged(Platform.Prefs.Mgr mgrSender, bool bIsNowDirty)
									{
										if(bIsNowDirty)
											MakeDirty();
									}

									private void OnChildDirtyChanged(Platform.Prefs.Item<bool> mgrSender, bool
										bIsNowDirty)
									{
										if(bIsNowDirty)
											MakeDirty();
									}

									private void OnChildDirtyChanged(Platform.Prefs.Item<string> mgrSender, bool
										bIsNowDirty)
									{
										if(bIsNowDirty)
											MakeDirty();
									}

									private void OnChildDirtyChanged(Platform.Prefs.Item<int> mgrSender, bool
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
							private void OnChildMgrDirtyChanged(Platform.Prefs.Mgr mgrSender, bool bIsNowDirty)
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
					private void OnChildMgrDirtyChanged(Platform.Prefs.Mgr mgrSender, bool bIsNowDirty)
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
			private void OnChildMgrDirtyChanged(Platform.Prefs.Mgr mgrSender, bool bIsNowDirty)
			{
				if(bIsNowDirty)
					MakeDirty();
			}
		#endregion
	}
}