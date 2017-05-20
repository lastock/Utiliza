using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{

    public class CategoriaPageViewModel : BaseViewModel
    {
        private ObservableCollection<Categoria> _categorias = new ObservableCollection<Categoria>();
        public ObservableCollection<Categoria> Categorias
        {
            get => _categorias;
            set => SetProperty(ref _categorias, value);
        }

        DelegateCommand<Categoria> _categoriaSelectedCommand;
        public DelegateCommand<Categoria> CategoriaSelectedCommand => _categoriaSelectedCommand != null ? _categoriaSelectedCommand : (_categoriaSelectedCommand = new DelegateCommand<Categoria>(CategoriaSelected));

        private async void CategoriaSelected(Categoria categoria)
        {
            var p = new NavigationParameters();
            p.Add("categoria", categoria);

            await _navigationService.NavigateAsync("SubCategoriaPage", p);
        }

        public CategoriaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Categorias - Mairiporã";
            Popula();
        }

        private void Popula()
        {
            var categorias = new PopulaListaCategorias().Popula();
            foreach (var categoria in categorias)
            {
                _categorias.Add(categoria);
            }
        }

    }
}
