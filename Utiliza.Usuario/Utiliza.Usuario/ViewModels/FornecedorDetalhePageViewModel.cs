using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;
using Xamarin.Forms;

namespace Utiliza.Usuario.ViewModels
{
    public class FornecedorDetalhePageViewModel : BaseViewModel
    {
        public DelegateCommand NavigateToSitePageCommand { get; private set; }
        public DelegateCommand NavigateToMapaEmpresaPageCommand { get; private set; }

        private IPageDialogService _dialogService;

        private List<Rotator> imageCollection = new List<Rotator>();
        public List<Rotator> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }

        private IList<Facilidade> _listaDeFacilidades = new List<Facilidade>();
        public IList<Facilidade> ListaDeFacilidades
        {
            get { return _listaDeFacilidades; }
            set { _listaDeFacilidades = value; }
        }

        private IList<Contato> _listaDeContatos = new List<Contato>();
        public IList<Contato> ListaDeContatos
        {
            get { return _listaDeContatos; }
            set { _listaDeContatos = value; }
        }


        private Fornecedor _fornecedor;
        public Fornecedor Fornecedor
        {
            get => _fornecedor;
            set => SetProperty(ref _fornecedor, value);
        }

        private string _nomeFantasia;
        public string nomeFantasia
        {
            get => _nomeFantasia;
            set => SetProperty(ref _nomeFantasia, value);
        }
        private string _chamada;
        public string chamada
        {
            get => _chamada;
            set => SetProperty(ref _chamada, value);
        }
        private string _telefones;
        public string telefones
        {
            get => _telefones;
            set => SetProperty(ref _telefones, value);
        }
        private double _avaliacao;
        public double avaliacao
        {
            get => _avaliacao;
            set => SetProperty(ref _avaliacao, value);
        }
        private string _resumo;
        public string resumo
        {
            get => _resumo;
            set => SetProperty(ref _resumo, value);
        }
        private string _horario;
        public string horario
        {
            get => _horario;
            set => SetProperty(ref _horario, value);
        }



        public FornecedorDetalhePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToSitePageCommand = new DelegateCommand(NavigateToSitePage);
            NavigateToMapaEmpresaPageCommand = new DelegateCommand(NavigateToMapaEmpresaPage);
            PopulaRotator();

        }

        protected void NavigateToSitePage()
        {
            _navigationService.NavigateAsync(new Uri("SitePage", UriKind.Relative));
        }
        protected void NavigateToMapaEmpresaPage()
        {
            _navigationService.NavigateAsync(new Uri("MapaEmpresaPage", UriKind.Relative));
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));
            _fornecedor = new ProcuraFornecedor().GetFornecedor(id);
            nomeFantasia = _fornecedor.NomeFantasia;
            _title = _fornecedor.NomeRazaoSocial;
            chamada = _fornecedor.Chamada;
            telefones = MontaStringTelefones(_fornecedor);
            avaliacao = _fornecedor.Avaliacao;
            resumo = _fornecedor.Resumo;
            //descricao = _fornecedor.Descricao;
            horario = Fornecedor.Horario;
            _listaDeContatos = _fornecedor.Contatos;
            _listaDeFacilidades = _fornecedor.Facilidades;

        }
        private void PopulaRotator()
        {
            ImageCollection.Add(new Rotator("big1.jpg"));
            ImageCollection.Add(new Rotator("big2.jpg"));
            ImageCollection.Add(new Rotator("big3.jpg"));
            ImageCollection.Add(new Rotator("big4.jpg"));
        }

        private string MontaStringTelefones(Fornecedor forn)
        {
            StringBuilder _tels = new StringBuilder();
            foreach (var tel in forn.Telefones)
            {
                _tels.Append("(");
                _tels.Append(tel.CodigoArea);
                _tels.Append(") ");
                _tels.Append(tel.NumeroTelefone);
                _tels.Append(" / ");
            }

            return _tels.ToString().Substring(0, _tels.ToString().Length - 3);
        }

    }
}
