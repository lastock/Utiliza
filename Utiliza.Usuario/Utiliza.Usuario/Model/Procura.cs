using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Procura
    {
        public string StringProcura { get; set; }
        public int Distancia { get; set; }
        public bool ProcuraPorDistancia { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubCategoria { get; set; }
    }
}
