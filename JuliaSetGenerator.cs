using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PendleCodeMonkey.FractalExplorer
{
	internal class JuliaSetGenerator
	{
		internal static void GenerateImage(WriteableBitmap wb,
			double cX, double cY, double zoom, double offsetX, double offsetY, int[] palette)
		{
			static int Iterate(double x, double y, double cX, double cY, int maxIterations)
			{
				var x0 = x;
				var y0 = y;
				int iteration = 0;
				while (iteration < maxIterations && x * x + y * y <= 4)
				{
					(x, y) = (x * x - y * y + cX, 2 * x * y + cY);
					iteration++;
				}

				return iteration < maxIterations ? iteration : 0;
			}

			var stride = wb.BackBufferStride;
			var width = wb.PixelWidth;
			var height = wb.PixelHeight;

			double halfWidth = width / 2;
			double halfHeight = height / 2;

			byte[] pixels = new byte[height * width * 4];
			Parallel.For(0, width, i =>
			{
				Parallel.For(0, height, j =>
				{
					double zx = 1.5 * (i - halfWidth) / (zoom * halfWidth) + offsetX;
					double zy = 1.0 * (j - halfHeight) / (zoom * halfHeight) + offsetY;
					int color = palette[Iterate(
						zx,
						zy,
						cX,
						cY,
						palette.Length)];

					int index = j * stride + i * 3;
					pixels[index++] = (byte)(color & 0xff);
					pixels[index++] = (byte)(color >> 8 & 0xff);
					pixels[index++] = (byte)(color >> 16 & 0xff);
				});
			});

			// Update writeable bitmap.
			Int32Rect rect = new(0, 0, width, height);
			wb.WritePixels(rect, pixels, stride, 0);
		}
	}
}
