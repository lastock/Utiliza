using System;
using System.Collections.Generic;
using Utiliza.Domain.Entities;
using Utiliza.Infra.Data.Repositories;

namespace TesteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var catRepo = new CategoriaRepository();
            var categoria = new List<Categoria>();
            bool continua = true;
            do
            {
                Console.WriteLine("Digite 1 para pesquisar somente uma categoria ou qualquer outra coisa para pesquisar todas.");
                string resposta = Console.ReadLine();

                if (resposta == "1")
                {
                    Console.WriteLine("Digite o código da categoria.");
                    string idCategoria = Console.ReadLine();
                    categoria = catRepo.Get(Convert.ToInt32(idCategoria));
                    
                }
                else
                {
                   categoria = catRepo.All();
                }

                foreach (var cat in categoria)
                {
                    Console.WriteLine($"Ordem = {cat.Ordem} Nome = {cat.NomeCategoria}");

                }
                Console.WriteLine("Nova consulta?");
                resposta = Console.ReadLine();
                if (resposta=="S" || resposta=="s")
                {
                    continua = true;
                    Console.Clear();
                }
                else
                {
                    continua = false;
                }
            } while (continua);
        }
    }
}
