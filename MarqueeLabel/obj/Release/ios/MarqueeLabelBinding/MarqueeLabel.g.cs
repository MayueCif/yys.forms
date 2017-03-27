//
// Auto-generated from generator.cs, do not edit
//
// We keep references to objects, so warning 414 is expected

#pragma warning disable 414

using System;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using UIKit;
using GLKit;
using Metal;
using MapKit;
using ModelIO;
using SceneKit;
using Security;
using AudioUnit;
using CoreVideo;
using CoreMedia;
using QuickLook;
using Foundation;
using CoreMotion;
using ObjCRuntime;
using AddressBook;
using CoreGraphics;
using CoreLocation;
using AVFoundation;
using NewsstandKit;
using CoreAnimation;
using CoreFoundation;

namespace MarqueeLabelBinding {
	[Register("MarqueeLabel", true)]
	public unsafe partial class MarqueeLabel : global::UIKit.UILabel {
		
		[CompilerGenerated]
		static readonly IntPtr class_ptr = Class.GetHandle ("MarqueeLabel");
		
		public override IntPtr ClassHandle { get { return class_ptr; } }
		
		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		public MarqueeLabel () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
			}
		}

		[CompilerGenerated]
		[DesignatedInitializer]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("initWithCoder:")]
		public MarqueeLabel (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;

			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("initWithCoder:"), coder.Handle), "initWithCoder:");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("initWithCoder:"), coder.Handle), "initWithCoder:");
			}
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected MarqueeLabel (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal MarqueeLabel (IntPtr handle) : base (handle)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[Export ("initWithFrame:")]
		[CompilerGenerated]
		public MarqueeLabel (CGRect frame)
			: base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_CGRect (this.Handle, Selector.GetHandle ("initWithFrame:"), frame), "initWithFrame:");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_CGRect (this.SuperHandle, Selector.GetHandle ("initWithFrame:"), frame), "initWithFrame:");
			}
		}
		
		[Export ("initWithFrame:rate:andFadeLength:")]
		[CompilerGenerated]
		public MarqueeLabel (CGRect frame, global::System.nfloat pixelsPerSec, global::System.nfloat fadeLength)
			: base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_CGRect_nfloat_nfloat (this.Handle, Selector.GetHandle ("initWithFrame:rate:andFadeLength:"), frame, pixelsPerSec, fadeLength), "initWithFrame:rate:andFadeLength:");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_CGRect_nfloat_nfloat (this.SuperHandle, Selector.GetHandle ("initWithFrame:rate:andFadeLength:"), frame, pixelsPerSec, fadeLength), "initWithFrame:rate:andFadeLength:");
			}
		}
		
		[Export ("initWithFrame:duration:andFadeLength:")]
		[CompilerGenerated]
		public MarqueeLabel (CGRect frame, global::System.Double scrollDuration, global::System.nfloat fadeLength)
			: base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_CGRect_Double_nfloat (this.Handle, Selector.GetHandle ("initWithFrame:duration:andFadeLength:"), frame, scrollDuration, fadeLength), "initWithFrame:duration:andFadeLength:");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_CGRect_Double_nfloat (this.SuperHandle, Selector.GetHandle ("initWithFrame:duration:andFadeLength:"), frame, scrollDuration, fadeLength), "initWithFrame:duration:andFadeLength:");
			}
		}
		
		[Export ("controllerLabelsShouldAnimate:")]
		[CompilerGenerated]
		public static void ControllerLabelsShouldAnimate (global::UIKit.UIViewController controller)
		{
			if (controller == null)
				throw new ArgumentNullException ("controller");
			global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle ("controllerLabelsShouldAnimate:"), controller.Handle);
		}
		
		[Export ("controllerLabelsShouldLabelize:")]
		[CompilerGenerated]
		public static void ControllerLabelsShouldLabelize (global::UIKit.UIViewController controller)
		{
			if (controller == null)
				throw new ArgumentNullException ("controller");
			global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle ("controllerLabelsShouldLabelize:"), controller.Handle);
		}
		
		[Export ("controllerViewAppearing:")]
		[CompilerGenerated]
		public static void ControllerViewAppearing (global::UIKit.UIViewController controller)
		{
			if (controller == null)
				throw new ArgumentNullException ("controller");
			global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle ("controllerViewAppearing:"), controller.Handle);
		}
		
		[Export ("controllerViewDidAppear:")]
		[CompilerGenerated]
		public static void ControllerViewDidAppear (global::UIKit.UIViewController controller)
		{
			if (controller == null)
				throw new ArgumentNullException ("controller");
			global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle ("controllerViewDidAppear:"), controller.Handle);
		}
		
		[Export ("controllerViewWillAppear:")]
		[CompilerGenerated]
		public static void ControllerViewWillAppear (global::UIKit.UIViewController controller)
		{
			if (controller == null)
				throw new ArgumentNullException ("controller");
			global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle ("controllerViewWillAppear:"), controller.Handle);
		}
		
		[Export ("labelReturnedToHome:")]
		[CompilerGenerated]
		public virtual void LabelReturnedToHome (bool finished)
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("labelReturnedToHome:"), finished);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("labelReturnedToHome:"), finished);
			}
		}
		
		[Export ("labelWillBeginScroll")]
		[CompilerGenerated]
		public virtual void LabelWillBeginScroll ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("labelWillBeginScroll"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("labelWillBeginScroll"));
			}
		}
		
		[Export ("minimizeLabelFrameWithMaximumSize:adjustHeight:")]
		[CompilerGenerated]
		public virtual void MinimizeLabelFrameWithMaximumSize (CGSize maxSize, bool adjustHeight)
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_CGSize_bool (this.Handle, Selector.GetHandle ("minimizeLabelFrameWithMaximumSize:adjustHeight:"), maxSize, adjustHeight);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_CGSize_bool (this.SuperHandle, Selector.GetHandle ("minimizeLabelFrameWithMaximumSize:adjustHeight:"), maxSize, adjustHeight);
			}
		}
		
		[Export ("pauseLabel")]
		[CompilerGenerated]
		public virtual void PauseLabel ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("pauseLabel"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("pauseLabel"));
			}
		}
		
		[Export ("resetLabel")]
		[CompilerGenerated]
		public virtual void ResetLabel ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("resetLabel"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("resetLabel"));
			}
		}
		
		[Export ("restartLabel")]
		[CompilerGenerated]
		public virtual void RestartLabel ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("restartLabel"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("restartLabel"));
			}
		}
		
		[Export ("restartLabelsOfController:")]
		[CompilerGenerated]
		public static void RestartLabelsOfController (global::UIKit.UIViewController controller)
		{
			if (controller == null)
				throw new ArgumentNullException ("controller");
			global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle ("restartLabelsOfController:"), controller.Handle);
		}
		
		[Export ("triggerScrollStart")]
		[CompilerGenerated]
		public virtual void TriggerScrollStart ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("triggerScrollStart"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("triggerScrollStart"));
			}
		}
		
		[Export ("unpauseLabel")]
		[CompilerGenerated]
		public virtual void UnpauseLabel ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("unpauseLabel"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("unpauseLabel"));
			}
		}
		
		[CompilerGenerated]
		public virtual global::UIKit.UIViewAnimationOptions AnimationCurve {
			[Export ("animationCurve", ArgumentSemantic.UnsafeUnretained)]
			get {
				global::UIKit.UIViewAnimationOptions ret;
				if (IsDirectBinding) {
					if (IntPtr.Size == 8) {
						ret = (global::UIKit.UIViewAnimationOptions) global::ApiDefinition.Messaging.UInt64_objc_msgSend (this.Handle, Selector.GetHandle ("animationCurve"));
					} else {
						ret = (global::UIKit.UIViewAnimationOptions) global::ApiDefinition.Messaging.UInt32_objc_msgSend (this.Handle, Selector.GetHandle ("animationCurve"));
					}
				} else {
					if (IntPtr.Size == 8) {
						ret = (global::UIKit.UIViewAnimationOptions) global::ApiDefinition.Messaging.UInt64_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("animationCurve"));
					} else {
						ret = (global::UIKit.UIViewAnimationOptions) global::ApiDefinition.Messaging.UInt32_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("animationCurve"));
					}
				}
				return ret;
			}
			
			[Export ("setAnimationCurve:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					if (IntPtr.Size == 8) {
						global::ApiDefinition.Messaging.void_objc_msgSend_UInt64 (this.Handle, Selector.GetHandle ("setAnimationCurve:"), (UInt64)value);
					} else {
						global::ApiDefinition.Messaging.void_objc_msgSend_UInt32 (this.Handle, Selector.GetHandle ("setAnimationCurve:"), (UInt32)value);
					}
				} else {
					if (IntPtr.Size == 8) {
						global::ApiDefinition.Messaging.void_objc_msgSendSuper_UInt64 (this.SuperHandle, Selector.GetHandle ("setAnimationCurve:"), (UInt64)value);
					} else {
						global::ApiDefinition.Messaging.void_objc_msgSendSuper_UInt32 (this.SuperHandle, Selector.GetHandle ("setAnimationCurve:"), (UInt32)value);
					}
				}
			}
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat AnimationDelay {
			[Export ("animationDelay", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("animationDelay"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("animationDelay"));
				}
			}
			
			[Export ("setAnimationDelay:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setAnimationDelay:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setAnimationDelay:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool AwayFromHome {
			[Export ("awayFromHome")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("awayFromHome"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("awayFromHome"));
				}
			}
			
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat ContinuousMarqueeExtraBuffer {
			[Export ("continuousMarqueeExtraBuffer", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("continuousMarqueeExtraBuffer"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("continuousMarqueeExtraBuffer"));
				}
			}
			
			[Export ("setContinuousMarqueeExtraBuffer:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setContinuousMarqueeExtraBuffer:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setContinuousMarqueeExtraBuffer:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat FadeLength {
			[Export ("fadeLength", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("fadeLength"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("fadeLength"));
				}
			}
			
			[Export ("setFadeLength:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setFadeLength:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setFadeLength:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool HoldScrolling {
			[Export ("holdScrolling")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("holdScrolling"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("holdScrolling"));
				}
			}
			
			[Export ("setHoldScrolling:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setHoldScrolling:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setHoldScrolling:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool IsPaused {
			[Export ("isPaused")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("isPaused"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("isPaused"));
				}
			}
			
		}
		
		[CompilerGenerated]
		public virtual bool Labelize {
			[Export ("labelize")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("labelize"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("labelize"));
				}
			}
			
			[Export ("setLabelize:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setLabelize:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setLabelize:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat LeadingBuffer {
			[Export ("leadingBuffer", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("leadingBuffer"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("leadingBuffer"));
				}
			}
			
			[Export ("setLeadingBuffer:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setLeadingBuffer:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setLeadingBuffer:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual MarqueeType MarqueeType {
			[Export ("marqueeType", ArgumentSemantic.UnsafeUnretained)]
			get {
				MarqueeType ret;
				if (IsDirectBinding) {
					if (IntPtr.Size == 8) {
						ret = (MarqueeType) global::ApiDefinition.Messaging.UInt64_objc_msgSend (this.Handle, Selector.GetHandle ("marqueeType"));
					} else {
						ret = (MarqueeType) global::ApiDefinition.Messaging.UInt32_objc_msgSend (this.Handle, Selector.GetHandle ("marqueeType"));
					}
				} else {
					if (IntPtr.Size == 8) {
						ret = (MarqueeType) global::ApiDefinition.Messaging.UInt64_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("marqueeType"));
					} else {
						ret = (MarqueeType) global::ApiDefinition.Messaging.UInt32_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("marqueeType"));
					}
				}
				return ret;
			}
			
			[Export ("setMarqueeType:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					if (IntPtr.Size == 8) {
						global::ApiDefinition.Messaging.void_objc_msgSend_UInt64 (this.Handle, Selector.GetHandle ("setMarqueeType:"), (UInt64)value);
					} else {
						global::ApiDefinition.Messaging.void_objc_msgSend_UInt32 (this.Handle, Selector.GetHandle ("setMarqueeType:"), (UInt32)value);
					}
				} else {
					if (IntPtr.Size == 8) {
						global::ApiDefinition.Messaging.void_objc_msgSendSuper_UInt64 (this.SuperHandle, Selector.GetHandle ("setMarqueeType:"), (UInt64)value);
					} else {
						global::ApiDefinition.Messaging.void_objc_msgSendSuper_UInt32 (this.SuperHandle, Selector.GetHandle ("setMarqueeType:"), (UInt32)value);
					}
				}
			}
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat Rate {
			[Export ("rate", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("rate"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("rate"));
				}
			}
			
			[Export ("setRate:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setRate:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setRate:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat ScrollDuration {
			[Export ("scrollDuration", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("scrollDuration"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("scrollDuration"));
				}
			}
			
			[Export ("setScrollDuration:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setScrollDuration:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setScrollDuration:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool TapToScroll {
			[Export ("tapToScroll")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("tapToScroll"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("tapToScroll"));
				}
			}
			
			[Export ("setTapToScroll:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setTapToScroll:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setTapToScroll:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual global::System.nfloat TrailingBuffer {
			[Export ("trailingBuffer", ArgumentSemantic.UnsafeUnretained)]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSend (this.Handle, Selector.GetHandle ("trailingBuffer"));
				} else {
					return global::ApiDefinition.Messaging.nfloat_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("trailingBuffer"));
				}
			}
			
			[Export ("setTrailingBuffer:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_nfloat (this.Handle, Selector.GetHandle ("setTrailingBuffer:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_nfloat (this.SuperHandle, Selector.GetHandle ("setTrailingBuffer:"), value);
				}
			}
		}
		
		public partial class MarqueeLabelAppearance : global::UIKit.UILabel.UILabelAppearance {
			protected internal MarqueeLabelAppearance (IntPtr handle) : base (handle) {}
		}
		
		public static new MarqueeLabelAppearance Appearance {
			get { return new MarqueeLabelAppearance (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (class_ptr, ObjCRuntime.Selector.GetHandle ("appearance"))); }
		}
		
		public static new MarqueeLabelAppearance GetAppearance<T> () where T: MarqueeLabel {
			return new MarqueeLabelAppearance (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (Class.GetHandle (typeof (T)), ObjCRuntime.Selector.GetHandle ("appearance")));
		}
		
		public static new MarqueeLabelAppearance AppearanceWhenContainedIn (params Type [] containers)
		{
			return new MarqueeLabelAppearance (UIAppearance.GetAppearance (class_ptr, containers));
		}
		
		public static new MarqueeLabelAppearance GetAppearance (UITraitCollection traits) {
			return new MarqueeLabelAppearance (UIAppearance.GetAppearance (class_ptr, traits));
		}
		
		public static new MarqueeLabelAppearance GetAppearance (UITraitCollection traits, params Type [] containers) {
			return new MarqueeLabelAppearance (UIAppearance.GetAppearance (class_ptr, traits, containers));
		}
		
		public static new MarqueeLabelAppearance GetAppearance<T> (UITraitCollection traits) where T: MarqueeLabel {
			return new MarqueeLabelAppearance (UIAppearance.GetAppearance (Class.GetHandle (typeof (T)), traits));
		}
		
		public static new MarqueeLabelAppearance GetAppearance<T> (UITraitCollection traits, params Type [] containers) where T: MarqueeLabel{
			return new MarqueeLabelAppearance (UIAppearance.GetAppearance (Class.GetHandle (typeof (T)), containers));
		}
		
		
	} /* class MarqueeLabel */
}
