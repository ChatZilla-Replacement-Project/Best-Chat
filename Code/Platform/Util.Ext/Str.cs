namespace BestChat.Util.Ext
{
	public static class Str
	{
		public static string EncodeForURL(this string strEncodeThis) => strEncodeThis.Replace("%", "%25").Replace(" ", "_").Replace("&", "%26").Replace(",", "%2C")
			.Replace("#", "%23").Replace(":", "%3A").Replace("'", "%27").Replace("\"", "%22").Replace("!", "%21").Replace("$", "%24").Replace("*", "%2A").Replace("+",
			"%2b").Replace("?", "3F").Replace("=", "%3D");

		public static string Fmt(this string strFmtThis, params object[] args) => string.Format(strFmtThis, args);

		public static bool IsEmpty(this string strTestThis) => strTestThis == null || strTestThis.Length == 0;

		public static string Min(string strLeft, string strRight) => strLeft.Equals(strRight) ? strRight : strLeft.CompareTo(strRight) < 0 ? strLeft : strRight;

		public static string Max(string strLeft, string strRight) => strLeft.Equals(strRight) ? strRight : strLeft.CompareTo(strRight) > 0 ? strLeft : strRight;

		public static bool Contains(this string strTestThis, char chTestFor) => strTestThis.Contains("" + chTestFor);

		public static bool StartsWith(this string strTestThis, char chTestFor) => strTestThis.StartsWith("" + chTestFor);

		public static bool EndsWith(this string strTestThis, char chTestFor) => strTestThis.EndsWith("" + chTestFor);
	}
}