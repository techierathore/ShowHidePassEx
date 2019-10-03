using Android.Text.Method;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ShowHidePassEx.Droid.Effects.ShowHidePassEffect), "ShowHidePassEffect")]
namespace ShowHidePassEx.Droid.Effects
{
    public class ShowHidePassEffect : PlatformEffect
	{


		protected override void OnAttached()
		{
			ConfigureControl();
		}

		protected override void OnDetached()
		{
		}

		private void ConfigureControl()
		{
			EditText editText = ((EditText)Control);
			editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.HidePass, 0);
			editText.SetOnTouchListener(new OnDrawableTouchListener());

		}
	}

	public class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
	{
		public bool OnTouch(Android.Views.View v, MotionEvent e)
		{
			if (v is EditText && e.Action == MotionEventActions.Up)
			{
				EditText editText = (EditText)v;
				if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
				{
					if (editText.TransformationMethod == null)
					{
						editText.TransformationMethod = PasswordTransformationMethod.Instance;
                                                editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.HidePass, 0);
			                         editText.SetSelection(editText.Length());
					}
					else
					{
						editText.TransformationMethod = null;
                                               editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.ShowPass, 0);
			                       editText.SetSelection(editText.Length());
					}

					return true;
				}
			}

			return false;
		}
	}
}
