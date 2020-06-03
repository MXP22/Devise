using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using RestSharp;
using System;
using Android.Content;
using Android.Preferences;
using Android.Views;
using Android.Gms.Ads;
using Xamarin.Essentials;


namespace Devices
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, Icon = "@drawable/Sanstitre")]
    public class MainActivity : Activity
    {
        string toast;
        string fd;

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            toast = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

        }


        protected override void OnCreate(Bundle savedInstanceState)
        {

            try
            {


                try
                {

                    base.OnCreate(savedInstanceState);
                    // Set our view from the "main" layout resource
                    SetContentView(Resource.Layout.Index);

                    var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                    toolbar.SetTitleTextColor(Android.Graphics.Color.White);

                    SetActionBar(toolbar);
                    ActionBar.Title = "Devise change";





                }
                catch (Exception ex)
                {

                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

                }
                AdView mAdView1 = FindViewById<AdView>(Resource.Id.adView1);
                var adRequest1 = new AdRequest.Builder().Build();
                // Start loading the ad.
                mAdView1.LoadAd(adRequest1);

                AdView mAdView3 = FindViewById<AdView>(Resource.Id.adView3);


                var adRequest3 = new AdRequest.Builder().Build();
                //Start loading the ad.
                mAdView3.LoadAd(adRequest3);

                AdView mAdView4 = FindViewById<AdView>(Resource.Id.adView4);
                var adRequest4 = new AdRequest.Builder().Build();
                // Start loading the ad.
                mAdView4.LoadAd(adRequest4);

                var textmontant = FindViewById<EditText>(Resource.Id.editText1);

                textmontant.Text = 1.ToString();
                var butn = FindViewById<Button>(Resource.Id.button1);

                var spinner = FindViewById<Spinner>(Resource.Id.spinner1);
                spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
                var adapter = ArrayAdapter.CreateFromResource(
                        this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spinner.Adapter = adapter;



                string url = "http://api.devises.zone/v1/full/" + toast + "/json?key=2227|hFWKNwVfSN14EiA5xhqjsEHzvYaT%2A8S%2A";



                butn.Click += delegate
                {




                    var client = new RestClient("http://api.devises.zone/v1/full/" + toast + "/json?key=2227|hFWKNwVfSN14EiA5xhqjsEHzvYaT%2A8S%2A");
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Connection", "keep-alive");
                    request.AddHeader("Accept-Encoding", "gzip, deflate");
                    request.AddHeader("Cookie", "__cfduid=db3e435404b255aba6b181ac8b0c243491564005682");
                    request.AddHeader("Host", "api.devises.zone");
                    request.AddHeader("Postman-Token", "7118d2bc-51de-44e0-8377-993a99f14f6c,f3379cba-9f7b-4112-8bfe-f49525d750b0");
                    request.AddHeader("Cache-Control", "no-cache");
                    request.AddHeader("Accept", "*/*");
                    request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
                    request.AddHeader("Content-Type", "application/json");
                    IRestResponse response = client.Execute(request);


                    var Vile = response.Content;
                    float val = 0;










                    val = float.Parse(textmontant.Text);
                    ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
                    ISharedPreferencesEditor editor = sharedPreferences.Edit();
                    editor.PutString("list", Vile);
                    editor.PutString("devise", toast);
                    editor.PutFloat("Montant", val);
                    editor.Apply();


                    if (Vile == "")
                    {

                        Toast.MakeText(this, "check your network", ToastLength.Long).Show();
                    }
                    else
                    {
                        Intent intentT = new Intent(this, typeof(ListviewDRVISE));

                        StartActivity(intentT);

                    }


                };




            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

            }
        }
    }
}
