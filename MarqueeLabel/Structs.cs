using System;
using ObjCRuntime;

namespace MarqueeLabelBinding
{
	[Native]
	public enum MarqueeType : ulong
	{
		LeftRight = 0,
		RightLeft,
		Continuous,
		ContinuousReverse
	}
}
