// Ignore Spelling: Dto

namespace BestChat.IRC.Data
{
	public abstract class MgrBase<ItemType, ItemBaseType, ItemDtoType> : Platform.Data.Obj<MgrBase<ItemType,
		ItemBaseType, ItemDtoType>>
		where ItemType : ItemBaseType
		where ItemBaseType : Platform.Data.Obj<ItemBaseType>, IDataDef<ItemBaseType>
		where ItemDtoType : IDataDefBasic<ItemDtoType>
	{
		#region Constructors & Deconstructors
			protected MgrBase(System.IO.FileInfo fileUserData, DGetItemFromDTO dItemMaker)
			{
				if(fileUserData.Exists)
					try
					{
						Init(fileUserData.OpenText().ReadToEnd(), dItemMaker);
					}
					catch (System.Exception e)
					{
						System.Windows.MessageBox.Show(System.Windows.Application.Current.MainWindow, 
							 $"Unable to reload your custom IRC networks due to {e.Message}.", 
							 "IRC Network load failure.", System.Windows.MessageBoxButton.OK, System.Windows
							 .MessageBoxImage.Error);
					}
			}

			protected MgrBase(System.Uri uriPredefinedData, DGetItemFromDTO itemMaker) => Init(client
				.GetStringAsync(uriPredefinedData.AbsoluteUri).Result, itemMaker);

			static MgrBase()
			{
				if(System.Windows.Application.Current is not Platform.HttpClientOwner.IHttpClientOwner)
					throw new System.InvalidProgramException("Mgr objects can only be used by applications that " +
						"implement BestChat.Platform.HttpClientOwner.IHttpClientOwner.");

				client = ((Platform.HttpClientOwner.IHttpClientOwner)System.Windows.Application.Current)
					.HttpClient;
			}
		#endregion

		#region Delegates
			protected delegate ItemType DGetItemFromDTO(ItemDtoType dto);
		#endregion

		#region Events
			public event DCollectionFieldChanged<System.Collections.Generic.IEnumerable<ItemType>>?
				evtListChanged;

			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private static readonly System.Net.Http.HttpClient client;

			private static readonly System.Text.Json.JsonSerializerOptions jso = new()
			{
				Converters =
				{
					new System.Text.Json.Serialization.JsonStringEnumConverter(),
				}
			};

			private readonly System.Collections.Generic.SortedDictionary<string, ItemType>
				mapAllItemsSortedByName = new();
		#endregion

		#region Properties
			public System.Collections.Generic.IEnumerable<ItemType> AllItemsSortedByName =>
				mapAllItemsSortedByName.Values;

			public System.Collections.Generic.IReadOnlyDictionary<string, ItemType> AllItems =>
				mapAllItemsSortedByName;
		#endregion

		#region Methods
			private void Init(string strUserDataCtnts, DGetItemFromDTO itemMaker)
			{
				ItemDtoType[]? anet = System.Text.Json.JsonSerializer
					.Deserialize<ItemDtoType[]>(strUserDataCtnts, jso);

				if(anet != null)
					foreach(ItemDtoType dnetCur in anet)
						mapAllItemsSortedByName[dnetCur.Name] = itemMaker(dnetCur);
			}

			public void Add(ItemType @new)
			{
				if(mapAllItemsSortedByName.ContainsKey(@new.Name))
					throw new System.ArgumentException("The IRC network manager already has a network named" +
						$" {@new.Name} and can't accommodate a second with the same name.", nameof(@new));

				mapAllItemsSortedByName[@new.Name] = @new;

				@new.evtNameChanged += OnChildNameChanged;

				evtListChanged?.Invoke(this, AllItemsSortedByName, CollectionChangeType.add);

				PropertyChanged?.Invoke(this, new(nameof(AllItemsSortedByName)));

				MakeDirty();
			}

			public void Remove(string strNameOfItemToRemove)
			{
				if(!mapAllItemsSortedByName.ContainsKey(strNameOfItemToRemove))
					throw new System.ArgumentException($"The network manager can't remove the network named {
						strNameOfItemToRemove} as no such network exists.", nameof(strNameOfItemToRemove));

				mapAllItemsSortedByName.Remove(strNameOfItemToRemove);

				evtListChanged?.Invoke(this, AllItemsSortedByName, CollectionChangeType.removed);

				PropertyChanged?.Invoke(this, new(nameof(AllItemsSortedByName)));

				MakeDirty();
			}
		#endregion

		#region Event Handlers
			private void OnChildNameChanged(ItemBaseType sender, string strOldVal, string strNewVal)
			{
				if(sender is not ItemType)
					throw new System.InvalidProgramException($"Some how an item in {GetType().FullName} " +
						$"isn't of type {typeof(ItemType)} as was expected.  Instead, an item of type {sender
						.GetType()} was found.");
				ItemType senderAsDerivedType = (ItemType)sender;

				if(mapAllItemsSortedByName.ContainsKey(strOldVal))
					mapAllItemsSortedByName.Remove(strOldVal);

				mapAllItemsSortedByName[sender.Name] = senderAsDerivedType;
			}
		#endregion
	}

	public class NetworkMgr : MgrBase<Defs.Network, Defs.Network, Defs.DTO.NetworkDTO>
	{
		private NetworkMgr() : base(new System.Uri("https://raw.githubusercontent.com/ChatZilla"
			+ "-Replacement-Project/JSON-Data/main/Defaults/Network-def.json"), MakeNetworkFromDto)
		{
		}

		public static readonly NetworkMgr mgr = new();

		private static Defs.Network MakeNetworkFromDto(Defs.DTO.NetworkDTO dnet) => new(dnet);
	}

	public class UserNetworkMgr : MgrBase<Defs.UserNetwork, Defs.Network, Defs.DTO.NetworkDTO>
	{
		private UserNetworkMgr() : base(new System.IO.FileInfo(System.IO.Path.Combine(((Platform
			.DataLoc.IDataLocProvider)System.Windows.Application.Current).LocalDataLoc.FullName,
			"User Networks.json")), MakeNetworkFromDto)
		{
		}

		static UserNetworkMgr()
		{
			if(System.Windows.Application.Current is not Platform.DataLoc.IDataLocProvider)
				throw new System.InvalidProgramException("UserNetworkMgr can only be used by applications that " +
					"implement BestChat.Platform.DataLoc.IDataLocProvider.");

			mgr = new();
		}

		public static readonly UserNetworkMgr mgr;

		private static Defs.UserNetwork MakeNetworkFromDto(Defs.DTO.NetworkDTO dnet) => new(dnet);
	}
}