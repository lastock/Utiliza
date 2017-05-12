using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class CategoriaPage : ContentPage
    {
        public CategoriaPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((CategoriaPageViewModel)this.BindingContext).CategoriaSelectedCommand.Execute((Categoria)args.Item);
        }
    }
}
