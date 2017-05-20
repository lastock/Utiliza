using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class InicialPage : MasterDetailPage
    {
        public InicialPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((InicialPageViewModel)this.BindingContext).MenuSelectedCommand.Execute((Menu)args.Item);
        }

    }
}