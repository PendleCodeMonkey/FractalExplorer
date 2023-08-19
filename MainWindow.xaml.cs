using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PendleCodeMonkey.FractalExplorer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Holds information about the selected zoom region (top-left and bottom-right coordinates)
		/// </summary>
		private class ZoomSelectionEventArgs : EventArgs
		{
			public int StartX { get; init; }
			public int StartY { get; init; }
			public int EndX { get; init; }
			public int EndY { get; init; }

			public ZoomSelectionEventArgs(int startX, int startY, int endX, int endY)
			{
				StartX = startX;
				StartY = startY;
				EndX = endX;
				EndY = endY;
			}
		}

		private readonly DataModel _model;

		private Point MandelbrotDefaultPosMin = new(-2.0, -1.5);
		private Point MandelbrotDefaultPosMax = new(1.5, 1.5);
		private Point JuliaDefaultPosMin = new(-1.5, -1.0);
		private Point JuliaDefaultPosMax = new(1.5, 1.0);

		private Point FixedRatio = new();

		private int _cachedWidth = 0;
		private int _cachedHeight = 0;

		private int[]? _palette = null;

		private Point? _selectionStart = null;
		private Point? _selectionEnd = null;

		private readonly double _initialWindowHeight;
		private readonly double _initialWindowWidth;

		private WriteableBitmap _bmp = new(
			(int)SystemParameters.PrimaryScreenWidth,
			(int)SystemParameters.PrimaryScreenHeight,
			96,
			96,
			PixelFormats.Bgr24,
			null);

		private event ZoomSelectedEventHandler? ZoomSelected;

		private readonly DispatcherTimer _dispatcherTimer;

		private double JuliaSetZoom { get; set; }
		private double JuliaOffsetX { get; set; }
		private double JuliaOffsetY { get; set; }

		private Point DefaultPosMin => _model.FractalType == FractalType.Mandelbrot ? MandelbrotDefaultPosMin : JuliaDefaultPosMin;

		private Point DefaultPosMax => _model.FractalType == FractalType.Mandelbrot ? MandelbrotDefaultPosMax : JuliaDefaultPosMax;

		private Point Centre { get; set; }

		private double MandelbrotStep { get; set; }

		private delegate void ZoomSelectedEventHandler(object sender, ZoomSelectionEventArgs e);

		public static readonly RoutedCommand PresetCmd = new();
		public static readonly RoutedCommand ResetButtonCmd = new();
		public static readonly RoutedCommand SaveButtonCmd = new();
		public static readonly RoutedCommand PresetButtonCmd = new();

		public MainWindow()
		{
			_model = new DataModel
			{
				FractalType = FractalType.Julia,
				JuliaCReal = -0.70176,
				JuliaCImg = -0.3842,
				MaxIterations = 100,
				ThemeNames = GradientColourTheme.ThemeNames(),
				SelectedThemeName = "pcm",
				ReverseColours = false,
				ForceBlackAsFirstColour = true
			};

			SetFixedRatio();

			_cachedHeight = int.MaxValue;
			_cachedWidth = int.MaxValue;
			_palette = GeneratePalette();

			_dispatcherTimer = new DispatcherTimer();
			_dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);

			ZoomSelected += MainWindow_ZoomSelected;

			JuliaSetZoom = 1.0;
			JuliaOffsetX = 0.0;
			JuliaOffsetY = 0.0;

			InitializeComponent();

			_initialWindowHeight = Height;
			_initialWindowWidth = Width;

			DataContext = _model;
		}

		private void SetFixedRatio()
		{
			double xDiff = DefaultPosMax.X - DefaultPosMin.X;
			double yDiff = DefaultPosMax.Y - DefaultPosMin.Y;
			FixedRatio = new Point(yDiff / xDiff, xDiff / yDiff);
			Centre = new Point(DefaultPosMin.X + DefaultPosMax.X, DefaultPosMin.Y + DefaultPosMax.Y);
		}

		private void MainWindow_ZoomSelected(object sender, ZoomSelectionEventArgs e)
		{
			var width = e.EndX - e.StartX;
			var height = e.EndY - e.StartY;
			int selectionCentreX = e.StartX + (width / 2);
			int selectionCentreY = e.StartY + (height / 2);

			if (_model.FractalType == FractalType.Mandelbrot)
			{
				var newStep = MandelbrotStep * (width / ImageBorder.ActualWidth);

				var newCentreX = Centre.X - (((int)ImageBorder.ActualWidth / 2 - selectionCentreX) * MandelbrotStep);
				var newCentreY = Centre.Y - (((int)ImageBorder.ActualHeight / 2 - selectionCentreY) * MandelbrotStep);

				MandelbrotStep = newStep;
				Centre = new Point(newCentreX, newCentreY);
			}
			else
			{
				// Zoom functionality for Julia Set
				double halfWidth = ImageBorder.ActualWidth / 2;
				double halfHeight = ImageBorder.ActualHeight / 2;
				JuliaOffsetX = Centre.X - (1.5 * (((int)halfWidth - selectionCentreX) / (JuliaSetZoom * halfWidth)));
				JuliaOffsetY = Centre.Y - (((int)halfHeight - selectionCentreY) / (JuliaSetZoom * halfHeight));
				Centre = new Point(JuliaOffsetX, JuliaOffsetY);
				JuliaSetZoom *= ImageBorder.ActualHeight / width;
			}
			Render();
		}

		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
			{
				int newMaxIterations = Math.Min((int)(e.Delta > 0 ? 1.1 * _model.MaxIterations : 0.9 * _model.MaxIterations), 2000);
				newMaxIterations = Math.Max(newMaxIterations, 10);
				if (newMaxIterations != _model.MaxIterations)
				{
					_model.MaxIterations = newMaxIterations;
					_palette = GeneratePalette();
				}
			}
			else
			{
				if (_model.FractalType == FractalType.Mandelbrot)
				{
					MandelbrotStep *= e.Delta > 0 ? 0.9 : 1.1;
				}
				else
				{
					JuliaSetZoom *= e.Delta > 0 ? 0.9 : 1.1;
				}
			}

			Render();

			base.OnMouseWheel(e);
		}

		private int[] GeneratePalette()
		{
			return GradientColourTheme.GeneratePalette(_model.SelectedThemeName, _model.MaxIterations, _model.ReverseColours, _model.ForceBlackAsFirstColour);
		}

		private void Render()
		{
			_palette ??= GeneratePalette();

			bool regenerated = false;
			int w = (int)ImageBorder.ActualWidth;
			int h = (int)ImageBorder.ActualHeight;

			// If width or height has changed then regenerate the image
			if (w != _cachedWidth || h != _cachedHeight)
			{
				_cachedWidth = w;
				_cachedHeight = h;
				_bmp = new WriteableBitmap(
						w,
						h,
						96,
						96,
						PixelFormats.Bgr24,
						null);
				regenerated = true;
			}

			if (_model.FractalType == FractalType.Mandelbrot)
			{
				MandelbrotGenerator.GenerateImage(
					_bmp,
					Centre.X - (_bmp.PixelWidth / 2) * MandelbrotStep,
					Centre.Y - (_bmp.PixelHeight / 2) * MandelbrotStep,
					MandelbrotStep,
					_palette);
			}
			else
			{
				JuliaSetGenerator.GenerateImage(
					_bmp,
					_model.JuliaCReal,
					_model.JuliaCImg,
					JuliaSetZoom,
					JuliaOffsetX,
					JuliaOffsetY,
					_palette);
			}

			if (regenerated)
			{
				img.Source = _bmp;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Don't want to allow the window to be resized any smaller than the initial (default) size.
			SetValue(MinWidthProperty, _initialWindowWidth);
			SetValue(MinHeightProperty, _initialWindowHeight);

			UseDefaultSettings();
			Render();
		}

		private void UseDefaultSettings()
		{
			Centre = new Point(DefaultPosMin.X + DefaultPosMax.X, DefaultPosMin.Y + DefaultPosMax.Y);

			// Determine step value that will show the full default range of the Mandelbrot fractal within the bitmap
			// at its current dimensions (i.e. the dimensions of the bitmap's parent Border control)
			double stepx = (DefaultPosMax.X - DefaultPosMin.X) / ImageBorder.ActualWidth;
			double stepy = (DefaultPosMax.Y - DefaultPosMin.Y) / ImageBorder.ActualHeight;
			MandelbrotStep = Math.Max(stepx, stepy);

			JuliaSetZoom = 1.0;
			JuliaOffsetX = 0.0;
			JuliaOffsetY = 0.0;
		}

		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			_selectionStart = e.GetPosition(ParentGrid);
			SelectionRect.Margin = new Thickness(_selectionStart.Value.X, _selectionStart.Value.Y, 0, 0);
			SelectionRect.Width = 0;
			SelectionRect.Height = 0;
			SelectionRect.Visibility = Visibility.Visible;
		}

		private void ParentGrid_MouseMove(object sender, MouseEventArgs e)
		{
			if (_selectionStart != null)
			{
				_selectionEnd = e.GetPosition(ParentGrid);

				var newWidth = (int)(_selectionEnd.Value.X - _selectionStart.Value.X);
				var newHeight = (int)(_selectionEnd.Value.Y - _selectionStart.Value.Y);

				if (newWidth > 0 && newHeight > 0)
				{
					(SelectionRect.Width, SelectionRect.Height) = FixRatio(newWidth, newHeight);
				}
				else
				{
					SelectionRect.Width = 0;
					SelectionRect.Height = 0;
				}
			}
		}

		private void ParentGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (_selectionStart != null && _selectionEnd != null)
			{
				int startX = (int)_selectionStart.Value.X;
				int startY = (int)_selectionStart.Value.Y;
				int endX = (int)_selectionEnd.Value.X;
				int endY = (int)_selectionEnd.Value.Y;

				EndSelection();

				if (endX > startX && endY > startY)
				{
					var (width, height) = FixRatio(endX - startX, endY - startY);
					ZoomSelected?.Invoke(this, new ZoomSelectionEventArgs(startX, startY, startX + width, startY + height));
				}
			}
		}

		private void EndSelection()
		{
			_selectionStart = null;
			_selectionEnd = null;
			SelectionRect.Width = 0;
			SelectionRect.Height = 0;
			SelectionRect.Visibility = Visibility.Hidden;
		}

		private void ParentGrid_MouseLeave(object sender, MouseEventArgs e)
		{
			if (_selectionStart != null)
			{
				EndSelection();
			}
		}

		private (int width, int height) FixRatio(int width, int height)
		{
			if (Math.Abs(width) > Math.Abs(height))
			{
				width = (int)(height * FixedRatio.Y);
			}
			if (Math.Abs(height) > Math.Abs(width))
			{
				height = (int)(width * FixedRatio.X);
			}

			return (width, height);
		}

		private void DelayedRender(double msDelay)
		{
			_dispatcherTimer.IsEnabled = true;
			_dispatcherTimer.Stop();
			_dispatcherTimer.Interval = TimeSpan.FromMilliseconds(msDelay);
			_dispatcherTimer.Start();
		}

		private void DispatcherTimer_Tick(object? sender, EventArgs e)
		{
			_dispatcherTimer.IsEnabled = false;
			Render();
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			DelayedRender(50.0);
		}

		private void FractalTypeRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			UseDefaultSettings();
			SetFixedRatio();
			Render();
		}

		private void CRealTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			DelayedRender(10.0);
		}

		private void CImaginaryTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			DelayedRender(10.0);
		}

		private void MaxIterationsTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			_palette = null;
			DelayedRender(10.0);
		}

		private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			_palette = null;
			DelayedRender(10.0);
		}

		private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
		{
			_palette = null;
			DelayedRender(10.0);
		}

		// CanExecuteRoutedEventHandler for the Reset button command.
		private void ResetButtonCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		// ExecutedRoutedEventHandler for the Reset button command.
		private void ResetButtonCmdExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			UseDefaultSettings();
			Render();
		}

		// CanExecuteRoutedEventHandler for the Select Preset button command.
		private void PresetButtonCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		// ExecutedRoutedEventHandler for the Select Preset button command.
		private void PresetButtonCmdExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (FindResource("PresetContextMenu") is ContextMenu cm)
			{
				cm.PlacementTarget = SelectPresetButton;
				cm.Placement = PlacementMode.Bottom;
				cm.IsOpen = true;
			}
		}

		// CanExecuteRoutedEventHandler for the Save Fractal Image button command.
		private void SaveButtonCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		// ExecutedRoutedEventHandler for the Save Fractal Image button command.
		private void SaveButtonCmdExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			string defaultNamePrefix = (string)Application.Current.FindResource("SaveImageDefaultNamePrefix");
			Microsoft.Win32.SaveFileDialog dlg = new()
			{
				FileName = $"{defaultNamePrefix}{DateTime.Now:yyyyMMddHHmmss}", // Default file name, "Fractal_" followed by current date & time.
				DefaultExt = ".bmp",    // Default to Windows BMP format.
				Filter = (string)Application.Current.FindResource("SaveImageFilter")
			};
			// Show the save file dialog box
			bool? result = dlg.ShowDialog();

			if (result == true)
			{
				// Save fractal image in the format specified by the file extension.
				string filename = dlg.FileName;
				string ext = Path.GetExtension(filename).Replace(".", "").ToLower();
				var type = ext switch
				{
					"gif" => ImageFileType.Gif,
					"jpeg" => ImageFileType.Jpeg,
					"png" => ImageFileType.Png,
					"tiff" => ImageFileType.Tiff,
					_ => ImageFileType.Bmp,
				};
				_bmp.Save(filename, type);
			}
		}

		// CanExecuteRoutedEventHandler for the Preset commands (NOTE: all presets have the same CanExecute handler).
		private void PresetCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		// ExecutedRoutedEventHandler for the Preset commands (NOTE: all presets have the same CmdExecuted handler).
		private void PresetCmdExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			// The CommandParameter indicates which preset command is being executed.
			if (e.Parameter is string param)
			{
				(double cR, double cI) = param switch
				{
					"1" => (0.285, 0.0),
					"2" => (0.285, 0.01),
					"3" => (-0.4, 0.6),
					"4" => (0.45, 0.1428),
					"5" => (-0.70176, -0.3842),
					"6" => (-0.835, -0.2321),
					"7" => (-0.8, 0.156),
					"8" => (-0.7269, 0.1889),
					"9" => (0.0, 0.8),
					"10" => (0.37, 0.1),
					"11" => (0.355, 0.355),
					"12" => (-0.4, -0.59),
					"13" => (0.34, -0.05),
					"14" => (-0.54, 0.54),
					"15" => (0.355534, -0.337292),
					"16" => (0.26, -0.0015),
					"17" => (0.26, -0.0016),
					"18" => (-0.75, 0.37),
					_ => (0.0, 0.0),
				};
				ApplyPreset(cR, cI);
			}
		}

		private void ApplyPreset(double cR, double cI)
		{
			_model.JuliaCReal = cR;
			_model.JuliaCImg = cI;
			DelayedRender(10.0);
		}

	}
}
