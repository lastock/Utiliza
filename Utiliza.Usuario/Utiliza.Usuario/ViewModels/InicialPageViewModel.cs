using System.Collections.Generic;
using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
        private List<Menu> _itensMenu;
        public List<Menu> ItensMenu
        {
            get { return _itensMenu; }
            set { SetProperty(ref _itensMenu, value); }
        }

        public Menu I { get; private set; }

        public InicialPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _itensMenu = new PopulaItensMenu().Popula();
        }
    }
}
