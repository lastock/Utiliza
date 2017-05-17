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
            _contatos.Add(new Contato { IdUsuario = 1, IdFornecedor = 1, Telefone = "(11) 99935-1364", NomeUsuario = "Luis Alfredo", Email = "luis@totaldog.com.br" });
            _contatos.Add(new Contato { IdUsuario = 2, IdFornecedor = 1, Telefone = "(11) 99935-1364", NomeUsuario = "Cindy", Email = "cindy@totaldog.com.br" });
            return _contatos.Where(x => x.IdFornecedor == idFornecedor).ToList();
        }

    }
}
