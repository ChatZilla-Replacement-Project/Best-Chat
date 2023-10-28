using System;

namespace BestChat.GUI
{
	/// <summary>
	/// Interaction logic for MainWnd.xaml
	/// </summary>
	public partial class MainWnd : System.Windows.Window, System.ComponentModel.INotifyPropertyChanged
	{
		public MainWnd() => InitializeComponent();

		private static PrefsWnd? prefsDlg = null;
		private static IRC.Global.View.NetworkListDlg? networkListDlg = null;
		private static IRC.Global.View.BncListEditor? bncListEditor = null;

		public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);

			treeLogicalSelector.Items.Add(new Platform.TreeData.VisualTreeData(e => new System
				.Windows.Controls.UserControl(), ClientConversation.instance));
		}

		private void OnIrcNetworkListClicked(object objSender, System.Windows.RoutedEventArgs e)
		{
			if(networkListDlg== null)
			{
				networkListDlg = new()
				{
					Owner = this,
				};

				networkListDlg.Show();

				networkListDlg.Closed += OnNetworkListDlgClosed;
			}
			else
				networkListDlg.Activate();
		}

		private void OnFileExitClicked(object objSender, System.Windows.RoutedEventArgs e) => App.Current
			.Shutdown();

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);

			App.Current.Shutdown();
		}

		private void OnPrefsClicked(object objSender, System.Windows.RoutedEventArgs e)
		{
			if(prefsDlg == null)
			{
				prefsDlg = new()
				{
					Owner = this,
				};

				prefsDlg.Show();

				prefsDlg.Closed += OnPrefsDlgClosed;
			}
			else
				prefsDlg.Activate();
		}

		private int iZoomLevel = 0;

		private const int iMinZoomLevel = -12;
		private const int iMaxZoomLevel = 10;

		private static readonly System.Collections.Generic.IReadOnlyDictionary<int, double>
			mapZoomLevelToScale = new System.Collections.Generic.SortedDictionary<int, double>()
		{
			[-12] = .5 + 1.0 / 14,
			[-11] = .5 + 1.0 / 13,
			[-10] = .5 + 1.0 / 12,
			[-9] = .5 + 1.0 / 11,
			[-8] = .5 + 1.0 / 10,
			[-7] = .5 + 1.0 / 9,
			[-6] = .5 + 1.0 / 8,
			[-5] = .5 + 1.0 / 7,
			[-4] = .5 + 1.0 / 6,
			[-3] = .5 + 1.0 / 5,
			[-2] = .5 + 1.0 / 4,
			[-1] = .5 + 1.0 / 3,
			[0] = 1,
			[1] = 1.1,
			[2] = 1.2,
			[3] = 1.3,
			[4] = 1.4,
			[5] = 1.5,
			[6] = 1.6,
			[7] = 1.7,
			[8] = 1.8,
			[9] = 1.9,
			[10] = 2,
		};

		public System.Windows.GridLength ExtendedToolBarRowTwoHeight
		{
			get
			{
				if(tbExtended == null || chkExtendedToolBarShow == null)
					System.Diagnostics.Debug.WriteLine("Nulls");
				else
					System.Diagnostics.Debug.WriteLine($"Extended: {tbExtended.IsMouseDirectlyOver
						}\tCheckbox: {chkExtendedToolBarShow.IsChecked}");
				return tbExtended != null && chkExtendedToolBarShow != null && (tbExtended.IsMouseDirectlyOver ||
					chkExtendedToolBarShow.IsChecked == true) ? System.Windows.GridLength.Auto : new
					(0);
			}
		}

		private void OnPrefsDlgClosed(object? objSender, System.EventArgs e) => prefsDlg = null;

		private void OnNetworkListDlgClosed(object? objSender, System.EventArgs e) => networkListDlg = null;

		private void OnZoomInClicked(object objSender, System.Windows.RoutedEventArgs e)
		{
			if(iZoomLevel < iMaxZoomLevel)
			{
				iZoomLevel++;

				scale.ScaleX = scale.ScaleY = mapZoomLevelToScale[iZoomLevel];
			}
		}

		private void OnZoomOutClicked(object objSender, System.Windows.RoutedEventArgs e)
		{
			if(iZoomLevel > iMinZoomLevel)
			{
				iZoomLevel--;

				scale.ScaleX = scale.ScaleY = mapZoomLevelToScale[iZoomLevel];
			}
		}

		private void OnFileIrcBouncerListClicked(object objSender, System.Windows.RoutedEventArgs e)
		{

		}


		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused " +
			"parameter", Justification = "Signature must match what's provided by Microsoft")]
		private void OnExtendedToolBarMouseDirectlyOverChanged(object objSender, System.Windows
			.DependencyPropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, new
			(nameof(ExtendedToolBarRowTwoHeight)));

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused " +
			"parameter", Justification = "Signature must match what's provided by Microsoft")]
		private void OnUserChangedIfExtendedToolBarShouldBePinned(object objSender, System.Windows
			.RoutedEventArgs e) => PropertyChanged?.Invoke(this, new
			(nameof(ExtendedToolBarRowTwoHeight)));
	}
}