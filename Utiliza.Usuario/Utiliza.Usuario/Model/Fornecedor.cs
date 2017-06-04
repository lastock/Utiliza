using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public int Codigo { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Chamada { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string TipoDePessoa { get; set; }
        public string CnpjCpf { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Site { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public Tuple <double, double> Localizacao { get; set; }
        public string Logo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public int Subcategoria { get; set; }
        public double Avaliacao { get; set; }

    }
}
