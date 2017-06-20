using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utiliza.Usuario.ViewModels
{
    public class TermosDeUsoPageViewModel : BaseViewModel
    {
        public TermosDeUsoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Termos";

            Texto1 = "1.) Todos os dados fornecidos pelo usuário não serão repassados para terceiros. O cadastro será utilizado somente para login em nosso aplicativo.";
            Texto2 = "2.) O Guia Onde Vamos poderá censurar / apagar comentários que possam conter ofensas ou insultos aos nossos clientes ou usuários cadastrados.";
            Texto3 = "3.) Todos os pedidos realizados dentro do nosso aplicativo são enviados diretamente aos estabelecimentos anunciantes e não nos responsabilizamos pela cobrança ou entrega dos mesmos.";

        }

        private string _texto1;
        public string Texto1
        {
            get => _texto1;
            set => SetProperty(ref _texto1, value);
        }
        private string _texto2;
        public string Texto2
        {
            get => _texto2;
            set => SetProperty(ref _texto2, value);
        }
        private string _texto3;
        public string Texto3
        {
            get => _texto3;
            set => SetProperty(ref _texto3, value);
        }

    }
}
