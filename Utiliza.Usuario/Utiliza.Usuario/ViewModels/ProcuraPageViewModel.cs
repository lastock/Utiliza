using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class ProcuraPageViewModel : BaseViewModel
    {
        public ProcuraPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            Title = "Procura";
            Popula();
        }

        private IPageDialogService _dialogService;

        DelegateCommand<Procura> _procuraClickedCommand;
        public DelegateCommand<Procura> ProcuraClickedCommand => _procuraClickedCommand != null ? _procuraClickedCommand : (_procuraClickedCommand = new DelegateCommand<Procura>(ProcuraClicked));


        private ObservableCollection<Categoria> _categorias = new ObservableCollection<Categoria>();
        public ObservableCollection<Categoria> Categorias
        {
            get => _categorias;
            set => SetProperty(ref _categorias, value);
        }

        //private void Popula()
        //{
        //    var categorias = new PopulaListaCategorias().Popula();
        //    foreach (var categoria in categorias)
        //    {
        //        _categorias.Add(categoria);
        //    }
        //    Categorias = _categorias;

        //}
        private void Popula()
        {
            List<Categoria> categorias = new CategoriaService().GetAllCategorias();
            foreach (var categoria in categorias)
            {
                _categorias.Add(categoria);
            }
            Categorias = _categorias;
        }


        private async void ProcuraClicked(Procura procura)
        {
            string mensagem = $"String procura = {procura.StringProcura} / Procura por distancia = {procura.ProcuraPorDistancia.ToString()} / Kms = {procura.Kilometros.ToString()} / Categoria = {procura.Categoria}";
            await _dialogService.DisplayAlertAsync("Procura", mensagem, "OK");

            var p = new NavigationParameters();
            p.Add("procura", procura);

            await _navigationService.NavigateAsync("ListaFornecedorPage", p);

        }

    }
}
