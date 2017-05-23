using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Prism.Commands;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
        private List<Menu> _itensMenu;
        public List<Menu> ItensMenu
        {
            get { return _itensMenu; }
            set { SetProperty(ref _itensMenu, value); }
        }

        public Menu I { get; private set; }

        public InicialPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _itensMenu = new PopulaItensMenu().Popula();
        }

        DelegateCommand _alteraCidadeCommand;
        public DelegateCommand AlteraCidadeCommand => _alteraCidadeCommand != null ? _alteraCidadeCommand : (_alteraCidadeCommand = new DelegateCommand(AlteraCidade));

        private void AlteraCidade()
        {
            _navigationService.NavigateAsync(new Uri("AlteraCidadePage", UriKind.Relative));
        }
        DelegateCommand _alteraMeusDadosComand;
        public DelegateCommand AlteraMeusDadosComand => _alteraMeusDadosComand != null ? _alteraMeusDadosComand : (_alteraMeusDadosComand = new DelegateCommand(AlteraMeusDados));

        private void AlteraMeusDados()
        {
            _navigationService.NavigateAsync(new Uri("MeusDadosPage", UriKind.Relative));
        }

        DelegateCommand<Menu> _menuSelectedCommand;
        public DelegateCommand<Menu> MenuSelectedCommand => _menuSelectedCommand != null ? _menuSelectedCommand : (_menuSelectedCommand = new DelegateCommand<Menu>(MenuSelected));

        private void MenuSelected(Menu menuItem)
        {
            switch (menuItem.IdMenu)
            {
                //Home
                case 1:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Fornecedor
                case 2:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/CategoriaPage", UriKind.Absolute));
                    break;
                //Chat
                case 3:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Troca de Cidade
                case 4:
                     _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Promoções
                case 5:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Favoritos
                case 6:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Mapa
                case 7:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Procurar
                case 8:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Minha Conta
                case 9:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MeusDadosPage", UriKind.Absolute));
                    break;
                //Configurações
                case 10:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Sobre o Utiliza
                case 11:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
                //Termos de Uso
                case 12:
                    _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
                    break;
            }



        }


    }
}
