using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private List<Rotator> imageCollection = new List<Rotator>();

        public List<Rotator> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Cidade = "Mairiporã";
            Title = "Utiliza - " + Cidade;
            PopulaRotator();
        }

        private void PopulaRotator()
        {
            ImageCollection.Add(new Rotator("movie1.jpg"));
            ImageCollection.Add(new Rotator("movie2.jpg"));
            ImageCollection.Add(new Rotator("movie3.jpg"));
            ImageCollection.Add(new Rotator("movie4.jpg"));
            ImageCollection.Add(new Rotator("movie5.jpg"));
            ImageCollection.Add(new Rotator("movie6.jpg"));
            ImageCollection.Add(new Rotator("movie7.jpg"));
            ImageCollection.Add(new Rotator("movie8.jpg"));
        }

    }
}
