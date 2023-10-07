// Ignore Spelling: Ctrls evt

namespace BestChat.GUI.Ctrls
{
	/// <summary>
	/// Interaction logic for IntegerUpDown.xaml
	/// </summary>
	public partial class IntegerUpDown : System.Windows.Controls.UserControl
	{
		#region Constructors & Deconstructors
			public IntegerUpDown()
			{
				InitializeComponent();

				if(editCnts.Text == "")
					editCnts.Text = "0";
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			/// <summary>The ValueChanged event is called when the IntegerUpDown of the control changes.</summary>
			public event System.Windows.RoutedEventHandler evtValueChanged
			{
				add => AddHandler(evtValueChangedEvent, value);

				remove => 
				RemoveHandler(evtValueChangedEvent, value);
			}

			/// <summary>The evtIncrease event is called when the IntegerUpDown's Up button is clicked.</summary>
			public event System.Windows.RoutedEventHandler evtIncrease
			{
				add => AddHandler(evtIncreaseEvent, value);

				remove => RemoveHandler(evtIncreaseEvent, value);
			}

			/// <summary>The evtDecrease event is called when the IntegerUpDown's Down button is clicked.</summary>
			public event System.Windows.RoutedEventHandler evtDecrease
			{
				add => AddHandler(evtDecreaseEvent, value);

				remove => RemoveHandler(evtDecreaseEvent, value);
			}
		#endregion

		#region Constants
			#region Dependency Properties
				[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification
					= "Naming convention is different for property listings")]
				public static readonly System.Windows.DependencyProperty MaximumProperty = System.Windows.DependencyProperty
					.Register("Maximum", typeof(int), typeof(IntegerUpDown), new System.Windows
					.UIPropertyMetadata(100));

				[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification
					= "Naming convention is different for property listings")]
				public static readonly System.Windows.DependencyProperty MinimumProperty = System.Windows.DependencyProperty
					.Register("Minimum", typeof(int), typeof(IntegerUpDown), new System.Windows
					.UIPropertyMetadata(0));

				[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification
					= "Naming convention is different for property listings")]
				public static readonly System.Windows.DependencyProperty ValueProperty = System.Windows.DependencyProperty
					.Register("Value", typeof(int), typeof(IntegerUpDown), new System.Windows
					.PropertyMetadata(0, OnSomeValuePropertyChanged));
			#endregion

			#region Routed Events
				private static readonly System.Windows.RoutedEvent evtValueChangedEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtValueChanged), System.Windows.RoutingStrategy.Bubble, typeof(System.Windows
					.RoutedEventHandler), typeof(IntegerUpDown));
				private static readonly System.Windows.RoutedEvent evtIncreaseEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtIncrease), System.Windows.RoutingStrategy.Bubble, typeof(System.Windows
					.RoutedEventHandler), typeof(IntegerUpDown));
				private static readonly System.Windows.RoutedEvent evtDecreaseEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtDecrease), System.Windows.RoutingStrategy.Bubble, typeof(System.Windows
					.RoutedEventHandler), typeof(IntegerUpDown));
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private bool bActionInProgress = false;
		#endregion

		#region Properties
			[System.ComponentModel.DefaultValue(int.MaxValue)]
			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("This is the maximum value the control can be set to.")]
			/// <summary>
			/// Maximum value for the Numeric Up Down control
			/// </summary>
			public int Maximum
			{
				get => (int)GetValue(MaximumProperty);

				set => SetValue(MaximumProperty, value);
			}

			[System.ComponentModel.DefaultValue(int.MinValue)]
			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("This is the minimum value the control can be set to.")]
			/// <summary>
			/// Minimum value of the numeric up down control.
			/// </summary>
			public int Minimum
			{
				get => (int)GetValue(MinimumProperty);

				set => SetValue(MinimumProperty, value);
			}

			[System.ComponentModel.DefaultValue(0)]
			[System.ComponentModel.Category("Common")]
			[System.ComponentModel.Description("This is the current value the control can be set to.")]
			public int Value
			{
				get => (int)GetValue(ValueProperty);

				set
				{
					if(!bActionInProgress)
					{
						bActionInProgress = true;

						editCnts.Text = value.ToString();
						SetValue(ValueProperty, value);

						bActionInProgress = false;
					}
				}
			}
		#endregion

		#region Methods
			private void DoUpAction()
			{
				if(Value < Maximum && !bActionInProgress)
				{
					Value++;
					RaiseEvent(new System.Windows.RoutedEventArgs(evtIncreaseEvent));
				}
			}

			private void DoDownAction()
			{
				if(Value > Minimum && !bActionInProgress)
				{
					Value--;
					RaiseEvent(new System.Windows.RoutedEventArgs(evtDecreaseEvent));
				}
			}
		#endregion

		#region Event Handlers
			private void OnUpClicked(object sender, System.Windows.RoutedEventArgs e) => DoUpAction();
			private void OnDownClicked(object sender, System.Windows.RoutedEventArgs e) => DoDownAction();

			private static void OnSomeValuePropertyChanged(System.Windows.DependencyObject target, System.Windows
				.DependencyPropertyChangedEventArgs e) => ((IntegerUpDown)target).editCnts.Text = e.NewValue.ToString();

			private void OnCtntsTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
			{
				if(!bActionInProgress)
				{
					bActionInProgress = true;

					System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
					if(!int.TryParse(tb.Text, out int iVal))
						tb.Text = Value.ToString();
					if(iVal < Minimum)
						iVal = Minimum;
					if(iVal > Maximum)
						iVal = Maximum;
					Value = iVal;

					RaiseEvent(new System.Windows.RoutedEventArgs(evtValueChangedEvent));

					bActionInProgress = false;
				}
			}

			private void OnCtntsPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
			{
				if(e.IsDown && e.Key == System.Windows.Input.Key.Up && Value < Maximum)
					DoUpAction();
				else if(e.IsDown && e.Key == System.Windows.Input.Key.Down && Value > Minimum)
					DoDownAction();
				else if(e.IsDown && !(e.Key >= System.Windows.Input.Key.D0 && e.Key <= System.Windows.Input.Key.D9 || e.Key >= System.Windows.Input
					.Key.NumPad0 && e.Key <= System.Windows.Input.Key.NumPad9) && e.Key != System.Windows.Input.Key.Left && e.Key != System.Windows
					.Input.Key.Right)
				{
					System.Media.SystemSounds.Beep.Play();

					e.Handled = true;
				}
			}
		#endregion
	}
}