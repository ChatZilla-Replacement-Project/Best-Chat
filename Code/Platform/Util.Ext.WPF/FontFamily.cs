// Ignore Spelling: Util iptr

using System.Linq;

namespace BestChat.Util.Ext.WPF
{
	public static class FontFamily
	{
		static FontFamily()
		{
			foreach(System.Windows.Media.FontFamily ffCurSystem in System.Windows.Media.Fonts
					.GetFontFamilies(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts)))
				mapKnownFontFamiliesByName[ffCurSystem.GetPlainName()] = ffCurSystem;

			LogFont lfSearchParam = new();
			using(System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(nint.Zero))
			{
				_ = EnumFontFamiliesEx(graphics.GetHdc(), ref lfSearchParam, OnCallBackOnFontInfo, nint.Zero,
					0);

				foreach(System.Windows.Media.FontFamily ffCurMissing in mapKnownFontFamiliesByName.Values
					.Where((System.Windows.Media.FontFamily ffCurMissing) => !mapKnownFontTypes
					.ContainsKey(ffCurMissing.GetPlainName())))
				{
					lfSearchParam.strFaceName = ffCurMissing.GetPlainName();

					try
					{
						_ = EnumFontFamiliesEx(graphics.GetHdc(), ref lfSearchParam, OnCallBackOnFontInfo, nint.Zero,
							0);
					}
					catch(System.Exception e)
					{
						System.Diagnostics.Debug.WriteLine($"Can't get font type for family '{ffCurMissing
							.GetPlainName()}'.  Assuming it's variable width.  Exception was {e.Message}.");

						mapKnownFontTypes[ffCurMissing.GetPlainName()] = false;
					}
				}
			}
		}

		public static string GetPlainName(this System.Windows.Media.FontFamily ffToGetNameFor) =>
			ffToGetNameFor.Source.IndexOf('#') > -1 ? ffToGetNameFor.Source.Split('#')[1] :
			ffToGetNameFor.Source;

		public static bool FontIsFixedWidth(this System.Windows.Media.FontFamily ffToCheck) =>
			mapKnownFontTypes[ffToCheck.GetPlainName()];

		private static readonly System.Collections.Generic.SortedDictionary<string, bool> mapKnownFontTypes =
			new();

		private static readonly System.Collections.Generic.SortedDictionary<string, System.Windows.Media
			.FontFamily> mapKnownFontFamiliesByName = new();


		private static bool OnCallBackOnFontInfo(ref LogFont lfInfo, nint iptrTextMetric, FontTypes ft, nint
			iptrParam)
		{
			if(mapKnownFontFamiliesByName.ContainsKey(lfInfo.strFaceName))
				mapKnownFontTypes[lfInfo.strFaceName] = lfInfo.IsFixedWidth;

			return true;
		}

		private delegate bool DEnumFontEx(ref LogFont lfInfo, nint ptrTextMetric, FontTypes ft, nint
			iptrParam);

		[System.Runtime.InteropServices.DllImport("gdi32.dll", SetLastError =true, CharSet = System
			.Runtime.InteropServices.CharSet.Unicode)]
		static extern int EnumFontFamiliesEx(nint hdc, [System.Runtime.InteropServices.In] ref LogFont
			lfSearchParam, DEnumFontEx procEnumFontFamEx, nint iptrParam, uint uiFlags);

		// if we specify CharSet.Auto instead of CharSet.Ansi, then the string will be unreadable
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime
			.InteropServices.CharSet.Auto)]
		public struct LogFont
		{
			public int iHeight;
			public int iWidth;
			public int iEscapement;
			public int iOrientation;
			public Weights weight;
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
			public bool bItalic;
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
			public bool bUnderline;
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
			public bool bStrikeOut;
			public CharSets charSet;
			public Precisions outPrecision;
			public ClipPrecisions clipPrecision;
			public Qualities quality;
			public PitchesAndFamilies pitchAndFamily;
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,
				SizeConst = 32)]
			public string strFaceName;

			public override string ToString()
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append("LOGFONT\n");
				sb.AppendFormat("   lfHeight: {0}\n", iHeight);
				sb.AppendFormat("   lfWidth: {0}\n", iWidth);
				sb.AppendFormat("   lfEscapement: {0}\n", iEscapement);
				sb.AppendFormat("   lfOrientation: {0}\n", iOrientation);
				sb.AppendFormat("   lfWeight: {0}\n", weight);
				sb.AppendFormat("   lfItalic: {0}\n", bItalic);
				sb.AppendFormat("   lfUnderline: {0}\n", bUnderline);
				sb.AppendFormat("   lfStrikeOut: {0}\n", bStrikeOut);
				sb.AppendFormat("   lfCharSet: {0}\n", charSet);
				sb.AppendFormat("   lfOutPrecision: {0}\n", outPrecision);
				sb.AppendFormat("   lfClipPrecision: {0}\n", clipPrecision);
				sb.AppendFormat("   lfQuality: {0}\n", quality);
				sb.AppendFormat("   lfPitchAndFamily: {0}\n", pitchAndFamily);
				sb.AppendFormat("   lfFaceName: {0}\n", strFaceName);

				return sb.ToString();
			}

			public bool IsFixedWidth => pitchAndFamily.HasFlag(PitchesAndFamilies.fixed_);

			public enum Weights : int
			{
				dontCare = 0,
				thin = 100,
				extraLight = 200,
				light = 300,
				normal = 400,
				medium = 500,
				semiBold = 600,
				bold = 700,
				extraBold = 800,
				heavy = 900,
			}

			public enum CharSets : byte
			{
				ansi = 0,
				@default = 1,
				symbol = 2,
				shiftJIS = 128,
				hangeul = 129,
				hangul = 129,
				gb2312 = 134,
				chineseBig5 = 136,
				oem = 255,
				johab = 130,
				hebrew = 177,
				arabic = 178,
				greek = 161,
				turkish = 162,
				vietnamese = 163,
				thai = 222,
				eastEurope = 238,
				russian = 204,
				mac = 77,
				bastic = 186,
			}

			public enum Precisions : byte
			{
				@default = 0,
				@string = 1,
				@char = 2,
				stroke = 3,
				tt = 4,
				dev = 5,
				raster = 6,
				ttOnly = 7,
				outline = 8,
				scrOutline = 9,
				psOnly = 10,
			}

			public enum ClipPrecisions : byte
			{
				@default = 0,
				@char = 1,
				stroke = 2,
				mask = 0xf,
				lhAngles = 1 << 4,
				ttAlways = 2 << 4,
				dfaDisable = 4 << 4,
				embedded = 8 << 4,
			}

			public enum Qualities : byte
			{
				@default = 0,
				draft = 1,
				proof = 2,
				nonAntiAliased = 3,
				antiAliased = 4,
				clearType = 5,
				clearTypeNatural = 6,
			}

			[System.Flags]
			public enum PitchesAndFamilies : byte
			{
				@default = 0,
				fixed_ = 1,
				variable = 2,
				dontCare = 0 << 4,
				roman = 1 << 4,
				swiss = 2 << 4,
				modern = 3 << 4,
				script = 4 << 4,
				decorative = 5 << 4,
			}
		}

		[System.Flags]
		public enum FontTypes
		{
			any = unknown | trueType | ps,

			unknown = 1,
			trueType = 4,
			ps = 2
		}
	}
}