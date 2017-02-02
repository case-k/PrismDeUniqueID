using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(PrismDeUniqueID.iOS.Classes.TDeviceInfo))]

namespace PrismDeUniqueID.iOS.Classes
{
    class TDeviceInfo : Interfaces.IDeviceInfo
    {
        public string UniqueID
        {
            get { return GetUniqueID(); }
        } 


        private string GetUniqueID()
        {
            return UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }
    }
}
