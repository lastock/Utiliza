using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("telefone") ]
    public class Telefone
    {
        [PrimaryKey]
        public int IdTelefone { get; set; }
        [NotNull]
        public int IdFornecedor { get; set; }
        [NotNull]
        public string CodigoArea { get; set; }
        [NotNull]
        public string NumeroTelefone { get; set; }

        public string Operadora { get; set; }
    }
}
