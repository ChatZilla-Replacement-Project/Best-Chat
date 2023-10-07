// Ignore Spelling: Cnt

namespace BestChat.Platform.Tools
{
	/// <summary>
	/// Provides a place to put all extension methods for strings.
	/// </summary>
	public static class Str
	{
		/// <summary>
		/// Returns <see langword="true"/> if the string is non-<see langword="null"/> and not empty.
		/// </summary>
		/// <param name="strVal">The value to test</param>
		/// <returns>Either <see langword="true"/> or <see langword="false"/></returns>
		[System.Obsolete("Use null coalescing instead", true)]
		public static bool IsNullOrEmpty(this string strVal) => strVal == null || strVal.Trim().Length == 0;

		/// <summary>
		/// Formats the string based on the parameters in <paramref name="parameters"/>
		/// </summary>
		/// <param name="strFmt">The format string</param>
		/// <param name="parameters">The parameters to use</param>
		/// <returns>The formated string</returns>
		public static string Fmt(this string strFmt, params object[] parameters) => string.Format(strFmt, parameters);

		/// <summary>
		/// Repeats a character <paramref name="iRepeatCnt"/> times
		/// </summary>
		/// <param name="chWhatToRepeat">Which character to repeat</param>
		/// <param name="iRepeatCnt">How many times to repeat it</param>
		/// <returns>The desired substring</returns>
		public static string Repeat(this char chWhatToRepeat, int iRepeatCnt) => "".PadLeft(iRepeatCnt, chWhatToRepeat);

		/// <summary>
		/// Same as <see cref="Repeat(char, int)"/>, but takes a substring instead of a single character.
		/// </summary>
		/// <param name="strWhatToRepeat">The substring to repeat</param>
		/// <param name="iRepeatCnt">How many times to repeat <paramref name="strWhatToRepeat"/></param>
		/// <returns>The requested substring</returns>
		public static string Repeat(this string strWhatToRepeat, int iRepeatCnt)
		{
			string strResult = "";

			while(iRepeatCnt-- > 0)
				strResult += strWhatToRepeat;

			return strResult;
		}
	}
}