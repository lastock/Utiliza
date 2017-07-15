using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{

    public class CategoriaPageViewModel : BaseViewModel
    {
        public CategoriaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Categorias";
            Popula();
        }

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


        private void Popula()
        {
           var categorias = new CategoriaService().GetAllCategorias();
            foreach (var categoria in categorias)
            {
                _categorias.Add(categoria);
            }
            Categorias = _categorias;
        }

    }
}
