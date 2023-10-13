// Ignore Spelling: dcm Defs

namespace BestChat.IRC.Data.Defs
{
	[System.ComponentModel.ImmutableObject(true)]
	public class ChanMode
	{
		#region Constructors & Deconstructors
			internal ChanMode(in char chModeChar, in LocalizedTextSystem textDesc, in bool bNotAlwaysAvailable =
				false, in System.Collections.Generic.IEnumerable<ModeParam>? @params = null, in string
				strFmtAsSentToNetwork = "", in bool bIsOperRequiredToChange = false)
			{
				this.chModeChar = chModeChar;
				this.textDesc = textDesc;
				this.bNotAlwaysAvailable = bNotAlwaysAvailable;
				if(@params != null)
					foreach(ModeParam mpCur in @params)
						mapParamsByName[mpCur.Name] = mpCur;
				this.strFmtAsSentToNetwork = strFmtAsSentToNetwork;
				this.bIsOperRequiredToChange = bIsOperRequiredToChange;
			}

			internal ChanMode(DTO.ChanModeDTO dcmUs)
			{
				chModeChar = dcmUs.Mode;
				textDesc = new(dcmUs.LocalizedDesc, dcmUs.DefaultDesc);
				bNotAlwaysAvailable = dcmUs.NotAlwaysAvailable;
				foreach(DTO.ModeParamDTO dmpCurParam in dcmUs.Parameters)
					mapParamsByName[dmpCurParam.Name] = new(dmpCurParam);
				strFmtAsSentToNetwork = dcmUs.FmtAsSentToNetwork;
				bIsOperRequiredToChange = dcmUs.IsOperRequiredToChange;
			}
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
			public readonly char chModeChar;

			public readonly LocalizedTextSystem textDesc;

			public readonly bool bNotAlwaysAvailable;

			private readonly System.Collections.Generic.SortedDictionary<string, ModeParam> mapParamsByName =
				new();

			public readonly string strFmtAsSentToNetwork;

			public readonly bool bIsOperRequiredToChange;
		#endregion

		#region Properties
			public char ModeChar => chModeChar;

			public LocalizedTextSystem Desc => textDesc;

			public bool NotAlwaysAvailable => bNotAlwaysAvailable;

			public System.Collections.Generic.IReadOnlyDictionary<string, ModeParam> ParamsByName =>
				mapParamsByName;

			public string FmtAsSentToNetwork => strFmtAsSentToNetwork;

			public bool IsOperRequiredToChange => bIsOperRequiredToChange;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}