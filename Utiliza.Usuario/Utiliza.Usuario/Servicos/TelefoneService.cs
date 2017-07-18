using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class TelefoneService
    {
        public TelefoneService()
        {
            PopulaTelefones();
        }

        private void PopulaTelefones()
        {
            var telefones = new List<Telefone>();
            telefones.Add(new Telefone { IdTelefone = 1, IdFornecedor = 1, CodigoArea = "11", NumeroTelefone = "99935-1364", Operadora = "Vivo" });
            telefones.Add(new Telefone { IdTelefone = 2, IdFornecedor = 1, CodigoArea = "11", NumeroTelefone = "99935-4059", Operadora = "Vivo" });
            foreach (var telefone in telefones)
            {
                if (FornecedorRepository.Instance.ExisteTelefone(telefone.IdTelefone))
                {
                    FornecedorRepository.Instance.UpdateTelefone(telefone);
                }
                else
                {
                    FornecedorRepository.Instance.AddTelefone(telefone);
                }
            }

        }

        public List<Telefone> TelefonesDoFornecedor(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetTelefonesDeUmFornecedor(idFornecedor);
        }
    }
}
