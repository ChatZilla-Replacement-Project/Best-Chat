// Ignore Spelling: Ctrl

namespace BestChat.Util.Ext.WPF
{
	public static class FrameworkElement
	{
		public static System.Windows.Window FindTopLevelOwner(this System.Windows.DependencyObject do_) => do_ == null
			? throw new System.ArgumentNullException(nameof(do_), "While looking for the top level owner of a WPF " +
			"control.") : System.Windows.Window.GetWindow(do_);
	}
}