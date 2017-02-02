using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDeUniqueID.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismDeUniqueID.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IDeviceInfo _deviceInfo;

        private string _uniqueid;
        public string UniqueID
        {
            get { return _uniqueid; }
            set { SetProperty(ref _uniqueid, value); }
        }

        public ICommand GetCommand { get; }

        public MainPageViewModel(IDeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
            GetCommand = new DelegateCommand(GetID);
        }

        private void GetID()
        {
            UniqueID = _deviceInfo.UniqueID;
        }
    }
}
