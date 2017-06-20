using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class PromocoesPageViewModel : BaseViewModel
    {
        public PromocoesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Promoções";
            PopulaPromocoes();
        }

        DelegateCommand<Promocao> _listaPromocaoSelectedCommand;
        public DelegateCommand<Promocao> ListaPromocaoSelectedCommand => _listaPromocaoSelectedCommand != null ? _listaPromocaoSelectedCommand : (_listaPromocaoSelectedCommand = new DelegateCommand<Promocao>(PromocaoSelected));

        private List<Promocao> _promocoes = new List<Promocao>();
        public List<Promocao> Promocoes
        {
            get => _promocoes;
            set => SetProperty(ref _promocoes, value);
        }



        private async void PromocaoSelected(Promocao promocao)
        {
            var id = promocao.IdFornecedor;
            var p = new NavigationParameters();
            p.Add("id", id);

            await _navigationService.NavigateAsync("/InicialPage/UtilizaNavigationPage/FornecedorTabbedPage/FornecedorDetalhePage", p, false);
        }

        private void PopulaPromocoes()
        {
            var promocoes = new FornecedorServicos().Promocoes();
            foreach (var promocao in promocoes)
            {
                _promocoes.Add(promocao);
            }

            Promocoes = _promocoes;
        }


    }
}
