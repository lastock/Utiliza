using SQLite;

namespace Utiliza.Usuario.Model
{
    [Table ("categoria")]
    public class Categoria
    {
        [PrimaryKey]
        public int IdCategoria { get; set; }

        [MaxLength(50), Unique, NotNull]
        public string NomeCategoria { get; set; }

        public int Ordem { get; set; }

        [MaxLength(250) ,NotNull]
        public string UrlLogo { get; set; }
    }
}
