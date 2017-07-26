using SQLite;
using System.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("usuario")]
    public class Usuario
    {
        [PrimaryKey]
        public int IdUsuario { get; set; }
        [NotNull]
        public string NomeUsuario { get; set; }
        [NotNull,Unique]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
