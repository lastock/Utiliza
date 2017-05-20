using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;
using Xamarin.Forms;
using System.Linq;
using Prism.Commands;

namespace Utiliza.Usuario.ViewModels
{
    public class SubCategoriaPageViewModel : BaseViewModel, INavigationAware
    {
        DelegateCommand<SubCategoria> _subcategoriaSelectedCommand;
        public DelegateCommand<SubCategoria> SubCategoriaSelectedCommand => _subcategoriaSelectedCommand != null ? _subcategoriaSelectedCommand : (_subcategoriaSelectedCommand = new DelegateCommand<SubCategoria>(SubCategoriaSelected));

        private ObservableCollection<SubCategoria> _subcategorias = new ObservableCollection<SubCategoria>();
        public ObservableCollection<SubCategoria> SubCategorias
        {
            get => _subcategorias;
            set => SetProperty(ref _subcategorias, value);
        }



        public SubCategoriaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Subcategorias - Mairiporã";
        }

        private async void SubCategoriaSelected(SubCategoria subcategoria)
        {
            var p = new NavigationParameters();
            p.Add("subcategoria", subcategoria);

            await _navigationService.NavigateAsync("ListaFornecedorPage", p);
        }



        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("categoria")) return;

            var categoria = parameters.GetValue<Categoria>("categoria");
            var subcategorias = new PopulaListaSubCategorias().Popula(categoria.IdCategoria);
            foreach (var subcategoria in subcategorias)
            {
                _subcategorias.Add(subcategoria);
            }

            SubCategorias = _subcategorias;
        }

    }
}
