using System;
using System.Collections.Generic;
using SQLite;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("fornecedor")]
    public class Fornecedor
    {
        [PrimaryKey]
        public int IdFornecedor { get; set; }

        [Unique, MaxLength(250)]
        public string NomeRazaoSocial { get; set; }

        [Unique, NotNull, MaxLength(150)]
        public string NomeFantasia { get; set; }

        [MaxLength(255)]
        public string Chamada { get; set; }

        [MaxLength(255)]
        public string Endereco { get; set; }

        [MaxLength(150)]
        public string Bairro { get; set; }

        [MaxLength(9)]
        public string Cep { get; set; }

        [MaxLength(50)]
        public string Cidade { get; set; }

        [MaxLength(2)]
        public string Estado { get; set; }

        [MaxLength(1)]
        public string TipoDePessoa { get; set; }

        [MaxLength(18)]
        public string CnpjCpf { get; set; }

        [MaxLength(255)]
        public string Site { get; set; }

        [MaxLength(13)]
        public string WhatsApp { get; set; }

        [MaxLength(255)]
        public string Resumo { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Logo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataModificacao { get; set; }

        public int Subcategoria { get; set; }

        public int Categoria { get; set; }

        public double Avaliacao { get; set; }

        [MaxLength(150)]
        public string Horario { get; set; }

        public bool Favorito { get; set; }
    }
}
