using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class ContatoService
    {
        public ContatoService()
        {
            PopulaContatos();
        }

        private void PopulaContatos()
        {
            var contatos = new List<Contato>();
            contatos.Add(new Contato { IdContato = 1, IdFornecedor = 1, NomeContato = "Luis Alfredo", Email = "luis@totaldog.com.br", Telefone = "(11) 99935-1364" });
            contatos.Add(new Contato { IdContato = 2, IdFornecedor = 1, NomeContato = "Cindy", Email = "cindy@totaldog.com.br", Telefone = "(11) 99935-4059" });

            foreach (var contato in contatos)
            {
                if (FornecedorRepository.Instance.ExisteTelefone(contato.IdContato))
                {
                    FornecedorRepository.Instance.UpdateContato(contato);
                }
                else
                {
                    FornecedorRepository.Instance.AddContato(contato);
                }
            }
        }

        public List<Contato> ContatosDoFornecedor(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetContatosDeUmFornecedor(idFornecedor);
        }

    }
}
