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
                conn.CreateTable<ImagemFornecedor>();
                conn.CreateTable<Telefone>();
                conn.CreateTable<Contato>();
                conn.CreateTable<Facilidade>();
                conn.CreateTable<Promocao>();
                conn.CreateTable<Avaliacao>();
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
        public void AddNewFornecedor(Fornecedor fornecedor)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    result = conn.Insert(fornecedor);
                }
                StatusMessage = string.Format($"{result} registro de Fornecedor adicionado: {fornecedor.NomeFantasia}");
                Debug.WriteLine(StatusMessage);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Falha ao adicionar {fornecedor.NomeFantasia}. Error: {ex.Message}");
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
                    var fornServicos = new FornecedorService();
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

        #region métodos favoritos

        public bool AdicionaRetiraFornecedorDosFavoritos(int idFornecedor)
        {
            var fornecedor = GetFornecedorById(idFornecedor);
            if (fornecedor.Favorito == true)
            {
                fornecedor.Favorito = false;
                var alterado = UpdateFornecedor(fornecedor);
                return false;
            }
            else
            {
                fornecedor.Favorito = true;
                var alterado = UpdateFornecedor(fornecedor);
                return true;
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
                    //var contatos = conn.Table<Contato>().ToList();
                    var contatosInfo = conn.GetTableInfo("contato");
                    var contatos = conn.Table<Contato>().ToList();

                    //var contatos = conn.Table<Contato>().Where(c => c.IdFornecedor == idFornecedor).ToList();
                    return contatos;
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
                    StatusMessage = string.Format($"Update feito no contato: {contato.NomeContato}.");
                    Debug.WriteLine(StatusMessage);

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
        public bool AddContato(Contato contato)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(contato);
                    StatusMessage = string.Format($"Adicionado novo contato: {contato.NomeContato}.");
                    Debug.WriteLine(StatusMessage);

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

        //Adiciona ou altera contato
        public bool AddOrUpdateContato(Contato contato)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var i = conn.InsertOrReplace(contato, typeof(Contato));
                    StatusMessage = string.Format($"{i} registro Adicionado ou alterado o contato: {contato.NomeContato}.");
                }
                    Debug.WriteLine(StatusMessage);

                    return true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar o telefone {contato.NomeContato}. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Verifica se um contato existe no banco
        public bool ExisteContato(int idContato)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var avaliacao = conn.Find<Contato>(c => c.IdContato == idContato);
                    if (avaliacao == null)
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
        //Retorna o telefone principal de um fornecedor
        public Telefone GetTelefonePrincipalDeUmFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                     return conn.Find<Telefone>(c => c.IdFornecedor == idFornecedor && c.TelefonePrincipal==true);
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

        //Verifica se um telefone existe no banco
        public bool ExisteTelefone(int idTelefone)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var avaliacao = conn.Find<Telefone>(c => c.IdTelefone == idTelefone);
                    if (avaliacao == null)
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

        //Verifica se a facilidade existe no banco
        public bool ExisteFacilidade(int idFacilidade)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var avaliacao = conn.Find<Facilidade>(c => c.IdFacilidade == idFacilidade);
                    if (avaliacao == null)
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

        #region metodos Imagens

        //Verifica se uma imagem existe no banco
        public bool ExisteImagem(int idImagem)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var avaliacao = conn.Find<ImagemFornecedor>(c => c.IdImagem == idImagem);
                    if (avaliacao == null)
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

        //Retorna promoções de um fornecedor
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

        //Retorna todas as promoções
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

        //Adiciona promoção
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

        //Verifica se uma promoção existe no banco
        public bool ExistePromocao(int idPromocao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var avaliacao = conn.Find<Promocao>(c => c.IdPromocao == idPromocao);
                    if (avaliacao == null)
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

        #region metodos Avaliacão

        //Retorna todas as avaliações
        public List<Avaliacao> GetAvaliacoesDoFornecedor(int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Table<Avaliacao>().Where(c => c.IdFornecedor == idFornecedor).ToList();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Retorna a avaliação de um usuário
        public Avaliacao GetAvaliacaoDoUsuario(string userName, int idFornecedor)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Find<Avaliacao>(c => c.UserName == userName && c.IdFornecedor == idFornecedor);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Retorna a avaliação de um usuário pelo id da avaliação
        public Avaliacao GetAvaliacaoById(int idAvaliacao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    return conn.Find<Avaliacao>(c => c.IdAvaliacao == idAvaliacao);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco. {ex.Message}");
                return null;
                //throw ex;
            }
        }

        //Atualiza avaliacao
        public bool UpdateAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Update(avaliacao);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao atualizar a avaliacao. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Deleta avaliacao
        public bool DeletaAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Delete(avaliacao);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco para deletar a avaliacao. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Adiciona avaliacao
        public bool AddAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    conn.Insert(avaliacao);
                    return true;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Não pude acessar o banco ao adicionar a avaliacao. {ex.Message}");
                Debug.WriteLine(StatusMessage);
                //throw ex;
                return false;
            }
        }

        //Verifica se uma avaliação existe no banco
        public bool ExisteAvaliacao(int idAvaliacao)
        {
            try
            {
                using (var conn = new SQLiteConnection(dbFile))
                {
                    var avaliacao = conn.Find<Avaliacao>(c => c.IdAvaliacao == idAvaliacao);
                    if (avaliacao == null)
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

        #endregion
    }
}
