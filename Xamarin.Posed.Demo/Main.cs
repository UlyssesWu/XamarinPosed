using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Xamarin.Posed
{
    [Activity(Name = "xamarin.posed.Main", Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", Icon = "@mipmap/ic_launcher", MainLauncher = true)]
    public class Main : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Xamarin Posed!", Snackbar.LengthLong)
                .SetAction("Action", new MySnackBarClickListener()).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] global::Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        class MySnackBarClickListener : Java.Lang.Object, View.IOnClickListener
        {
            public void OnClick(View v)
            {
                //do nothing!
            }
        }
    }
}
