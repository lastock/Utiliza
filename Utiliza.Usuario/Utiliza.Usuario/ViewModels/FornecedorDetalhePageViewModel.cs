using System;
using Prism.Commands;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class FornecedorDetalhePageViewModel : BaseViewModel
    {
        public DelegateCommand NavigateToSitePageCommand { get; private set; }
        public DelegateCommand NavigateToMapaEmpresaPageCommand { get; private set; }

        private Fornecedor _fornecedor;
        public Fornecedor Fornecedor
        {
            get => _fornecedor;
            set => SetProperty(ref _fornecedor, value);
        }

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

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));
            _fornecedor= new ProcuraFornecedor().GetFornecedor(id);

        }



    }
}
