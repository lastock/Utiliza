using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class FavoritosPageViewModel : BaseViewModel
    {
        public FavoritosPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Favoritos";
            PopulaFavoritos();
        }

        DelegateCommand<Fornecedor> _listaFavoritoSelectedCommand;
        public DelegateCommand<Fornecedor> ListaFavoritoSelectedCommand => _listaFavoritoSelectedCommand != null ? _listaFavoritoSelectedCommand : (_listaFavoritoSelectedCommand = new DelegateCommand<Fornecedor>(FavoritoSelected));

        private List<Fornecedor> _favoritos = new List<Fornecedor>();
        public List<Fornecedor> Favoritos
        {
            get => _favoritos;
            set => SetProperty(ref _favoritos, value);
        }

        private async void FavoritoSelected(Fornecedor fornecedor)
        {
            var id = fornecedor.IdFornecedor;
            var p = new NavigationParameters();
            p.Add("id", id);

            await _navigationService.NavigateAsync("/InicialPage/UtilizaNavigationPage/MainPage/FornecedorTabbedPage/FornecedorDetalhePage", p, false);
        }

        private void PopulaFavoritos()
        {
            int idUsuário = 1;
            var fornecedores = new FornecedorServicos().FornecedoresFavoritos(idUsuário);
            foreach (var fornecedor in fornecedores)
            {
                _favoritos.Add(fornecedor);
            }

            Favoritos = _favoritos;
        }
    }
}
