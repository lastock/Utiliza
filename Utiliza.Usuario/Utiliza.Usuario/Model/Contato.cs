using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("contato")]
    public class Contato
    {
        [PrimaryKey]
        public int IdContato { get; set; }
        [NotNull]
        public int IdFornecedor { get; set; }
        public string Telefone { get; set; }
        [NotNull, MaxLength(100)]
        public string NomeContato { get; set; }
        public string Email { get; set; }

    }
}
