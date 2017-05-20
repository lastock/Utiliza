using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class PopulaItensMenu
    {
        public List<Menu> Popula()
        {
            var _itensMenu = new List<Menu>();
            _itensMenu.Add(new Menu { IdMenu = 1, Icone = "home32.png", Item = "Home" });
            _itensMenu.Add(new Menu { IdMenu = 2, Icone = "minhaconta32.png", Item = "Fornecedores" });
            _itensMenu.Add(new Menu { IdMenu = 3, Icone = "chat32.png", Item = "Chat" });
            _itensMenu.Add(new Menu { IdMenu = 4, Icone = "cidade32.png", Item = "Trocar Cidade" });
            _itensMenu.Add(new Menu { IdMenu = 5, Icone = "promocao32.png", Item = "Promoções" });
            _itensMenu.Add(new Menu { IdMenu = 6, Icone = "favoritos32.png", Item = "Favoritos" });
            _itensMenu.Add(new Menu { IdMenu = 7, Icone = "location32.png", Item = "Mapa" });
            _itensMenu.Add(new Menu { IdMenu = 8, Icone = "lupa32.png", Item = "Procurar" });
            _itensMenu.Add(new Menu { IdMenu = 9, Icone = "minhaconta32.png", Item = "Minha Conta" });
            _itensMenu.Add(new Menu { IdMenu = 10, Icone = "config32.png", Item = "Configurações" });
            _itensMenu.Add(new Menu { IdMenu = 11, Icone = "info32.png", Item = "Sobre o Utiliza" });
            _itensMenu.Add(new Menu { IdMenu = 12, Icone = "termos32.png", Item = "Termos de uso" });
            return _itensMenu;
        }

    }
}
