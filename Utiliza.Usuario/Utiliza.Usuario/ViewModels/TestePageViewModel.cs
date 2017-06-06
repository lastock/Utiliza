using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class TestePageViewModel : BaseViewModel
    {
        private Fornecedor _fornecedor;
        public Fornecedor Fornecedor
        {
            get => _fornecedor;
            set => SetProperty(ref _fornecedor, value);
        }


        private List<Contato> _listaDeContatos = new List<Contato>();
        public List<Contato> ListaDeContatos
        {
            get { return _listaDeContatos; }
            set { _listaDeContatos = value; }
        }


        public TestePageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            var id = 1;
            _fornecedor = new ProcuraFornecedor().GetFornecedor(id);
            _title = _fornecedor.NomeRazaoSocial;
            //_listaDeContatos = _fornecedor.Contatos;
            var contatos = _fornecedor.Contatos;
            foreach (var contato in contatos)
            {
                _listaDeContatos.Add(contato);
            }
            ListaDeContatos = _listaDeContatos;
        }

    }
}
