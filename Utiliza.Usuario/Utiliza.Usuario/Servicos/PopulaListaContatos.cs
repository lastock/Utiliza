using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class PopulaListaContatos
    {
        public List<Contato> Popula(int idFornecedor)
        {
            var _contatos = new List<Contato>();
            _contatos.Add(new Contato(1, 1, "(11) 99935-1364", "Luis Alfredo", "luis@totaldog.com.br"));
            _contatos.Add(new Contato(2, 1, "(11) 99935-4059", "Cindy", "cindy@totaldog.com.br"));
            return _contatos.Where(x => x.IdFornecedor == idFornecedor).ToList();
        }

    }
}
