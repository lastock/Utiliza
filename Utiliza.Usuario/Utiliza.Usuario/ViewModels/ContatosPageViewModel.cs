using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.ViewModels
{
    public class ContatosPageViewModel : BaseViewModel
    {
        public ContatosPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        private List<Contato> _listaDeContatos = new List<Contato>();
        public List<Contato> ListaDeContatos
        {
            get { return _listaDeContatos; }
            set { _listaDeContatos = value; }
        }

    }
}
