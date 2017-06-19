using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class AlteraCidadePageViewModel : BaseViewModel
    {
        public AlteraCidadePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Altera Cidade";
            PopulaListaDeCidades();
        }

        DelegateCommand<Cidade> _cidadeSelectedCommand;
        public DelegateCommand<Cidade> CidadeSelectedCommand => _cidadeSelectedCommand != null ? _cidadeSelectedCommand : (_cidadeSelectedCommand = new DelegateCommand<Cidade>(CidadeSelected));


        private List<Cidade> _cidades = new List<Cidade>();
        public List<Cidade> Cidades
        {
            get => _cidades;
            set => SetProperty(ref _cidades, value);
        }
        private void PopulaListaDeCidades()
        {
            var cidades = new CidadeServicos().ListaDeCidades();
            foreach (var cidade in cidades)
            {
                _cidades.Add(cidade);
            }
            Cidades = _cidades;
        }

        private void CidadeSelected(Cidade cidade)
        {

            _navigationService.NavigateAsync(new Uri("/InicialPage/UtilizaNavigationPage/MainPage", UriKind.Absolute));

        }

    }
}
