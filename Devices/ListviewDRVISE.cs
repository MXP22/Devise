using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Devices.Class;
using Newtonsoft.Json.Linq;

namespace Devices
{
    [Activity(Label = "ListviewDRVISE")]
    public class ListviewDRVISE : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListDevise);
            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);

            var s = sharedPreferences.GetString("list", null);
            string toasdevise = sharedPreferences.GetString("devise", null);
            float Montant = sharedPreferences.GetFloat("Montant", 0);
            JObject @object = JObject.Parse(s);
            List<Devi> devisees = new List<Devi>();

                List<JToken> list = @object["result"]["conversion"].Children().ToList();

                for (int i = 0; i < list.Count; i++)
                {
               
               devisees.Add(new Devi(list[i]["to"].ToString(), list[i]["date"].ToString(), Montant * (float)list[i]["rate"],  Montant +" "+toasdevise + " ="));

                }

                ListView listView = FindViewById<ListView>(Resource.Id.listViewConvistisseurDevise);

                //Toast.MakeText(this,, ToastLength.Long).Show();

                listView.Adapter = new HomeScreenAdapter(this, devisees);
            AdView mAdView4 = FindViewById<AdView>(Resource.Id.adViewAA);
            var adRequest4 = new AdRequest.Builder().Build();
            // Start loading the ad.
            mAdView4.LoadAd(adRequest4);

            AdView mAdView5 = FindViewById<AdView>(Resource.Id.adViewBB);
            var adRequest5 = new AdRequest.Builder().Build();
            // Start loading the ad.
            mAdView5.LoadAd(adRequest5);

        }
        }
    
}