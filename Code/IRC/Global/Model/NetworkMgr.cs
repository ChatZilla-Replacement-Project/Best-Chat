// Ignore Spelling: IRC evt

namespace BestChat.IRC.Global.Model
{
	public class NetworkMgr : Platform.Data.Obj<NetworkMgr>
	{
		#region Constructors & Deconstructors
			public NetworkMgr()
			{
				string strFileCtnts = client.GetStringAsync("https://raw.githubusercontent.com/ChatZilla" +
					"-Replacement-Project/JSON-Data/main/Defaults/Network-def.json").Result;
				try
				{
				Data.Defs.DTO.NetworkDTO[]? anetPredefined = System.Text.Json.JsonSerializer.Deserialize<Data.Defs
					.DTO.NetworkDTO[]>(strFileCtnts, jso);

				if(anetPredefined != null)
					foreach(Data.Defs.DTO.NetworkDTO dnetCurPredefined in anetPredefined)
					{
						Data.Defs.Network netCurPredefined = new(dnetCurPredefined);

						mapAllPredefinedNetworksSortedByName[netCurPredefined.Name] = netCurPredefined;
						mapAllNetworksSortedByName[netCurPredefined.Name] = new(netCurPredefined);
					}
				}
				catch(System.Exception ex)
				{
				}
			}

			static NetworkMgr()
			{
				if(System.Windows.Application.Current is not Platform.HttpClientOwner.IHttpClientOwner)
					throw new System.InvalidProgramException("NetworkMgr can only be used by applications that implement " +
						"BestChat.Platform.HttpClientOwner.IHttpClientOwner.");

				client = ((Platform.HttpClientOwner.IHttpClientOwner)System.Windows.Application.Current).HttpClient;

				mgr = new NetworkMgr();
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event DCollectionFieldChanged<System.Collections.Generic.IEnumerable<Data.Defs.UserNetwork>>?
				evtListChanged;

			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public static readonly NetworkMgr mgr;

			private static readonly System.Net.Http.HttpClient client;

			private static readonly System.Text.Json.JsonSerializerOptions jso = new()
			{
				Converters =
				{
					new System.Text.Json.Serialization.JsonStringEnumConverter(),
				}
			};

			private readonly System.Collections.Generic.SortedDictionary<string, Data.Defs.UserNetwork>
				mapAllNetworksSortedByName = new();

			private readonly System.Collections.Generic.SortedDictionary<string, Data.Defs.Network>
				mapAllPredefinedNetworksSortedByName = new();
		#endregion

		#region Properties
			public System.Collections.Generic.IEnumerable<Data.Defs.UserNetwork> AllNetworksSortedByName =>
				mapAllNetworksSortedByName.Values;

			public System.Collections.Generic.IReadOnlyDictionary<string, Data.Defs.Network> AllPredefinedNetworks =>
				mapAllPredefinedNetworksSortedByName;

			public System.Collections.Generic.IReadOnlyDictionary<string, Data.Defs.UserNetwork> AllNetworks =>
				mapAllNetworksSortedByName;
		#endregion

		#region Methods
			public void AddNetwork(Data.Defs.UserNetwork netNew)
			{
				if(mapAllNetworksSortedByName.ContainsKey(netNew.Name))
					throw new System.ArgumentException($"The IRC network manager already has a network named {netNew.Name
						} and can't accommodate a second with the same name.", nameof(netNew));

				mapAllNetworksSortedByName[netNew.Name] = netNew;

				netNew.evtNameChanged += OnNameOfNetworkChanged;

				evtListChanged?.Invoke(this, AllNetworksSortedByName, CollectionChangeType.add);

				PropertyChanged?.Invoke(this, new(nameof(AllNetworksSortedByName)));

				MakeDirty();
			}

			public void RemoveNetwork(string strNameOfNetworkToRemove)
			{
				if(!mapAllNetworksSortedByName.ContainsKey(strNameOfNetworkToRemove))
					throw new System.ArgumentException($"The network manager can't remove the network named {
						strNameOfNetworkToRemove} as no such network exists.", nameof(strNameOfNetworkToRemove));

				mapAllNetworksSortedByName.Remove(strNameOfNetworkToRemove);

				evtListChanged?.Invoke(this, AllNetworksSortedByName, CollectionChangeType.removed);

				PropertyChanged?.Invoke(this, new(nameof(AllNetworksSortedByName)));

				MakeDirty();
			}
		#endregion

		#region Event Handlers
			private void OnNameOfNetworkChanged(Data.Defs.Network netSender, string strOldVal, string strNewVal)
			{
				if(mapAllNetworksSortedByName.ContainsKey(strOldVal))
					mapAllNetworksSortedByName.Remove(strOldVal);

				// Only user network should ever change this.  Predefined networks should never change.
				if(netSender is Data.Defs.UserNetwork unetSender)
					mapAllNetworksSortedByName[unetSender.Name] = unetSender;
			}
		#endregion
	}
}