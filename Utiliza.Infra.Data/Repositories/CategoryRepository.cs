using Utiliza.Infra.Data.Common;
using Dapper;
using Utiliza.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Utiliza.Domain.Views;

namespace Utiliza.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase
    {
        public CategoriaRepository()
        {
            //Debug.WriteLine("Passei por aqui!");
        }

        public List<Categoria> Get(int id)
        {
            using (var cn = UtilizaConnection)
            {
                var categoria = cn.QueryAsync<Categoria>($"Select * from Categoria Where IdCategoria = {id}").Result.ToList<Categoria>();
                return categoria;
            }
        }

        public List<Categoria> All()
        {
            using (var cn = UtilizaConnection)
            {
                var categoria = cn.QueryAsync<Categoria>($"Select * from Categoria").Result.ToList<Categoria>();
                return categoria;
            }
        }

        public void Add(List<Categoria> categoria)
        {
            using (var cn = UtilizaConnection)
            {
                cn.ExecuteAsync(@"INSERT INTO Categoria (NomeCategoria, Ordem, UrlLogo) VALUES (@NomeCategoria, @Ordem, @UrlLogo)", categoria);
            }
        }
        public void Update(List<Categoria> categoria)
        {
            using (var cn = UtilizaConnection)
            {
                cn.ExecuteAsync(@"UPDATE Categoria SET (NomeCategoria = @NomeCategoria, Ordem = @Ordem, UrlLogo = @UrlLogo) WHERE IdCategoria = @IdCategoria", categoria);
            }
        }
        public void Delete(List<int> id)
        {
            List<IdCategoriaView> idCategoria = new List<IdCategoriaView>(); ;
            foreach (var item in id)
            {
                idCategoria.Add(new IdCategoriaView { IdCategoria = item });
            }

            using (var cn = UtilizaConnection)
            {

                cn.Execute(@"DELETE FROM Categoria WHERE IdCategoria = @IdCategoria", idCategoria);
            }
        }
    }
}
