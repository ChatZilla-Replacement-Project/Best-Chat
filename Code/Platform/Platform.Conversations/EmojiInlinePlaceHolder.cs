namespace BestChat.Platform.Conversations
{
	public class EmojiInlinePlaceHolder : PlaceHolder.IInlinePlaceHolder
	{
		#region Constructors & Deconstructors
			private EmojiInlinePlaceHolder(in string strTextFound) => this.strTextFound = strTextFound;
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly string strTextFound;

			private static readonly System.Collections.Generic.SortedDictionary<string, System.Collections
				.Generic.IEnumerable<string>> mapEmojiToEmoticons = new()
				{
					["🙂"] = new string[] { ":)" },
					["😀"] = new string[] { ":D", ":grin:" },
					["😟"] = new string[] {":("},
					["😒"] = new string[] {"9_9"},
				};

			private static readonly System.Collections.Generic.SortedDictionary<string, string>
				mapEmoticonsToEmoji = new()
				{
					[":)"] = "🙂",
					[":D"] = "😀",
					[":grin:"] = "😀",
					[":("] = "😟",
					["9_9"] = "😒",
				};
		#endregion

		#region Properties
			public string TextFound => strTextFound;

			public System.Collections.Generic.IEnumerable<string> EmojiForText => mapEmojiToEmoticons
				.ContainsKey(strTextFound) ? mapEmojiToEmoticons[strTextFound] : new string[] { strTextFound };

			public string EmoticonForText => mapEmoticonsToEmoji.ContainsKey(strTextFound) ?
				mapEmoticonsToEmoji[strTextFound] : strTextFound;


			// TODO: Look up a preference to be created as to how the emoji should be displayed.
			public string AsText => strTextFound;



			public static System.Collections.Generic.IReadOnlyDictionary<string, System.Collections
				.Generic.IEnumerable<string>> AllEmoticonsByEmojiText => mapEmojiToEmoticons;

			public static System.Collections.Generic.IReadOnlyDictionary<string, string> AllEmojiByEmoticonText
				=> mapEmoticonsToEmoji;
		#endregion

		#region Methods
			public static EmojiInlinePlaceHolder? IsEmojiPresent(in string strInput)
			{
				foreach(string strCurEmoji in mapEmojiToEmoticons.Keys)
					if(strInput.StartsWith(strCurEmoji))
						return new EmojiInlinePlaceHolder(strCurEmoji);

				foreach(string strCurEmoticon in mapEmoticonsToEmoji.Keys)
					if(strInput.StartsWith(strCurEmoticon))
						return new EmojiInlinePlaceHolder(strCurEmoticon);

				return null;
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}