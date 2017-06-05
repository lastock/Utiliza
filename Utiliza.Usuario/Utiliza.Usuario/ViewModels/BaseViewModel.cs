using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Utiliza.Usuario.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        protected INavigationService _navigationService;
        public DelegateCommand NavigateToMainPageCommand { get; private set; }
        public DelegateCommand NavigateToCategoriaPageCommand { get; private set; }
        public DelegateCommand NavigateToProcuraPageCommand { get; private set; }
        public DelegateCommand NavigateToLoginPageCommand { get; private set; }
        public DelegateCommand NavigateToCadastroUsuarioPageCommand { get; private set; }
        public DelegateCommand NavigateToConfiguracaoPageCommand { get; private set; }
        public DelegateCommand NavigateToMudaSenhaPageCommand { get; private set; }
        public DelegateCommand NavigateToSobrePageCommand { get; private set; }

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
        }

        public void InicializaNavegacao(INavigationService navigationService)
        {
        }


        protected string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _cidade;
        public string Cidade
        {
            get { return _cidade; }
            set { SetProperty(ref _cidade, value); }
        }

        #region Metodos de Navegação
        protected void NavigateToMainPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));
        }
        protected async void NavigateToCategoriaPage()
        {
            await _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/CategoriaPage", UriKind.Absolute));
        }
        protected void NavigateToProcuraPage()
        {
            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/ProcuraPage", UriKind.Relative));
        }
        protected void NavigateToLoginPage()
        {
            _navigationService.NavigateAsync("LoginPage");
        }
        protected void NavigateToCadastroUsuarioPage()
        {
            _navigationService.NavigateAsync("CadastroUsuarioPage");
        }
        protected void NavigateToConfiguracaoPage()
        {
            _navigationService.NavigateAsync("ConfiguracaoPage");
        }
        protected void NavigateToMudaSenhaPage()
        {
            _navigationService.NavigateAsync("MudaSenhaPage");
        }
        protected void NavigateToSobrePage()
        {
            _navigationService.NavigateAsync("SobrePage");
        }

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

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void SetProperty<T>(ref T backValue, T value, [CallerMemberName] String propertyName = "")
        //{
        //    backValue = value;
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
