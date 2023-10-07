// Ignore Spelling: Util

namespace BestChat.Util.Ext
{
	public static class Type
	{
		public static bool IsDerivedFrom(this System.Type typeDerivedTypeToTest, System.Type typeBaseTypeToTest) =>
			typeDerivedTypeToTest == null ? throw new System.ArgumentNullException(nameof(typeDerivedTypeToTest),
			"While testing for derivation") : typeDerivedTypeToTest == typeBaseTypeToTest ? true :
			typeDerivedTypeToTest.BaseType == typeBaseTypeToTest ? true : typeDerivedTypeToTest.BaseType == null ? false :
			typeDerivedTypeToTest.BaseType != typeof(object) ? typeDerivedTypeToTest.BaseType
			.IsDerivedFrom(typeBaseTypeToTest) : false;
	}
}