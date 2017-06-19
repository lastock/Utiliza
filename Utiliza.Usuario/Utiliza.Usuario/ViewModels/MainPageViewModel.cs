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

        DelegateCommand<string> _imageTappedCommand;
        public DelegateCommand<string> ImageTappedCommand => _imageTappedCommand != null ? _imageTappedCommand : (_imageTappedCommand = new DelegateCommand<string>(ImageTapped));


        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            Cidade = "Mairiporã";
            Title = "Utiliza - " + Cidade;
            PopulaRotator();
        }

        private async void ImageTapped(string nomeArquivo)
        {
            //await _dialogService.DisplayAlertAsync("Id Empresa",id,"OK");
            var p = new NavigationParameters();

            //Pega o id da empresa a partir do nome do Arquivo da imagem. O nome do arquivo da imagem deve ter o id da empresa que deve estar no final logo depois de um underscore "_" 
            string idStr;
            int id;
            idStr = nomeArquivo.Substring(nomeArquivo.IndexOf("_")+1);
            if(!Int32.TryParse(idStr,out id))
            {
                await _dialogService.DisplayAlertAsync("Nome do arquivo", $"Não achei o id da empresa no arquivo {nomeArquivo}", "OK");
            }



            p.Add("id", id);

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
