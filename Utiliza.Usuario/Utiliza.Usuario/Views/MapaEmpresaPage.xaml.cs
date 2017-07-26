using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

//using Xamarin.Forms.Maps;

namespace Utiliza.Usuario.Views
{
    public partial class MapaEmpresaPage : ContentPage
    {
        public MapaEmpresaPage()
        {
            InitializeComponent();
            //MyMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //        new Position(37, -122), Distance.FromMiles(1)));

            //var pinFornecedor = new Pin()
            //{
            //    Label = ((MapaEmpresaPageViewModel)this.BindingContext).nomeFornecedor,
            //    Address = ((MapaEmpresaPageViewModel)this.BindingContext).telefoneFornecedor,
            //    Position = new Position(((MapaEmpresaPageViewModel)this.BindingContext).latitude, ((MapaEmpresaPageViewModel)this.BindingContext).longitude)
            //};
            //map.Pins.Add(pinFornecedor);

        }

    }
}
