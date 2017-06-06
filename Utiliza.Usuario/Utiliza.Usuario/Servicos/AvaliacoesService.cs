using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class AvaliacoesService
    {
        public AvaliacoesService()
        {
            
        }

        public List<Avaliacao> RetornaAvaliacoes(int idFornecedor)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            avaliacoes.Add(new Avaliacao(1, idFornecedor, 5, "É o melhor hotel para chachorros que eu conheci!"));
            avaliacoes.Add(new Avaliacao(2, idFornecedor, 4, "O espaço para os cães é incrível."));
            avaliacoes.Add(new Avaliacao(3, idFornecedor, 5, "Trataram muito bem do meu cão e o lugar é maravilgoso. Recomendo!"));
            avaliacoes.Add(new Avaliacao(4, idFornecedor, 5, "Levo sempre meu cão lá. É ótimo e mau cão adora ficar lá."));
            avaliacoes.Add(new Avaliacao(5, idFornecedor, 4, "Os proprieários são muito prestativos e meu cão ficou muito bem lá."));
            avaliacoes.Add(new Avaliacao(6, idFornecedor, 5, "Nunca imaginei que pudesse ter um local como esse tão perto de São Paulo."));
            return null;
        }
    }
}
