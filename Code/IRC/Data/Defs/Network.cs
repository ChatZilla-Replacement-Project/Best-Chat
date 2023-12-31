﻿// Ignore Spelling: Defs evt IRC enet eunet Serv dnetwork

using System.Linq;

namespace BestChat.IRC.Data.Defs
{
	public abstract class Network : Platform.Data.Obj<Network>, IDataDef<Network>
	{
		#region Constructors & Deconstructors
			public Network()
			{
				strName = string.Empty;
				uriHomepage = null;
			}

			public Network(string strName, System.Uri uriHomepage, params ServerInfo[] allServers)
			{
				this.strName = strName;
				this.uriHomepage = uriHomepage;

				foreach(ServerInfo serverCur in allServers)
					mapServers[serverCur.Domain] = serverCur;
			}

			protected Network(in Network netCopyThis)
			{
				strName = netCopyThis.Name;
				uriHomepage = netCopyThis.Homepage;
				foreach(ServerInfo serverCur in netCopyThis.AllUnsortedServers)
					mapServers[serverCur.Domain] = serverCur;
				nickServ = netCopyThis.NickServ;
				chanServ = netCopyThis.ChanServ;
				bHasAlis = netCopyThis.HasAlis;
				bHasQ = netCopyThis.HasQ;
			}

			public Network(in DTO.NetworkDTO dnetworkUs)
			{
				strName = dnetworkUs.Name;
				uriHomepage = dnetworkUs.Homepage;
				foreach(DTO.ServerInfoDTO dserverCur in dnetworkUs.Servers)
					mapServers[dserverCur.Domain] = new(this, dserverCur);
				nickServ = dnetworkUs.NickServ;
				chanServ = dnetworkUs.ChanServ;
				bHasAlis = dnetworkUs.HasAlis;
				bHasQ = dnetworkUs.HasQ;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event DFieldChanged<string>? evtNameChanged;
			public event DFieldChanged<System.Uri?>? evtHomepageChanged;
			public event DCollectionFieldChanged<System.Collections.Generic.IReadOnlyDictionary<string, ServerInfo>>?
				evtServersSortedByNameChanged;
			public event DCollectionFieldChanged<System.Collections.Generic.IEnumerable<string>>?
				evtEnabledServerDomainsInSearchOrder;
			public event DFieldChanged<NickServOpts?>? evtNickServChanged;
			public event DFieldChanged<ChanServOpts?>? evtChanServChanged;
			public event DFieldChanged<bool?>? evtHasAlisChanged;
			public event DFieldChanged<bool?>? evtHasQChanged;

			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private string strName;

			private System.Uri? uriHomepage;


			private readonly System.Collections.Generic.Dictionary<string, ServerInfo> mapServers = new
				();

			private NickServOpts? nickServ = null;

			private ChanServOpts? chanServ = null;

			private bool? bHasAlis = null;

			private bool? bHasQ = null;
		#endregion

		#region Properties
			public string Name
			{
				get => strName;

				protected set
				{
					if(GetType() == typeof(Network))
						throw new System.InvalidProgramException($"The names of predefined networks, like {Name
							}, is readonly.");

					if(strName != value)
					{
						string strOldValue = strName;

						strName = value;

						MakeDirty();

						FireNameChanged(strOldValue);
					}
				}
			}

			public System.Uri? Homepage
			{
				get => uriHomepage;

				protected set
				{
					if(GetType() == typeof(Network))
						throw new System.InvalidProgramException($"The homepage of predefined networks, like {Name
							}, is readonly.");

					if(uriHomepage != value)
					{
						System.Uri? uriOldHomepage = uriHomepage;

						uriHomepage = value;

						MakeDirty();

						FireHomepageChanged(uriOldHomepage);
					}
				}
			}

			public System.Collections.Generic.IEnumerable<ServerInfo> ServersSortedByName =>
				from ServerInfo curServer in mapServers.Values
				orderby curServer.Domain
				select curServer;

			public System.Collections.Generic.IEnumerable<string> EnabledServerDomainsInSearchOrder => 
				from ServerInfo curServer in mapServers.Values
				where curServer.IsEnabled
				select curServer.Domain;

			public System.Collections.Generic.IEnumerable<ServerInfo> EnabledServersInSearchOrder => 
				from ServerInfo curServer in mapServers.Values
				where curServer.IsEnabled
				select curServer;

			public System.Collections.Generic.IReadOnlyCollection<ServerInfo> AllUnsortedServers => mapServers
				.Values;

			public string EnabledServerDomainsInSearchOrderAsText => string.Join(" ⪢ ",
				EnabledServerDomainsInSearchOrder);

			public NickServOpts? NickServ
			{
				get => nickServ;

				protected set
				{
					if(nickServ != value)
					{
						NickServOpts? oldNickServ = nickServ;

						nickServ = value;

						MakeDirty();

						FireNickServChanged(oldNickServ);
					}
				}
			}

			public string NickServAsText =>
				nickServ switch
				{
					null => Resources.strNickServOptNull,
					NickServOpts.unknown => Resources.strNickServOptUnknown,
					NickServOpts.atTheme => Resources.strNickServOptAtTheme,
					_ => throw new System.NotImplementedException(),
				};

			public string NickServToolTip =>
				nickServ switch
				{
					null => Resources.strNickServOptNullToolTip,
					NickServOpts.unknown => Resources.strNickServOptUnknownToolTip,
					NickServOpts.atTheme => Resources.strNickServOptAtThemeToolTip,
					_ => throw new System.NotImplementedException(),
				};

			public ChanServOpts? ChanServ
			{
				get => chanServ;

				protected set
				{
					if(chanServ != value)
					{
						ChanServOpts? oldChanServ = chanServ;

						chanServ = value;

						MakeDirty();

						FireChanServChanged(oldChanServ);
					}
				}
			}

			public string ChanServAsText =>
				chanServ switch
				{
					null => Resources.strChanServOptNull,
					ChanServOpts.unknown => Resources.strChanServOptUnknown,
					ChanServOpts.atTheme => Resources.strChanServOptAtTheme,
					_ => throw new System.NotImplementedException(),
				};

			public string ChanServToolTip =>
				chanServ switch
				{
					null => Resources.strChanServOptNullToolTip,
					ChanServOpts.unknown => Resources.strChanServOptUnknownToolTip,
					ChanServOpts.atTheme => Resources.strChanServOptAtThemeToolTip,
					_ => throw new System.NotImplementedException(),
				};

			public bool? HasAlis
			{
				get => bHasAlis;

				set
				{
					if(bHasAlis != value)
					{
						bool? bOldHasAlis = bHasAlis;

						bHasAlis = value;

						MakeDirty();

						FireHasAlisChanged(bOldHasAlis);
					}
				}
			}

			public string HasAlisAsText =>
				bHasAlis switch
				{
					null => Resources.strHasAlisUnknown,
					false => Resources.strHasAlisFalse,
					true => Resources.strHasAlisTrue,
				};

			public string HasAlisToolTip =>
				bHasAlis switch
				{
					null => Resources.strHasAlisUnknownToolTip,
					false => Resources.strHasAlisFalseToolTip,
					true => Resources.strHasAlisTrueToolTip,
				};

			public bool? HasQ
			{
				get => bHasQ;

				set
				{
					if(bHasQ!= value)
					{
						bool? bOldHasQ = bHasQ;

						bHasQ= value;

						MakeDirty();

						FireHasQChanged(bOldHasQ);
					}
				}
			}

			public string HasQAsText =>
				bHasQ switch
				{
					null => Resources.strHasQUnknown,
					false => Resources.strHasQFalse,
					true => Resources.strHasQTrue,
				};

			public string HasQToolTip =>
				bHasQ switch
				{
					null => Resources.strHasQUnknownToolTip,
					false => Resources.strHasQFalseToolTip,
					true => Resources.strHasQTrueToolTip,
				};

			public virtual bool IsServerListDefaulted => false;

			public bool IsCustomized => UserNetworkMgr.mgr.AllItems.ContainsKey(strName);

			public abstract System.Collections.Generic.IReadOnlyDictionary<char, ChanMode> ChanModesByModeChar
			{
				get;
			}

			public abstract System.Collections.Generic.IReadOnlyDictionary<char, UserMode> UserModesByModeChar
			{
				get;
			}
		#endregion

		#region Methods
		protected void FirePropChanged(string strPropName) => PropertyChanged?.Invoke(this, new
				(strPropName));

			protected void FireNameChanged(string strOldVal)
			{
				FirePropChanged(nameof(Name));

				evtNameChanged?.Invoke(this, strOldVal, strName);
			}

			protected void FireHomepageChanged(System.Uri? uriOldHomepage)
			{
				FirePropChanged(nameof(Homepage));

				evtHomepageChanged?.Invoke(this, uriOldHomepage, uriHomepage);
			}

			protected void FireServersSortedByNameChanged(CollectionChangeType howTheCollectionChanged)
			{
				FirePropChanged(nameof(ServersSortedByName));

				evtServersSortedByNameChanged?.Invoke(this, mapServers, howTheCollectionChanged);
			}

			protected void FireEnabledServerDomainsInSearchOrderChanged(CollectionChangeType howThCollectionChanged)
			{
				FirePropChanged(nameof(EnabledServerDomainsInSearchOrder));

				evtEnabledServerDomainsInSearchOrder?.Invoke(this, EnabledServerDomainsInSearchOrder, howThCollectionChanged);
			}

			protected void FireNickServChanged(NickServOpts? oldNickServ)
			{
				FirePropChanged(nameof(NickServ));

				evtNickServChanged?.Invoke(this, oldNickServ, nickServ);
			}

			protected void FireChanServChanged(ChanServOpts? oldNickServ)
			{
				FirePropChanged(nameof(ChanServ));

				evtChanServChanged?.Invoke(this, oldNickServ, chanServ);
			}

			protected void FireHasAlisChanged(bool? bOldHasAlis)
			{
				FirePropChanged(nameof(HasAlis));

				evtHasAlisChanged?.Invoke(this, bOldHasAlis, bHasAlis);
			}

			protected void FireHasQChanged(bool? bOldHasQ)
			{
				FirePropChanged(nameof(HasQ));

				evtHasQChanged?.Invoke(this, bOldHasQ, bHasQ);
			}

			protected void AddServerDomain(ServerInfo server)
			{
				if(mapServers.ContainsKey(server.Domain))
					throw new System.NotSupportedException("This server is already present");

				mapServers[server.Domain] = server;

				FireServersSortedByNameChanged(CollectionChangeType.add);

				server.evtIsEnabledChanged += OnServerEnabledStateChanged;
				FireEnabledServerDomainsInSearchOrderChanged(CollectionChangeType.changed);

				FirePropChanged(nameof(IsServerListDefaulted));
			}

			protected void DelServerDomain(ServerInfo server)
			{
				if(!mapServers.ContainsKey(server.Domain))
					return;

				mapServers.Remove(server.Domain);

				FireServersSortedByNameChanged(CollectionChangeType.removed);
				FireEnabledServerDomainsInSearchOrderChanged(CollectionChangeType.changed);

				FirePropChanged(nameof(IsServerListDefaulted));
			}

			protected void ClearServerDomainList()
			{
				mapServers.Clear();

				MakeDirty();

				FireEnabledServerDomainsInSearchOrderChanged(CollectionChangeType.changed);

				FirePropChanged(nameof(IsServerListDefaulted));
			}

			protected void MoveServerDownSearchList(in ServerInfo server)
			{
				if(!mapServers.ContainsKey(server.Domain))
					throw new System.InvalidProgramException($"Can't move the server {server.Domain
						} in the search list for the network '{Name}' as it doesn't exist in the network.");

				System.Collections.Generic.LinkedList<ServerInfo> llServers = new(mapServers.Values);
				mapServers.Clear();

				System.Collections.Generic.LinkedListNode<ServerInfo>? llnNextServer = (llServers.Find(server)?.Next) ??
					llServers.Last;

				llServers.Remove(server);

				if(llnNextServer == null || llnNextServer == llServers.Last)
					llServers.AddLast(server);
				else
					llServers.AddAfter(llnNextServer, server);

				foreach(ServerInfo serverCur in llServers)
					mapServers[serverCur.Domain] = serverCur;

				FirePropChanged(nameof(IsServerListDefaulted));
			}

			protected void MoveServerUpSearchList(in ServerInfo server)
			{
				if(!mapServers.ContainsKey(server.Domain))
					throw new System.InvalidProgramException($"Can't move the server {server.Domain
						} in the search list for the network '{Name}' as it doesn't exist in the network.");

				System.Collections.Generic.LinkedList<ServerInfo> llServers = new(mapServers.Values);
				mapServers.Clear();

				System.Collections.Generic.LinkedListNode<ServerInfo>? llnPrevServer = (llServers.Find(server)?.Previous) ??
					llServers.First;

				llServers.Remove(server);

				if(llnPrevServer == null || llnPrevServer == llServers.First)
					llServers.AddFirst(server);
				else
					llServers.AddBefore(llnPrevServer, server);

				foreach(ServerInfo serverCur in llServers)
					mapServers[serverCur.Domain] = serverCur;

				FirePropChanged(nameof(IsServerListDefaulted));
			}

			protected virtual void ResetServerDomainList()
			{
			}
		#endregion

		#region Event Handlers
			private void OnServerEnabledStateChanged(ServerInfo objSender, bool bNewVal) => 
				FireEnabledServerDomainsInSearchOrderChanged(CollectionChangeType.changed);
		#endregion
	}
}