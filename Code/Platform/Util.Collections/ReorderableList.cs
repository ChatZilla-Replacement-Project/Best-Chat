namespace BestChat.Util.Collections
{
	public class ReorderableList<ValueType> : System.Collections.Generic.List<ValueType>
	{
		#region Constructors & Destructors
			public ReorderableList()
			{
			}

			public ReorderableList(System.Collections.Generic.IEnumerable<ValueType> copyThis) : base(copyThis)
			{
			}

			public ReorderableList(int iInitialCapacity) : base(iInitialCapacity)
			{
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
		#endregion

		#region Helper types
		#endregion

		#region Members
		#endregion

		#region Properties
			public bool IsEmpty
			{
				get
				{
					return Count == 0;
				}
			}
		#endregion

		#region Methods
			public void SetIndexForItem(ValueType itemToMove, int iNewIndex)
			{
				if(!Contains(itemToMove))
					throw new System.ArgumentException("The item you passed isn't in this ordered list", "itemToMove");

				if(iNewIndex < 0 || iNewIndex >= Count)
					throw new System.IndexOutOfRangeException();

				int iExistingIndex = IndexOf(itemToMove);

				if(iNewIndex == iExistingIndex)
					return;

				Remove(itemToMove);
				Insert(iNewIndex, itemToMove);
			}
		#endregion
	}
}