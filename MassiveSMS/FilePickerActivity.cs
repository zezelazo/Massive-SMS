using Android.App;
using Android.OS;
using Android.Support.V4.App;
using com.devlab.massiveSMS.Resources;

namespace com.devlab.massiveSMS
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class FilePickerActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
        }
    }
}
