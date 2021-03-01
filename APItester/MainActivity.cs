using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System;

namespace APItester
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public EditText url { get; private set; }
        public EditText json { get; private set; }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            url = FindViewById<EditText>(Resource.Id.url);
            json = FindViewById<EditText>(Resource.Id.json);
            Button button = FindViewById<Button>(Resource.Id.shutoku);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            String apiurl = url.Text;
            WebRequest request = WebRequest.Create(apiurl);
            WebResponse Res = request.GetResponse();
            StreamReader reader = new StreamReader(Res.GetResponseStream(), new UTF8Encoding(false));
            var obj_from_json = JArray.Parse(reader.ReadToEnd());
            json.Text = obj_from_json.ToString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}