using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Utiliza.Usuario.ViewModels;
using Utiliza.Usuario.Servicos;
using Prism.Navigation;
using System;

namespace Utiliza.Usuario.Views
{
    public partial class FornecedorMapaPage : ContentPage, INavigationAware
    {
        public FornecedorMapaPage()
        {
            InitializeComponent();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));

            var fornecedor = new FornecedorService().GetFornecedor(id);
            var telefone = new TelefoneService().TelefonePrincipalDofornecedor(fornecedor.IdFornecedor);

            var posicaoInicial = new Position(fornecedor.Latitude, fornecedor.Longitude);

            var cameraUpdate = CameraUpdateFactory.NewPositionZoom(posicaoInicial, 15d);

            map.InitialCameraUpdate = cameraUpdate;

            var pinFornecedor = new Pin()
            {
                Label = fornecedor.NomeFantasia, 
                Address = $"({telefone.CodigoArea}) {telefone.NumeroTelefone}",
                Position = posicaoInicial,
                IsVisible =true
            };
            map.Pins.Add(pinFornecedor);
        }
    }
}
