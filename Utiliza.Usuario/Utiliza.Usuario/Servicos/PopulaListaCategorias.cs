﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class PopulaListaCategorias
    {
        public PopulaListaCategorias()
        {
            
        }

        public void Popula()
        {
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Alimentação", 1, "alimentacao.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Moda", 2, "moda.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Serviços", 3, "servicos.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Saúde", 4, "saude.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Beleza e Estética", 5, "belezaestetica.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Produtos", 6, "produtos.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Casa e Decoração", 7, "casadecoracao.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Festas e Eventos", 8, "festaseventos.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Esportes e Lazer", 9, "esporteslazer.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Automóveis", 10, "automoveis.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Turismo", 11, "turismo.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Animais", 12, "animais.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Taxi", 13, "taxi.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Calçados", 14, "calcados.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Igrejas", 15, "igrejas.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Farmácias", 16, "farmacia.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Reparos", 17, "reparos.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Saúde e Fitness", 18, "saudefitness.png");
            //await CategoriaRepository.Instance.AddNewCategoriaAsync("Serviços Públicos", 19, "publicos.png");

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
                if (CategoriaRepository.Instance.GetCategoria(categoria.IdCategoria) == null)
                {
                    CategoriaRepository.Instance.AddNewCategoria(categoria.IdCategoria, categoria.NomeCategoria, categoria.Ordem, categoria.UrlLogo);
                }
                else
                {
                    CategoriaRepository.Instance.UpdateCategoria(categoria);
                }
            }
        }

    }
}
