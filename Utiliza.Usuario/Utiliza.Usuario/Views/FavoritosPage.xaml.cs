using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class FavoritosPage : ContentPage
    {
        public FavoritosPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((FavoritosPageViewModel)this.BindingContext).ListaFavoritoSelectedCommand.Execute((Fornecedor)args.Item);
        }

    }
}
