using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Utiliza.Usuario.ViewModels
{
    public class FornecedorDetalhePageViewModel : BaseViewModel
    {
        public DelegateCommand NavigateToSitePageCommand { get; private set; }
        public DelegateCommand NavigateToMapaEmpresaPageCommand { get; private set; }


        public FornecedorDetalhePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToSitePageCommand = new DelegateCommand(NavigateToSitePage);
            NavigateToMapaEmpresaPageCommand = new DelegateCommand(NavigateToMapaEmpresaPage);

        }

        protected void NavigateToSitePage()
        {
            _navigationService.NavigateAsync(new Uri("SitePage", UriKind.Relative));
        }
        protected void NavigateToMapaEmpresaPage()
        {
            _navigationService.NavigateAsync(new Uri("MapaEmpresaPage", UriKind.Relative));
        }

    }
}
