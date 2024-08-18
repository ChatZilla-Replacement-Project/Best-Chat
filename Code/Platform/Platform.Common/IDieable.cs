// Ignore Spelling: Dieable

namespace BestChat.Platform.Common
{
	/// <summary>
	/// Provides a way to inform interested callers that the sender isn't valid any more and should be discarded.
	/// </summary>
	public interface IDieable
	{
		/// <summary>
		/// Tells the caller the object is going away.
		/// </summary>
		/// <param name="dieing">Which object is dieing</param>
		public delegate void OnDieing(IDieable dieing);

		/// <summary>
		/// Fired when the object is dieing
		/// </summary>
		event OnDieing? evtDieing;
	}
}