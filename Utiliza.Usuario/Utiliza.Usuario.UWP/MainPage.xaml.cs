using Prism.Unity;
using Microsoft.Practices.Unity;

namespace Utiliza.Usuario.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("RXh0hc3g78jR7OFnFhcV~B9TvamoeWf-0GmCl0OTrRg~AqXVpeWmWWaOv-3TCWmkBNd7s8e6N1fFhzb9VSyGmPGkZx_W7xCdsLxVDM24LJLD");
            LoadApplication(new Utiliza.Usuario.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
