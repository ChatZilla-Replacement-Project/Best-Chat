// Ignore Spelling: Ctrls Serv evt Sel

namespace BestChat.IRC.Global.View.Ctrls
{
	public class NickServOptComboBox : System.Windows.Controls.ComboBox
	{
		#region Constructors & Deconstructors
			public NickServOptComboBox()
			{
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event System.Windows.RoutedEventHandler evtSelValChanged
			{
				add => AddHandler(evtSelValChangedEvent, value);

				remove => RemoveHandler(evtSelValChangedEvent, value);
			}
		#endregion

		#region Constants
			#region Dependency Properties
				public static readonly System.Windows.DependencyProperty SelValProperty = System.Windows
					.DependencyProperty.Register(nameof(SelVal), typeof(Data.Defs.NickServOpts?),
					typeof(NickServOptComboBox));
			#endregion

			#region Routed Events
				public static readonly System.Windows.RoutedEvent evtSelValChangedEvent = System.Windows
					.EventManager.RegisterRoutedEvent(nameof(evtSelValChanged), System.Windows.RoutingStrategy
					.Bubble, typeof(System.Windows.RoutedEventHandler), typeof(NickServOptComboBox));
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
		#endregion

		#region Properties
			[System.ComponentModel.Description("This is the value selected in the combobox in the " +
				"desired type.  Other Selected properties will show you the index or a label object.  Don't use "
				+ "SelectedValue or SelectedItem")]
			[System.ComponentModel.Category("Common")]
			public Data.Defs.NickServOpts? SelVal
			{
				get => SelectedIndex == -1 || Items.Count == 0 ? default : (Data.Defs.NickServOpts)((System
					.Windows.Controls.Label)Items[SelectedIndex]).Tag;

				set
				{
					if(Items.Count == 0)
						SelectedIndex = -1;
					else
					{
						int iIndexOfCurItem = 0;

						foreach(object objCurItem in Items)
						{
							if(objCurItem is System.Windows.Controls.Label labelCurItem && labelCurItem.Tag ==
								(object?)value)
							{
								SelectedIndex = iIndexOfCurItem;

								break;
							}

							iIndexOfCurItem++;
						}
					}
				}
			}
		#endregion

		#region Methods
			private static void GetEnumDesc(object objEnumVal, out string strDesc, out string strExtendedDesc)
			{
				string strEnumValAsStr = objEnumVal.ToString() ?? throw new System
					.InvalidProgramException("Unexpected null");
				System.Reflection.FieldInfo? fieldInfo = objEnumVal.GetType().GetField(strEnumValAsStr) ?? throw
					new System.InvalidProgramException($"Can't find field on instance of type {
					typeof(Data.Defs.NickServOpts).FullName} for {strEnumValAsStr}");

				object[] attribArray = fieldInfo.GetCustomAttributes(typeof(Util.Attr.LocalizedDescAttribute),
					false);

				if(attribArray.Length == 0)
				{
					strDesc =strEnumValAsStr;
					strExtendedDesc = "";
				}
				else
				{
					Util.Attr.LocalizedDescAttribute attrib = (Util.Attr.LocalizedDescAttribute)attribArray[0];

					strDesc = attrib.Description;
					strExtendedDesc = attrib.ExtendedDesc;
				}
			}

			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				IsEditable = false;
				IsReadOnly = true;

				AddItem(Ctrls.Resources.strNickServOptNull, Ctrls.Resources.strNickServOptNullTooltip, null);
				foreach(object objCurNickServOptVal in System.Enum.GetValues(typeof(Data.Defs.NickServOpts)))
				{
					GetEnumDesc(objCurNickServOptVal, out string strText, out string strToolTipText);

					AddItem(strText, strToolTipText, objCurNickServOptVal as Data.Defs.NickServOpts?);
				}
			}

			private void AddItem(string strText, string strToolTipText, Data.Defs.NickServOpts? val)
			{
				System.Windows.Controls.Label labelForCurValInEnumType = new()
				{
					Content = strText,
					ToolTip = strToolTipText,
					Tag = val,
					VerticalAlignment = System.Windows.VerticalAlignment.Center,
					VerticalContentAlignment = System.Windows.VerticalAlignment.Center
				};

				Items.Add(labelForCurValInEnumType);
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}