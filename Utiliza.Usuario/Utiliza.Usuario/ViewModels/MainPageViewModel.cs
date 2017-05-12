using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private readonly ObservableCollection<Conversa> _conversas = new ObservableCollection<Conversa>();
        public ObservableCollection<Conversa> Conversas { get; }



        public MainPageViewModel(INavigationService navigationService)
        {
            InicializaNavegacao(navigationService);
            Popula();
            Conversas = _conversas;
            Cidade = "Mairiporã";
            Title = "Utiliza - " + Cidade;
        }

        private void Popula()
        {
            var listaConversas = new PopulaListaConversas().Popula();
            foreach (var conversa in listaConversas)
            {
                _conversas.Add(conversa);
            }
        }
    }
}
