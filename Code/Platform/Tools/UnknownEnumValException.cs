namespace BestChat.Platform.Tools
{
	/// <summary>
	/// Provides an exception for when the value of an <see langword="enum"/> type variable isn't part of a <see langword="switch"/> statement
	/// </summary>
	/// <typeparam name="EnumType">The <see langword="enum"/> type</typeparam>
	public class UnknownEnumValException<EnumType> : System.Exception
		where EnumType : System.Enum
	{
		/// <summary>
		/// Constructs a new instance of <see cref="UnknownEnumValException{EnumType}"/> for the given value found
		/// </summary>
		/// <param name="valFound">Which value was unknown or invalid</param>
		public UnknownEnumValException(EnumType valFound) : base("The value {0} for the type {1} was either invalid or unknown.".Fmt(valFound.GetType().ToString(), valFound)) =>
			this.valFound = valFound;

		/// <summary>
		/// The value found
		/// </summary>
		public readonly EnumType valFound;
	}
}