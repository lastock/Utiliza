using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class ListaFornecedorPageViewModel : BaseViewModel
    {
        public ListaFornecedorPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Cidade;
        }

        DelegateCommand<Fornecedor> _listaFornecedorSelectedCommand;
        public DelegateCommand<Fornecedor> ListaFornecedorSelectedCommand => _listaFornecedorSelectedCommand != null ? _listaFornecedorSelectedCommand : (_listaFornecedorSelectedCommand = new DelegateCommand<Fornecedor>(FornecedorSelected));

        private List<Fornecedor> _fornecedores = new List<Fornecedor>();
        public List<Fornecedor> Fornecedores
        {
            get => _fornecedores;
            set => SetProperty(ref _fornecedores, value);
        }



        private async void FornecedorSelected(Fornecedor fornecedor)
        {
            var id = fornecedor.IdFornecedor;
            var p = new NavigationParameters();
            p.Add("id", id);

            await _navigationService.NavigateAsync("/InicialPage/UtilizaNavigationPage/FornecedorTabbedPage/FornecedorDetalhePage", p, false);
        }


        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("subcategoria"))
            {
                var subcategoria = parameters.GetValue<SubCategoria>("subcategoria");
                var fornecedores = new FornecedorService().FornecedoresDeUmaSubCategoria(subcategoria.IdSubCategoria);
                foreach (var fornecedor in fornecedores)
                {
                    _fornecedores.Add(fornecedor);
                }
            }
            else if (parameters.ContainsKey("procura"))
            {
                var procura = parameters.GetValue<Procura>("procura");
                var fornecedores = new FornecedorService().FornecedoresDaProcura(procura);
                foreach (var fornecedor in fornecedores)
                {
                    _fornecedores.Add(fornecedor);
                }
            }

            else
            {
                return;
            }


            Fornecedores = _fornecedores;

        }
    }
}
