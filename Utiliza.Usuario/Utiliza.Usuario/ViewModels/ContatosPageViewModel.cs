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
    public class ContatosPageViewModel : BaseViewModel
    {
        public ContatosPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Contatos";
        }
        private List<Contato> _listaDeContatos = new List<Contato>();
        public List<Contato> ListaDeContatos
        {
            get { return _listaDeContatos; }
            set { _listaDeContatos = value; }
        }

        private Fornecedor _fornecedor;
        public Fornecedor Fornecedor
        {
            get => _fornecedor;
            set => SetProperty(ref _fornecedor, value);
        }

        private string _nomeFantasia;
        public string nomeFantasia
        {
            get => _nomeFantasia;
            set => SetProperty(ref _nomeFantasia, value);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));

            _fornecedor = new FornecedorService().GetFornecedor(id);
            nomeFantasia = _fornecedor.NomeFantasia;
            _title = _fornecedor.NomeRazaoSocial;
            //descricao = _fornecedor.Descricao;

            var contatos = new ContatoService().ContatosDoFornecedor(id);
            foreach (var contato in contatos)
            {
                _listaDeContatos.Add(contato);
            }
            ListaDeContatos = _listaDeContatos;
        }


    }
}
