using System;

namespace Utiliza.Usuario.Model
{
    public class SubCategoria
    {
        public int IdSubCategoria { get; set; }
        public string NomeSubCategoria { get; set; }
        public int IdCategoria { get; set; }
        public int Ordem { get; set; }
    }
}
