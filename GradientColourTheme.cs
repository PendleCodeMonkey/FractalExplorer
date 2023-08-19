using System;
using System.Collections.Generic;
using System.Linq;

namespace PendleCodeMonkey.FractalExplorer
{
	internal class GradientColourTheme
	{
		private class Stop
		{
			internal double StopValue { get; set; }
			internal double R { get; set; }
			internal double G { get; set; }
			internal double B { get; set; }
		}

		//
		// Colour theme settings
		//
		private static readonly List<Stop> _aquamarine = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=0.496f, G=1.000f, B=0.828f }
		};

		private static readonly List<Stop> _autumn = new()
		{
			new Stop { StopValue=0f, R=1.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.000f }
		};

		private static readonly List<Stop> _bathymetry = new()
		{
			new Stop { StopValue=0f, R=0.157f, G=0.102f, B=0.173f },
			new Stop { StopValue=0.13f, R=0.231f, G=0.192f, B=0.353f },
			new Stop { StopValue=0.25f, R=0.251f, G=0.298f, B=0.545f },
			new Stop { StopValue=0.38f, R=0.247f, G=0.431f, B=0.592f },
			new Stop { StopValue=0.5f, R=0.282f, G=0.557f, B=0.620f },
			new Stop { StopValue=0.63f, R=0.333f, G=0.682f, B=0.639f },
			new Stop { StopValue=0.75f, R=0.471f, G=0.808f, B=0.639f },
			new Stop { StopValue=0.88f, R=0.733f, G=0.902f, B=0.675f },
			new Stop { StopValue=1f, R=0.992f, G=0.996f, B=0.800f }
		};

		private static readonly List<Stop> _blackbody = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.2f, R=0.902f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.4f, R=0.902f, G=0.824f, B=0.000f },
			new Stop { StopValue=0.7f, R=1.000f, G=1.000f, B=1.000f },
			new Stop { StopValue=1f, R=0.627f, G=0.784f, B=1.000f }
		};

		private static readonly List<Stop> _bluered = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=1.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.000f, B=0.000f }
		};

		private static readonly List<Stop> _blues = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=0.000f, G=0.400f, B=1.000f }
		};

		private static readonly List<Stop> _bone = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.376f, R=0.329f, G=0.329f, B=0.455f },
			new Stop { StopValue=0.753f, R=0.663f, G=0.784f, B=0.784f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=1.000f }
		};

		private static readonly List<Stop> _cdom = new()
		{
			new Stop { StopValue=0f, R=0.184f, G=0.059f, B=0.243f },
			new Stop { StopValue=0.13f, R=0.341f, G=0.090f, B=0.337f },
			new Stop { StopValue=0.25f, R=0.510f, G=0.110f, B=0.388f },
			new Stop { StopValue=0.38f, R=0.671f, G=0.161f, B=0.376f },
			new Stop { StopValue=0.5f, R=0.808f, G=0.263f, B=0.337f },
			new Stop { StopValue=0.63f, R=0.902f, G=0.416f, B=0.329f },
			new Stop { StopValue=0.75f, R=0.949f, G=0.584f, B=0.404f },
			new Stop { StopValue=0.88f, R=0.976f, G=0.757f, B=0.529f },
			new Stop { StopValue=1f, R=0.996f, G=0.929f, B=0.690f }
		};

		private static readonly List<Stop> _chlorophyll = new()
		{
			new Stop { StopValue=0f, R=0.071f, G=0.141f, B=0.078f },
			new Stop { StopValue=0.13f, R=0.098f, G=0.247f, B=0.161f },
			new Stop { StopValue=0.25f, R=0.094f, G=0.357f, B=0.231f },
			new Stop { StopValue=0.38f, R=0.051f, G=0.467f, B=0.282f },
			new Stop { StopValue=0.5f, R=0.071f, G=0.580f, B=0.314f },
			new Stop { StopValue=0.63f, R=0.314f, G=0.678f, B=0.349f },
			new Stop { StopValue=0.75f, R=0.518f, G=0.769f, B=0.478f },
			new Stop { StopValue=0.88f, R=0.686f, G=0.867f, B=0.635f },
			new Stop { StopValue=1f, R=0.843f, G=0.976f, B=0.816f }
		};

		private static readonly List<Stop> _cool = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=1.000f, B=1.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.000f, B=1.000f }
		};

		private static readonly List<Stop> _cool2 = new()
		{
			new Stop { StopValue=0f, R=0.490f, G=0.000f, B=0.702f },
			new Stop { StopValue=0.13f, R=0.455f, G=0.000f, B=0.855f },
			new Stop { StopValue=0.25f, R=0.384f, G=0.290f, B=0.929f },
			new Stop { StopValue=0.38f, R=0.267f, G=0.573f, B=0.906f },
			new Stop { StopValue=0.5f, R=0.000f, G=0.800f, B=0.773f },
			new Stop { StopValue=0.63f, R=0.000f, G=0.969f, B=0.573f },
			new Stop { StopValue=0.75f, R=0.000f, G=1.000f, B=0.345f },
			new Stop { StopValue=0.88f, R=0.157f, G=1.000f, B=0.031f },
			new Stop { StopValue=1f, R=0.576f, G=1.000f, B=0.000f }
		};

		private static readonly List<Stop> _copper = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.804f, R=1.000f, G=0.627f, B=0.400f },
			new Stop { StopValue=1f, R=1.000f, G=0.780f, B=0.498f }
		};

		private static readonly List<Stop> _cubehelix = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.07f, R=0.086f, G=0.020f, B=0.231f },
			new Stop { StopValue=0.13f, R=0.235f, G=0.016f, B=0.412f },
			new Stop { StopValue=0.2f, R=0.427f, G=0.004f, B=0.529f },
			new Stop { StopValue=0.27f, R=0.631f, G=0.000f, B=0.576f },
			new Stop { StopValue=0.33f, R=0.824f, G=0.008f, B=0.557f },
			new Stop { StopValue=0.4f, R=0.984f, G=0.043f, B=0.482f },
			new Stop { StopValue=0.47f, R=1.000f, G=0.114f, B=0.380f },
			new Stop { StopValue=0.53f, R=1.000f, G=0.212f, B=0.271f },
			new Stop { StopValue=0.6f, R=1.000f, G=0.333f, B=0.180f },
			new Stop { StopValue=0.67f, R=1.000f, G=0.471f, B=0.133f },
			new Stop { StopValue=0.73f, R=1.000f, G=0.616f, B=0.145f },
			new Stop { StopValue=0.8f, R=0.945f, G=0.749f, B=0.224f },
			new Stop { StopValue=0.87f, R=0.878f, G=0.863f, B=0.365f },
			new Stop { StopValue=0.93f, R=0.855f, G=0.945f, B=0.557f },
			new Stop { StopValue=1f, R=0.890f, G=0.992f, B=0.776f }
		};

		private static readonly List<Stop> _density = new()
		{
			new Stop { StopValue=0f, R=0.212f, G=0.055f, B=0.141f },
			new Stop { StopValue=0.13f, R=0.349f, G=0.090f, B=0.314f },
			new Stop { StopValue=0.25f, R=0.431f, G=0.176f, B=0.518f },
			new Stop { StopValue=0.38f, R=0.471f, G=0.302f, B=0.698f },
			new Stop { StopValue=0.5f, R=0.471f, G=0.443f, B=0.835f },
			new Stop { StopValue=0.63f, R=0.451f, G=0.592f, B=0.894f },
			new Stop { StopValue=0.75f, R=0.525f, G=0.725f, B=0.890f },
			new Stop { StopValue=0.88f, R=0.694f, G=0.839f, B=0.890f },
			new Stop { StopValue=1f, R=0.902f, G=0.945f, B=0.945f }
		};

		private static readonly List<Stop> _earth = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.510f },
			new Stop { StopValue=0.1f, R=0.000f, G=0.706f, B=0.706f },
			new Stop { StopValue=0.2f, R=0.157f, G=0.824f, B=0.157f },
			new Stop { StopValue=0.4f, R=0.902f, G=0.902f, B=0.196f },
			new Stop { StopValue=0.6f, R=0.471f, G=0.275f, B=0.078f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=1.000f }
		};

		private static readonly List<Stop> _electric = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.15f, R=0.118f, G=0.000f, B=0.392f },
			new Stop { StopValue=0.4f, R=0.471f, G=0.000f, B=0.392f },
			new Stop { StopValue=0.6f, R=0.627f, G=0.353f, B=0.000f },
			new Stop { StopValue=0.8f, R=0.902f, G=0.784f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.980f, B=0.863f }
		};

		private static readonly List<Stop> _freesurface_blue = new()
		{
			new Stop { StopValue=0f, R=0.118f, G=0.016f, B=0.431f },
			new Stop { StopValue=0.13f, R=0.184f, G=0.055f, B=0.690f },
			new Stop { StopValue=0.25f, R=0.161f, G=0.176f, B=0.925f },
			new Stop { StopValue=0.38f, R=0.098f, G=0.388f, B=0.831f },
			new Stop { StopValue=0.5f, R=0.267f, G=0.514f, B=0.784f },
			new Stop { StopValue=0.63f, R=0.447f, G=0.612f, B=0.773f },
			new Stop { StopValue=0.75f, R=0.616f, G=0.710f, B=0.796f },
			new Stop { StopValue=0.88f, R=0.784f, G=0.816f, B=0.847f },
			new Stop { StopValue=1f, R=0.945f, G=0.929f, B=0.925f }
		};

		private static readonly List<Stop> _freesurface_red = new()
		{
			new Stop { StopValue=0f, R=0.235f, G=0.035f, B=0.071f },
			new Stop { StopValue=0.13f, R=0.392f, G=0.067f, B=0.106f },
			new Stop { StopValue=0.25f, R=0.557f, G=0.078f, B=0.114f },
			new Stop { StopValue=0.38f, R=0.694f, G=0.169f, B=0.106f },
			new Stop { StopValue=0.5f, R=0.753f, G=0.341f, B=0.247f },
			new Stop { StopValue=0.63f, R=0.804f, G=0.490f, B=0.412f },
			new Stop { StopValue=0.75f, R=0.847f, G=0.635f, B=0.580f },
			new Stop { StopValue=0.88f, R=0.890f, G=0.780f, B=0.757f },
			new Stop { StopValue=1f, R=0.945f, G=0.929f, B=0.925f }
		};

		private static readonly List<Stop> _golden = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.840f, B=0.000f }
		};

		private static readonly List<Stop> _greens = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.267f, B=0.106f },
			new Stop { StopValue=0.125f, R=0.000f, G=0.427f, B=0.173f },
			new Stop { StopValue=0.25f, R=0.137f, G=0.545f, B=0.271f },
			new Stop { StopValue=0.375f, R=0.255f, G=0.671f, B=0.365f },
			new Stop { StopValue=0.5f, R=0.455f, G=0.769f, B=0.463f },
			new Stop { StopValue=0.625f, R=0.631f, G=0.851f, B=0.608f },
			new Stop { StopValue=0.75f, R=0.780f, G=0.914f, B=0.753f },
			new Stop { StopValue=0.875f, R=0.898f, G=0.961f, B=0.878f },
			new Stop { StopValue=1f, R=0.969f, G=0.988f, B=0.961f }
		};

		private static readonly List<Stop> _greys = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=1.000f }
		};

		private static readonly List<Stop> _hot = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.3f, R=0.902f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.6f, R=1.000f, G=0.824f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=1.000f }
		};

		private static readonly List<Stop> _hotpinks = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.410f, B=0.703f }
		};

		private static readonly List<Stop> _hsv = new()
		{
			new Stop { StopValue=0f, R=1.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.169f, R=0.992f, G=1.000f, B=0.008f },
			new Stop { StopValue=0.173f, R=0.969f, G=1.000f, B=0.008f },
			new Stop { StopValue=0.337f, R=0.000f, G=0.988f, B=0.016f },
			new Stop { StopValue=0.341f, R=0.000f, G=0.988f, B=0.039f },
			new Stop { StopValue=0.506f, R=0.004f, G=0.976f, B=1.000f },
			new Stop { StopValue=0.671f, R=0.008f, G=0.000f, B=0.992f },
			new Stop { StopValue=0.675f, R=0.031f, G=0.000f, B=0.992f },
			new Stop { StopValue=0.839f, R=1.000f, G=0.000f, B=0.984f },
			new Stop { StopValue=0.843f, R=1.000f, G=0.000f, B=0.961f },
			new Stop { StopValue=1f, R=1.000f, G=0.000f, B=0.024f }
		};

		private static readonly List<Stop> _inferno = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.016f },
			new Stop { StopValue=0.13f, R=0.122f, G=0.047f, B=0.282f },
			new Stop { StopValue=0.25f, R=0.333f, G=0.059f, B=0.427f },
			new Stop { StopValue=0.38f, R=0.533f, G=0.133f, B=0.416f },
			new Stop { StopValue=0.5f, R=0.729f, G=0.212f, B=0.333f },
			new Stop { StopValue=0.63f, R=0.890f, G=0.349f, B=0.200f },
			new Stop { StopValue=0.75f, R=0.976f, G=0.549f, B=0.039f },
			new Stop { StopValue=0.88f, R=0.976f, G=0.788f, B=0.196f },
			new Stop { StopValue=1f, R=0.988f, G=1.000f, B=0.643f }
		};

		private static readonly List<Stop> _jet = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.514f },
			new Stop { StopValue=0.125f, R=0.000f, G=0.235f, B=0.667f },
			new Stop { StopValue=0.375f, R=0.020f, G=1.000f, B=1.000f },
			new Stop { StopValue=0.625f, R=1.000f, G=1.000f, B=0.000f },
			new Stop { StopValue=0.875f, R=0.980f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=0.502f, G=0.000f, B=0.000f }
		};

		private static readonly List<Stop> _magma = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.016f },
			new Stop { StopValue=0.13f, R=0.110f, G=0.063f, B=0.267f },
			new Stop { StopValue=0.25f, R=0.310f, G=0.071f, B=0.482f },
			new Stop { StopValue=0.38f, R=0.506f, G=0.145f, B=0.506f },
			new Stop { StopValue=0.5f, R=0.710f, G=0.212f, B=0.478f },
			new Stop { StopValue=0.63f, R=0.898f, G=0.314f, B=0.392f },
			new Stop { StopValue=0.75f, R=0.984f, G=0.529f, B=0.380f },
			new Stop { StopValue=0.88f, R=0.996f, G=0.761f, B=0.529f },
			new Stop { StopValue=1f, R=0.988f, G=0.992f, B=0.749f }
		};

		private static readonly List<Stop> _oranges = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.500f, B=0.250f }
		};

		private static readonly List<Stop> _oxygen = new()
		{
			new Stop { StopValue=0f, R=0.251f, G=0.020f, B=0.020f },
			new Stop { StopValue=0.13f, R=0.416f, G=0.024f, B=0.059f },
			new Stop { StopValue=0.25f, R=0.565f, G=0.102f, B=0.027f },
			new Stop { StopValue=0.38f, R=0.659f, G=0.251f, B=0.012f },
			new Stop { StopValue=0.5f, R=0.737f, G=0.392f, B=0.016f },
			new Stop { StopValue=0.63f, R=0.808f, G=0.533f, B=0.043f },
			new Stop { StopValue=0.75f, R=0.863f, G=0.682f, B=0.098f },
			new Stop { StopValue=0.88f, R=0.906f, G=0.843f, B=0.173f },
			new Stop { StopValue=1f, R=0.973f, G=0.996f, B=0.412f }
		};

		private static readonly List<Stop> _par = new()
		{
			new Stop { StopValue=0f, R=0.200f, G=0.078f, B=0.094f },
			new Stop { StopValue=0.13f, R=0.353f, G=0.125f, B=0.137f },
			new Stop { StopValue=0.25f, R=0.506f, G=0.173f, B=0.133f },
			new Stop { StopValue=0.38f, R=0.624f, G=0.267f, B=0.098f },
			new Stop { StopValue=0.5f, R=0.714f, G=0.388f, B=0.075f },
			new Stop { StopValue=0.63f, R=0.780f, G=0.525f, B=0.086f },
			new Stop { StopValue=0.75f, R=0.831f, G=0.671f, B=0.137f },
			new Stop { StopValue=0.88f, R=0.867f, G=0.824f, B=0.212f },
			new Stop { StopValue=1f, R=0.882f, G=0.992f, B=0.294f }
		};

		private static readonly List<Stop> _pcm = new()
		{
			new Stop {StopValue=0.000f, R=0.000f, G=0.000f, B=0.000f },
			new Stop {StopValue=0.160f, R=0.125f, G=0.420f, B=0.796f },
			new Stop {StopValue=0.420f, R=0.930f, G=1.000f, B=1.000f },
			new Stop {StopValue=0.642f, R=1.000f, G=0.666f, B=0.000f },
			new Stop {StopValue=1.000f, R=0.000f, G=0.000f, B=0.000f },
		};

		private static readonly List<Stop> _phase = new()
		{
			new Stop { StopValue=0f, R=0.569f, G=0.412f, B=0.071f },
			new Stop { StopValue=0.13f, R=0.722f, G=0.278f, B=0.149f },
			new Stop { StopValue=0.25f, R=0.729f, G=0.227f, B=0.451f },
			new Stop { StopValue=0.38f, R=0.627f, G=0.278f, B=0.725f },
			new Stop { StopValue=0.5f, R=0.431f, G=0.380f, B=0.855f },
			new Stop { StopValue=0.63f, R=0.196f, G=0.482f, B=0.643f },
			new Stop { StopValue=0.75f, R=0.122f, G=0.514f, B=0.431f },
			new Stop { StopValue=0.88f, R=0.302f, G=0.506f, B=0.133f },
			new Stop { StopValue=1f, R=0.569f, G=0.412f, B=0.071f }
		};

		private static readonly List<Stop> _picnic = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=1.000f },
			new Stop { StopValue=0.1f, R=0.200f, G=0.600f, B=1.000f },
			new Stop { StopValue=0.2f, R=0.400f, G=0.800f, B=1.000f },
			new Stop { StopValue=0.3f, R=0.600f, G=0.800f, B=1.000f },
			new Stop { StopValue=0.4f, R=0.800f, G=0.800f, B=1.000f },
			new Stop { StopValue=0.5f, R=1.000f, G=1.000f, B=1.000f },
			new Stop { StopValue=0.6f, R=1.000f, G=0.800f, B=1.000f },
			new Stop { StopValue=0.7f, R=1.000f, G=0.600f, B=1.000f },
			new Stop { StopValue=0.8f, R=1.000f, G=0.400f, B=0.800f },
			new Stop { StopValue=0.9f, R=1.000f, G=0.400f, B=0.400f },
			new Stop { StopValue=1f, R=1.000f, G=0.000f, B=0.000f }
		};

		private static readonly List<Stop> _pinks = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.750f, B=0.793f }
		};

		private static readonly List<Stop> _pinkgold = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.75f, R=1.000f, G=0.750f, B=0.793f },
			new Stop { StopValue=1f, R=1.000f, G=0.840f, B=0.000f }
		};

		private static readonly List<Stop> _plasma = new()
		{
			new Stop { StopValue=0f, R=0.051f, G=0.031f, B=0.529f },
			new Stop { StopValue=0.13f, R=0.294f, G=0.012f, B=0.631f },
			new Stop { StopValue=0.25f, R=0.490f, G=0.012f, B=0.659f },
			new Stop { StopValue=0.38f, R=0.659f, G=0.133f, B=0.588f },
			new Stop { StopValue=0.5f, R=0.796f, G=0.275f, B=0.475f },
			new Stop { StopValue=0.63f, R=0.898f, G=0.420f, B=0.365f },
			new Stop { StopValue=0.75f, R=0.973f, G=0.580f, B=0.255f },
			new Stop { StopValue=0.88f, R=0.992f, G=0.765f, B=0.157f },
			new Stop { StopValue=1f, R=0.941f, G=0.976f, B=0.129f }
		};

		private static readonly List<Stop> _portland = new()
		{
			new Stop { StopValue=0f, R=0.047f, G=0.200f, B=0.514f },
			new Stop { StopValue=0.25f, R=0.039f, G=0.533f, B=0.729f },
			new Stop { StopValue=0.5f, R=0.949f, G=0.827f, B=0.220f },
			new Stop { StopValue=0.75f, R=0.949f, G=0.561f, B=0.220f },
			new Stop { StopValue=1f, R=0.851f, G=0.118f, B=0.118f }
		};

		private static readonly List<Stop> _rainbow = new()
		{
			new Stop { StopValue=0f, R=0.588f, G=0.000f, B=0.353f },
			new Stop { StopValue=0.125f, R=0.000f, G=0.000f, B=0.784f },
			new Stop { StopValue=0.25f, R=0.000f, G=0.098f, B=1.000f },
			new Stop { StopValue=0.375f, R=0.000f, G=0.596f, B=1.000f },
			new Stop { StopValue=0.5f, R=0.173f, G=1.000f, B=0.588f },
			new Stop { StopValue=0.625f, R=0.592f, G=1.000f, B=0.000f },
			new Stop { StopValue=0.75f, R=1.000f, G=0.918f, B=0.000f },
			new Stop { StopValue=0.875f, R=1.000f, G=0.435f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.000f, B=0.000f }
		};

		private static readonly List<Stop> _rainbow_soft = new()
		{
			new Stop { StopValue=0f, R=0.490f, G=0.000f, B=0.702f },
			new Stop { StopValue=0.1f, R=0.780f, G=0.000f, B=0.706f },
			new Stop { StopValue=0.2f, R=1.000f, G=0.000f, B=0.475f },
			new Stop { StopValue=0.3f, R=1.000f, G=0.424f, B=0.000f },
			new Stop { StopValue=0.4f, R=0.871f, G=0.761f, B=0.000f },
			new Stop { StopValue=0.5f, R=0.588f, G=1.000f, B=0.000f },
			new Stop { StopValue=0.6f, R=0.000f, G=1.000f, B=0.216f },
			new Stop { StopValue=0.7f, R=0.000f, G=0.965f, B=0.588f },
			new Stop { StopValue=0.8f, R=0.196f, G=0.655f, B=0.871f },
			new Stop { StopValue=0.9f, R=0.404f, G=0.200f, B=0.922f },
			new Stop { StopValue=1f, R=0.486f, G=0.000f, B=0.729f }
		};

		private static readonly List<Stop> _rdbu = new()
		{
			new Stop { StopValue=0f, R=0.020f, G=0.039f, B=0.675f },
			new Stop { StopValue=0.35f, R=0.416f, G=0.537f, B=0.969f },
			new Stop { StopValue=0.5f, R=0.745f, G=0.745f, B=0.745f },
			new Stop { StopValue=0.6f, R=0.863f, G=0.667f, B=0.518f },
			new Stop { StopValue=0.7f, R=0.902f, G=0.569f, B=0.353f },
			new Stop { StopValue=1f, R=0.698f, G=0.039f, B=0.110f }
		};

		private static readonly List<Stop> _reds = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.000f, B=0.000f }
		};

		private static readonly List<Stop> _salinity = new()
		{
			new Stop { StopValue=0f, R=0.165f, G=0.094f, B=0.424f },
			new Stop { StopValue=0.13f, R=0.129f, G=0.196f, B=0.635f },
			new Stop { StopValue=0.25f, R=0.059f, G=0.353f, B=0.569f },
			new Stop { StopValue=0.38f, R=0.157f, G=0.463f, B=0.537f },
			new Stop { StopValue=0.5f, R=0.231f, G=0.573f, B=0.529f },
			new Stop { StopValue=0.63f, R=0.310f, G=0.686f, B=0.494f },
			new Stop { StopValue=0.75f, R=0.471f, G=0.796f, B=0.408f },
			new Stop { StopValue=0.88f, R=0.757f, G=0.867f, B=0.392f },
			new Stop { StopValue=1f, R=0.992f, G=0.937f, B=0.604f }
		};

		private static readonly List<Stop> _salmon = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=0.625f, B=0.477f }
		};

		private static readonly List<Stop> _seagreenyellow = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=0.4f, R=0.559f, G=0.734f, B=0.559f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.000f }
		};

		private static readonly List<Stop> _skyblues = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=0.527f, G=0.805f, B=0.918f }
		};

		private static readonly List<Stop> _spring = new()
		{
			new Stop { StopValue=0f, R=1.000f, G=0.000f, B=1.000f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.000f }
		};

		private static readonly List<Stop> _summer = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.502f, B=0.400f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.400f }
		};

		private static readonly List<Stop> _temperature = new()
		{
			new Stop { StopValue=0f, R=0.016f, G=0.137f, B=0.200f },
			new Stop { StopValue=0.13f, R=0.090f, G=0.200f, B=0.478f },
			new Stop { StopValue=0.25f, R=0.333f, G=0.231f, B=0.616f },
			new Stop { StopValue=0.38f, R=0.506f, G=0.310f, B=0.561f },
			new Stop { StopValue=0.5f, R=0.686f, G=0.373f, B=0.510f },
			new Stop { StopValue=0.63f, R=0.871f, G=0.439f, B=0.396f },
			new Stop { StopValue=0.75f, R=0.976f, G=0.573f, B=0.259f },
			new Stop { StopValue=0.88f, R=0.976f, G=0.769f, B=0.255f },
			new Stop { StopValue=1f, R=0.910f, G=0.980f, B=0.357f }
		};

		private static readonly List<Stop> _turbidity = new()
		{
			new Stop { StopValue=0f, R=0.133f, G=0.122f, B=0.106f },
			new Stop { StopValue=0.13f, R=0.255f, G=0.196f, B=0.161f },
			new Stop { StopValue=0.25f, R=0.384f, G=0.271f, B=0.204f },
			new Stop { StopValue=0.38f, R=0.514f, G=0.349f, B=0.224f },
			new Stop { StopValue=0.5f, R=0.631f, G=0.439f, B=0.231f },
			new Stop { StopValue=0.63f, R=0.725f, G=0.549f, B=0.259f },
			new Stop { StopValue=0.75f, R=0.792f, G=0.682f, B=0.345f },
			new Stop { StopValue=0.88f, R=0.847f, G=0.820f, B=0.494f },
			new Stop { StopValue=1f, R=0.914f, G=0.965f, B=0.671f }
		};

		private static readonly List<Stop> _velocity_blue = new()
		{
			new Stop { StopValue=0f, R=0.067f, G=0.125f, B=0.251f },
			new Stop { StopValue=0.13f, R=0.137f, G=0.204f, B=0.455f },
			new Stop { StopValue=0.25f, R=0.114f, G=0.318f, B=0.612f },
			new Stop { StopValue=0.38f, R=0.122f, G=0.443f, B=0.635f },
			new Stop { StopValue=0.5f, R=0.196f, G=0.565f, B=0.663f },
			new Stop { StopValue=0.63f, R=0.341f, G=0.678f, B=0.690f },
			new Stop { StopValue=0.75f, R=0.584f, G=0.769f, B=0.741f },
			new Stop { StopValue=0.88f, R=0.796f, G=0.867f, B=0.827f },
			new Stop { StopValue=1f, R=0.996f, G=0.984f, B=0.902f }
		};

		private static readonly List<Stop> _velocity_green = new()
		{
			new Stop { StopValue=0f, R=0.090f, G=0.137f, B=0.075f },
			new Stop { StopValue=0.13f, R=0.094f, G=0.251f, B=0.149f },
			new Stop { StopValue=0.25f, R=0.043f, G=0.373f, B=0.176f },
			new Stop { StopValue=0.38f, R=0.153f, G=0.482f, B=0.137f },
			new Stop { StopValue=0.5f, R=0.373f, G=0.573f, B=0.047f },
			new Stop { StopValue=0.63f, R=0.596f, G=0.647f, B=0.071f },
			new Stop { StopValue=0.75f, R=0.788f, G=0.729f, B=0.271f },
			new Stop { StopValue=0.88f, R=0.914f, G=0.847f, B=0.537f },
			new Stop { StopValue=1f, R=1.000f, G=0.992f, B=0.804f }
		};

		private static readonly List<Stop> _viridis = new()
		{
			new Stop { StopValue=0f, R=0.267f, G=0.004f, B=0.329f },
			new Stop { StopValue=0.13f, R=0.278f, G=0.173f, B=0.478f },
			new Stop { StopValue=0.25f, R=0.231f, G=0.318f, B=0.545f },
			new Stop { StopValue=0.38f, R=0.173f, G=0.443f, B=0.557f },
			new Stop { StopValue=0.5f, R=0.129f, G=0.565f, B=0.553f },
			new Stop { StopValue=0.63f, R=0.153f, G=0.678f, B=0.506f },
			new Stop { StopValue=0.75f, R=0.361f, G=0.784f, B=0.388f },
			new Stop { StopValue=0.88f, R=0.667f, G=0.863f, B=0.196f },
			new Stop { StopValue=1f, R=0.992f, G=0.906f, B=0.145f }
		};

		private static readonly List<Stop> _warm = new()
		{
			new Stop { StopValue=0f, R=0.490f, G=0.000f, B=0.702f },
			new Stop { StopValue=0.13f, R=0.675f, G=0.000f, B=0.733f },
			new Stop { StopValue=0.25f, R=0.859f, G=0.000f, B=0.667f },
			new Stop { StopValue=0.38f, R=1.000f, G=0.000f, B=0.510f },
			new Stop { StopValue=0.5f, R=1.000f, G=0.247f, B=0.290f },
			new Stop { StopValue=0.63f, R=1.000f, G=0.482f, B=0.000f },
			new Stop { StopValue=0.75f, R=0.918f, G=0.690f, B=0.000f },
			new Stop { StopValue=0.88f, R=0.745f, G=0.894f, B=0.000f },
			new Stop { StopValue=1f, R=0.576f, G=1.000f, B=0.000f }
		};

		private static readonly List<Stop> _winter = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=1.000f },
			new Stop { StopValue=1f, R=0.000f, G=1.000f, B=0.502f }
		};

		private static readonly List<Stop> _yellows = new()
		{
			new Stop { StopValue=0f, R=0.000f, G=0.000f, B=0.000f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.000f }
		};

		private static readonly List<Stop> _yignbu = new()
		{
			new Stop { StopValue=0f, R=0.031f, G=0.114f, B=0.345f },
			new Stop { StopValue=0.125f, R=0.145f, G=0.204f, B=0.580f },
			new Stop { StopValue=0.25f, R=0.133f, G=0.369f, B=0.659f },
			new Stop { StopValue=0.375f, R=0.114f, G=0.569f, B=0.753f },
			new Stop { StopValue=0.5f, R=0.255f, G=0.714f, B=0.769f },
			new Stop { StopValue=0.625f, R=0.498f, G=0.804f, B=0.733f },
			new Stop { StopValue=0.75f, R=0.780f, G=0.914f, B=0.706f },
			new Stop { StopValue=0.875f, R=0.929f, G=0.973f, B=0.851f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.851f }
		};

		private static readonly List<Stop> _yiorrd = new()
		{
			new Stop { StopValue=0f, R=0.502f, G=0.000f, B=0.149f },
			new Stop { StopValue=0.125f, R=0.741f, G=0.000f, B=0.149f },
			new Stop { StopValue=0.25f, R=0.890f, G=0.102f, B=0.110f },
			new Stop { StopValue=0.375f, R=0.988f, G=0.306f, B=0.165f },
			new Stop { StopValue=0.5f, R=0.992f, G=0.553f, B=0.235f },
			new Stop { StopValue=0.625f, R=0.996f, G=0.698f, B=0.298f },
			new Stop { StopValue=0.75f, R=0.996f, G=0.851f, B=0.463f },
			new Stop { StopValue=0.875f, R=1.000f, G=0.929f, B=0.627f },
			new Stop { StopValue=1f, R=1.000f, G=1.000f, B=0.800f }
		};

		// Dictionary that maps theme names to their corresponding theme settings.
		private static readonly Dictionary<string, List<Stop>> colourThemes = new()
		{
			{ "aquamarine", _aquamarine },
			{ "autumn", _autumn },
			{ "bathymetry", _bathymetry },
			{ "blackbody", _blackbody },
			{ "bluered", _bluered },
			{ "blues", _blues },
			{ "bone", _bone },
			{ "cdom", _cdom },
			{ "chlorophyll", _chlorophyll },
			{ "cool", _cool },
			{ "cool2", _cool2 },
			{ "copper", _copper },
			{ "cubehelix", _cubehelix },
			{ "density", _density },
			{ "earth", _earth },
			{ "electric", _electric },
			{ "freesurface_blue", _freesurface_blue },
			{ "freesurface_red", _freesurface_red },
			{ "golden", _golden },
			{ "greens", _greens },
			{ "greys", _greys },
			{ "hot", _hot },
			{ "hotpinks", _hotpinks },
			{ "hsv", _hsv },
			{ "inferno", _inferno },
			{ "jet", _jet },
			{ "magma", _magma },
			{ "oranges", _oranges },
			{ "oxygen", _oxygen },
			{ "par", _par },
			{ "pcm", _pcm },
			{ "phase", _phase },
			{ "picnic", _picnic },
			{ "pinks", _pinks },
			{ "pinkgold", _pinkgold },
			{ "plasma", _plasma },
			{ "portland", _portland },
			{ "rainbow", _rainbow },
			{ "rainbow_soft", _rainbow_soft },
			{ "rdbu", _rdbu },
			{ "reds", _reds },
			{ "salinity", _salinity },
			{ "salmon", _salmon },
			{ "seagreenyellow", _seagreenyellow },
			{ "skyblues", _skyblues },
			{ "spring", _spring },
			{ "summer", _summer },
			{ "temperature", _temperature },
			{ "turbidity", _turbidity },
			{ "velocity_blue", _velocity_blue },
			{ "velocity_green", _velocity_green },
			{ "viridis", _viridis },
			{ "warm", _warm },
			{ "winter", _winter },
			{ "yellows", _yellows },
			{ "yignbu", _yignbu },
			{ "yiorrd", _yiorrd }
		};

		// Generates a colour palette of a required size (as specified by the maxIterations parameter) using the theme with
		// the specified name.
		// Additional (optional) boolean parameters allow the caller to specify if the palette should be reversed and if the
		// first colour in the palette should be forced to Black (which can give improved colour display, particularly when
		// used to colour a Mandelbrot set)
		internal static int[] GeneratePalette(string themeName, int maxIterations, bool reverse = false, bool forceBlackAsFirstColour = true)
		{
			// Local function that gets an integer representation of the colour (with the RBG values encoded into an integer) at
			// the specified floating point position on the gradient scale of 0.0 to 1.0
			static int GetColour(float gradientPos, List<Stop> gradientStops)
			{
				gradientPos = Math.Min(gradientPos, 1.0f);
				var gs0 = gradientStops[0];
				for (int i = 1; i <= gradientStops.Count - 1; i++)
				{
					var gs1 = gradientStops[i];
					if (gradientPos >= gs0.StopValue && gradientPos <= gs1.StopValue)
					{
						var pos = (gradientPos - gs0.StopValue) / (gs1.StopValue - gs0.StopValue);
						var rpos = 1 - pos;
						return
							(byte)((rpos * gs0.B + pos * gs1.B) * 255) |
							(byte)((rpos * gs0.G + pos * gs1.G) * 255) << 8 |
							(byte)((rpos * gs0.R + pos * gs1.R) * 255) << 16;
					}
					gs0 = gs1;
				}

				return 0;
			}

			var x = new int[maxIterations];
			if (colourThemes.ContainsKey(themeName))
			{
				var gradientStops = colourThemes[themeName];

				for (int i = 0; i < maxIterations; i++)
				{
					x[i] = GetColour(i / (float)maxIterations, gradientStops);
				}
				if (reverse)
				{
					x = x.Reverse().ToArray();
				}
				if (forceBlackAsFirstColour)
				{
					x[0] = 0;
				}
			}
			return x;
		}

		// Returns the list of colour theme names.
		internal static List<string> ThemeNames()
		{
			return colourThemes.Keys.ToList();
		}
	}
}
