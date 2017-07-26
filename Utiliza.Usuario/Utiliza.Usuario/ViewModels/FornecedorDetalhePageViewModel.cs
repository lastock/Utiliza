using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;
using Xamarin.Forms;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System.Threading.Tasks;

namespace Utiliza.Usuario.ViewModels
{
    public class FornecedorDetalhePageViewModel : BaseViewModel
    {

        #region Inicialização de variáveis
        //Variável para mostrar alerts do prism
        //private IPageDialogService _dialogService;
        private int _idFornecedor;
        #endregion

        #region Construtor
        // Construtor da classe
        public FornecedorDetalhePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToSitePageCommand = new DelegateCommand(NavigateToSitePage);
            NavigateToMapaEmpresaPageCommand = new DelegateCommand(NavigateToMapaEmpresaPage);
            MostraAvaliacoesCommand = new DelegateCommand(MostraAvaliacoesSelected);
            WhatsAppChatCommand = new DelegateCommand(AbreChatNoWhatsApp);
            //CompartilharFornecedorCommand = new DelegateCommand(CompartilharFornecedor);
        }

        #endregion

        #region Propriedades Command
        ////Botão para mostrar o site (precisa implementar o parâmetro com o id do fornecedor para a qual vai navegar)
        public DelegateCommand NavigateToSitePageCommand { get; private set; }

        ////Botão para mostrar o mapa da empresa (precisa implementar o parâmetro com o id do fornecedor que vai mostrar o mapa)
        public DelegateCommand NavigateToMapaEmpresaPageCommand { get; private set; }

        ////Botão para mostrar a página com todas as avaliações do fornecedor por parte dos usuários
        public DelegateCommand MostraAvaliacoesCommand { get; private set; }

        ////Botão para mostrar chat com o fornecedor
        public DelegateCommand WhatsAppChatCommand { get; private set; }

        ////Botão para Compartilhar o fornecedor 
        DelegateCommand _compartilharFornecedorCommand;
        public DelegateCommand CompartilharFornecedorCommand => _compartilharFornecedorCommand != null ? _compartilharFornecedorCommand : (_compartilharFornecedorCommand = new DelegateCommand(CompartilharFornecedor));

        ////Botão para marcar desmarcar empresa dos favoritos 
        DelegateCommand _marcaDesmarcaFavoritosCommand;
        public DelegateCommand MarcaDesmarcaFavoritosCommand => _marcaDesmarcaFavoritosCommand != null ? _marcaDesmarcaFavoritosCommand : (_marcaDesmarcaFavoritosCommand = new DelegateCommand(MarcaDesmarcaFavoritos));

        //public DelegateCommand CompartilharFornecedorCommand { get; private set; }

        #endregion

        #region Metodos de navegação
        //Navega para o site da empresa (precisa implementar o parâmetrao com o id do fornecedor para o qual vai navegar)
        private async void NavigateToSitePage()
        {
            var p = new NavigationParameters();
            p.Add("id", _idFornecedor);

            await _navigationService.NavigateAsync(new Uri("SitePage", UriKind.Relative),p);
        }

        //Navega para página com o mapa da empresa (precisa implementar o parâmetrao com o id do fornecedor que vai mostrar o mapa)
        private async void NavigateToMapaEmpresaPage()
        {
            var p = new NavigationParameters();
            p.Add("id", _idFornecedor);

            await _navigationService.NavigateAsync(new Uri("FornecedorMapaPage", UriKind.Relative),p);
        }

        //Navega para página que mostra todas as avaliações do fornecedor
        private void MostraAvaliacoesSelected()
        {
            var p = new NavigationParameters();
            p.Add("id", _idFornecedor);

            _navigationService.NavigateAsync(new Uri("FornecedoresAvaliacoesPage", UriKind.Relative), p);
        }

        //Navega para página que mostra todas as avaliações do fornecedor
        private void AbreChatNoWhatsApp()
        {
            var numWhatsApp = _fornecedor.WhatsApp;
            var mensagem = $"Mensagem do cliente: XXXXX para {_fornecedor.NomeFantasia}";
            Device.OpenUri(new Uri($"http://api.whatsapp.com/send?phone={numWhatsApp}&text={mensagem}"));

        }
        //Navega para página que mostra todas as avaliações do fornecedor
        private void MarcaDesmarcaFavoritos()
        {
            var favorito = new FornecedorService().AdicionaRetiraDosFavoritos(_fornecedor.IdFornecedor);

            if (favorito == true)
            {
                opacidadeFavorito = 1;
            }
            else
            {
                opacidadeFavorito = 0.5;
            }
        }

        //Compartilha o site e informações do fornecedor
        private void CompartilharFornecedor()
        {
            var site = _fornecedor.Site;
            var nomeFornecedor = $"{_fornecedor.NomeFantasia } compartilhado pelo app Guia OndeVamos Mairiporã.";
            var titulo = "Guia OndeVamos Mairiporã";
            ShareMessage mensagem = new ShareMessage();
            mensagem.Url = site;
            mensagem.Title = titulo;
            mensagem.Text = nomeFornecedor;
            Compartilhar(mensagem);
        }

        #endregion

        #region Propriedades do Fornecedor
        // Propriedades dos fornecedor que serão utilizadas na página
        private Fornecedor _fornecedor;
        public Fornecedor Fornecedor
        {
            get => _fornecedor;
            set => SetProperty(ref _fornecedor, value);
        }
        private List<Rotator> imageCollection = new List<Rotator>();
        public List<Rotator> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
        private string _imagem;
        public string imagem
        {
            get => _imagem;
            set => SetProperty(ref _imagem, value);
        }


        private List<Facilidade> _listaDeFacilidades = new List<Facilidade>();
        public List<Facilidade> ListaDeFacilidades
        {
            get { return _listaDeFacilidades; }
            set { _listaDeFacilidades = value; }
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
        private double _opacidadeFavorito;
        public double opacidadeFavorito
        {
            get => _opacidadeFavorito;
            set => SetProperty(ref _opacidadeFavorito, value);
        }

        #endregion





        #region Método para recuperar parâmetros
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));
            _idFornecedor = id;

            PopulaRotator(_idFornecedor);

            _fornecedor = new FornecedorService().GetFornecedor(id);
            imagem = _fornecedor.Logo;
            nomeFantasia = _fornecedor.NomeFantasia;
            _title = _fornecedor.NomeRazaoSocial;
            chamada = _fornecedor.Chamada;
            telefones = MontaStringTelefones(_fornecedor.IdFornecedor);
            avaliacao = _fornecedor.Avaliacao;
            resumo = _fornecedor.Resumo;
            if (_fornecedor.Favorito == true)
            {
                opacidadeFavorito = 1;
            }
            else
            {
                opacidadeFavorito = 0.5;
            }
            //descricao = _fornecedor.Descricao;
            horario = Fornecedor.Horario;
            //var facilidades = _fornecedor.Facilidades;
            //foreach (var facilidade in facilidades)
            //{
            //    _listaDeFacilidades.Add(facilidade);
            //}
            //ListaDeFacilidades = _listaDeFacilidades;

        }

        #endregion

        #region Metodos auxiliares

        //método para compartilhar um site de um fornecedor
        public void Compartilhar(ShareMessage mensagem)
        {
            if (CrossShare.IsSupported)
            {
                CrossShare.Current.Share(mensagem);
            }
        }


        //Popula lista de fotos do fornecedor
        private void PopulaRotator(int idFornecedor)
        {
            var imagens = new ImagemService().ImagensDoFornecedor(idFornecedor);

            foreach (var imagem in imagens)
            {
                ImageCollection.Add(new Rotator(imagem.NomeArquivo));
            }
        }

        //Monta a linha dos telefonos do fornecedor
        private string MontaStringTelefones(int idFornecedor)
        {
            var telefones = new TelefoneService().TelefonesDoFornecedor(idFornecedor);
            StringBuilder _tels = new StringBuilder();
            foreach (var tel in telefones)
            {
                _tels.Append("(");
                _tels.Append(tel.CodigoArea);
                _tels.Append(") ");
                _tels.Append(tel.NumeroTelefone);
                _tels.Append(" / ");
            }

            return _tels.ToString().Substring(0, _tels.ToString().Length - 3);
        }

        #endregion

    }
}
