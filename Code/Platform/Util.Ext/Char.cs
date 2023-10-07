namespace BestChat.Util.Ext
{
	public static class Char
	{
		#region Tests
			public static bool IsUpper(this char chTest)
			{
				return char.IsUpper(chTest);
			}

			public static bool IsLower(this char chTest)
			{
				return char.IsLower(chTest);
			}

			public static bool IsLetter(this char chTest)
			{
				return char.IsLetter(chTest);
			}

			public static bool IsDigit(this char chTest)
			{
				return char.IsDigit(chTest);
			}

			public static bool IsLetterOrDigit(this char chTest)
			{
				return char.IsLetterOrDigit(chTest);
			}

			public static bool IsControl(this char chTest)
			{
				return char.IsControl(chTest);
			}

			public static bool IsHighSurrogate(this char chTest)
			{
				return char.IsHighSurrogate(chTest);
			}

			public static bool IsLowSurrogate(this char chTest)
			{
				return char.IsLowSurrogate(chTest);
			}

			public static bool IsNumber(this char chTest)
			{
				return char.IsNumber(chTest);
			}

			public static bool IsPunctuation(this char chTest)
			{
				return char.IsPunctuation(chTest);
			}

			public static bool IsSeparator(this char chTest)
			{
				return char.IsSeparator(chTest);
			}

			public static bool IsSurrogate(this char chTest)
			{
				return char.IsSurrogate(chTest);
			}

			public static bool IsSymbol(this char chTest)
			{
				return char.IsSymbol(chTest);
			}

			public static bool IsWhiteSpace(this char chTest)
			{
				return char.IsWhiteSpace(chTest);
			}
		#endregion

		#region Conversions
			public static char ToLower(this char chConvertThis)
			{
				return char.ToLower(chConvertThis);
			}

			public static char ToLower(this char chConvertThis, System.Globalization.CultureInfo culture)
			{
				return char.ToLower(chConvertThis, culture);
			}

			public static char ToLowerInvariant(this char chConvertThis)
			{
				return char.ToLowerInvariant(chConvertThis);
			}

			public static char ToUpper(this char chConvertThis)
			{
				return char.ToUpper(chConvertThis);
			}

			public static char ToUpper(this char chConvertThis, System.Globalization.CultureInfo culture)
			{
				return char.ToUpper(chConvertThis, culture);
			}

			public static char ToUpperInvariant(this char chConvertThis)
			{
				return char.ToUpperInvariant(chConvertThis);
			}
		#endregion
	}
}