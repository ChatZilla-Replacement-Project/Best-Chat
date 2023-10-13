// Ignore Spelling: Defs dmp

namespace BestChat.IRC.Data.Defs
{
	[System.ComponentModel.ImmutableObject(true)]
	public class ModeParam
	{
		#region Constructors & Deconstructors
			public ModeParam(DTO.ModeParamDTO dmpUs)
			{
				strName = dmpUs.Name;
				type = dmpUs.Type switch
				{
					DTO.ModeParamDTO.Types.@string => Types.@string,
					DTO.ModeParamDTO.Types.number => Types.number,
					DTO.ModeParamDTO.Types.chanName => Types.chanName,
					_ => throw new Util.Exceptions.UnknownOrInvalidEnum<DTO.ModeParamDTO.Types>(dmpUs.Type,
					"A mode param was loading as part of a predefined database of networks"),
				};
				textDisplayName = new(dmpUs.LocalizedDisplayNames, dmpUs.DefaultDisplayName);
				textDesc = new(dmpUs.LocalizedDesc, dmpUs.DefaultDesc);
				textPostFixLabel = dmpUs.DefaultPostFixLabel == null ? null : new(dmpUs
					.LocalizedPostFixLabel, dmpUs.DefaultPostFixLabel);
				if(type == Types.number)
				{
					iMinForNum = dmpUs.MinForNumber;
					iMaxForNum = dmpUs.MaxForNumber;
				}
			}
		#endregion

		#region Constants
		#endregion

		#region Helper Types
			public enum Types
			{
				@string,
				number,
				chanName
			}
		#endregion

		#region Members
			public readonly string strName;

			public readonly Types type;

			public readonly LocalizedTextSystem textDisplayName;

			public readonly LocalizedTextSystem textDesc;

			public readonly LocalizedTextSystem? textPostFixLabel;

			public readonly int? iMinForNum;

			public readonly int? iMaxForNum;
		#endregion

		#region Properties
			public string Name => strName;

			public Types Type => type;

			public LocalizedTextSystem DisplayName => textDisplayName;

			public LocalizedTextSystem Desc => textDesc;

			public LocalizedTextSystem? PostFixLabel => textPostFixLabel;

			public int? MinForNum => iMinForNum;

			public int? MaxForNum => iMaxForNum;
		#endregion
	}
}