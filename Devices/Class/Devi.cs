using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Devices.Class
{
    class Devi
    {

        private string drvice;
        private string devise;

        private string datemiseajour;

        private float rAt;
        public Devi(string d, string dateTime, float r,string dr)
        {
            this.devise = d;
            this.datemiseajour = dateTime;
            this.rAt = r;
            this.Drvice = dr;

        }

        public string Devise { get => devise; set => devise = value; }
        public string Datemiseajour { get => datemiseajour; set => datemiseajour = value; }
        public float RAt { get => rAt; set => rAt = value; }
       
        public string Drvice { get => drvice; set => drvice = value; }
    }

}
    