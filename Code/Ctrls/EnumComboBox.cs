// Ignore Spelling: Ctrl Ctrls evt Sel

namespace BestChat.GUI.Ctrls
{
	public class EnumComboBox<EnumType> : System.Windows.Controls.ComboBox
		where EnumType : System.Enum
	{
		#region Constructors & Deconstructors
			public EnumComboBox()
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
				public static readonly System.Windows.DependencyProperty TypeOfEnumProperty = System.Windows
					.DependencyProperty.Register(nameof(TypeOfEnum), typeof(string), typeof(EnumComboBox<EnumType>),
					new System.Windows.PropertyMetadata(OnEnumTypePropChanged));

				public static readonly System.Windows.DependencyProperty SelValProperty = System.Windows
					.DependencyProperty.Register(nameof(SelVal), typeof(EnumType?), typeof(EnumComboBox<EnumType>));
			#endregion

			#region Routed Events
				public static readonly System.Windows.RoutedEvent evtSelValChangedEvent = System.Windows
					.EventManager.RegisterRoutedEvent(nameof(evtSelValChanged), System.Windows.RoutingStrategy
					.Bubble, typeof(System.Windows.RoutedEventHandler), typeof(EnumComboBox<EnumType>));
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private System.Type? typeOfEnum = null;
		#endregion

		#region Properties
			[System.ComponentModel.Description("This is the enum type that the items are based on.  Each value in that type "
				+ "must have BestChat.Util.Attr.LocalizedDescAttribute applied to it.")]
			[System.ComponentModel.Category("Common")]
			public string TypeOfEnum
			{
				get => (string)GetValue(TypeOfEnumProperty);

				set => SetValue(TypeOfEnumProperty, value);
			}

			[System.ComponentModel.Description("This is the value selected in the combobox in the " +
				"desired type.  Other Selected properties will show you the index or a label object.  Don't use "
				+ "SelectedValue or SelectedItem")]
			[System.ComponentModel.Category("Common")]
			public EnumType? SelVal
			{
				get => SelectedIndex == -1 || Items.Count == 0 ? default : (EnumType)((System.Windows.Controls
					.Label)Items[SelectedIndex]).Tag;

				set
				{
					if(null == value || Items.Count == 0)
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
				string strEnumValAsStr = objEnumVal.ToString() ?? throw new System.InvalidProgramException("Unexpected "
					+ "null");
				System.Reflection.FieldInfo? fieldInfo = objEnumVal.GetType().GetField(strEnumValAsStr) ?? throw new System
					.InvalidProgramException(
					$"Can't find field on instance of type {typeof(EnumType).FullName} for {strEnumValAsStr}");

				object[] attribArray = fieldInfo.GetCustomAttributes(typeof(Util.Attr.LocalizedDescAttribute), false);

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
		#endregion

		#region Event Handlers
			private void OnEnumTypePropChanged(string strNewVal)
			{
				System.Type? typeProposed = System.Type.GetType(strNewVal);

				if(typeProposed == typeOfEnum)
					return;

				if(typeProposed == null || !typeProposed.IsEnum)
					return;

				typeOfEnum = typeProposed;

				foreach(object objCurValInEnumType in typeOfEnum.GetEnumValues())
				{
					GetEnumDesc(objCurValInEnumType, out string strText, out string strTooltip);

					System.Windows.Controls.Label labelForCurValInEnumType = new()
					{
						Content = strText,
						ToolTip = strTooltip,
						Tag = objCurValInEnumType,
						VerticalAlignment = System.Windows.VerticalAlignment.Center,
						VerticalContentAlignment = System.Windows.VerticalAlignment.Center
					};

				Items.Add(labelForCurValInEnumType);
				}
			}

			private static void OnEnumTypePropChanged(System.Windows.DependencyObject ctrlParent, System.Windows
				.DependencyPropertyChangedEventArgs e) => ((EnumComboBox<EnumType>)ctrlParent)
				.OnEnumTypePropChanged((string)e.NewValue);

			protected override void OnSelectionChanged(System.Windows.Controls.SelectionChangedEventArgs e) => base
				.OnSelectionChanged(e);
		#endregion
	}
}