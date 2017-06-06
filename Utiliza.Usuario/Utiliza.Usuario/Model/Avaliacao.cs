using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public int IdFornecedor { get; set; }
        public double ValorAvaliacao { get; set; }
        public string Comentario { get; set; }

        public Avaliacao(int idAvaliacao, int idFornecedor, double valorAvaliacao, string comentario)
        {
            IdAvaliacao = idAvaliacao;
            IdFornecedor = idFornecedor;
            ValorAvaliacao = valorAvaliacao;
            Comentario = comentario;
        }
    }
}
