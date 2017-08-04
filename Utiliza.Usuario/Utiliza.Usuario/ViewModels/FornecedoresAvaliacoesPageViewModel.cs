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
        public FornecedoresAvaliacoesPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        //Clicar na lista de avaliações 
        DelegateCommand<Avaliacao> _mostrarAvaliacaoCommand;
        public DelegateCommand<Avaliacao> MostrarAvaliacaoCommand => _mostrarAvaliacaoCommand != null ? _mostrarAvaliacaoCommand : (_mostrarAvaliacaoCommand = new DelegateCommand<Avaliacao>(MostrarAvaliacao));

        private List<Avaliacao> _listaDeAvaliacoes = new List<Avaliacao>();
        public List<Avaliacao> ListaDeAvaliacoes
        {
            get { return _listaDeAvaliacoes; }
            set { _listaDeAvaliacoes = value; }
        }
        private string _nomeFor;
        public string nomeFor
        {
            get { return _nomeFor; }
            set { _nomeFor = value; }
        }

        private void MostrarAvaliacao(Avaliacao avaliacao)
        {
            var p = new NavigationParameters();
            p.Add("avaliacao", avaliacao);

            _navigationService.NavigateAsync(new Uri("AvaliacaoPage", UriKind.Relative), p);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;
            var idfornecedor = parameters.GetValue<int>("id");
            Title = "Avaliações";
            nomeFor = "Total Dog";

            _nomeFor = new FornecedorService().NomeFornecedor(idfornecedor);
            var avaliacoes = new AvaliacaoService().RetornaAvaliacoes(idfornecedor);
            foreach (var avaliacao in avaliacoes)
            {
                _listaDeAvaliacoes.Add(avaliacao);
            }
            ListaDeAvaliacoes = _listaDeAvaliacoes;
        }
    }
}
