using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class FornecedoresAvaliacoesPageViewModel : BaseViewModel
    {
        private List<Avaliacao> _listaDeAvaliacoes = new List<Avaliacao>();
        public List<Avaliacao> ListaDeAvaliacoes
        {
            get { return _listaDeAvaliacoes; }
            set { _listaDeAvaliacoes = value; }
        }
        private string _nomeFornecedor;
        public string NomeFornecedor
        {
            get { return _nomeFornecedor; }
            set { _nomeFornecedor = value; }
        }

        public FornecedoresAvaliacoesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Avaliações";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;
            var idfornecedor = parameters.GetValue<int>("id");
            NomeFornecedor = new FornecedorServicos().NomeFornecedor(idfornecedor);
            var avaliacoes = new AvaliacoesService().RetornaAvaliacoes(idfornecedor);
            foreach (var avaliacao in avaliacoes)
            {
                _listaDeAvaliacoes.Add(avaliacao);
            }
            ListaDeAvaliacoes = _listaDeAvaliacoes;
        }
    }
}
