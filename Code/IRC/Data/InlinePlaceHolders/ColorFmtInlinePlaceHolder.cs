// Ignore Spelling: Inline Ctnts iph Fg Bg

namespace BestChat.IRC.Data.InlinePlaceHolders
{
	public class ColorFmtInlinePlaceHolder : Platform.Conversations.AbstractGroupInlinePlaceHolder
	{
		public ColorFmtInlinePlaceHolder(in System.Collections.Generic.IEnumerable<Platform.Conversations
			.PlaceHolder.IInlinePlaceHolder> ieCtnts, in int iFgColor, in int? iBgColor = null) : base(ieCtnts)
		{
			this.iFgColor = iFgColor;
			this.iBgColor = iBgColor;
		}


		public readonly int iFgColor;

		public readonly int? iBgColor;


		public int FgColor => iFgColor;

		public int? BgColor => iBgColor;
	}
}