// Ignore Spelling: Prefs evt

using System.ComponentModel;

namespace BestChat.IRC.Prefs.Data
{
	public class Prefs : Platform.Prefs.Data.AbstractChildMgr
	{
		#region Constructors & Deconstructors
			public Prefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "IRC", Rsrcs.strIRCRootTitle, Rsrcs.strIrcRootDesc)
			{
				global = new(this);
			}

			public Prefs(Platform.Prefs.Data.AbstractChildMgr mgrParent, DTO.IrcDTO dto) : base(mgrParent, "IRC", Rsrcs.strIRCRootTitle,
				Rsrcs.strIrcRootDesc)
			{
				global = new(this);
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
			public class GlobalPrefs : Platform.Prefs.Data.AbstractChildMgr
			{
				#region Constructors & Deconstructors
					public GlobalPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Global", Rsrcs.strGlobalTitle, Rsrcs
						.strGlobalDesc)
					{
						aliases = new(this);
					}

					public GlobalPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.IrcDTO.GlobalDTO dto) : base(mgrParent, "Global", Rsrcs
						.strGlobalTitle, Rsrcs.strGlobalDesc)
					{
						aliases = new(this, dto.Aliases);
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
					public class AliasesPrefs : Platform.Prefs.Data.AbstractChildMgr
					{
						#region Constructors & Deconstructors
							public AliasesPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Aliases", Rsrcs
								.strGlobalAliasesTitle, Rsrcs.strGlobalAliasesDesc) => mapEntriesSortedByName = [];

							public AliasesPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.IrcDTO.GlobalDTO.AliasDTO[]? dto) : base(mgrParent,
								"Aliases",
								Rsrcs.strGlobalAliasesTitle, Rsrcs.strGlobalAliasesDesc)
							{
								mapEntriesSortedByName = [];
								if(dto != null)
									foreach(DTO.IrcDTO.GlobalDTO.AliasDTO daliasCur in dto)
									{
										Alias aliasCur = new(daliasCur);
										mapEntriesSortedByName[aliasCur.Name] = aliasCur;

										aliasCur.evtDirtyChanged += OnChildAliasDirtyChanged;
										aliasCur.evtNameChanged += OnChildAliasNameChanged;
									}
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
							public class Alias : Platform.Data.Obj<Alias>
							{
								#region Constructors & Deconstructors
									public Alias(in string strName, in string strCmd)
									{
										this.strName = strName;
										this.strCmd = strCmd;
									}

									public Alias(in DTO.IrcDTO.GlobalDTO.AliasDTO dto)
									{
										strName = dto.Name;
										strCmd = dto.Cmd;
									}
								#endregion

								#region Delegates
								#endregion

								#region Events
									public override event PropertyChangedEventHandler? PropertyChanged;

									public event DFieldChanged<string> evtNameChanged;

									public event DFieldChanged<string> evtCmdChanged;
								#endregion

								#region Constants
								#endregion

								#region Helper Types
								#endregion

								#region Members
									private string strName;

									private string strCmd;
								#endregion

								#region Properties
									public string Name
									{
										get => strName;

										set
										{
											if(strName != value)
											{
												string strOldName = strName;

												strName = value;

												FireNameChanged(strOldName);

												MakeDirty();
											}
										}
									}

									public string Cmd
									{
										get => strCmd;

										set
										{
											if(strCmd != value)
											{
												string strOldCmd = strCmd;

												strCmd = value;

												FireCmdChanged(strOldCmd);

												MakeDirty();
											}
										}
									}
								#endregion

								#region Methods
									private void FirePropChanged(in string strPropName) => PropertyChanged?.Invoke(this, new(strPropName));

									private void FireNameChanged(in string strOldName)
									{
										FirePropChanged(nameof(Name));

										evtNameChanged?.Invoke(this, strOldName, strName);
									}

									private void FireCmdChanged(in string strOldCmd)
									{
										FirePropChanged(nameof(Cmd));

										evtCmdChanged?.Invoke(this, strOldCmd, strCmd);
									}
								#endregion

								#region Event Handlers
								#endregion
							}
						#endregion

						#region Members
							private readonly System.Collections.Generic.SortedDictionary<string, Alias> mapEntriesSortedByName;
						#endregion

						#region Properties
							public System.Collections.Generic.IReadOnlyCollection<Alias> Entries => mapEntriesSortedByName.Values;
						#endregion

						#region Methods
						#endregion

						#region Event Handlers
							private void OnChildAliasNameChanged(Alias aliasSender, string strOldVal, string strNewVal)
							{
								mapEntriesSortedByName.Remove(strOldVal);
								mapEntriesSortedByName[strNewVal] = aliasSender;
							}

							private void OnChildAliasDirtyChanged(Alias aliasSender, bool bIsNowDirty) => MakeDirty();
						#endregion
					}


				#endregion

				#region Members
					private readonly AliasesPrefs aliases;
				#endregion

				#region Properties
					public AliasesPrefs Aliases => aliases;
				#endregion

				#region Methods
				#endregion

				#region Event Handlers
				#endregion
			}

			public class NetworkPrefs : Platform.Prefs.Data.AbstractChildMgr
			{
				#region Constructors & Deconstructors
					public NetworkPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "IRC", Rsrcs.strGlobalAliasesTitle, Rsrcs
						.strGlobalAliasesDesc)
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
			public static Prefs? instance = null;

			private readonly GlobalPrefs global;
		#endregion

		#region Properties
			public static Prefs Instance = instance ?? throw new System.InvalidProgramException("Call BestChat.IRC.Prefs.Data.Prefs.Init" +
				" before trying to access an instance of Prefs.");

			public GlobalPrefs Global => global;
		#endregion

		#region Methods
			public static Prefs Init(Platform.Prefs.Data.AbstractMgr mgrParent) => instance != null ? throw new System
				.InvalidProgramException("Don't call BestChat.IRC.Prefs.Data.Prefs.Init more than once.") : (instance = new(mgrParent));
		#endregion

		#region Event Handlers
		#endregion
	}
}