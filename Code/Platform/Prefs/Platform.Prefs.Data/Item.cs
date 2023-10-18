namespace BestChat.Platform.Prefs.Data
{
	public abstract class ItemBase
	{
		#region Constructors & Deconstructors
			public ItemBase(in string strItemName, in string strItemLongDesc)
			{
				this.strItemName = strItemName;
				this.strItemLongDesc = strItemLongDesc;
			}
		#endregion

		#region Members
			public readonly string strItemName;

			public readonly string strItemLongDesc;
		#endregion

		#region Properties
			public string ItemName => strItemName;

			public string ItemLongDesc => strItemLongDesc;
		#endregion
	}

	public class Item<TypeOfItem> : ItemBase, System.ComponentModel.INotifyPropertyChanged
	{
		#region Constructors & Deconstructors
			public Item(in TypeOfItem def, in string strItemName, in string strItemLongDesc, in TypeOfItem
				valCur) : base(strItemName, strItemLongDesc)
			{
				this.def = def;
				this.valCur = valCur;
			}
		#endregion

		#region Delegates
			public delegate void DCurValChanged(Item<TypeOfItem> itemSender, TypeOfItem oldVal, TypeOfItem
				newVal);
		#endregion

		#region Events
			public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public event DCurValChanged? evtCurValChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly TypeOfItem def;


			private TypeOfItem valCur;
		#endregion

		#region Properties
			public TypeOfItem Def => def;

			public TypeOfItem CurVal
			{
				get => valCur;

				set
				{
					if(valCur != null && !valCur.Equals(value) || value != null)
					{
						TypeOfItem oldVal = valCur;

						valCur = value;

						PropertyChanged?.Invoke(this, new(nameof(CurVal)));

						evtCurValChanged?.Invoke(this, oldVal, value);
					}
				}
			}
		#endregion

		#region Methods
			public void Reset() => CurVal = def;
		#endregion

		#region Event Handlers
		#endregion
	}
}