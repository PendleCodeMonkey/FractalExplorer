using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PendleCodeMonkey.FractalExplorer
{
	internal class DataModel : INotifyPropertyChanged
	{
		private FractalType _fractalType;
		private double _juliaCReal;
		private double _juliaCImg;
		private int _maxIterations;
		private List<string> _themeNames;
		private string _selectedThemeName;
		private bool _reverseColours;
		private bool _forceBlackAsFirstColour;

		public FractalType FractalType
		{
			get
			{
				return _fractalType;
			}

			set
			{
				if (value != _fractalType)
				{
					_fractalType = value;
					NotifyPropertyChanged();
				}
			}
		}

		public double JuliaCReal
		{
			get
			{
				return _juliaCReal;
			}

			set
			{
				if (value != _juliaCReal)
				{
					_juliaCReal = value;
					NotifyPropertyChanged();
				}
			}
		}

		public double JuliaCImg
		{
			get
			{
				return _juliaCImg;
			}

			set
			{
				if (value != _juliaCImg)
				{
					_juliaCImg = value;
					NotifyPropertyChanged();
				}
			}
		}

		public int MaxIterations
		{
			get
			{
				return _maxIterations;
			}

			set
			{
				if (value != _maxIterations)
				{
					_maxIterations = value;
					NotifyPropertyChanged();
				}
			}
		}

		public List<string> ThemeNames
		{
			get
			{
				return _themeNames;
			}

			set
			{
				if (value != _themeNames)
				{
					_themeNames = value;
					NotifyPropertyChanged();
				}
			}
		}

		public string SelectedThemeName
		{
			get
			{
				return _selectedThemeName;
			}

			set
			{
				if (value != _selectedThemeName)
				{
					_selectedThemeName = value;
					NotifyPropertyChanged();
				}
			}
		}

		public bool ReverseColours
		{
			get
			{
				return _reverseColours;
			}

			set
			{
				if (value != _reverseColours)
				{
					_reverseColours = value;
					NotifyPropertyChanged();
				}
			}
		}

		public bool ForceBlackAsFirstColour
		{
			get
			{
				return _forceBlackAsFirstColour;
			}

			set
			{
				if (value != _forceBlackAsFirstColour)
				{
					_forceBlackAsFirstColour = value;
					NotifyPropertyChanged();
				}
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		public DataModel()
		{
			_themeNames = new List<string>();
			_selectedThemeName = string.Empty;
		}

		// This method is called by the Set accessor of each property.  
		// The CallerMemberName attribute that is applied to the optional propertyName  
		// parameter causes the property name of the caller to be substituted as an argument.  
		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
