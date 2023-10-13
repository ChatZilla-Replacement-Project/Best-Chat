// Ignore Spelling: Defs

namespace BestChat.IRC.Data.Defs
{
	[System.ComponentModel.ImmutableObject(true)]
	public partial class LocalizedTextSystem
	{
		#region Constructors & Deconstructors
			internal LocalizedTextSystem(System.Collections.Generic.IEnumerable<DTO.LocalizedTextDTO>
				translations, string strDef)
			{
				this.strDef = strDef;
				foreach(DTO.LocalizedTextDTO dtextCur in translations)
					mapTranslationByLang[dtextCur.Lang] = dtextCur.Translation;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
			public static readonly System.Text.RegularExpressions.Regex regexParentLangObtainer =
				InitParentLangObtainer();
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly string strDef;

			private readonly System.Collections.Generic.SortedDictionary<string, string> mapTranslationByLang =
				new();
		#endregion

		#region Properties
		#endregion

		#region Operators
			public string this[string strLangID]
			{
				get
				{
					if(mapTranslationByLang.ContainsKey(strLangID))
						return mapTranslationByLang[strLangID];

					if(strLangID.Contains('-'))
					{
						string strParentLangID = regexParentLangObtainer.Replace(strLangID, "$1");

						if(mapTranslationByLang.ContainsKey(strParentLangID))
							return mapTranslationByLang[strParentLangID];
					}

					return strDef;
				}
			}

			public string this[System.Globalization.CultureInfo culture] => mapTranslationByLang
				.ContainsKey(culture.Name) ? mapTranslationByLang[culture.Name] : culture.Parent != null ?
				this[culture.Parent] : strDef;

			public string TranslationForCurCulture => this[System.Globalization.CultureInfo.CurrentCulture];
		#endregion

		#region Methods
			[System.Text.RegularExpressions.GeneratedRegex("([a-z][a-z])(-[A-Z][A-Z])")]
			private static partial System.Text.RegularExpressions.Regex InitParentLangObtainer();
		#endregion

		#region Event Handlers
		#endregion
	}
}