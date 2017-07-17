using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("promocao")]
    public class Promocao
    {
        [PrimaryKey]
        public int IdPromocao { get; set; }
        [NotNull]
        public int IdFornecedor { get; set; }
        [NotNull]
        public string Logo { get; set; }
        [NotNull,MaxLength(255)]
        public string DescricaoPromocao { get; set; }
        [NotNull]
        public string NomeEmpresa { get; set; }
        public DateTime DataValidade { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeRestante { get; set; }
        public double PorcentagemDesconto { get; set; }
        public bool StatusPromocao { get; set; }
    }
}
