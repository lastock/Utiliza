using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Promocao
    {
        public int IdPromocao { get; set; }
        public int IdFornecedor { get; set; }
        public string Logo { get; set; }
        public string DescricaoPromocao { get; set; }
        public string NomeEmpresa { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeRestante { get; set; }
        public double PorcentagemDesconto { get; set; }
    }
}
