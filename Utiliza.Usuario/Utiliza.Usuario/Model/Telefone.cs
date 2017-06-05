using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Telefone
    {
        public int IdEmpresa { get; set; }
        public string CodigoArea { get; set; }
        public string NumeroTelefone { get; set; }

        public Telefone(int idEmpresa, string codigoArea, string numeroTelefone)
        {
            IdEmpresa = idEmpresa;
            CodigoArea = codigoArea;
            NumeroTelefone = numeroTelefone;
        }
    }
}
