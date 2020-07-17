//
// GKLeaderBoardSet.cs: Non-generated API for GKLeaderBoard.
//
// Authors:
//   Whitney Schmidt (whschm@microsoft.com)
//
// Copyright 2020, Microsoft Corp. All rights reserved.
//
// The class can be either constructed from a string (from user code)
// or from a handle (from iphone-sharp.dll internal calls).  This
// delays the creation of the actual managed string until actually
// required
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if !MONOMAC

using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace GameKit {
	public partial class GKLeaderboardSet {

		// Before iOS14, Watch7, and OSX 10.16 `LoadLeaderboards:` must be used (it's the only way to create GKScore)
		//
		// After iOS14 `LoadLeaderBoardsWithHandler:` replace this (new terminology) but we can't use
		// it because it won't be available while executing on earlier release
		//
		// We could continue to use the older one... but we're not 100% sure that their implementation won't
		// start to differ in future releases
		public void LoadLeaderboardsWithHandler (GKLeaderboardsHandler completionHandler)
		{
#if IOS || TVOS
			if (UIKit.UIDevice.CurrentDevice.CheckSystemVersion (14, 0))
#elif WATCH
			if (WatchKit.WKInterfaceDevice.CurrentDevice.CheckSystemVersion (7, 0))
#elif MONOMAC
			if (PlatformHelper.CheckSystemVersion (10, 16))
#endif
				LoadLeaderboardsWithCompletionHandler (completionHandler);
			else
				LoadLeaderboards (completionHandler);
		}
	}
}

#endif // !MONOMAC
