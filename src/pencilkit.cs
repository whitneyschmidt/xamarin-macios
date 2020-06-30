//
// PencilKit C# bindings
//
// Authors:
//	Whitney Schmidt  <whschm@microsoft.com>
//
// Copyright 2020 Microsoft Corporation All rights reserved.
//

#if MONOMAC
using AppKit;
using UIColor = AppKit.NSColor;
using UIImage = AppKit.NSImage;

using UIScrollViewDelegate = Foundation.NSObjectProtocol;
using UIScrollView = Foundation.NSObject;
using UIGestureRecognizer = Foundation.NSObject;
using UIResponder = Foundation.NSObject;
using UIView = Foundation.NSObject;
using UIWindow = Foundation.NSObject;
using UIUserInterfaceStyle = Foundation.NSObject;
using UIBezierPath = Foundation.NSObject;
#else
using UIKit;
using NSBezierPath = Foundation.NSObject;
#endif

using System;
using ObjCRuntime;
using Foundation;
using CoreGraphics;

namespace PencilKit {

	[iOS (13, 0), Mac (10, 16)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[Native]
	enum PKEraserType : long {
		Vector,
		Bitmap,
	}

	[iOS (13, 0), Mac (10, 16)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	enum PKInkType {
		[Field ("PKInkTypePen")]
		Pen,

		[Field ("PKInkTypePencil")]
		Pencil,

		[Field ("PKInkTypeMarker")]
		Marker,
	}

	[iOS (14, 0), NoMac]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[Native]
	enum PKCanvasViewDrawingPolicy : ulong
	{
		Default,
		AnyInput,
		PencilOnly,
	}

	[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
	[iOS (13, 0), NoMac]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (NSObject))]
	[Model (AutoGeneratedName = true)] [Protocol]
	interface PKCanvasViewDelegate : UIScrollViewDelegate {

		[Export ("canvasViewDrawingDidChange:")]
		void DrawingDidChange (PKCanvasView canvasView);

		[Export ("canvasViewDidFinishRendering:")]
		void DidFinishRendering (PKCanvasView canvasView);

		[Export ("canvasViewDidBeginUsingTool:")]
		void DidBeginUsingTool (PKCanvasView canvasView);

		[Export ("canvasViewDidEndUsingTool:")]
		void EndUsingTool (PKCanvasView canvasView);
	}

	interface IPKCanvasViewDelegate {}

	[iOS (13, 0), NoMac]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (UIScrollView))]
	interface PKCanvasView : PKToolPickerObserver {

		// This exists in the base class
		// [Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		// NSObject WeakDelegate { get; set; }

		[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
		[Wrap ("WeakDelegate"), NullAllowed, New]
		IPKCanvasViewDelegate Delegate { get; set; }

		[Export ("drawing", ArgumentSemantic.Copy)]
		PKDrawing Drawing { get; set; }

		[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
		[Export ("tool", ArgumentSemantic.Copy)]
		PKTool Tool { get; set; }

		[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
		[Export ("rulerActive")]
		bool RulerActive { [Bind ("isRulerActive")] get; set; }

		[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
		[Export ("drawingGestureRecognizer")]
		UIGestureRecognizer DrawingGestureRecognizer { get; }

		[Introduced (PlatformName.iOS, 13, 0, message: "Use 'drawingPolicy' property instead.")]
		[Deprecated (PlatformName.iOS, 14, 0, message: "Use 'drawingPolicy' property instead.")]
		[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
		[Export ("allowsFingerDrawing")]
		bool AllowsFingerDrawing { get; set; }

		[iOS (14, 0)]
		[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")] // should this line be included? probably...
		[Export ("drawingPolicy", ArgumentSemantic.Assign)]
		PKCanvasViewDrawingPolicy DrawingPolicy { get; set; }
	}

	[iOS (13, 0), Mac (10, 15)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (NSObject))]
	[DesignatedDefaultCtor]
	interface PKDrawing : NSCopying, NSSecureCoding {

		[Field ("PKAppleDrawingTypeIdentifier")]
		NSString AppleDrawingTypeIdentifier { get; }

		[DesignatedInitializer]
		[Export ("initWithData:error:")]
		IntPtr Constructor (NSData data, [NullAllowed] out NSError error);

		[Mac (10, 16), iOS (14, 0)]
		[Export ("initWithStrokes:")]
		IntPtr Constructor (PKStroke[] strokes);

		[Export ("dataRepresentation")]
		NSData DataRepresentation { get; }

		[Export ("bounds")]
		CGRect Bounds { get; }

		[Mac (10, 16), iOS (14, 0)]
		[Export ("strokes")]
		PKStroke[] Strokes { get; }

		[Export ("imageFromRect:scale:")]
		UIImage GetImage (CGRect rect, nfloat scale);

		[Export ("drawingByApplyingTransform:")]
		PKDrawing GetDrawing (CGAffineTransform transform);

		[Export ("drawingByAppendingDrawing:")]
		PKDrawing GetDrawing (PKDrawing drawing);

		[Mac (10, 16), iOS (14, 0)]
		[Export ("drawingByAppendingStrokes:")]
		PKDrawing GetDrawing (PKStroke[] strokes);
	}

	[iOS (13, 0), Mac (10, 16)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (PKTool))]
	[DisableDefaultCtor]
	interface PKEraserTool {

		[Export ("eraserType")]
		PKEraserType EraserType { get; }

		[DesignatedInitializer]
		[Export ("initWithEraserType:")]
		IntPtr Constructor (PKEraserType eraserType);
	}

	[iOS (13, 0), Mac (10, 16)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (PKTool))]
	[DisableDefaultCtor]
	interface PKInkingTool {

		[DesignatedInitializer]
		[Export ("initWithInkType:color:width:")]
		IntPtr Constructor ([BindAs (typeof (PKInkType))] NSString type, UIColor color, nfloat width);

		[Export ("initWithInkType:color:")]
		IntPtr Constructor ([BindAs (typeof (PKInkType))] NSString type, UIColor color);

		[iOS (14, 0)]
		[Export ("initWithInk:width:")]
		IntPtr Constructor (PKInk ink, nfloat width);

		[Static]
		[Export ("defaultWidthForInkType:")]
		nfloat GetDefaultWidth ([BindAs (typeof (PKInkType))] NSString inkType);

		[Static]
		[Export ("minimumWidthForInkType:")]
		nfloat GetMinimumWidth ([BindAs (typeof (PKInkType))] NSString inkType);

		[Static]
		[Export ("maximumWidthForInkType:")]
		nfloat GetMaximumWidth ([BindAs (typeof (PKInkType))] NSString inkType);

		[Export ("inkType")]
		[BindAs (typeof (PKInkType))]
		NSString InkType { get; }

		[Static]
		[Export ("convertColor:fromUserInterfaceStyle:to:")]
		UIColor ConvertColor (UIColor color, UIUserInterfaceStyle fromUserInterfaceStyle, UIUserInterfaceStyle toUserInterfaceStyle);

		[Export ("color")]
		UIColor Color { get; }

		[Export ("width")]
		nfloat Width { get; }

		[iOS (14, 0)]
		[Export ("ink")]
		PKInk Ink { get; }
	}

	[iOS (13, 0), Mac (10, 16)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (PKTool))]
	[DesignatedDefaultCtor]
	interface PKLassoTool {}

	[iOS (13, 0), Mac (10, 16)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PKTool : NSCopying {}

	interface IPKToolPickerObserver {}

	[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
	[iOS (13, 0), NoMac]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[Protocol]
	interface PKToolPickerObserver {

		[Export ("toolPickerSelectedToolDidChange:")]
		void SelectedToolDidChange (PKToolPicker toolPicker);

		[Export ("toolPickerIsRulerActiveDidChange:")]
		void IsRulerActiveDidChange (PKToolPicker toolPicker);

		[Export ("toolPickerVisibilityDidChange:")]
		void VisibilityDidChange (PKToolPicker toolPicker);

		[Export ("toolPickerFramesObscuredDidChange:")]
		void FramesObscuredDidChange (PKToolPicker toolPicker);
	}


	[Unavailable (PlatformName.UIKitForMac), Advice ("This API is not available when using UIKit on macOS.")]
	[iOS (13, 0), NoMac]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface PKToolPicker {

		[iOS (14, 0)]
		[Export ("init")]
		IntPtr Constructor ();

		[Export ("addObserver:")]
		void AddObserver (IPKToolPickerObserver observer);

		[Export ("removeObserver:")]
		void RemoveObserver (IPKToolPickerObserver observer);

		[Export ("setVisible:forFirstResponder:")]
		void SetVisible (bool visible, UIResponder responder);

		[Export ("selectedTool", ArgumentSemantic.Strong)]
		PKTool SelectedTool { get; set; }

		[Export ("rulerActive")]
		bool RulerActive { [Bind ("isRulerActive")] get; set; }

		[Export ("isVisible")]
		bool IsVisible { get; }

		[Export ("frameObscuredInView:")]
		CGRect GetFrameObscured (UIView view);

		[Export ("overrideUserInterfaceStyle", ArgumentSemantic.Assign)]
		UIUserInterfaceStyle OverrideUserInterfaceStyle { get; set; }

		[Export ("colorUserInterfaceStyle", ArgumentSemantic.Assign)]
		UIUserInterfaceStyle ColorUserInterfaceStyle { get; set; }

		[Introduced (PlatformName.iOS, 13, 0, message: "Create individual instances instead.")]
		[Deprecated (PlatformName.iOS, 14, 0, message: "Create individual instances instead.")]
		[Static]
		[return: NullAllowed]
		[Export ("sharedToolPickerForWindow:")]
		PKToolPicker GetSharedToolPicker (UIWindow window);

		[iOS (14, 0)]
		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[Export ("showsDrawingPolicyControls")]
		bool ShowsDrawingPolicyControls { get; set; }

		// !missing-null-allowed! 'System.Void PencilKit.PKToolPicker::set_AutosaveName(System.String)' is missing an [NullAllowed] on parameter #0
		[iOS (14, 0)]
		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[Export ("stateAutosaveName")]
		string stateAutosaveName { get; set; }
	}

	[Mac (10, 16), iOS (14, 0)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof(NSObject))]
	interface PKInk : NSCopying
	{
		[Export ("initWithInkType:color:")]
		[DesignatedInitializer]
		IntPtr Constructor (string type, UIColor color);

		[Export ("inkType")]
		string InkType { get; }

		[Export ("color")]
		UIColor Color { get; }
	}

	[Mac (10, 16), iOS (14, 0)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof(NSObject))]
	interface PKFloatRange : NSCopying
	{
		[Export ("initWithLowerBound:upperBound:")]
		IntPtr Constructor (nfloat lowerBound, nfloat upperBound);

		[Export ("lowerBound")]
		nfloat LowerBound { get; }

		[Export ("upperBound")]
		nfloat UpperBound { get; }
	}

	[Mac (10, 16), iOS (14, 0)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof(NSObject))]
	interface PKStroke : NSCopying
	{
		[NoMac]
		[Export ("initWithInk:strokePath:transform:mask:")]
		IntPtr Constructor (PKInk ink, PKStrokePath path, CGAffineTransform transform, [NullAllowed] UIBezierPath mask);

		[NoiOS]
		[Export ("initWithInk:strokePath:transform:mask:")]
		IntPtr Constructor (PKInk ink, PKStrokePath path, CGAffineTransform transform, [NullAllowed] NSBezierPath mask);

		[Export ("ink")]
		PKInk Ink { get; }

		[Export ("transform")]
		CGAffineTransform Transform { get; }

		[Export ("path")]
		PKStrokePath Path { get; }

#if MONOMAC
		[NoiOS]
		[NullAllowed, Export ("mask")]
		NSBezierPath Mask { get; }
#else
		[NoMac]
		[NullAllowed, Export ("mask")]
		UIBezierPath Mask { get; }
#endif

		[Export ("renderBounds")]
		CGRect RenderBounds { get; }

		[Export ("maskedPathRanges")]
		PKFloatRange[] MaskedPath { get; }
	}

	delegate void PKInterpolatedPointsEnumeratorHandler (PKStrokePoint strokePoint, out bool stop);

	[Mac (10, 16), iOS (14, 0)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof(NSObject))]
	interface PKStrokePath : NSCopying
	{
		[Export ("initWithControlPoints:creationDate:")]
		[DesignatedInitializer]
		IntPtr Constructor (PKStrokePoint[] controlPoints, NSDate creationDate);

		[Export ("count")]
		nuint Count { get; }

		[Export ("creationDate")]
		NSDate CreationDate { get; }

		[Export ("pointAtIndex:")]
		PKStrokePoint PointAtIndex (nuint i);

		[Export ("objectAtIndexedSubscript:")]
		PKStrokePoint GetObjectAtIndexedSubscript (nuint i);

		[Export ("interpolatedLocationAt:")]
		CGPoint GetInterpolatedLocation (nfloat parametricValue);

		[Export ("interpolatedPointAt:")]
		PKStrokePoint GetInterpolatedPoint (nfloat parametricValue);

		// option to add an enum since two of these enumerateInterpolates... share the same signature. Not sure whether this makes sense since only 2/3
		// have the same sig + these aren't constructors.
		[Export ("enumerateInterpolatedPointsInRange:strideByDistance:usingBlock:")]
		void EnumerateInterpolatedPointsByDistance (PKFloatRange range, nfloat distanceStep, PKInterpolatedPointsEnumeratorHandler enumeratorHandler);

		[Export ("enumerateInterpolatedPointsInRange:strideByTime:usingBlock:")]
		void EnumerateInterpolatedPointsByTime (PKFloatRange range, double timeStep, PKInterpolatedPointsEnumeratorHandler enumeratorHandler);

		[Export ("enumerateInterpolatedPointsInRange:strideByParametricStep:usingBlock:")]
		void EnumerateInterpolatedPointsByParametric (PKFloatRange range, nfloat parametricStep, PKInterpolatedPointsEnumeratorHandler enumeratorHandler);

		[Export ("parametricValue:offsetByDistance:")]
		nfloat GetParametricValue (nfloat parametricValue, nfloat distanceStep);

		[Export ("parametricValue:offsetByTime:")]
		nfloat GetParametricValue (nfloat parametricValue, double timeStep);
	}

	[Mac (10, 16), iOS (14, 0)]
	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface PKStrokePoint : NSCopying
	{
		[Export ("initWithLocation:timeOffset:size:opacity:force:azimuth:altitude:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGPoint location, double timeOffset, CGSize size, nfloat opacity, nfloat force, nfloat azimuth, nfloat altitude);

		[Export ("location")]
		CGPoint Location { get; }

		[Export ("timeOffset")]
		double TimeOffset { get; }

		[Export ("size")]
		CGSize Size { get; }

		[Export ("opacity")]
		nfloat Opacity { get; }

		[Export ("azimuth")]
		nfloat Azimuth { get; }

		[Export ("force")]
		nfloat Force { get; }

		[Export ("altitude")]
		nfloat Altitude { get; }
	}
}
