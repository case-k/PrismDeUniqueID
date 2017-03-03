using PrismDeUniqueID.Interfaces;
using Xamarin.Forms;

namespace PrismDeUniqueID.Views
{
    public partial class MainPage : ContentPage
    {
        private IDeviceInfo _deviceInfo;

        public MainPage(IDeviceInfo deviceInfo)
        {
            InitializeComponent();
            _deviceInfo = deviceInfo;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            lblOrientation.Text = "Orientation：" + _deviceInfo.Orientation.ToString();

            base.OnSizeAllocated(width, height);
        }
    }
}
