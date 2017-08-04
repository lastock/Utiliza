using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class AvaliacaoService
    {
        public AvaliacaoService()
        {
            PopulaAvaliacao();
        }

        public List<Avaliacao> RetornaAvaliacoes(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetAvaliacoesDoFornecedor(idFornecedor);
        }

        public Avaliacao RetornaAvaliacaoById(int idAvaliacao)
        {
            return FornecedorRepository.Instance.GetAvaliacaoById(idAvaliacao);
        }

        public Avaliacao AvaliacaoDoUsuario(string userName, int idFornecedor)
        {
            return FornecedorRepository.Instance.GetAvaliacaoDoUsuario(userName, idFornecedor);
        }

        public void PopulaAvaliacao()
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            avaliacoes.Add(new Avaliacao { IdAvaliacao = 1, IdFornecedor = 1, UserName = "lastock@outlook.com.br", Nome = "Luis", ValorAvaliacao = 5, Comentario = "É o melhor hotel para cachorros que eu conheci!" });
            avaliacoes.Add(new Avaliacao { IdAvaliacao = 2, IdFornecedor = 1, UserName = "pedro@gmail.com", Nome = "Pedro", ValorAvaliacao = 4, Comentario = "O espaço para os cães é incrível." });
            avaliacoes.Add(new Avaliacao { IdAvaliacao = 3, IdFornecedor = 1, UserName = "maria@hotmail.com", Nome = "Maria", ValorAvaliacao = 5, Comentario = "Trataram muito bem do meu cão e o lugar é maravilgoso. Recomendo!" });
            avaliacoes.Add(new Avaliacao { IdAvaliacao = 4, IdFornecedor = 1, UserName = "leda@bol.com.br", Nome = "Leda", ValorAvaliacao = 5, Comentario = "Levo sempre meu cão lá. É ótimo e mau cão adora ficar lá." });
            avaliacoes.Add(new Avaliacao { IdAvaliacao = 5, IdFornecedor = 1, UserName = "xuxa@uol.com.br", Nome = "Xuxa", ValorAvaliacao = 4, Comentario = "Os proprieários são muito prestativos e meu cão ficou muito bem lá." });
            avaliacoes.Add(new Avaliacao { IdAvaliacao = 6, IdFornecedor = 1, UserName = "lucas@lilas.com", Nome = "Lucas", ValorAvaliacao = 5, Comentario = "Nunca imaginei que pudesse ter um local como esse tão perto de São Paulo." });
            foreach (var avaliacao in avaliacoes)
            {
                if (FornecedorRepository.Instance.ExisteAvaliacao(avaliacao.IdAvaliacao))
                {
                    //FornecedorRepository.Instance.UpdateAvaliacao(avaliacao);
                }
                else
                {
                    FornecedorRepository.Instance.AddAvaliacao(avaliacao);
                }
            }
        }


    }
}
