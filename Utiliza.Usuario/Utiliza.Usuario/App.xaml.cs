 using Prism.Unity;
using Utiliza.Usuario.Repositories;
using Utiliza.Usuario.Views;
using Xamarin.Forms;

namespace Utiliza.Usuario
{
    public partial class App : PrismApplication
    {
        public App(string dbFileName, IPlatformInitializer initializer = null) : base(initializer)
        {
            CategoriaRepository.Initialize(dbFileName);
            SubCategoriaRepository.Initialize(dbFileName);
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync("/InicialPage/UtilizaNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<CategoriaPage>();
            Container.RegisterTypeForNavigation<SubCategoriaPage>();
            Container.RegisterTypeForNavigation<ConversaPage>();
            Container.RegisterTypeForNavigation<ProximosPage>();
            Container.RegisterTypeForNavigation<ListaFornecedorPage>();
            Container.RegisterTypeForNavigation<ProximosMapaPage>();
            Container.RegisterTypeForNavigation<ProcuraPage>();
            Container.RegisterTypeForNavigation<FornecedorDetalhePage>();
            Container.RegisterTypeForNavigation<SitePage>();
            Container.RegisterTypeForNavigation<FornecedorMapaPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<CadastroUsuarioPage>();
            Container.RegisterTypeForNavigation<ConfiguracaoPage>();
            Container.RegisterTypeForNavigation<MudaSenhaPage>();
            Container.RegisterTypeForNavigation<SobrePage>();
            Container.RegisterTypeForNavigation<InicialPage>();
            Container.RegisterTypeForNavigation<UtilizaNavigationPage>();
            Container.RegisterTypeForNavigation<AlteraCidadePage>();
            Container.RegisterTypeForNavigation<MeusDadosPage>();
            Container.RegisterTypeForNavigation<MapaEmpresaPage>();
            Container.RegisterTypeForNavigation<ConversaIndividualPage>();
            Container.RegisterTypeForNavigation<TestePage>();
            Container.RegisterTypeForNavigation<FornecedoresAvaliacoesPage>();
            Container.RegisterTypeForNavigation<FornecedorTabbedPage>();
            Container.RegisterTypeForNavigation<ContatosPage>();
            Container.RegisterTypeForNavigation<FacilidadesPage>();
            Container.RegisterTypeForNavigation<PromocoesPage>();
            Container.RegisterTypeForNavigation<FavoritosPage>();
            Container.RegisterTypeForNavigation<TermosDeUsoPage>();
        }
    }
}
