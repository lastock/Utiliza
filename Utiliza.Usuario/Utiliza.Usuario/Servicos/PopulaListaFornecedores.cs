using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class PopulaListaFornecedores
    {
        public List<Fornecedor> Popula(int subcategoria)
        {
            var _fornecedores = new List<Fornecedor>();
            _fornecedores.Add(new Fornecedor { IdFornecedor = 1, NomeFantasia = "TotalDog", Resumo = "O melhor hotel para cães da grande São Paulo", Logo = "teste.png", Subcategoria = 35 });
            _fornecedores.Add(new Fornecedor { IdFornecedor = 2, NomeFantasia = "Pizzaria do Zé", Resumo = "A melhor pizza de Mairiporã", Logo = "teste.png", Subcategoria = 2 });
            _fornecedores.Add(new Fornecedor { IdFornecedor = 3, NomeFantasia = "Cidade Bonita", Resumo = "A melhor piza com a melhor vista da cidade.", Logo = "teste.png", Subcategoria = 2 });
            _fornecedores.Add(new Fornecedor { IdFornecedor = 4, NomeFantasia = "Restaurante do Pipo", Resumo = "Coma a vontade e pague quando puder.", Logo = "teste.png", Subcategoria = 1 });
            _fornecedores.Add(new Fornecedor { IdFornecedor = 5, NomeFantasia = "Kilo da Chepa", Resumo = "Vale quanto pesa.", Logo = "teste.png", Subcategoria = 1 });
            return _fornecedores.Where(x => x.Subcategoria== subcategoria).ToList();
        }
    }
}
