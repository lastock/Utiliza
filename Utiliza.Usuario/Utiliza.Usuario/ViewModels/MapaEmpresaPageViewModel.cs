using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.GoogleMaps;

namespace Utiliza.Usuario.ViewModels
{
    public class MapaEmpresaPageViewModel : BaseViewModel
    {
        public MapaEmpresaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _position = CameraUpdateFactory.NewPositionZoom(new Position(-23.343091d, -46.574892d), 15d);
        }
        private CameraUpdate _position;

        public CameraUpdate position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }
        //private IList<Pin> _pins;

        //public IList<Pin> pins
        //{
        //    get => _pins;
        //    set => SetProperty(ref _pins, value);
        //}

        //private  void CriaPins()
        //{
        //    //await Task.Delay(1000);
        //    var pin = new Pin()
        //    {
        //        Type = PinType.Place,
        //        Label = "Total Dog",
        //        Address = "(11) 99935-1364",
        //        Position = new Position(-23.343091d, -46.574892d),
        //    };
        //    _pins.Add(pin);
        //}

    }
}
