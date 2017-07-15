using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.Repositories
{
    public class FornecedorRepository
    {
        #region Construtor
        private FornecedorRepository()
        {
            using (var conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<Fornecedor>();
            }
        }
        #endregion

        #region Inicialização de Variáveis
        private static string dbFile;
        #endregion

        #region Propriedades
        //propriedade para acesso a mensagens - acho que não vai ser usada... talvez deletar
        public string StatusMessage { get; set; }

        // Propriedade estática para acesso ao repositório.
        private static FornecedorRepository instance;
        public static FornecedorRepository Instance
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

        public static void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            dbFile = filename;
            instance = new FornecedorRepository();
        }

        //Verifica se um fornecedor existe no banco
        public bool ExisteFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var fornecedor = conn.Find<Fornecedor>(c => c.IdFornecedor == idFornecedor);
                    if (fornecedor == null)
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

        //Faz update de um fornecedor
        public bool UpdateSubCategoria(Fornecedor fornecedor)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Update(fornecedor);
                }
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = ($"Falha ao atualizar o fornecedor: {fornecedor.NomeFantasia}. Erro: {ex.Message}.");
                Debug.WriteLine(StatusMessage);
                return false;
            }
        }

        //Adiciona um fornecedor ao banco
        public void AddNewFornecedor(int IdFornecedor, 
            string razaoSocial, 
            string nomeFantasia,
            string chamada,
            string endereco,
            string bairro,
            string cep,
            string cidade,
            string estado,
            string tipoDePessoa,
            string cnpjCpf,
            string site,
            string resumo,
            string descricao,
            double latitude,
            double longitude,
            string logo,
            int subCategoria,
            int categoria,
            double avaliacao,
            string horario)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Insert(new Fornecedor {
                        IdFornecedor = IdFornecedor,
                        NomeRazaoSocial = razaoSocial,
                        NomeFantasia = nomeFantasia,
                        Chamada = chamada,
                        Endereco = endereco,
                        Bairro = bairro,
                        Cep = cep,
                        Cidade = cidade,
                        Estado = estado,
                        TipoDePessoa = tipoDePessoa,
                        CnpjCpf = cnpjCpf,
                        Site = site,
                        Resumo = resumo,
                        Descricao = descricao,
                        Latitude = latitude,
                        Longitude = longitude,
                        Logo = logo,
                        Subcategoria = subCategoria,
                        Categoria = categoria,
                        Avaliacao = avaliacao,
                        Horario = horario
                    });
                }
                StatusMessage = string.Format($"{result} registro de Fornecedor adicionado: {razaoSocial}");
                Debug.WriteLine(StatusMessage);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Falha ao adicionar {razaoSocial}. Error: {ex.Message}");
                Debug.WriteLine(StatusMessage);
            }
        }

        //Método que retorna todos os fornecedores de uma categoria
        public List<Fornecedor> GetFornecedoresDeUmaCategoria(int idCategoria)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Fornecedor>().Where(c => c.Categoria == idCategoria).OrderBy(s => s.NomeFantasia).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }
        //Método que retorna todos os fornecedores de uma subcategoria
        public List<Fornecedor> GetFornecedoresDeUmaSubCategoria(int idSubCategoria)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Fornecedor>().Where(c => c.Subcategoria == idSubCategoria).OrderBy(s => s.NomeFantasia).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Retorna um fornecedor
        public Fornecedor GetCategoria(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Find<Fornecedor>(c => c.IdFornecedor == idFornecedor);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não encontrei o fornecedor com id = {idFornecedor}. Erro: {ex.Message}.");
                Debug.WriteLine(StatusMessage);
                return null;
            }

        }

        //Retorna procura de fornecedores
        public List<Fornecedor> GetProcuraFornecedores(string procura, bool procuraPorDistancia, int distancia = 0, int subCategoria = 0, int categoria = 0)
        {
            try
            {
                var fornecedores = new List<Fornecedor>();
                using (var conn = new SQLiteConnection(dbFile))
                {
                    if (subCategoria==0 && categoria == 0)
                    {
                        if (String.IsNullOrEmpty(procura))
                        {
                            fornecedores = conn.Table<Fornecedor>().OrderBy(f => f.NomeFantasia).ToList();
                        }
                        else
                        {
                            fornecedores = conn.Table<Fornecedor>().Where(f => f.NomeFantasia.Contains(procura) || f.NomeRazaoSocial.Contains(procura) || f.Resumo.Contains(procura) || f.Descricao.Contains(procura) || f.Chamada.Contains(procura)).OrderBy(f => f.NomeFantasia).ToList();
                        }
                    }
                    else
                    {
                        if (subCategoria == 0)
                        {
                            if (String.IsNullOrEmpty(procura))
                            {
                                fornecedores = conn.Table<Fornecedor>().Where(f => f.Categoria== categoria).OrderBy(s => s.NomeFantasia).ToList();
                            }
                            else
                            {
                                fornecedores = conn.Table<Fornecedor>().Where(f => (f.Categoria==categoria)  && (f.NomeFantasia.Contains(procura) || f.NomeRazaoSocial.Contains(procura) || f.Resumo.Contains(procura) || f.Descricao.Contains(procura) || f.Chamada.Contains(procura))).OrderBy(f => f.NomeFantasia).ToList();
                            }
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(procura))
                            {
                                fornecedores = conn.Table<Fornecedor>().Where(f => f.Subcategoria == subCategoria).OrderBy(s => s.NomeFantasia).ToList();
                            }
                            else
                            {
                                fornecedores = conn.Table<Fornecedor>().Where(f => (f.Subcategoria == subCategoria) && (f.NomeFantasia.Contains(procura) || f.NomeRazaoSocial.Contains(procura) || f.Resumo.Contains(procura) || f.Descricao.Contains(procura) || f.Chamada.Contains(procura))).OrderBy(f => f.NomeFantasia).ToList();
                            }
                        }
                    }
                }

                if (procuraPorDistancia)
                {
                    var fornecedoresNaDistancia = new List<Fornecedor>();
                    var fornServicos = new FornecedorServicos();
                    foreach (var fornecedor in fornecedores)
                    {
                        if (fornServicos.DistanciaDoLocal(fornecedor.Latitude,fornecedor.Longitude) <= distancia)
                        {
                            fornecedoresNaDistancia.Add(fornecedor);
                        }
                    }
                    fornecedores = fornecedoresNaDistancia;
                }

                return fornecedores;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        #endregion
    }
}
