using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class CidadeService
    {
        public List<Cidade> ListaDeCidades()
        {
            List<Cidade> cidades = new List<Cidade>() ;
            cidades.Add(new Cidade { IdCidade = 1, NomeCidade = "Mairiporã", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 2, NomeCidade = "Franco da Rocha", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 3, NomeCidade = "Caeiras", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 4, NomeCidade = "Atibaia", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 5, NomeCidade = "Bragança Paulista", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 6, NomeCidade = "Francisco Morato", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 7, NomeCidade = "Várzea Paulista", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 8, NomeCidade = "Campo Limpo Paulista", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 9, NomeCidade = "Jundiaí", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 10, NomeCidade = "Nazaré Paulista", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 11, NomeCidade = "Itatiba", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 12, NomeCidade = "Piracaia", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 13, NomeCidade = "Joanópolis", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 14, NomeCidade = "Jarinu", SiglaEstado = "SP" });
            cidades.Add(new Cidade { IdCidade = 15, NomeCidade = "São Paulo", SiglaEstado = "SP" });
            return cidades;
        }
    }
}
