using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class SubCategoriaPage : ContentPage
    {
        public SubCategoriaPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((SubCategoriaPageViewModel)this.BindingContext).SubCategoriaSelectedCommand.Execute((SubCategoria)args.Item);
        }

    }
}
