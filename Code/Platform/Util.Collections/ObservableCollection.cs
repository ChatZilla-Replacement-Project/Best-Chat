// Ignore Spelling: Util

namespace BestChat.Util.Collections
{
	public class ObservableCollection<ElementType> : System.Collections.ObjectModel.ObservableCollection<ElementType>
	{
		#region Constants
			public static class PropNames
			{
				public const string strCount = nameof(ObservableCollection<ElementType>.Count);
				public const string strItems = nameof(ObservableCollection<ElementType>.Items);
			}
		#endregion

		public void RemoveRange(int index, int count)
		{
			CheckReentrancy();
			System.Collections.Generic.List<ElementType> items = (System.Collections.Generic.List<ElementType>)Items;
			items.RemoveRange(index, count);
			OnReset();
		}

		public void InsertRange(int index, System.Collections.Generic.IEnumerable<ElementType> collection)
		{
			CheckReentrancy();
			System.Collections.Generic.List<ElementType> items = (System.Collections.Generic.List<ElementType>)Items;
			items.InsertRange(index, collection);
			OnReset();
		}

		private void OnReset()
		{
			FirePropertyChanged(PropNames.strCount);
			FirePropertyChanged(PropNames.strItems);
			OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections
				.Specialized.NotifyCollectionChangedAction.Reset));
		}

		private void FirePropertyChanged(string strPropName) => OnPropertyChanged(new System.ComponentModel
			.PropertyChangedEventArgs(strPropName));
	}
}