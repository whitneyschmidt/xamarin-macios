//
// Copyright 2014 Xamarin Inc
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//

// 'AVAudioFormat' defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable 0660
// 'AVAudioFormat' defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning disable 0661
// In both of these cases, the NSObject Equals/GetHashCode implementation works fine, so we can ignore these warnings.

using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AVFoundation {
	public partial class AVAudioFormat {
		public static bool operator == (AVAudioFormat a, AVAudioFormat b)
		{
			return !(a == b);
		}

		public static bool operator != (AVAudioFormat a, AVAudioFormat b)
		{
			if ((object) a != (object) b)
				return true;
			if ((object) a == null ^ (object) b == null)
				return true;
			return !a.Equals (b);
		}
	}
}
