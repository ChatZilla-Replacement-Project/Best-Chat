// Ignore Spelling: Ctrls evt Sel

namespace BestChat.IRC.General.Ctrls
{
	public class HasQComboBox : System.Windows.Controls.ComboBox
	{
		#region Constructors & Deconstructors
			public HasQComboBox()
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
					.DependencyProperty.Register(nameof(SelVal), typeof(bool?), typeof(HasQComboBox));
			#endregion

			#region Routed Events
				public static readonly System.Windows.RoutedEvent evtSelValChangedEvent = System.Windows
					.EventManager.RegisterRoutedEvent(nameof(evtSelValChanged), System.Windows.RoutingStrategy
					.Bubble, typeof(System.Windows.RoutedEventHandler), typeof(HasQComboBox));
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
			public bool? SelVal
			{
				get => SelectedIndex != -1 && Items.Count != 0 && (bool)((System.Windows.Controls
					.Label)Items[SelectedIndex]).Tag;

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
			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				IsEditable = false;
				IsReadOnly = true;

				AddItem(Ctrls.Resources.strHasQFalse, Ctrls.Resources.strHasQFalseTooltip, false);
				AddItem(Ctrls.Resources.strHasQUnknown, Ctrls.Resources.strHasQUnknownTooltip, null);
				AddItem(Ctrls.Resources.strHasQTrue, Ctrls.Resources.strHasQTrueTooltip, true);
			}

			private void AddItem(string strText, string strToolTipText, bool? val)
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