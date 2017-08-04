using Prism.Navigation;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.ViewModels
{
    public class AvaliacaoPageViewModel : BaseViewModel
    {
        public AvaliacaoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Avaliação";
        }

        private Avaliacao _avaliacao;

        private string _nomeFornecedor;
        public string NomeFornecedor
        {
            get => _nomeFornecedor; 
            set => SetProperty(ref _nomeFornecedor , value); 
        }
        private string _comentario;
        public string Comentario
        {
            get => _comentario;
            set => SetProperty(ref _comentario, value);
        }
        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }
        private double _valorAvaliacao;
        public double ValorAvaliacao
        {
            get => _valorAvaliacao;
            set => SetProperty(ref _valorAvaliacao, value);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("avaliacao")) return;
            _avaliacao = parameters.GetValue<Avaliacao>("avaliacao");

            Nome = $"{_avaliacao.Nome} - {_avaliacao.UserName}";
            Comentario = _avaliacao.Comentario;
            ValorAvaliacao = _avaliacao.ValorAvaliacao;
            NomeFornecedor = new FornecedorService().NomeFornecedor(_avaliacao.IdFornecedor);
        }

    }
}
