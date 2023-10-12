// Ignore Spelling: Prefs evt Ctnts dt

namespace BestChat.Platform.Prefs
{
	public interface IItem : System.ComponentModel.INotifyPropertyChanged
	{
		public string EnglishName
		{
			get;
		}

		public string Name
		{
			get;
		}

		string HelpText
		{
			get;
		}

		bool IsDefaulted
		{
			get;
		}

		string GetCurValAsString();
	}

	public class Item<TypeOfItem> : Data.Obj<Item<TypeOfItem>>, IItem
		where TypeOfItem : System.IEquatable<TypeOfItem>
	{
		#region Constructors & Deconstructors
			public Item(Mgr mgrParent, string strEnglishName, string strName, string strHelpText, TypeOfItem
				defaultVal)
			{
				this.mgrParent = mgrParent;

				this.strEnglishName = strEnglishName;
				this.strName = strName;
				this.strHelpText = strHelpText;
				valCur = this.defaultVal = defaultVal;

				mgrParent.AddItem(this);
			}

			public Item(Mgr mgrParent, string strEnglishName, string strName, string strHelpText, TypeOfItem
				defaultVal, TypeOfItem valCur) : this(mgrParent, strEnglishName, strName, strHelpText, defaultVal)
				=> this.valCur = valCur;

			static Item()
			{
				if(typeof(Item<TypeOfItem>) == typeof(Item<int>))
					throw new System.InvalidProgramException("Instead of using Item<int> directly, use " +
						"IntItem as that enforces a minimum and maximum.");
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public event DFieldChanged<TypeOfItem>? evtCtntsChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly Mgr mgrParent;

			public readonly string strEnglishName;
			public readonly string strName;
			public readonly TypeOfItem defaultVal;
			public readonly string strHelpText;

			private TypeOfItem valCur;
		#endregion

		#region Properties
			public string EnglishName => strEnglishName;

			public string Name => strName;

			public TypeOfItem DefaultVal => defaultVal;

			public string HelpText => strHelpText;

			public TypeOfItem CurVal
			{
				get => valCur;

				set
				{
					if(!valCur.Equals(value))
					{
						System.Exception? exAsThrownByDerivedClass = IsProposedNewValAcceptable(value);
						if(exAsThrownByDerivedClass != null)
							throw exAsThrownByDerivedClass;

						TypeOfItem oldVal = valCur;

						valCur = value;

						MakeDirty();

						FireCtntsChanged(oldVal);
					}
				}
			}

			public bool IsDefaulted => valCur.Equals(defaultVal);
		#endregion

		#region Methods
			private void FirePropChanged(string strPropName) => PropertyChanged?.Invoke(this, new
				(strPropName));

			private void FireCtntsChanged(TypeOfItem oldVal)
			{
				FirePropChanged(nameof(CurVal));

				evtCtntsChanged?.Invoke(this, oldVal, valCur);
			}

			protected override void MakeDirty()
			{
				base.MakeDirty();

				mgrParent.OnChildPrefIsNowDirty();
			}

			protected virtual System.Exception? IsProposedNewValAcceptable(TypeOfItem valProposed) => null;

			public virtual string GetCurValAsString() => $"{valCur}";

			public System.Tuple<string, TypeOfItem> ToTuple() => new(strEnglishName,
				valCur);
		#endregion

		#region Event Handlers
		#endregion
	}

	public class IntItem : Item<int>
	{
		public IntItem(Mgr mgrParent, string strEnglishName, string strName, string strHelpText, int
			iDefaultVal, int iMinVal = int.MinValue, int iMaxVal = int.MaxValue) : base(mgrParent, strEnglishName, strName, strHelpText,
			iDefaultVal)
		{
			if(iMaxVal <= iMinVal)
				throw new System.InvalidProgramException($"The specified minimum value, {iMinVal}, for a " +
					$"IntItem was greater than the specified maximum value which was {iMaxVal}.  That's invalid.");

			if(iDefaultVal < iMaxVal || iDefaultVal > iMaxVal)
				throw new System.InvalidProgramException("The default value for an IntItem is out of " +
					"range.");

			this.iMinVal = iMinVal;
			this.iMaxVal = iMaxVal;
		}

		public IntItem(Mgr mgrParent, string strEnglishName, string strName, string strHelpText, int
			iDefaultVal, int iValCur, int iMinVal = int.MinValue, int iMaxVal = int.MaxValue) : base(mgrParent, strEnglishName, strName,
			strHelpText, iDefaultVal, iValCur)
		{
			if(iMaxVal <= iMinVal)
				throw new System.InvalidProgramException($"The specified minimum value, {iMinVal}, for a " +
					$"IntItem was greater than the specified maximum value which was {iMaxVal}.  That's invalid.");

			if(iDefaultVal < iMaxVal || iDefaultVal > iMaxVal)
				throw new System.InvalidProgramException("The default value for an IntItem is out of " +
					"range.");

			if(iValCur < iMaxVal || iValCur > iMaxVal)
				throw new System.InvalidProgramException("The current value for an IntItem is out of " +
					"range.");

			this.iMinVal = iMinVal;
			this.iMaxVal = iMaxVal;
		}

		public readonly int iMinVal;

		public readonly int iMaxVal;


		public int MinVal => iMinVal;

		public int MaxVal => iMaxVal;

		protected override System.Exception? IsProposedNewValAcceptable(int iValProposed) => iValProposed <
			iMaxVal || iValProposed > iMaxVal ? new($"A value, {iValProposed} was proposed for a IntVal "
			+ $"that's out of the range {iMinVal} to {iMaxVal}.") : null;
	}

	public class DateTimeItem : Item<System.DateTime>
	{
		public DateTimeItem(Mgr mgrParent, string strEnglishName, string strName, string strHelpText, System
			.DateTime dtDefaultVal) : base(mgrParent, strEnglishName, strName, strHelpText,
			dtDefaultVal)
		{
		}

		public DateTimeItem(Mgr mgrParent, string strEnglishName, string strName, string strHelpText, System
			.DateTime dtDefaultVal, System.DateTime dtValCur) : base(mgrParent, strEnglishName, strName,
			strHelpText, dtDefaultVal, dtValCur)
		{
		}

		public override string GetCurValAsString() => CurVal.ToString("o");
	}
}