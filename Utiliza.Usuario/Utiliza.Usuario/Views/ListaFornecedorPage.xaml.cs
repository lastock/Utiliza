using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class ListaFornecedorPage : ContentPage
    {
        public ListaFornecedorPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((ListaFornecedorPageViewModel)this.BindingContext).ListaFornecedorSelectedCommand.Execute((Fornecedor)args.Item);
        }

    }
}
