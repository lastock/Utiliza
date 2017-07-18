using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("avaliacao")]
    public class Avaliacao
    {
        [PrimaryKey]
        public int IdAvaliacao { get; set; }

        [NotNull]
        public int IdFornecedor { get; set; }

        [NotNull]
        public string UserName { get; set; }

        public string Nome { get; set; }

        [NotNull]
        public double ValorAvaliacao { get; set; }

        [MaxLength(255)]
        public string Comentario { get; set; }
    }
}
