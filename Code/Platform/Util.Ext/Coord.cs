// Ignore Spelling: Util Coord

namespace BestChat.Util.Ext
{
	public static class Coord
	{
		public static System.Drawing.Point GetCenter(this System.Drawing.Rectangle rect) => new System.Drawing.Point(rect.Left + rect.Width / 2, rect.Top +
			rect.Height / 2);

		public static System.Drawing.Rectangle FromCenter(this System.Drawing.Point ptCenter, System.Drawing.Size size) => new System.Drawing.Rectangle(ptCenter.X -
			size.Width / 2, ptCenter.Y - size.Height / 2, size.Width, size.Height);

		public static System.Drawing.Rectangle FromCenter(this System.Drawing.Size sizeCenter, System.Drawing.Size size) => new System.Drawing.Rectangle(sizeCenter
			.Width - size.Width / 2, sizeCenter.Height - size.Height / 2, size.Width, size.Height);

		public static System.Drawing.PointF GetCenter(this System.Drawing.RectangleF rect) => new System.Drawing.PointF(rect.Left + rect.Width / 2, rect.Top +
			rect.Height / 2);

		public static System.Drawing.RectangleF FromCenter(this System.Drawing.PointF ptCenter, System.Drawing.Size size) => new System.Drawing.RectangleF(ptCenter
			.X - size.Width / 2, ptCenter.Y - size.Height / 2, size.Width, size.Height);

		public static System.Drawing.RectangleF FromCenter(this System.Drawing.SizeF sizeCenter, System.Drawing.Size size) => new System.Drawing
			.RectangleF(sizeCenter.Width - size.Width / 2, sizeCenter.Height - size.Height / 2, size.Width, size.Height);

		public static System.Windows.Point GetCenter(this System.Windows.Rect rect) => new System.Windows.Point(rect.Left + rect.Width / 2, rect.Top + rect.Height
			/ 2);

		public static System.Windows.Rect FromCenter(this System.Windows.Point ptCenter, System.Windows.Size size) => new System.Windows.Rect(ptCenter
			.X - size.Width / 2, ptCenter.Y - size.Height / 2, size.Width, size.Height);

		public static System.Windows.Rect FromCenter(this System.Windows.Size ptCenter, System.Windows.Size size) => new System.Windows.Rect(ptCenter
			.Width - size.Width / 2, ptCenter.Height - size.Height / 2, size.Width, size.Height);

		public static System.Windows.Rect FromCenter(this System.Windows.Vector ptCenter, System.Windows.Size size) => new System.Windows.Rect(ptCenter
			.X - size.Width / 2, ptCenter.Y - size.Height / 2, size.Width, size.Height);

		public static System.Windows.Rect FromCenter(this System.Windows.Vector ptCenter, System.Windows.Vector size) => new System.Windows.Rect(ptCenter
			.X - size.X / 2, ptCenter.Y - size.Y / 2, size.X, size.Y);

		public static System.Windows.Rect FromCenter(this System.Windows.Size ptCenter, System.Windows.Vector size) => new System.Windows.Rect(ptCenter
			.Width - size.X / 2, ptCenter.Height - size.Y / 2, size.X, size.Y);

		public static System.Windows.Rect ToWinRect(this System.Drawing.Rectangle rectToConvert) => new System.Windows.Rect(rectToConvert.Left, rectToConvert.Top,
			rectToConvert.Width, rectToConvert.Height);

		public static System.Windows.Rect ToWinRect(this System.Drawing.RectangleF rectToConvert) => new System.Windows.Rect(rectToConvert.Left, rectToConvert.Top,
			rectToConvert.Width, rectToConvert.Height);

		public static System.Drawing.RectangleF ToFloatRect(this System.Drawing.RectangleF rectToConvert) => new System.Drawing.RectangleF(rectToConvert.Left,
			rectToConvert.Top, rectToConvert.Width, rectToConvert.Height);

		public static System.Windows.Point ToWinPt(this System.Drawing.Point ptToConvert) => new System.Windows.Point(ptToConvert.X, ptToConvert.Y);

		public static System.Windows.Point ToWinPt(this System.Drawing.PointF ptToConvert) => new System.Windows.Point(ptToConvert.X, ptToConvert.Y);

		public static System.Drawing.PointF ToFloatPt(this System.Drawing.PointF ptToConvert) => new System.Drawing.PointF(ptToConvert.X, ptToConvert.Y);
	}
}