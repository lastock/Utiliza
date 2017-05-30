using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class ConversaPageViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Conversa> _conversas = new ObservableCollection<Conversa>();
        public ObservableCollection<Conversa> Conversas { get; }
        public ConversaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
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
