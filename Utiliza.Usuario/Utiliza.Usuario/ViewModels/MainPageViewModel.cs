using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Services;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;
using System;

namespace Utiliza.Usuario.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private IPageDialogService _dialogService;
        private List<Rotator> imageCollection = new List<Rotator>();

        public List<Rotator> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }

        DelegateCommand<int> _imageTappedCommand;
        public DelegateCommand<int> ImageTappedCommand => _imageTappedCommand != null ? _imageTappedCommand : (_imageTappedCommand = new DelegateCommand<int>(ImageTapped));


        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            Cidade = "Mairiporã";
            Title = "Utiliza - " + Cidade;
            PopulaRotator();
        }

        private async void ImageTapped(int idFornecedor)
        {
            var p = new NavigationParameters();
            p.Add("id", idFornecedor);

            await _navigationService.NavigateAsync("/InicialPage/UtilizaNavigationPage/FornecedorTabbedPage/FornecedorDetalhePage", p,false,true);
        }


        private void PopulaRotator()
        {
            ImageCollection.Add(new Rotator("big_1.jpg"));
            ImageCollection.Add(new Rotator("big_2.jpg"));
            ImageCollection.Add(new Rotator("big_3.jpg"));
            ImageCollection.Add(new Rotator("big_4.jpg"));
        }

    }
}
