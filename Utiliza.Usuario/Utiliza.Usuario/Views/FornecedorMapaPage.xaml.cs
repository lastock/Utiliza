using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Utiliza.Usuario.Views
{
    public partial class FornecedorMapaPage : ContentPage
    {
        public FornecedorMapaPage()
        {
            InitializeComponent();
            //map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(-23.343091d, -46.574892d), 15d);
            ////map.IsShowingUser = true;
            //map.IsIndoorEnabled = true;
            var pinFornecedor = new Pin()
            {
                Label = "Total Dog",
                Address = "(11) 99935-1364",
                Position = new Position(-23.343091d, -46.574892d)
            };
            map.Pins.Add(pinFornecedor);
           
        }
    }
}
