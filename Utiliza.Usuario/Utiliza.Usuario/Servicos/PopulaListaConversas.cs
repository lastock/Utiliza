using System.Collections.Generic;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class PopulaListaConversas
    {
        public List<Conversa> Popula()
        {
            var _conversas = new List<Conversa>();
            _conversas.Add(new Conversa
            {
                IdFornecedor = 1,
                NomeFornecedor = "Total Dog",
                DescricaoFornecedor = "O melhor hotel para cães da grande São Paulo.",
                UrlLogo = "teste.png",
                HoraUltimaMensagem = "10:40",
                MensagensNaoLidas = 3
            });
            _conversas.Add(new Conversa
            {
                IdFornecedor = 2,
                NomeFornecedor = "Casa do Pastel",
                DescricaoFornecedor = "O melhor pastel de Mairiporã.",
                UrlLogo = "teste.png",
                HoraUltimaMensagem = "09:32",
                MensagensNaoLidas = 5
            });
            _conversas.Add(new Conversa
            {
                IdFornecedor = 3,
                NomeFornecedor = "Casa de Tintas",
                DescricaoFornecedor = "Aqui você compra suas tintas pelo menor preço.",
                UrlLogo = "teste.png",
                HoraUltimaMensagem = "11:47",
                MensagensNaoLidas = 2
            });
            return _conversas;
        }

    }
}
