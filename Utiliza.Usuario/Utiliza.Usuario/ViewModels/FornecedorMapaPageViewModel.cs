using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfRating.XForms;
using Utiliza.Usuario.Views;
using Xamarin.Forms.GoogleMaps;

namespace Utiliza.Usuario.ViewModels
{
    public class FornecedorMapaPageViewModel : BaseViewModel
    { 
        public FornecedorMapaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
