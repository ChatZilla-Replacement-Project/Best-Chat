// Ignore Spelling: prefs Conf dto Ungrouped

using System.Linq;

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

						appearance = new(this);
						appearance.evtDirtyChanged += OnChildMgrDirtyChanged;

						plugin = new(this);
						plugin.evtDirtyChanged += OnChildMgrDirtyChanged;
					}

					internal GlobalPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO dto) :
						base(mgrParent, "Global", Resources.strGlobalName, Resources
						.strGlobalNameToolTipText)
					{
						general = new(this, dto.General);
						general.evtDirtyChanged += OnChildMgrDirtyChanged;

						appearance = new(this);
						appearance.evtDirtyChanged += OnChildMgrDirtyChanged;

						plugin = new(this, dto.Plugins);
						plugin.evtDirtyChanged += OnChildMgrDirtyChanged;
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
								confMode.evtDirtyChanged += OnChildMgrDirtyChanged;

								font = new(this);
								font.evtDirtyChanged += OnChildMgrDirtyChanged;

								timestamp = new(this);
								timestamp.evtDirtyChanged += OnChildMgrDirtyChanged;

								userlist = new(this);
								userlist.evtDirtyChanged += OnChildMgrDirtyChanged;
							}

							internal AppearancePrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.AppearanceDTO dto) :
								base(mgrParent, "Appearance", Resources.strGlobalAppearancePageTitle, Resources.strGlobalAppearancePageDesc)
							{
								confMode = new(this, dto.ConfMode);
								confMode.evtDirtyChanged += OnChildMgrDirtyChanged;

								font = new(this, dto.Font);
								font.evtDirtyChanged += OnChildMgrDirtyChanged;

								timestamp = new(this, dto.TimeStamp);
								timestamp.evtDirtyChanged += OnChildMgrDirtyChanged;

								userlist = new(this, dto.UserList);
								userlist.evtDirtyChanged += OnChildMgrDirtyChanged;
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
							public class ConfModePrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public ConfModePrefs(in Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Conference Mode", Resources
										.strGlobalAppearanceConfModeTitle, Resources.strGlobalAppearanceConfModeDesc)
									{
										confModeEnabled = new(this, "Conference Mode Enabled?", Resources
											.strGlobalAppearanceConfModeEnabledTitle, Resources.strGlobalAppearanceConfModeEnabledDesc, false);
										confModeEnabled.evtDirtyChanged += OnChildNowDirty;

										userLimitBeforeTrigger = new(this, "User Limit Before Trigger", Resources
											.strGlobalAppearanceConfModeLimitTitle, Resources.strGlobalAppearanceConfModeLimitDesc, 150, iMinVal: 2);
										userLimitBeforeTrigger.evtDirtyChanged += OnChildNowDirty;

										actionsCollapsed = new(this, "Collapse Actions When Collapsing Messages", Resources
											.strGlobalAppearanceConfModeCollapseActionsTitle, Resources.strGlobalAppearanceConfModeCollapseActionsDesc,
											false);
										actionsCollapsed.evtDirtyChanged += OnChildNowDirty;

										msgsCollapsed = new(this, "Collapse Messages?", Resources
											.strGlobalAppearanceConfModeCollapseMsgsTitle, Resources.strGlobalAppearanceConfModeCollapseMsgsDesc, false);
										msgsCollapsed.evtDirtyChanged += OnChildNowDirty;
									}

									internal ConfModePrefs(in Platform.Prefs.Data.AbstractMgr mgrParent, in DTO.PrefsDTO.GlobalDTO.AppearanceDTO.ConfModeDTO
										dto) : base(mgrParent, "Conference Mode", Resources
										.strGlobalAppearanceConfModeTitle, Resources.strGlobalAppearanceConfModeDesc)
									{
										confModeEnabled = new(this, "Conference Mode Enabled?", Resources
											.strGlobalAppearanceConfModeEnabledTitle, Resources.strGlobalAppearanceConfModeEnabledDesc, false, dto
											.ConfModeEnabled);
										confModeEnabled.evtDirtyChanged += OnChildNowDirty;

										userLimitBeforeTrigger = new(this, "User Limit Before Trigger", Resources
											.strGlobalAppearanceConfModeLimitTitle, Resources.strGlobalAppearanceConfModeLimitDesc, 150, iMinVal: 2, iCurVal:
											dto.UserLimitBeforeTrigger);
										userLimitBeforeTrigger.evtDirtyChanged += OnChildNowDirty;

										actionsCollapsed = new(this, "Collapse Actions When Collapsing Messages", Resources
											.strGlobalAppearanceConfModeCollapseActionsTitle, Resources.strGlobalAppearanceConfModeCollapseActionsDesc,
											false, dto.ActionsCollapsed);
										actionsCollapsed.evtDirtyChanged += OnChildNowDirty;

										msgsCollapsed = new(this, "Collapse Messages?", Resources
											.strGlobalAppearanceConfModeCollapseMsgsTitle, Resources.strGlobalAppearanceConfModeCollapseMsgsDesc, false, dto
											.MsgsCollapsed);
										msgsCollapsed.evtDirtyChanged += OnChildNowDirty;
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
									private void OnChildNowDirty(Platform.Prefs.Data.ItemBase objSender, bool bIsNowDirty) => MakeDirty();
								#endregion
							}

							public class FontPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public FontPrefs(in Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Font", Resources
										.strGlobalAppearanceFontTitle, Resources.strGlobalAppearanceFontDesc)
									{
										normalFamily = new(this, "Normal Family", Resources.strGlobalAppearanceFontNormalFamilyTitle,
											Resources.strGlobalAppearanceFontNormalFamilyDesc, "Times New Roman");
										normalFamily.evtDirtyChanged += OnChidItemDirtyChanged;

										fixedWidthFamily = new(this, "Fixed Width Family", Resources
											.strGlobalAppearanceFontFixedWidthFamilyTitle, Resources.strGlobalAppearanceFontFixedWidthFamilyDesc,
											"Courier New");
										fixedWidthFamily.evtDirtyChanged += OnChidItemDirtyChanged;

										fontsize = new(this, "Font Size", Resources.strGlobalAppearanceFontSizeTitle, Resources
											.strGlobalAppearanceFontSizeDesc, 12, iMaxVal: 50, iMinVal: 8);
										fontsize.evtDirtyChanged += OnChidItemDirtyChanged;

										weight = new(this, "Font Weight", Resources.strGlobalAppearanceFontWeightTitle, Resources
											.strGlobalAppearanceFontWeightTitle, System.Windows.FontWeights.Normal);
										weight.evtDirtyChanged += OnChidItemDirtyChanged;
									}

									internal FontPrefs(in Platform.Prefs.Data.AbstractMgr mgrParent, in DTO.PrefsDTO.GlobalDTO.AppearanceDTO.FontDTO dto) :
										base(mgrParent, "Font", Resources
										.strGlobalAppearanceFontTitle, Resources.strGlobalAppearanceFontDesc)
									{
										normalFamily = new(this, "Normal Family", Resources.strGlobalAppearanceFontNormalFamilyTitle,
											Resources.strGlobalAppearanceFontNormalFamilyDesc, "Times New Roman", dto.NormalFamily);
										normalFamily.evtDirtyChanged += OnChidItemDirtyChanged;

										fixedWidthFamily = new(this, "Fixed Width Family", Resources
											.strGlobalAppearanceFontFixedWidthFamilyTitle, Resources.strGlobalAppearanceFontFixedWidthFamilyDesc,
											"Courier New", dto.FixedWidthFamily);
										fixedWidthFamily.evtDirtyChanged += OnChidItemDirtyChanged;

										fontsize = new(this, "Font Size", Resources.strGlobalAppearanceFontSizeTitle, Resources
											.strGlobalAppearanceFontSizeDesc, 12, dto.FontSize, 8, 50);
										fontsize.evtDirtyChanged += OnChidItemDirtyChanged;

										weight = new(this, "Font Weight", Resources.strGlobalAppearanceFontWeightTitle, Resources
											.strGlobalAppearanceFontWeightTitle, System.Windows.FontWeights.Normal, dto.Weight ?? System.Windows.FontWeights
											.Normal);
										weight.evtDirtyChanged += OnChidItemDirtyChanged;
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
								#endregion

								#region Members
									private readonly Platform.Prefs.Data.Item<string> normalFamily;

									private readonly Platform.Prefs.Data.Item<string> fixedWidthFamily;

									private readonly Platform.Prefs.Data.IntItem fontsize;

									private readonly Platform.Prefs.Data.Item<System.Windows.FontWeight> weight;
								#endregion

								#region Properties
									private Platform.Prefs.Data.Item<string> NormalFamily => normalFamily;

									private Platform.Prefs.Data.Item<string> FixedWidthFamily => fixedWidthFamily;

									private Platform.Prefs.Data.IntItem FontSize => fontsize;

									private Platform.Prefs.Data.Item<System.Windows.FontWeight> FontWeight => weight;
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
									private void OnChidItemDirtyChanged(Platform.Prefs.Data.ItemBase objSender, bool bIsNowDirty) => MakeDirty();
								#endregion
							}

							public class TimeStampPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public TimeStampPrefs(in Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Time Stamp", Resources
										.strGlobalAppearanceTimeStampTitle, Resources.strGlobalAppearanceTimeStampDesc)
									{
										show = new(this, "Show the time stamp", Resources.strGlobalAppearanceTimeStampShowTitle, Resources
											.strGlobalAppearanceTimeStampShowDesc, true);
										show.evtDirtyChanged += OnItemDirtyChanged;

										fmt = new(this, "Format", Resources.strGlobalAppearanceTimeStampFmtTitle, Resources
											.strGlobalAppearanceTimeStampFmtDesc, "G");
										fmt.evtDirtyChanged += OnItemDirtyChanged;
									}

									internal TimeStampPrefs(in Platform.Prefs.Data.AbstractMgr mgrParent, in DTO.PrefsDTO.GlobalDTO.AppearanceDTO.TimeStampDTO
										dto) : base(mgrParent, "Time Stamp", Resources.strGlobalAppearanceTimeStampTitle, Resources
										.strGlobalAppearanceTimeStampDesc)
									{
										show = new(this, "Show the time stamp", Resources.strGlobalAppearanceTimeStampShowTitle, Resources
											.strGlobalAppearanceTimeStampShowDesc, true, dto.Show);
										show.evtDirtyChanged += OnItemDirtyChanged;

										fmt = new(this, "Format", Resources.strGlobalAppearanceTimeStampFmtTitle, Resources
											.strGlobalAppearanceTimeStampFmtDesc, "G", dto.Fmt);
										fmt.evtDirtyChanged += OnItemDirtyChanged;
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
									private void OnItemDirtyChanged(Platform.Prefs.Data.ItemBase objSender, bool bIsNowDirty) => MakeDirty();
								#endregion
							}

							public class UserListPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public UserListPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Time Stamp", Resources
										.strGlobalAppearanceUserListLocTitle, Resources.strGlobalAppearanceUserListLocDesc)
									{
										location = new(this, "Location", Resources.strGlobalAppearanceUserListLocTitle, Resources
											.strGlobalAppearanceUserListLocTitle, Locations.left);
										location.evtDirtyChanged += OnItemDirtyChanged;

										howToShowModes = new(this, "Ways to show modes", Resources
											.strGlobalAppearanceUserListWaysToShowModesTitle, Resources.strGlobalAppearanceUserListWaysToShowModesDesc,
											WaysToShowModes.symbols);
										howToShowModes.evtDirtyChanged += OnItemDirtyChanged;

										sortByMode = new(this, "Sort by mode", Resources.strGlobalAppearanceUserListSortByModeTitle, Resources
											.strGlobalAppearanceUserListSortByModeDesc, true);
										sortByMode.evtDirtyChanged += OnItemDirtyChanged;
									}

									internal UserListPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.AppearanceDTO.UserListDTO dto) :
										base(mgrParent, "Time Stamp", Resources.strGlobalAppearanceUserListLocTitle, Resources
										.strGlobalAppearanceUserListLocDesc)
									{
										location = new(this, "Location", Resources.strGlobalAppearanceUserListLocTitle, Resources
											.strGlobalAppearanceUserListLocTitle, Locations.left, dto.Loc);
										location.evtDirtyChanged += OnItemDirtyChanged;

										howToShowModes = new(this, "Ways to show modes", Resources
											.strGlobalAppearanceUserListWaysToShowModesTitle, Resources.strGlobalAppearanceUserListWaysToShowModesDesc,
											WaysToShowModes.symbols, dto.HowToShowModes);
										howToShowModes.evtDirtyChanged += OnItemDirtyChanged;

										sortByMode = new(this, "Sort by mode", Resources.strGlobalAppearanceUserListSortByModeTitle, Resources
											.strGlobalAppearanceUserListSortByModeDesc, true, dto.SortByMode);
										sortByMode.evtDirtyChanged += OnItemDirtyChanged;
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
									public enum Locations : byte
									{
										[Util.Attr.LocalizedDesc(nameof(Resources.strGlobalAppearanceUserListLeftTitle), "Left", nameof(Resources
											.strGlobalAppearanceUserListLeftDesc), "Places the user list on the left side of" +
											" the client area.", typeof(Locations))]
										left = 0,

										[Util.Attr.LocalizedDesc(nameof(Resources.strGlobalAppearanceUserListRightTitle), "Left", nameof(Resources
											.strGlobalAppearanceUserListRightDesc), "Places the user list on the right side " +
											"of the client area.", typeof(Locations))]
										right = 1,
									}

									public enum WaysToShowModes
									{
										[Util.Attr.LocalizedDesc(nameof(Resources.strGlobalAppearanceUserListWaysToShowModesSymbolsTitle), "Show " +
											"Symbols", nameof(Resources.strGlobalAppearanceUserListWaysToShowModesSymbolsDesc), "If you select " +
											"this, Best Chat will show op, half op, and voice with traditional symbols.", typeof(WaysToShowModes))]
										symbols,

										[Util.Attr.LocalizedDesc(nameof(Resources.strGlobalAppearanceUserLIstWaysToShowModesColoredDiscsTitle), 
											"Colored Discs", nameof(Resources.strGlobalAppearanceUserLIstWaysToShowModesColoredDiscsDesc),
											"If you select this, colored discs will be used to indicate op/half op status and voice.",
											typeof(WaysToShowModes))]
										coloredDiscs,
										hidden,
									}
								#endregion

								#region Members
									private readonly Platform.Prefs.Data.Item<Locations> location;

									private readonly Platform.Prefs.Data.Item<WaysToShowModes> howToShowModes;

									private readonly Platform.Prefs.Data.Item<bool> sortByMode;
								#endregion

								#region Properties
									public Platform.Prefs.Data.Item<Locations> Loc => location;

									public Platform.Prefs.Data.Item<WaysToShowModes> HowToShowModes => howToShowModes;

									public Platform.Prefs.Data.Item<bool> SortByMode;
								#endregion

								#region Methods
									private void FirePropChanged(string strWhichProp) => PropertyChanged?.Invoke(this, new(strWhichProp));
								#endregion

								#region Event Handlers
									private void OnItemDirtyChanged(Platform.Prefs.Data.ItemBase objSender, bool bIsNowDirty) => MakeDirty();
								#endregion
							}
						#endregion

						#region Members
							private readonly ConfModePrefs confMode;

							private readonly FontPrefs font;

							private readonly TimeStampPrefs timestamp;

							private readonly UserListPrefs userlist;
						#endregion

						#region Properties
							public ConfModePrefs ConfMode => confMode;

							public FontPrefs Font => font;

							public TimeStampPrefs TimeStamp => timestamp;

							public UserListPrefs UserList => userlist;
						#endregion

						#region Methods
						#endregion

						#region Event Handlers
							private void OnChildMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr objSender, bool bIsNowDirty) => MakeDirty();
						#endregion
					}

					public class PluginPrefs : Platform.Prefs.Data.AbstractChildMgr
					{
						#region Constructors & Deconstructors
							public PluginPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Plugins", Resources
								.strGlobalPluginsTitle, Resources.strGlobalPluginsDesc)
							{
								ext = new(this);
								ext.evtDirtyChanged += OnChidMgrDirtyChanged;
							}

							internal PluginPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.PluginsDTO dto) : base(mgrParent, 
								"Plugins", Resources.strGlobalPluginsTitle, Resources.strGlobalPluginsDesc)
							{
								ext = new(this, dto.Ext);
								ext.evtDirtyChanged += OnChidMgrDirtyChanged;
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
							public class ExtPrefs : Platform.Prefs.Data.AbstractChildMgr
							{
								#region Constructors & Deconstructors
									public ExtPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, System.Collections.Generic.IEnumerable<ScriptEntry>? scripts =
										null, System.Collections.Generic.IEnumerable<ProgramEntry>? programs = null) : base(mgrParent, "External",
										Resources.strGlobalPluginsExtTitle, Resources.strGlobalPluginsDesc)
									{
										whereToLook = new(this);
										whereToLook.evtDirtyChanged += OnChildMgrDirtyChanged;

										howToRunScripts = new(this);
										howToRunScripts.evtDirtyChanged += OnChildMgrDirtyChanged;

										if(scripts != null)
										{
											this.scripts.AddRange(scripts);
											foreach(ScriptEntry curScript in scripts)
												curScript.evtDirtyChanged += OnScriptDirtyChanged;
										}

										if(programs != null)
										{
											this.programs.AddRange(programs);
											foreach(ProgramEntry curProgram in programs)
												curProgram.evtDirtyChanged += OnProgramDirtyChanged;
										}
									}

									internal ExtPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.PluginsDTO.ExtDTO dto) : base(mgrParent,
										"External", Resources.strGlobalPluginsExtTitle, Resources.strGlobalPluginsDesc)
									{
										whereToLook = new(this, dto.WhereToLook);
										whereToLook.evtDirtyChanged += OnChildMgrDirtyChanged;

										howToRunScripts = new(this);
										howToRunScripts.evtDirtyChanged += OnChildMgrDirtyChanged;

										if(dto.Scripts is System.Collections.Generic.IEnumerable<DTO.PrefsDTO.GlobalDTO.PluginsDTO.ExtDTO.ScriptEntryDTO>
											scripts)
										{
											this.scripts.AddRange(scripts.Select(curScript => new ScriptEntry(curScript)));
											foreach(ScriptEntry curScript in this.scripts)
												curScript.evtDirtyChanged += OnScriptDirtyChanged;
										}

										if(dto.Programs is System.Collections.Generic.IEnumerable<DTO.PrefsDTO.GlobalDTO.PluginsDTO.ExtDTO.ProgramEntryDTO>
											programs)
										{
											this.programs.AddRange(dto.Programs.Select(curProgram => new ProgramEntry(curProgram)));
											foreach(ProgramEntry curProgram in this.programs)
												curProgram.evtDirtyChanged += OnProgramDirtyChanged;
										}
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
									public class WhereToLookPrefs : Platform.Prefs.Data.AbstractChildMgr
									{
										#region Constructors & Deconstructors
											public WhereToLookPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Where To Look", Resources
												.strGlobalPluginsExtWhereToLookTitle, Resources.strGlobalPluginsExtWhereToLookDesc)
											{
												llistPaths = [];

												includeSysPath = new(this, "Include Your System Path Environment Variable in the Search",
													Resources.strGlobalPluginsExtWhereToLookIncludeSysPathTitle, Resources
													.strGlobalPluginsExtWhereToLookIncludeSysPathDesc, true);
												includeSysPath.evtDirtyChanged += OnItemDirtyChanged;
											}

											internal WhereToLookPrefs(Platform.Prefs.Data.AbstractMgr mgrParent, DTO.PrefsDTO.GlobalDTO.PluginsDTO.ExtDTO
												.WhereToLookDTO dto) : base(mgrParent, "Where To Look", Resources.strGlobalPluginsExtWhereToLookTitle,
													Resources.strGlobalPluginsExtWhereToLookDesc)
											{
												llistPaths = new(dto.Paths is string[] paths ? paths : []);

												includeSysPath = new(this, "Include Your System Path Environment Variable in the Search",
													Resources.strGlobalPluginsExtWhereToLookIncludeSysPathTitle, Resources
													.strGlobalPluginsExtWhereToLookIncludeSysPathDesc, dto.IncludeSysPaths);
												includeSysPath.evtDirtyChanged += OnItemDirtyChanged;
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
										#endregion

										#region Members
											private readonly System.Collections.Generic.LinkedList<string> llistPaths;

											private readonly Platform.Prefs.Data.Item<bool> includeSysPath;
										#endregion

										#region Properties
											public System.Collections.Generic.IEnumerable<string> Paths => llistPaths;

											private Platform.Prefs.Data.Item<bool> IncludeSysPath => includeSysPath;
										#endregion

										#region Methods
										#endregion

										#region Event Handlers
											private void OnItemDirtyChanged(Platform.Prefs.Data.ItemBase objSender, bool bIsNowDirty) => MakeDirty();
										#endregion
									}

									public class HowToRunScriptsPrefs : Platform.Prefs.Data.AbstractChildMgr
									{
										#region Constructors & Deconstructors
											public HowToRunScriptsPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "How to run them",
												Resources.strGlobalPluginsHowToRunThemTitle, Resources.strGlobalPluginsHowToRunThemDesc)
											{
												groupedByWhatRunsThem = new(this);

												ungrouped = new (this);
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
											public class GroupedByWhatRunsThemPrefs : Platform.Prefs.Data.AbstractChildMgr
											{
												#region Constructors & Deconstructors
													public GroupedByWhatRunsThemPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Grouped by what" +
														" runs them", Resources.strGlobalPluginsHowToRunThemGroupedByWhatRunsThemTitle, Resources
														.strGlobalPluginsHowToRunThemGroupedByWhatRunsThemDesc)
													{
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

											public class UngroupedPrefs : Platform.Prefs.Data.AbstractChildMgr
											{
												#region Constructors & Deconstructors
													public UngroupedPrefs(Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "Ungrouped",
														Resources.strGlobalPluginsHowToRunThemTitle, Resources.strGlobalPluginsHowToRunThemDesc)
													{
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
											private readonly GroupedByWhatRunsThemPrefs groupedByWhatRunsThem;

											private readonly UngroupedPrefs ungrouped;
										#endregion

										#region Properties
											public GroupedByWhatRunsThemPrefs GroupedByWhatRunsThem => groupedByWhatRunsThem;

											public UngroupedPrefs Ungrouped => ungrouped;
										#endregion

										#region Methods
										#endregion

										#region Event Handlers
											private void OnChildMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr objSender, bool bIsNowDirty) => MakeDirty();
										#endregion
									}

									public class ScriptEntry : Platform.Data.Obj<ScriptEntry>
									{
										#region Constructors & Deconstructors
											public ScriptEntry(in string strFileNameExtOrMask, in System.IO.FileInfo? fileProgramNeeded, in string
												strParamsToPass, in bool bEnabled)
											{
												this.strFileNameExtOrMask = strFileNameExtOrMask;
												this.fileProgramNeeded = fileProgramNeeded;
												this.strParamsToPass = strParamsToPass;
												this.bEnabled = bEnabled;
											}

											internal ScriptEntry(in DTO.PrefsDTO.GlobalDTO.PluginsDTO.ExtDTO.ScriptEntryDTO dto)
											{
												strFileNameExtOrMask = dto.FileNameExtOrMask;
												fileProgramNeeded = dto.ProgramNeeded is string strProgramNeeded ? new(strProgramNeeded) : null;
												strParamsToPass = dto.ParamsToPass;
												bEnabled = dto.Enabled;
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
										#endregion

										#region Members
											private string strFileNameExtOrMask;

											private System.IO.FileInfo? fileProgramNeeded;

											private string strParamsToPass;

											private bool bEnabled;
										#endregion

										#region Properties
											public string FileNameExtOrMask
											{
												get => strFileNameExtOrMask;

												set
												{
													if(strFileNameExtOrMask != value)
													{
														strFileNameExtOrMask = value;

														FirePropChanged(nameof(FileNameExtOrMask));

														MakeDirty();
													}
												}
											}

											public System.IO.FileInfo? ProgramNeeded
											{
												get => fileProgramNeeded;

												set
												{
													if(fileProgramNeeded != value)
													{
														fileProgramNeeded = value;

														FirePropChanged(nameof(ProgramNeeded));

														MakeDirty();
													}
												}
											}

											public string ParamsToPass
											{
												get => strParamsToPass;

												set
												{
													if(strParamsToPass != value)
													{
														strParamsToPass = value;

														FirePropChanged(nameof(ParamsToPass));

														MakeDirty();
													}
												}
											}

											public bool Enabled
											{
												get => bEnabled;

												set
												{
													if(bEnabled != value)
													{
														bEnabled = value;

														FirePropChanged(nameof(Enabled));

														MakeDirty();
													}
												}
											}
										#endregion

										#region Methods
											private void FirePropChanged(string strNameOfChangedProp) => PropertyChanged?.Invoke(this, new
												(strNameOfChangedProp));
										#endregion

										#region Event Handlers
										#endregion
									}

									public class ProgramEntry : Platform.Data.Obj<ProgramEntry>
									{
										#region Constructors & Deconstructors
											public ProgramEntry(in string strName, in System.IO.FileInfo fileProgram, in string strParamsToPass, in bool
												bEnabled)
											{
												this.strName = strName;
												this.fileProgram = fileProgram;
												this.strParamsToPass = strParamsToPass;
												this.bEnabled = bEnabled;
											}

											internal ProgramEntry(in DTO.PrefsDTO.GlobalDTO.PluginsDTO.ExtDTO.ProgramEntryDTO dto)
											{
												strName = dto.Name;
												fileProgram = new(dto.Program);
												strParamsToPass = dto.ParamsToPass;
												bEnabled = dto.Enabled;
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
										#endregion

										#region Members
											private string strName;

											private System.IO.FileInfo fileProgram;

											private string strParamsToPass;

											private bool bEnabled;
										#endregion

										#region Properties
											public string Name
											{
												get => strName;

												set
												{
													if(strName != value)
													{
														strName = value;

														FirePropChanged(nameof(Name));

														MakeDirty();
													}
											}
											}

											public System.IO.FileInfo Program
											{
												get => fileProgram;

												set
												{
													if(fileProgram != value)
													{
														fileProgram = value;

														FirePropChanged(nameof(Program));

														MakeDirty();
													}
												}
											}

											public string ParamsToPass
											{
												get => strParamsToPass;

												set
												{
													if(strParamsToPass != value)
													{
														strParamsToPass = value;

														FirePropChanged(nameof(ParamsToPass));

														MakeDirty();
													}
												}
											}

											public bool Enabled
											{
												get => bEnabled;

												set
												{
													if(bEnabled != value)
													{
														bEnabled = value;

														FirePropChanged(nameof(Enabled));

														MakeDirty();
													}
												}
											}
										#endregion

										#region Methods
										#endregion

										#region Event Handlers
											private void FirePropChanged(string strNameOfChangedProp) => PropertyChanged?.Invoke(this, new
												(strNameOfChangedProp));
										#endregion
									}
								#endregion

								#region Members
									private readonly WhereToLookPrefs whereToLook;

									private readonly HowToRunScriptsPrefs howToRunScripts;

									private readonly System.Collections.Generic.List<ScriptEntry> scripts = [];

									private readonly System.Collections.Generic.List<ProgramEntry> programs = [];
								#endregion

								#region Properties
									public WhereToLookPrefs WhereToLook => whereToLook;

									public HowToRunScriptsPrefs HowToRunThem => howToRunScripts;
								#endregion

								#region Methods
								#endregion

								#region Event Handlers
									private void OnChildMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr objSender, bool bIsNowDirty) => MakeDirty();

									private void OnScriptDirtyChanged(Platform.Data.Obj<ScriptEntry> sender, bool bIsNowDirty) => MakeDirty();

									private void OnProgramDirtyChanged(Platform.Data.Obj<ProgramEntry> sender, bool bIsNowDirty) => MakeDirty();
								#endregion
							}
						#endregion

						#region Members
							private readonly ExtPrefs ext;
						#endregion

						#region Properties
							public ExtPrefs Ext => ext;
						#endregion

						#region Methods
						#endregion

						#region Event Handlers
							private void OnChidMgrDirtyChanged(Platform.Prefs.Data.AbstractMgr objSender, bool bIsNowDirty) => MakeDirty();
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
					private readonly AppearancePrefs appearance;

					private readonly PluginPrefs plugin;

					public readonly GeneralPrefs general;
				#endregion

				#region Properties
					public AppearancePrefs Appearance => appearance;

					public GeneralPrefs General => general;

					public PluginPrefs Plugin => plugin;
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