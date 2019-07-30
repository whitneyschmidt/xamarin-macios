﻿//
// Unit tests for HKCategoryTypeIdentifier
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2014 Xamarin Inc. All rights reserved.
//

#if !__TVOS__ && !MONOMAC

using System;

#if XAMCORE_2_0
using Foundation;
using HealthKit;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.HealthKit;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.HealthKit {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class CategoryTypeIdentifier {

		[Test]
		public void EnumValues_22351 ()
		{
			TestRuntime.AssertXcodeVersion (6, 0);

			foreach (HKCategoryTypeIdentifier value in Enum.GetValues (typeof (HKCategoryTypeIdentifier))) {

				switch (value) {
				case HKCategoryTypeIdentifier.SleepAnalysis:
					break;
				case HKCategoryTypeIdentifier.MindfulSession:
					if (!TestRuntime.CheckXcodeVersion (8, 0))
						continue;
					break;
				case HKCategoryTypeIdentifier.HighHeartRateEvent:
				case HKCategoryTypeIdentifier.LowHeartRateEvent:
				case HKCategoryTypeIdentifier.IrregularHeartRhythmEvent:
					if (!TestRuntime.CheckXcodeVersion (10, 2))
						continue;
					break;
                case HKCategoryTypeIdentifier.AudioExposureEvent:
					if (!TestRuntime.CheckXcodeVersion (13, 0))
						continue;
					break;
				default:
					if (!TestRuntime.CheckXcodeVersion (7, 0))
						continue;
					break;
				}

				try {
					using (var ct = HKCategoryType.Create (value)) {
						Assert.That (ct.Handle, Is.Not.EqualTo (IntPtr.Zero), value.ToString ());
					}
				}
				catch (Exception e) {
					Assert.Fail ("{0} could not be created: {1}", value, e);
				}
			}
		}
	}
}

#endif // !__TVOS__
