namespace BestChat.Platform.Tools
{
	/// <summary>
	/// Place to put any extension methods that affect collections
	/// </summary>
	public static class Collection
	{
		/// <summary>
		/// Tests to see if the collection is either <see langword="null"/> or empty (length == 0)
		/// </summary>
		/// <typeparam name="EntryType">The of the collection's entries</typeparam>
		/// <param name="collection">The actual collection</param>
		/// <returns></returns>
		[System.Obsolete("Use null coalescing instead", true)]
		public static bool IsNullOrEmpty<EntryType>(this System.Collections.Generic.IReadOnlyCollection<EntryType>? collection) => collection == null || collection
			.Count == 0;

		/// <summary>
		/// Tests to see if the collection is either <see langword="null"/> or empty (length == 0)
		/// </summary>
		/// <typeparam name="EntryType">The of the collection's entries</typeparam>
		/// <param name="collection">The actual collection</param>
		/// <returns></returns>
		[System.Obsolete("Use null coalescing instead", true)]
		public static bool IsNullOrEmpty<EntryType>(this EntryType[]? collection) => collection == null || collection.Length == 0;
	}
}