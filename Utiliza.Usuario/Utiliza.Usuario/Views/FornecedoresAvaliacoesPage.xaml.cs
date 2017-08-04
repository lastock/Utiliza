using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class FornecedoresAvaliacoesPage : ContentPage
    {
        public FornecedoresAvaliacoesPage()
        {
            InitializeComponent();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((FornecedoresAvaliacoesPageViewModel)this.BindingContext).MostrarAvaliacaoCommand.Execute((Avaliacao)args.Item);
        }

    }
}
