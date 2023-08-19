using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PendleCodeMonkey.FractalExplorer
{
	internal class MandelbrotGenerator
	{
		internal static void GenerateImage(WriteableBitmap wb,
			double startX, double startY, double step, int[] palette)
		{
			static int Iterate(double x, double y, int maxIterations)
			{
				var x0 = x;
				var y0 = y;
				int iteration = 0;
				while (iteration < maxIterations && x * x + y * y <= 4)
				{
					(x, y) = (x * x - y * y + x0, 2 * x * y + y0);
					iteration++;
				}

				return iteration < maxIterations ? iteration : 0;
			}

			var stride = wb.BackBufferStride;
			var width = wb.PixelWidth;
			var height = wb.PixelHeight;

			byte[] pixels = new byte[height * width * 4];
			Parallel.For(0, height, j =>
			{
				Parallel.For(0, width, i =>
				{
					int color = palette[Iterate(
						startX + i * step,
						startY + j * step,
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
