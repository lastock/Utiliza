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

        #region Métodos Fornecedor

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
        public bool UpdateFornecedor(Fornecedor fornecedor)
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


        //Retorna procura de fornecedores
        public List<Fornecedor> GetProcuraFornecedores(Procura _procura)
        {
            var procura = _procura.StringProcura ;
            var procuraPorDistancia = _procura.ProcuraPorDistancia;
            var distancia = _procura.Distancia;
            var subCategoria = _procura.IdSubCategoria;
            var categoria = _procura.IdCategoria;
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

        //Retorna um fornecedor
        public Fornecedor GetFornecedorById(int idFornecedor)
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
                StatusMessage = string.Format("Não encontrei o fornecedor com id = {0}. Erro: {1}.", idFornecedor, ex.Message);
                Debug.WriteLine(StatusMessage);
                return null;
            }

        }

        //Retorna fornecedores favoritos
        public List<Fornecedor> GetFornecedoresFavoritos()
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Fornecedor>().Where(c => c.Favorito == true).OrderBy(s => s.NomeFantasia).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }
        #endregion

        #region Metodos Contato

        //Retorna contatos de um fornecedor
        public List<Contato> GetContatosDeUmFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Contato>().Where(c => c.IdFornecedor == idFornecedor).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Atualiza contato
        public bool UpdateContato(Contato contato)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Update(contato);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {contato.NomeContato}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Deleta contato
        public bool DeletaContato(Contato contato)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Delete(contato);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco para deletar o telefone {contato.NomeContato}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Adiciona contato
        public bool AddTelefone(Contato contato)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(contato);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {contato.NomeContato}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        #endregion

        #region metodos Telefone

        //Retorna telefones de um fornecedor
        public List<Telefone> GetTelefonesDeUmFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Telefone>().Where(c => c.IdFornecedor == idFornecedor).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Atualiza telefone
        public bool UpdateTelefone(Telefone telefone)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Update(telefone);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {telefone.NumeroTelefone}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Deleta telefone
        public bool DeletaTelefone(Telefone telefone)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Delete(telefone);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco para deletar o telefone {telefone.NumeroTelefone}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Adiciona telefone
        public bool AddTelefone(Telefone telefone)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(telefone);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {telefone.NumeroTelefone}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        #endregion

        #region metodos Facilidades

        //Retorna facilidades de um fornecedor
        public List<Facilidade> GetFacilidadesDeUmFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Facilidade>().Where(c => c.IdFornecedor == idFornecedor).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Atualiza facilidade
        public bool UpdateFacilidade(Facilidade facilidade)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Update(facilidade);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {facilidade.DescricaoFacilidade}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Deleta facilidade
        public bool DeletaFacilidade(Facilidade facilidade)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Delete(facilidade);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco para deletar o facilidade {facilidade.DescricaoFacilidade}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Adiciona facilidade
        public bool AddFacilidade(Facilidade facilidade)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(facilidade);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {facilidade.DescricaoFacilidade}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        #endregion

        #region metodos Imagens

        //Retorna imagens de um fornecedor
        public List<ImagemFornecedor> GetImagensDeUmFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<ImagemFornecedor>().Where(c => c.IdFornecedor == idFornecedor).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Atualiza ImagemFornecedor
        public bool UpdateImagemFornecedor(ImagemFornecedor imagem)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Update(imagem);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar a imagem {imagem.NomeArquivo}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Deleta ImagemFornecedor
        public bool DeletaFacilidade(ImagemFornecedor imagem)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Delete(imagem);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco para deletar a imagem {imagem.NomeArquivo}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Adiciona facilidade
        public bool AddImagemFornecedor(ImagemFornecedor imagem)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(imagem);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao adicionar a imagem {imagem.NomeArquivo}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        #endregion

        #region metodos promoções

        //Retorna imagens de um fornecedor
        public List<Promocao> GetPromocoesDeUmFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Promocao>().Where(c => c.IdFornecedor == idFornecedor && c.StatusPromocao == true).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        public List<Promocao> GetTodasPromocoes()
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Promocao>().Where(c => c.StatusPromocao == true).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Atualiza ImagemFornecedor
        public bool UpdatePromocao(Promocao promocao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Update(promocao);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar a promocao {promocao.DescricaoPromocao}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Deleta ImagemFornecedor
        public bool DeletaPromocao(Promocao promocao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Delete(promocao);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco para deletar a promocao {promocao.DescricaoPromocao}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Adiciona facilidade
        public bool AddPromocao(Promocao promocao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(promocao);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao adicionar a promocao {promocao.DescricaoPromocao}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        #endregion

        #endregion
    }
}
