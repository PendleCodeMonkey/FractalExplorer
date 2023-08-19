using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PendleCodeMonkey.FractalExplorer
{
	/// <summary>
	/// Interaction logic for ColourThemeControl.xaml
	/// </summary>
	public partial class ColourThemeControl : UserControl
	{
		private int[]? _palette = null;

		public static readonly DependencyProperty ThemeNameProperty =
			DependencyProperty.Register(
				name: "ThemeName",
				propertyType: typeof(string),
				ownerType: typeof(ColourThemeControl),
				typeMetadata: new FrameworkPropertyMetadata(defaultValue: "",
					new PropertyChangedCallback(ThemeNameProperty_PropertyChanged)));

		private static void ThemeNameProperty_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			if (obj is ColourThemeControl ctrl)
			{
				ctrl.Render();
			}
		}

		public string ThemeName
		{
			get => (string)GetValue(ThemeNameProperty);
			set => SetValue(ThemeNameProperty, value);
		}

		public ColourThemeControl()
		{
			Loaded += ColourThemeControl_Loaded;
			InitializeComponent();
		}

		private void ColourThemeControl_Loaded(object sender, RoutedEventArgs e)
		{
			Render();
		}

		internal void Render()
		{
			int w = (int)ImageBorder.ActualWidth;
			int h = (int)ImageBorder.ActualHeight;

			if (w == 0 || h == 0)
			{
				return;
			}

			WriteableBitmap bmp = new(
				w,
				h,
				96,
				96,
				PixelFormats.Bgr24,
				null);

			var stride = bmp.BackBufferStride;
			var width = bmp.PixelWidth;
			var height = bmp.PixelHeight;

			_palette = GradientColourTheme.GeneratePalette(ThemeName, width, false, false);

			byte[] pixels = new byte[height * width * 4];
			for (int x = 0; x < width; x++)
			{
				int color = _palette[x];
				byte r = (byte)(color & 0xff);
				byte g = (byte)(color >> 8 & 0xff);
				byte b = (byte)(color >> 16 & 0xff);
				for (int y = 0; y < height; y++)
				{
					int index = y * stride + x * 3;
					pixels[index++] = r;
					pixels[index++] = g;
					pixels[index++] = b;
				}
			}

			// Update writeable bitmap.
			Int32Rect rect = new(0, 0, width, height);
			bmp.WritePixels(rect, pixels, stride, 0);

			img.Source = bmp;
		}

		private void ImageBorder_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			Render();
		}
	}
}
