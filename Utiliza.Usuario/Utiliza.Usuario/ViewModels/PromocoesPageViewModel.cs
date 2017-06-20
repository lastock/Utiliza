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

        DelegateCommand<Fornecedor> _listaPromocaoSelectedCommand;
        public DelegateCommand<Fornecedor> ListaPromocaoSelectedCommand => _listaPromocaoSelectedCommand != null ? _listaPromocaoSelectedCommand : (_listaPromocaoSelectedCommand = new DelegateCommand<Fornecedor>(PromocaoSelected));

        private List<Fornecedor> _promocoes = new List<Fornecedor>();
        public List<Fornecedor> Promocoes
        {
            get => _promocoes;
            set => SetProperty(ref _promocoes, value);
        }



        private async void PromocaoSelected(Fornecedor fornecedor)
        {
            var id = fornecedor.IdFornecedor;
            var p = new NavigationParameters();
            p.Add("id", id);

            await _navigationService.NavigateAsync("/InicialPage/UtilizaNavigationPage/FornecedorTabbedPage/FornecedorDetalhePage", p, false);
        }

        private void PopulaPromocoes()
        {
            int idUsuário = 1;
            var fornecedores = new FornecedorServicos().FornecedoresFavoritos(idUsuário);
            foreach (var fornecedor in fornecedores)
            {
                _promocoes.Add(fornecedor);
            }

            Promocoes = _promocoes;
        }


    }
}
