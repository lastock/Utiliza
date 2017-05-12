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
    public class ListaFornecedorPageViewModel : BaseViewModel, INavigationAware
    {
        DelegateCommand<Fornecedor> _listaFornecedorSelectedCommand;
        public DelegateCommand<Fornecedor> ListaFornecedorSelectedCommand => _listaFornecedorSelectedCommand != null ? _listaFornecedorSelectedCommand : (_listaFornecedorSelectedCommand = new DelegateCommand<Fornecedor>(FornecedorSelected));

        private ObservableCollection<Fornecedor> _fornecedores = new ObservableCollection<Fornecedor>();
        public ObservableCollection<Fornecedor> Fornecedores
        {
            get => _fornecedores;
            set => SetProperty(ref _fornecedores, value);
        }


        public ListaFornecedorPageViewModel(INavigationService navigationService)
        {
            Title = "Fornecedores - Mairiporã";
            InicializaNavegacao(navigationService);
        }

        private async void FornecedorSelected(Fornecedor fornecedor)
        {
            var p = new NavigationParameters();
            p.Add("fornecedor", fornecedor);

            await _navigationService.NavigateAsync("FornecedorDetalhePage", p);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("subcategoria")) return;

            var subcategoria = parameters.GetValue<SubCategoria>("subcategoria");
            var fornecedores = new PopulaListaFornecedores().Popula(subcategoria.IdSubCategoria);
            foreach (var fornecedor in fornecedores)
            {
                _fornecedores.Add(fornecedor);
            }

            Fornecedores = _fornecedores;

        }
    }
}
