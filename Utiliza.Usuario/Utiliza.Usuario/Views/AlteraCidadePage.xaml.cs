using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class AlteraCidadePage : ContentPage
    {
        public AlteraCidadePage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((AlteraCidadePageViewModel)this.BindingContext).CidadeSelectedCommand.Execute((Cidade)args.Item);
        }

    }
}
