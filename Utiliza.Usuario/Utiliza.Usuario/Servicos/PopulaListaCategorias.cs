using System.Collections.Generic;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class PopulaListaCategorias
    {
        public PopulaListaCategorias()
        {
            
        }
        public List<Categoria> Popula()
        {
            var _categorias = new List<Categoria>();
            _categorias.Add(new Categoria { IdCategoria = 1, NomeCategoria = "Alimentação", Ordem = 1, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 2, NomeCategoria = "Moda", Ordem = 2, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 3, NomeCategoria = "Serviços", Ordem = 3, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 4, NomeCategoria = "Saúde", Ordem = 4, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 5, NomeCategoria = "Beleza", Ordem = 5, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 6, NomeCategoria = "Produtos", Ordem = 6, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 7, NomeCategoria = "Casa", Ordem = 7, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 8, NomeCategoria = "Festas", Ordem = 8, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 9, NomeCategoria = "Lazer", Ordem = 9, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 10, NomeCategoria = "Automóveis", Ordem = 10, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 11, NomeCategoria = "Turismo", Ordem = 11, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 12, NomeCategoria = "Animais", Ordem = 12, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 13, NomeCategoria = "Taxi", Ordem = 13, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 14, NomeCategoria = "Onibus", Ordem = 14, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 15, NomeCategoria = "Igrejas", Ordem = 15, UrlLogo = "teste.png" });
            _categorias.Add(new Categoria { IdCategoria = 16, NomeCategoria = "Serviços", Ordem = 16, UrlLogo = "teste.png" });
            return _categorias;
        }

    }
}
