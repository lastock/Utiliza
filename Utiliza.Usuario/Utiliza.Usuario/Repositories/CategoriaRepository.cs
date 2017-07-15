using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Repositories
{
    public sealed class CategoriaRepository
    {
        #region Construtor

        //construtor
        private CategoriaRepository()
        {
            //conn = new SQLiteAsyncConnection(dbPath);
            //connSync = new SQLiteConnection(dbPath);
            using (var conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<Categoria>();

            }
        }

        #endregion

        #region inicialização de variáveis
        //variáveis de conexão com o Banco SQLite
        //private SQLiteAsyncConnection conn;
        //private SQLiteConnection connSync;
        #endregion

        #region propriedades
        //propriedade para acesso a mensagens - acho que não vai ser usada... talvez deletar
        public string StatusMessage { get; set; }

        // Propriedade estática para acesso ao repositório.
        private static string dbFile;
        private static CategoriaRepository instance;
        public static CategoriaRepository Instance
        {
            get
            {
                if (instance == null)
                    throw new Exception("You must call Initialize before retrieving the singleton for the CategoriaRepository.");

                return instance;
            }
        }

        #endregion

        #region Métodos
        //Método de inicialização - abre a conexão com o Banco
        public static void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            //dispose any existing connection
            //if (instance != null)
            //{
            //    instance.conn.GetConnection().Dispose();
            //}
            dbFile = filename;
            instance = new CategoriaRepository();
        }

        //Retorna todas as categorias assíncrono
        public List<Categoria> GetAllCategorias()
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Categoria>().OrderBy(c => c.Ordem).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Não pude acessar o banco. {0}", ex.Message);
                 return null;
           }

        }


        //Adiciona uma categoria ao Banco
        public void AddNewCategoria(int idCategoria, string nomeCategoria, int ordem, string urlLogo)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Insert(new Categoria {IdCategoria = idCategoria, NomeCategoria = nomeCategoria, Ordem = ordem, UrlLogo = urlLogo });
                }

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, nomeCategoria);
                Debug.WriteLine(StatusMessage);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nomeCategoria, ex.Message);
                Debug.WriteLine(StatusMessage);
            }
        }

        //Retorna uma categoria
        public Categoria GetCategoria(int idCategoria)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Find<Categoria>(c => c.IdCategoria == idCategoria);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Não encontrei a categoria com id = {0}. Erro: {1}.", idCategoria, ex.Message);
                Debug.WriteLine(StatusMessage);
                return null;
            }

        }

        //Verifica se uma dada categoria existe no banco
        public bool ExisteCategoria(int idCategoria)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var categoria = conn.Find<Categoria>(c => c.IdCategoria == idCategoria);
                    if (categoria == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Deleta uma categoria
        public bool DeleteCategoriaAsync(Categoria categoria)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Delete(categoria);
                }
                StatusMessage = $"A categoria {categoria.NomeCategoria} foi excluida.";
                Debug.WriteLine(StatusMessage);
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = ($"Falha ao deletar a Categoria. Erro: {ex.Message}.");
                Debug.WriteLine(StatusMessage);
                return false;
            }
        }

        //Faz update de uma categoria
        public bool UpdateCategoria(Categoria categoria)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Update(categoria);
                }
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = ($"Falha ao atualizar a categoria: {categoria.NomeCategoria}. Erro: {ex.Message}.");
                Debug.WriteLine(StatusMessage);
                return false;
            }
        }
       #endregion
    }
}
