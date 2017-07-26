using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class FacilidadeService
    {
        public FacilidadeService()
        {
            PopulaFacilidades();        
        }

        private void PopulaFacilidades()
        {
            var facilidades = new List<Facilidade>();

            facilidades.Add(new Facilidade { IdFacilidade = 1, IdFornecedor = 1, IconFacilidade = "pet.png", DescricaoFacilidade = "Cães são bem vindos" });
            facilidades.Add(new Facilidade { IdFacilidade = 2, IdFornecedor = 1, IconFacilidade = "estacionamento.png", DescricaoFacilidade = "Estacionamento no local" });
            facilidades.Add(new Facilidade { IdFacilidade = 3, IdFornecedor = 1, IconFacilidade = "bitcoin.png", DescricaoFacilidade = "Aceita-se pagamento em bitcoins" });
            facilidades.Add(new Facilidade { IdFacilidade = 4, IdFornecedor = 1, IconFacilidade = "wifi.png", DescricaoFacilidade = "Wifi disponível para clientes" });
            foreach (var facilidade in facilidades)
            {
                if (FornecedorRepository.Instance.ExisteFacilidade(facilidade.IdFacilidade))
                {
                    //FornecedorRepository.Instance.UpdateFacilidade(facilidade);
                }
                else
                {
                    FornecedorRepository.Instance.AddFacilidade(facilidade);
                }
            }

        }

        public List<Facilidade> FacilidadeDoFornecedor(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetFacilidadesDeUmFornecedor(idFornecedor);
        }

    }
}
