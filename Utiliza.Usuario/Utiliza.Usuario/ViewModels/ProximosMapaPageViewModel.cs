using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms.GoogleMaps;

namespace Utiliza.Usuario.ViewModels
{
    public class ProximosMapaPageViewModel : BaseViewModel
    {
        public ProximosMapaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _position = CameraUpdateFactory.NewPositionZoom(new Position(-23.343091d, -46.574892d), 15d);
        }
        private CameraUpdate _position;

        public CameraUpdate position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

    }
}
