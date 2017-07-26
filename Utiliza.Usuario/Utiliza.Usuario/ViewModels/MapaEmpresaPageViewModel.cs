using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.GoogleMaps;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class MapaEmpresaPageViewModel : BaseViewModel
    {
        public MapaEmpresaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private CameraUpdate _position;
        public CameraUpdate position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        private Position _posisaoPinFornecedor;
        public Position posisaoPinFornecedor
        {
            get => _posisaoPinFornecedor;
            set => SetProperty(ref _posisaoPinFornecedor, value);
        }


        private string _nomeFornecedor;
        public string nomeFornecedor
        {
            get => _nomeFornecedor;
            set => SetProperty(ref _nomeFornecedor, value);
        }
        private string _telefoneFornecedor;
        public string telefoneFornecedor
        {
            get => _telefoneFornecedor;
            set => SetProperty(ref _telefoneFornecedor, value);
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

        #region Método para recuperar parâmetros
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));
            //_idFornecedor = id;


            var _fornecedor = new FornecedorService().GetFornecedor(id);

            _position = CameraUpdateFactory.NewPositionZoom(new Position(_fornecedor.Latitude, _fornecedor.Longitude), 15d);

            posisaoPinFornecedor = new Position(_fornecedor.Latitude, _fornecedor.Longitude);

            nomeFornecedor = _fornecedor.NomeFantasia;
            var telefonePrincipal = new TelefoneService().TelefonePrincipalDofornecedor(id);
            telefoneFornecedor = $"({telefonePrincipal.CodigoArea }) {telefonePrincipal.NumeroTelefone}";

        }

        #endregion

    }
}
