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
            _itensMenu.Add(new Menu { IdMenu = 1, Icone = "lupa16.png", Item = "Chat" });
            _itensMenu.Add(new Menu { IdMenu = 2, Icone = "lupa16.png", Item = "Fornecedores" });
            _itensMenu.Add(new Menu { IdMenu = 3, Icone = "lupa16.png", Item = "Procura" });
            _itensMenu.Add(new Menu { IdMenu = 4, Icone = "lupa16.png", Item = "Login" });
            _itensMenu.Add(new Menu { IdMenu = 5, Icone = "lupa16.png", Item = "Sobre" });
            return _itensMenu;
        }

    }
}
