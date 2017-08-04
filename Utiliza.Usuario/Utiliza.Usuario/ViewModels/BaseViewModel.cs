using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Utiliza.Usuario.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        #region Construtor

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToMainPageCommand = new DelegateCommand(NavigateToMainPage);
            NavigateToCategoriaPageCommand = new DelegateCommand(NavigateToCategoriaPage);
            NavigateToProcuraPageCommand = new DelegateCommand(NavigateToProcuraPage);
            NavigateToLoginPageCommand = new DelegateCommand(NavigateToLoginPage);
            NavigateToCadastroUsuarioPageCommand = new DelegateCommand(NavigateToCadastroUsuarioPage);
            NavigateToConfiguracaoPageCommand = new DelegateCommand(NavigateToConfiguracaoPage);
            NavigateToMudaSenhaPageCommand = new DelegateCommand(NavigateToMudaSenhaPage);
            NavigateToSobrePageCommand = new DelegateCommand(NavigateToSobrePage);

            Cidade = RetornaCidade();

        }

        #endregion

        #region Inicialização de variáveis

        protected INavigationService _navigationService;
        public DelegateCommand NavigateToMainPageCommand { get; private set; }
        public DelegateCommand NavigateToCategoriaPageCommand { get; private set; }
        public DelegateCommand NavigateToProcuraPageCommand { get; private set; }
        public DelegateCommand NavigateToLoginPageCommand { get; private set; }
        public DelegateCommand NavigateToCadastroUsuarioPageCommand { get; private set; }
        public DelegateCommand NavigateToConfiguracaoPageCommand { get; private set; }
        public DelegateCommand NavigateToMudaSenhaPageCommand { get; private set; }
        public DelegateCommand NavigateToSobrePageCommand { get; private set; }

        #endregion


        //public void InicializaNavegacao(INavigationService navigationService)
        //{
        //}


        protected string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        protected string _cidade;
        public string Cidade
        {
            get { return _cidade; }
            set { SetProperty(ref _cidade, value); }
        }

        #region Metodos de Navegação

        //Navega para MainPage
        protected void NavigateToMainPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
        }

        //Navega para Categorias
        protected async void NavigateToCategoriaPage()
        {
            await _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/CategoriaPage", UriKind.Absolute));
        }

        //Navega para Procura
        protected void NavigateToProcuraPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/ProcuraPage", UriKind.Relative));
        }

        //Navega para Login
        protected void NavigateToLoginPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/LoginPage", UriKind.Absolute));
        }

        //Navega para Cadastro de Usuário
        protected void NavigateToCadastroUsuarioPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/CadastroUsuarioPage", UriKind.Absolute));
        }

        //Navega para Configuração
        protected void NavigateToConfiguracaoPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/ConfiguracaoPage", UriKind.Absolute));
        }

        //Navega para Mudar Senha
        protected void NavigateToMudaSenhaPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MudaSenhaPage", UriKind.Absolute));
        }

        //Navega para Sobre
        protected void NavigateToSobrePage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/SobrePage", UriKind.Absolute));
        }

        #endregion

        #region Metodos - eventos - interface INavigationAware
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }


        #endregion

        #region Metodos auxiliares

        protected string RetornaCidade()
        {
            var cidade = "Mairiporã";
            return cidade;
        }


        #endregion

        public virtual void Destroy()
        {
        }

    }
}
