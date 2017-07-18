using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class CategoriaService
    {
        public void PopulaCategoria()
        {
            var _categorias = new List<Categoria>();
            _categorias.Add(new Categoria { IdCategoria = 1, NomeCategoria = "Alimentação", Ordem = 1, UrlLogo = "alimentacao.png" });
            _categorias.Add(new Categoria { IdCategoria = 2, NomeCategoria = "Moda", Ordem = 2, UrlLogo = "moda.png" });
            _categorias.Add(new Categoria { IdCategoria = 3, NomeCategoria = "Serviços", Ordem = 3, UrlLogo = "servicos.png" });
            _categorias.Add(new Categoria { IdCategoria = 4, NomeCategoria = "Saúde", Ordem = 4, UrlLogo = "saude.png" });
            _categorias.Add(new Categoria { IdCategoria = 5, NomeCategoria = "Beleza e Estética", Ordem = 5, UrlLogo = "belezaestetica.png" });
            _categorias.Add(new Categoria { IdCategoria = 6, NomeCategoria = "Produtos", Ordem = 6, UrlLogo = "produtos.png" });
            _categorias.Add(new Categoria { IdCategoria = 7, NomeCategoria = "Casa e Decoração", Ordem = 7, UrlLogo = "casadecoracao.png" });
            _categorias.Add(new Categoria { IdCategoria = 8, NomeCategoria = "Festas e Eventos", Ordem = 8, UrlLogo = "festaseventos.png" });
            _categorias.Add(new Categoria { IdCategoria = 9, NomeCategoria = "Esportes e Lazer", Ordem = 9, UrlLogo = "esporteslazer.png" });
            _categorias.Add(new Categoria { IdCategoria = 10, NomeCategoria = "Automóveis", Ordem = 10, UrlLogo = "automoveis.png" });
            _categorias.Add(new Categoria { IdCategoria = 11, NomeCategoria = "Turismo", Ordem = 11, UrlLogo = "turismo.png" });
            _categorias.Add(new Categoria { IdCategoria = 12, NomeCategoria = "Animais", Ordem = 12, UrlLogo = "animais.png" });
            _categorias.Add(new Categoria { IdCategoria = 13, NomeCategoria = "Taxi", Ordem = 13, UrlLogo = "taxi.png" });
            _categorias.Add(new Categoria { IdCategoria = 14, NomeCategoria = "Calçados", Ordem = 14, UrlLogo = "calcados.png" });
            _categorias.Add(new Categoria { IdCategoria = 15, NomeCategoria = "Igrejas", Ordem = 15, UrlLogo = "igrejas.png" });
            _categorias.Add(new Categoria { IdCategoria = 16, NomeCategoria = "Farmácias", Ordem = 16, UrlLogo = "farmacia.png" });
            _categorias.Add(new Categoria { IdCategoria = 17, NomeCategoria = "Reparos", Ordem = 17, UrlLogo = "reparos.png" });
            _categorias.Add(new Categoria { IdCategoria = 18, NomeCategoria = "Saúde e Fitness", Ordem = 18, UrlLogo = "saudefitness.png" });
            _categorias.Add(new Categoria { IdCategoria = 19, NomeCategoria = "Serviços Públicos", Ordem = 19, UrlLogo = "publicos.png" });

            foreach (var categoria in _categorias)
            {
                if ( CategoriaRepository.Instance.ExisteCategoria(categoria.IdCategoria))
                {
                    CategoriaRepository.Instance.UpdateCategoria(categoria);
                }
                else
                {
                    CategoriaRepository.Instance.AddNewCategoria(categoria.IdCategoria, categoria.NomeCategoria, categoria.Ordem, categoria.UrlLogo);
                }
            }

        }

        public List<Categoria> GetAllCategorias()
        {
            PopulaCategoria();
            return CategoriaRepository.Instance.GetAllCategorias();
        }

        public Categoria GetCategoria(int idCategoria)
        {
            return CategoriaRepository.Instance.GetCategoria(idCategoria);
        }
        public Categoria GetCategoria(string Categoria)
        {
            return CategoriaRepository.Instance.GetCategoria(Categoria);
        }
    }
}
