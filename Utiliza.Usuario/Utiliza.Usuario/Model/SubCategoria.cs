using SQLite;
using System;

namespace Utiliza.Usuario.Model
{
    [Table ("subcategoria")]
    public class SubCategoria
    {
        [PrimaryKey]
        public int IdSubCategoria { get; set; }
        
        [MaxLength(50), Unique, NotNull]
        public string NomeSubCategoria { get; set; }

        [NotNull]
        public int IdCategoria { get; set; }

        public int Ordem { get; set; }
    }
}
