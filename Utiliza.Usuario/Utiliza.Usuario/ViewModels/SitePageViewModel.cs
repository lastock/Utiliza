using Prism.Mvvm;
using Prism.Navigation;
using System;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class SitePageViewModel : BaseViewModel
    {
        public SitePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private string _site;
        public string site
        {
            get => _site;
            set => SetProperty(ref _site, value);
        }


        #region Método para recuperar parâmetros
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));


            var _fornecedor = new FornecedorService().GetFornecedor(id);

            site = _fornecedor.Site;
        }
        #endregion

    }
}
