using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Facilidade
    {
        public int IdFornecedor { get; set; }
        public string IconFacilidade { get; set; }
        public string DescricaoFacilidade { get; set; }

        public Facilidade(int idFornecedor, string iconFacilidade, string descricaoFacilidade)
        {
            IdFornecedor = idFornecedor;
            IconFacilidade = iconFacilidade;
            DescricaoFacilidade = descricaoFacilidade;
        }

    }
}
