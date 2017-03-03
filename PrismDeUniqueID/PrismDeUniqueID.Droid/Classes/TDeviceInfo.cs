using Android.App;
using Android.Content;
using Android.Telephony;
using Android.Provider;

using Java.Util;
using PrismDeUniqueID.Interfaces;
using Android.Content.Res;

//using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(PrismDeUniqueID.Droid.Classes.TDeviceInfo))]

namespace PrismDeUniqueID.Droid.Classes
{
    class TDeviceInfo : Interfaces.IDeviceInfo
    {
        public string UniqueID
        {
            //get { return GetSerial(); }
            //get { return GetAndroidID(); }
            //get { return GetDeviceID(); }
            get { return GetUUID(); }
        }

        public string Model
        {
            get { return GetModel(); }
        }

        public string Name
        {
            get { return GetName(); }
        }

        public DeviceOrientation Orientation
        {
            get { return GetOrientation(); }
        }


        private string GetSerial()
        {
            return Android.OS.Build.Serial;
        }

        private string GetAndroidID()
        {
            return Settings.Secure.GetString(Application.Context.ApplicationContext.ContentResolver, Settings.Secure.AndroidId);
        }

        private string GetDeviceID()
        {
            // permission:READ_PHONE_STATE
            var telMan = Application.Context.ApplicationContext.GetSystemService(Context.TelephonyService) as TelephonyManager;
            string result = "";
            try
            {
                result = telMan.DeviceId;
            }
            catch (Java.Lang.SecurityException)
            {
                result = "SecurityException";
            }

            return result;
        }

        private string GetUUID()
        {
            var serial = GetSerial();
            var androidID = GetAndroidID();
            var deviceUuid = new UUID(androidID.GetHashCode(), serial.GetHashCode());
            return deviceUuid.ToString();
        }

        private string GetModel()
        {
            return Android.OS.Build.Model;
        }

        private string GetName()
        {
            return "n/a";
            // AndroidÇ…ÇÕëäìñÇ∑ÇÈçÄñ⁄Ç™ñ≥Ç¢ÅcÇÊÇÀÅH
        }

        private DeviceOrientation GetOrientation()
        {
            Resources resources = Resources.System;
            Configuration config = resources.Configuration;
            switch(config.Orientation)
            {
                case Android.Content.Res.Orientation.Landscape: return DeviceOrientation.Landscape;
                case Android.Content.Res.Orientation.Portrait: return DeviceOrientation.Portrait;
                default: return DeviceOrientation.Unknown;
            }
        }
    }
}