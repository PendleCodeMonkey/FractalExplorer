using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace PendleCodeMonkey.FractalExplorer
{
	public static class Extensions
	{
		public static T? GetVisualParent<T>(this DependencyObject child) where T : Visual
		{
			while ((child != null) && child is not T)
			{
				child = VisualTreeHelper.GetParent(child);
			}
			return child as T;
		}

		// Save a WriteableBitmap to a file in the specified format.
		public static void Save(this WriteableBitmap wb, string filename, ImageFileType type)
		{
			BitmapEncoder encoder = type switch
			{
				ImageFileType.Jpeg => new JpegBitmapEncoder(),
				ImageFileType.Gif => new GifBitmapEncoder(),
				ImageFileType.Png => new PngBitmapEncoder(),
				ImageFileType.Tiff => new TiffBitmapEncoder(),
				_ => new BmpBitmapEncoder(),
			};
			using FileStream stream = new(filename, FileMode.Create);
			encoder.Frames.Add(BitmapFrame.Create(wb));
			encoder.Save(stream);
		}
	}
}
