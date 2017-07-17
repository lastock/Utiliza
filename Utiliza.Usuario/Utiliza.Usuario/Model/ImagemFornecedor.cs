using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("imagemfornecedor")]
    public class ImagemFornecedor
    {
        [PrimaryKey]
        public int IdImagem { get; set; }
        [NotNull]
        public int IdFornecedor { get; set; }
        [NotNull]
        public string NomeArquivo { get; set; }

    }
}
