namespace BestChat.Util.Exceptions
{
	public class UnknownOrInvalidEnum<EnumType> : System.Exception
	{
		#region Constructors & Destructors
			public UnknownOrInvalidEnum(EnumType objFoundThis, string strActionDesc)
			{
				System.Diagnostics.Debug.Assert(strActionDesc != null && strActionDesc.Length > 0);

				this.objFoundThis = objFoundThis;
				this.strActionDesc = strActionDesc;
			}
		#endregion

		// Members
		#region Members
			public readonly EnumType objFoundThis;
			public readonly string strActionDesc;
		#endregion

		// Properties
		#region Properties
			public override string Message
			{
				get
				{
					return string.Format("Unknown or invalid {0} enum value while {1}: {2}", typeof(EnumType).ToString(), strActionDesc, objFoundThis);
				}
			}
		#endregion
	}
}