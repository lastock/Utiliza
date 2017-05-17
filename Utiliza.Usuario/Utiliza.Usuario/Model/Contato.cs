using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Contato
    {
        public int IdUsuario { get; set; }
        public int IdFornecedor { get; set; }
        public string Telefone { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
    }
}
