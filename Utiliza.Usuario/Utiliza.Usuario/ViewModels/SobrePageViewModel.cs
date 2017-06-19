using Prism.Mvvm;
using Prism.Navigation;

namespace Utiliza.Usuario.ViewModels
{
    public class SobrePageViewModel : BaseViewModel
    {
        public SobrePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sobre";

            Logo = "icon.png";

            TextoGuia = "O Guia Onde Vamos é o seu mais completo, rápido e fácil guia comercial de bolso. Onde você estiver tenha certeza que os comércios estarão com você! Com opção de busca rápida, traçar rota até o estabeleciento, ligação direta do aplicativo, consulta de site, ofertas, e-mail, descontos e também a posibilidade de localizar o estabelecimento mais próximo de onde você está.";

            Disclaimer = "Entre em contato e saiba mais como anunciar no Guia Onde Vamos!";

            Site = "www.guiaondevamos.com.br";

            Tel1 = "(11) 97121-8331 (vivo/whatsapp)";
            Tel2 = "(11) 99737-5404 (vivo/whatsapp)";
            Tel3 = "(11) 419-5911";
            Email = "contato@guiaondevamos.com.br";
        }

        private string _logo;
        public string Logo
        {
            get => _logo;
            set => SetProperty(ref _logo, value);
        }
        private string _textoGuia;
        public string TextoGuia
        {
            get => _textoGuia;
            set => SetProperty(ref _textoGuia, value);
        }
        private string _disclaimer;
        public string Disclaimer
        {
            get => _disclaimer;
            set => SetProperty(ref _disclaimer, value);
        }
        private string _site;
        public string Site
        {
            get => _site;
            set => SetProperty(ref _site, value);
        }
        private string _tel1;
        public string Tel1
        {
            get => _tel1;
            set => SetProperty(ref _tel1, value);
        }
        private string _tel2;
        public string Tel2
        {
            get => _tel2;
            set => SetProperty(ref _tel2, value);
        }
        private string _tel3;
        public string Tel3
        {
            get => _tel3;
            set => SetProperty(ref _tel3, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

    }
}
