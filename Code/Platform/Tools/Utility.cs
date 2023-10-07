// Ignore Spelling: Vals

namespace BestChat.Platform.Tools
{
	public static class Utility
	{
		public static void SwapTwoVals<TypeOfValsToSwap>(ref TypeOfValsToSwap val1, ref TypeOfValsToSwap val2)
		{
			TypeOfValsToSwap temp = val1;

			val1 = val2;

			val2 = temp;
		}
	}
}