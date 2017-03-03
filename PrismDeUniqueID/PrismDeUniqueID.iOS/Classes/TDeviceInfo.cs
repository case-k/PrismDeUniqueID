using PrismDeUniqueID.Interfaces;
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


        private string GetUniqueID()
        {
            return UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }

        private string GetModel()
        {
            return UIKit.UIDevice.CurrentDevice.Model;
        }

        private string GetName()
        {
            return UIKit.UIDevice.CurrentDevice.Name;
        }

        private DeviceOrientation GetOrientation()
        {
            var orientation = UIKit.UIApplication.SharedApplication.StatusBarOrientation;
            switch (orientation)
            {
                case UIKit.UIInterfaceOrientation.Portrait: return DeviceOrientation.Portrait;
                case UIKit.UIInterfaceOrientation.PortraitUpsideDown: return DeviceOrientation.Portrait;
                case UIKit.UIInterfaceOrientation.LandscapeRight: return DeviceOrientation.Landscape;
                case UIKit.UIInterfaceOrientation.LandscapeLeft: return DeviceOrientation.Landscape;
                default: return DeviceOrientation.Unknown;
            }
        }
    }
}
