using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Services;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

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

        DelegateCommand<string> _imageTappedCommand;
        public DelegateCommand<string> ImageTappedCommand => _imageTappedCommand != null ? _imageTappedCommand : (_imageTappedCommand = new DelegateCommand<string>(ImageTapped));


        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            Cidade = "Mairiporã";
            Title = "Utiliza - " + Cidade;
            PopulaRotator();
        }

        private async void ImageTapped(string id)
        {
            //await _dialogService.DisplayAlertAsync("Id Empresa",id,"OK");
            var p = new NavigationParameters();
            p.Add("id", id);

            await _navigationService.NavigateAsync("FornecedorDetalhePage", p);
        }


        private void PopulaRotator()
        {
            ImageCollection.Add(new Rotator("movie1_1.png"));
            ImageCollection.Add(new Rotator("movie2_12.png"));
            ImageCollection.Add(new Rotator("movie3_123.png"));
            ImageCollection.Add(new Rotator("movie4_1234.png"));
            ImageCollection.Add(new Rotator("movie5_12345.png"));
        }

    }
}
