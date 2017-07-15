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
    public class SubCategoriaRepository
    {
        #region Construtor
        private SubCategoriaRepository()
        {
            using (var conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<SubCategoria>();
            }

        }

        #endregion

        #region inicialização de variáveis
        //conexão com o banco SQLite
        private static string dbFile;
        #endregion

        #region Propriedades
        //propriedade para acesso a mensagens - acho que não vai ser usada... talvez deletar
        public string StatusMessage { get; set; }

        // Propriedade estática para acesso ao repositório.
        private static SubCategoriaRepository instance;
        public static SubCategoriaRepository Instance
        {
            get
            {
                if (instance == null)
                    throw new Exception("You must call Initialize before retrieving the singleton for the CategoriaRepository.");

                return instance;
            }
        }
        #endregion

        #region Metodos
        //Método de inicialização - abre a conexão com o Banco
        public static void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            dbFile = filename;
            instance = new SubCategoriaRepository();
        }

        //Método que retorna todas as sub categorias de uma categoria
        public List<SubCategoria> GetSubCategoriasDeUmaCategoria(int idCategoria)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<SubCategoria>().Where(c => c.IdCategoria == idCategoria).OrderBy(s => s.Ordem).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Não pude acessar o banco. {0}", ex.Message);
                return null;
               //throw ex;
            }
        }

        //Adiciona uma subcategoria ao banco
        public void AddNewSubCategoria(int idSubCategoria, string nomeSubCategoria, int ordem, int idCategoria)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Insert(new SubCategoria { IdSubCategoria = idSubCategoria, NomeSubCategoria = nomeSubCategoria, Ordem = ordem, IdCategoria = idCategoria });
                }                    
                StatusMessage = string.Format($"{result} registro de SubCategoria adicionada: {nomeSubCategoria}");
                Debug.WriteLine(StatusMessage);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Falha ao adicionar {nomeSubCategoria}. Error: {ex.Message}");
                Debug.WriteLine(StatusMessage);
            }
        }

        //Faz update de uma sub categoria
        public bool UpdateSubCategoria(SubCategoria subCategoria)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Update(subCategoria);
                }
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = ($"Falha ao atualizar a subcategoria: {subCategoria.NomeSubCategoria}. Erro: {ex.Message}.");
                Debug.WriteLine(StatusMessage);
                return false;
            }
        }

        //Verifica se uma dada subcategoria existe no banco
        public bool ExisteSubCategoria(int idSubCategoria)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var subCategoria = conn.Find<SubCategoria>(c => c.IdSubCategoria == idSubCategoria);
                    if (subCategoria == null)
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
                Debug.WriteLine($"Erro no método ExisteSubCategoria. Erro: {ex.Message}");
                throw ex;
            }
        }


        #endregion


    }
}
