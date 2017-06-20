using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class PromocoesPage : ContentPage
    {
        public PromocoesPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((PromocoesPageViewModel)this.BindingContext).ListaPromocaoSelectedCommand.Execute((Fornecedor)args.Item);
        }

    }
}
