namespace BestChat.IRC.Data
{
	public interface IDataDefBasic<ItemType>
	{
		string Name
		{
			get;
		}
	}

	public interface IDataDef<ItemType> : IDataDefBasic<ItemType>
		where ItemType : Platform.Data.Obj<ItemType>
	{
		event Platform.Data.Obj<ItemType>.DFieldChanged<string> evtNameChanged;
	}
}