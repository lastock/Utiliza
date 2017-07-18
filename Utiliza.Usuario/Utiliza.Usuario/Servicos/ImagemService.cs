using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class ImagemService
    {
        public ImagemService()
        {
            PopulaImagemServicos();
        }

        private void PopulaImagemServicos()
        {
            var imagens = new List<ImagemFornecedor>();
            imagens.Add(new ImagemFornecedor { IdImagem = 1, IdFornecedor = 1, NomeArquivo = "big_1.jpg" });
            imagens.Add(new ImagemFornecedor { IdImagem = 2, IdFornecedor = 1, NomeArquivo = "big_2.jpg" });
            imagens.Add(new ImagemFornecedor { IdImagem = 3, IdFornecedor = 1, NomeArquivo = "big_3.jpg" });
            imagens.Add(new ImagemFornecedor { IdImagem = 4, IdFornecedor = 1, NomeArquivo = "big_4.jpg" });
            foreach (var imagem in imagens)
            {
                if (FornecedorRepository.Instance.ExisteImagem(imagem.IdImagem))
                {
                    FornecedorRepository.Instance.UpdateImagemFornecedor(imagem);
                }
                else
                {
                    FornecedorRepository.Instance.AddImagemFornecedor(imagem);
                }
            }

        }

        public List<ImagemFornecedor> ImagensDoFornecedor(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetImagensDeUmFornecedor(idFornecedor);
        }
    }
}
