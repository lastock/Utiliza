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

    public class FacilidadesPageViewModel : BaseViewModel
    {
        private List<Facilidade> _listaDeFacilidades = new List<Facilidade>();
        public List<Facilidade> ListaDeFacilidades
        {
            get { return _listaDeFacilidades; }
            set { _listaDeFacilidades = value; }
        }

        private Fornecedor _fornecedor;
        public Fornecedor Fornecedor
        {
            get => _fornecedor;
            set => SetProperty(ref _fornecedor, value);
        }

        public FacilidadesPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));

            _fornecedor = new FornecedorServicos().GetFornecedor(id);
            //nomeFantasia = _fornecedor.NomeFantasia;
            //_title = _fornecedor.NomeRazaoSocial;
            //descricao = _fornecedor.Descricao;

            var facilidades = _fornecedor.Facilidades;
            foreach (var facilidade in facilidades)
            {
                _listaDeFacilidades.Add(facilidade);
            }
            ListaDeFacilidades = _listaDeFacilidades;
        }

    }
}
