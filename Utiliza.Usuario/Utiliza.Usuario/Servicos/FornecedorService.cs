using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Repositories;

namespace Utiliza.Usuario.Servicos
{
    public class FornecedorService
    {
        //private List<Fornecedor> fornecedores = new List<Fornecedor>();
        public FornecedorService()
        {
            PopulaListafornecedores();
        }

        private void PopulaListafornecedores()
        {
            var fornecedores = new List<Fornecedor>();
            fornecedores.Add(new Fornecedor { IdFornecedor = 1,
                NomeRazaoSocial = "Total Dog Ltda;",
                NomeFantasia = "TotalDog",
                Chamada = "O melhor hotel para cães da grande São Paulo.",
                Endereco = "Rod. Arão Sahm, 1750 - km 31",
                Bairro = "Votorantim",
                Cep = "07600-000",
                Cidade = "Mairiporã",
                Estado = "SP",
                TipoDePessoa = "J",
                CnpjCpf = "10.922.665/0001-06",
                Site = "http://www.totaldog.com.br",
                WhatsApp = "5511999354059",
                Resumo = "Hotel para cães, adestramento e agility, com 6.500 m2 de área verde a 20 min de São Paulo pela Fernão Dias, com total segurança e área totalmente murada. Administrado por pessoas que são apaixonados por cães. Aqui nós prezamos em primeiro lugar a felicidade do seu melhor amigo. Temos uma infraestrutura voltada para seu cão, muito próxima da natureza mas com toda a segurança e conforto que seu amigo merece. Esperamos ter você como novo membro da nossa família usufruindo do nosso paraíso canino. Equipe especializada no tratamento com cães de todas as raças e preparada para tornar a estadia aqui na Total Dog a mais feliz e agradável possível.",
                Descricao = @"<html>
	                                    <body>
		                                    <p>
                                                Oferecemos ao seu cão um exclusivo serviço de <b>hotel para cães</b>. Ele terá a sua disposição um lugar paradisíaco para brincar e conviver com outros cães. Pode ser por um dia, uma semana, um mês ou mais, onde ele receberá todo o cuidado e atenção necessários para que se sinta feliz mesmo longe de seus donos. Cada cão é tratado de maneira diferenciada, de acordo com sua raça, porte e grau de socialização.
                                            </p>
					                                <ul>
						                                <li>No nosso <b>hotel para cachorro</b> seu amigo não fica confinado em uma baia apertada.</li>
						                                <li>Usufrui do saudável convívio com outros cães compatíveis.</li>
						                                <li>Fica em contato estreito com a natureza.</li>
						                                <li>Aproveita de um ambiente rico em estímulos sensoriais.</li>
						                                <li>Brinca, corre e nada num lugar amplo e protegido.</li>
						                                <li>É amado e bem cuidado seguindo todas as suas orientações.</li>
						                                <li>Come e dorme em baias individuais.</li>
					                                </ul><br />
					                                <h2>Exigências:</h2>
					                                <ol>
						                                <li>Vacinação completa do cão: V8, Raiva e Bordetella (tosse dos canis).</li>
						                                <li>Vermifugação recente.</li>
						                                <li>Ausência de pulgas e carrapatos.</li>
						                                <li>Ser bem socializado.</li>
					                                </ol>
					                                <p>Obs.: As vacinas deverão estar em dia, podendo ter sido feitas até 7 dias antes da chegada do seu pet à Total Dog. Se estas estiverem em atraso e o proprietário preferir, um veterinário responsável da Total Dog poderá examinar o cão e aplicar as vacinas, entregando um atestado. Da mesma maneira poderão ser feitas as medicações contra vermes, pulgas e carrapatos e esses procedimentos serão cobrados à parte.<br />
                                                        <br />TODOS os cães que entram na Total Dog são verificados quanto à presença de pulgas e/ou carrapatos. No caso de presença de parasitas será administrado uma dose de  Capstar e depois de 48 horas um Frontline ou Max3, que serão cobrado a parte.<br />
                                                        <br />Você pode trazer brinquedos, cama e outros acessórios do seu Pet, mas sugerimos que não seja algo de muito valor.<br />
                                                        <br />Nós sabemos que cada pet é único e especial e por isso fazemos o seu cadastro em nosso banco de dados da forma mais completa possível.<br />
                                                        <br />Estes dados ficaram arquivados e seram fornecidos uma só vez.<br />
                                                        <br />Deixe seu melhor amigo onde ele também vai ter suas férias com acomodações amplas e confortáveis, um parque de diversões à disposição com pessoal especializado para divertir seu cão; piscinas, banhos, xampus e condicionadores.<br />
                                                        <br />O nosso sistema é o mesmo dos hotéis para os humanos. Seu cão vai passar dias agradáveis com DIVERTIMENTO E LAZER.<br />
                                                        <br />Na inscrição você deverá fornecer o nome, endereço e telefone do veterinário que atende seu cão. Em caso de necessidade, o nosso Veterinário Responsável entrará em contato para seguir suas instruções. Em caso de emergência, será imediatamente atendido aqui, para depois entrarmos em contato com o veterinário do seu cão.</p>
	                                    </body>
                                    </html>",
                Latitude = -23.343091,
                Longitude = -46.574892,
                Logo = "teste.png",
                Subcategoria = 35,
                Categoria = 12,
                Avaliacao=5,
                Horario = "Todos os dias das 8:00 hs às 17:00 hs"
            });
            fornecedores.Add(new Fornecedor { IdFornecedor = 2, NomeFantasia = "Pizzaria do Zé", Resumo = "A melhor pizza de Mairiporã", Logo = "teste.png", Categoria=1, Subcategoria = 2 });
            fornecedores.Add(new Fornecedor { IdFornecedor = 3, NomeFantasia = "Cidade Bonita", Resumo = "A melhor piza com a melhor vista da cidade.", Logo = "teste.png", Categoria = 1, Subcategoria = 2 });
            fornecedores.Add(new Fornecedor { IdFornecedor = 4, NomeFantasia = "Restaurante do Pipo", Resumo = "Coma a vontade e pague quando puder.", Logo = "teste.png", Categoria = 1, Subcategoria = 1 });
            fornecedores.Add(new Fornecedor { IdFornecedor = 5, NomeFantasia = "Kilo da Chepa", Resumo = "Vale quanto pesa.", Logo = "teste.png", Categoria = 1, Subcategoria = 1 });
            foreach (var fornecedor in fornecedores)
            {
                if (FornecedorRepository.Instance.ExisteFornecedor(fornecedor.IdFornecedor))
                {
                    //FornecedorRepository.Instance.UpdateFornecedor(fornecedor);
                }
                else
                {
                    FornecedorRepository.Instance.AddNewFornecedor(fornecedor);
                }
            }
        }

        public Fornecedor GetFornecedor(int idFornecedor)
        {
            //List<Telefone> _telefones = new List<Telefone>();
            //List<Facilidade> _facilidades = new List<Facilidade>();
            //List<Contato> _contatos = new List<Contato>();

            //Fornecedor fornecedor = new Fornecedor();
            //fornecedor.IdFornecedor = idFornecedor;
            //fornecedor.NomeRazaoSocial = "Total Dog Ltda";
            //fornecedor.NomeFantasia = "Total Dog - Seu cão mais feliz!";
            //fornecedor.Chamada = "O melhor hotel para cães da grande São Paulo";
            //fornecedor.Endereco = "Rod. Arão Sahm, 1750 - Km 31";
            //fornecedor.Bairro = "Votorantim";
            //fornecedor.Cep = "07600-000";
            //fornecedor.Cidade = "Mairiporã";
            //fornecedor.Estado = "SP";
            //fornecedor.TipoDePessoa = "J";
            //fornecedor.CnpjCpf = "123.123.123/0001-00";
            //fornecedor.Site = "http:\\www.uol.com.br";
            //fornecedor.Resumo = "Hotel para cães, adestramento e agility, com 6.500 m2 de área verde a 20 min de São Paulo pela Fernão Dias, com total segurança e área totalmente murada. Administrado por pessoas que são apaixonados por cães. Aqui nós prezamos em primeiro lugar a felicidade do seu melhor amigo. Temos uma infraestrutura voltada para seu cão, muito próxima da natureza mas com toda a segurança e conforto que seu amigo merece. Esperamos ter você como novo membro da nossa família usufruindo do nosso paraíso canino. Equipe especializada no tratamento com cães de todas as raças e preparada para tornar a estadia aqui na Total Dog a mais feliz e agradável possível.";
            //fornecedor.Descricao = @"<html>
	           //                         <body>
		          //                          <p>
            //                                    Oferecemos ao seu cão um exclusivo serviço de <b>hotel para cães</b>. Ele terá a sua disposição um lugar paradisíaco para brincar e conviver com outros cães. Pode ser por um dia, uma semana, um mês ou mais, onde ele receberá todo o cuidado e atenção necessários para que se sinta feliz mesmo longe de seus donos. Cada cão é tratado de maneira diferenciada, de acordo com sua raça, porte e grau de socialização.
            //                                </p>
					       //                         <ul>
						      //                          <li>No nosso <b>hotel para cachorro</b> seu amigo não fica confinado em uma baia apertada.</li>
						      //                          <li>Usufrui do saudável convívio com outros cães compatíveis.</li>
						      //                          <li>Fica em contato estreito com a natureza.</li>
						      //                          <li>Aproveita de um ambiente rico em estímulos sensoriais.</li>
						      //                          <li>Brinca, corre e nada num lugar amplo e protegido.</li>
						      //                          <li>É amado e bem cuidado seguindo todas as suas orientações.</li>
						      //                          <li>Come e dorme em baias individuais.</li>
					       //                         </ul><br />
					       //                         <h2>Exigências:</h2>
					       //                         <ol>
						      //                          <li>Vacinação completa do cão: V8, Raiva e Bordetella (tosse dos canis).</li>
						      //                          <li>Vermifugação recente.</li>
						      //                          <li>Ausência de pulgas e carrapatos.</li>
						      //                          <li>Ser bem socializado.</li>
					       //                         </ol>
					       //                         <p>Obs.: As vacinas deverão estar em dia, podendo ter sido feitas até 7 dias antes da chegada do seu pet à Total Dog. Se estas estiverem em atraso e o proprietário preferir, um veterinário responsável da Total Dog poderá examinar o cão e aplicar as vacinas, entregando um atestado. Da mesma maneira poderão ser feitas as medicações contra vermes, pulgas e carrapatos e esses procedimentos serão cobrados à parte.<br />
            //                                            <br />TODOS os cães que entram na Total Dog são verificados quanto à presença de pulgas e/ou carrapatos. No caso de presença de parasitas será administrado uma dose de  Capstar e depois de 48 horas um Frontline ou Max3, que serão cobrado a parte.<br />
            //                                            <br />Você pode trazer brinquedos, cama e outros acessórios do seu Pet, mas sugerimos que não seja algo de muito valor.<br />
            //                                            <br />Nós sabemos que cada pet é único e especial e por isso fazemos o seu cadastro em nosso banco de dados da forma mais completa possível.<br />
            //                                            <br />Estes dados ficaram arquivados e seram fornecidos uma só vez.<br />
            //                                            <br />Deixe seu melhor amigo onde ele também vai ter suas férias com acomodações amplas e confortáveis, um parque de diversões à disposição com pessoal especializado para divertir seu cão; piscinas, banhos, xampus e condicionadores.<br />
            //                                            <br />O nosso sistema é o mesmo dos hotéis para os humanos. Seu cão vai passar dias agradáveis com DIVERTIMENTO E LAZER.<br />
            //                                            <br />Na inscrição você deverá fornecer o nome, endereço e telefone do veterinário que atende seu cão. Em caso de necessidade, o nosso Veterinário Responsável entrará em contato para seguir suas instruções. Em caso de emergência, será imediatamente atendido aqui, para depois entrarmos em contato com o veterinário do seu cão.</p>
	           //                         </body>
            //                        </html>";
            //fornecedor.Latitude = -23.343091;
            //fornecedor.Longitude = -46.574892;
            //fornecedor.Logo = "big_1.jpg";
            //fornecedor.DataCriacao = DateTime.Parse("15/01/2017", new CultureInfo("pt-br"));
            //fornecedor.DataModificacao = DateTime.Now;
            //fornecedor.Avaliacao = 4.95;
            //_telefones.Add(new Telefone(idFornecedor, "11", "99935-1364"));
            //_telefones.Add(new Telefone(idFornecedor, "11", "99935-4059"));
            //fornecedor.Telefones = _telefones;
            //fornecedor.Horario = "Todos os dias das 8:00 hs às 17:00 hs";
            //_facilidades.Add(new Facilidade(idFornecedor, "pet.png", "Cães são bem vindos"));
            //_facilidades.Add(new Facilidade(idFornecedor, "estacionamento.png", "Estacionamento no local"));
            //_facilidades.Add(new Facilidade(idFornecedor, "bitcoin.png", "Aceita-se pagamento em bitcoins"));
            //_facilidades.Add(new Facilidade(idFornecedor, "wifi.png", "Wifi disponível para clientes"));
            //fornecedor.Facilidades = _facilidades;
            //_contatos.Add(new Contato(1, idFornecedor, "(11) 99935-1364", "Luis Alfredo", "luis@totaldog.com.br"));
            //_contatos.Add(new Contato(2, idFornecedor, "(11) 99935-4059", "Cindy", "cindy@totaldog.com.br"));
            //fornecedor.Contatos = _contatos;


            return FornecedorRepository.Instance.GetFornecedorById(idFornecedor);
        }

        public string NomeFornecedor(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetFornecedorById(idFornecedor).NomeFantasia;
        }

        public List<Fornecedor> FornecedoresDeUmaSubCategoria(int subcategoria)
        {
            return FornecedorRepository.Instance.GetFornecedoresDeUmaSubCategoria(subcategoria);
        }

        public List<Fornecedor> FornecedoresDeUmaCategoria(int categoria)
        {
            return FornecedorRepository.Instance.GetFornecedoresDeUmaCategoria(categoria);
        }

        public List<Fornecedor> FornecedoresDaProcura(Procura procura)
        {
            return FornecedorRepository.Instance.GetProcuraFornecedores(procura);
        }

        public List<Fornecedor> FornecedoresFavoritos()
        {
            return FornecedorRepository.Instance.GetFornecedoresFavoritos();
        }

        public List<Promocao> PromocoesDoFornecedor(int idFornecedor)
        {
            return FornecedorRepository.Instance.GetPromocoesDeUmFornecedor(idFornecedor);
        }

        public List<Promocao> Promocoes()
        {
            //var _promocoes = new List<Promocao>();
            //_promocoes.Add(new Promocao { IdPromocao = 1, IdFornecedor = 1, Logo = "percentage_64.png", NomeEmpresa = "Total Dog", DescricaoPromocao = "Hospede seu cão no final de semana 2 pague somente uma diária!", PorcentagemDesconto = 0, QuantidadeRestante = 10, QuantidadeTotal = 15 });
            //_promocoes.Add(new Promocao { IdPromocao = 2, IdFornecedor = 2, Logo = "percentage_64.png", NomeEmpresa = "Pizzaria do Zé", DescricaoPromocao = "Desconto de 70% para os primeiros 10 clientes que apresentarem este cupom!", PorcentagemDesconto = 70, QuantidadeRestante = 3, QuantidadeTotal = 10 });
            //_promocoes.Add(new Promocao { IdPromocao = 3, IdFornecedor = 3, Logo = "percentage_64.png", NomeEmpresa = "Cidade Bonita", DescricaoPromocao = "Desconto de 60% para os primeiros 10 clientes que apresentarem este cupom!", PorcentagemDesconto = 60, QuantidadeRestante = 5, QuantidadeTotal = 10 });
            //_promocoes.Add(new Promocao { IdPromocao = 4, IdFornecedor = 4, Logo = "percentage_64.png", NomeEmpresa = "Restaurante do Pipo", DescricaoPromocao = "Na apresentação deste cupom o seu acompanhante não paga!", PorcentagemDesconto = 0, QuantidadeRestante = 8, QuantidadeTotal = 15 });
            //_promocoes.Add(new Promocao { IdPromocao = 5, IdFornecedor = 5, Logo = "percentage_64.png", NomeEmpresa = "Kilo da Chepa", DescricaoPromocao = "Desconto de 50% para os primeiros 20 clientes que apresentarem este cupom!", PorcentagemDesconto = 50, QuantidadeRestante = 17, QuantidadeTotal = 20 });
            //return _promocoes;
            return FornecedorRepository.Instance.GetTodasPromocoes();

        }

        public int DistanciaDoLocal(double latitude, double longitude)
        {
            return 5;
        }

        public bool AdicionaRetiraDosFavoritos(int idFornecedor)
        {
            return FornecedorRepository.Instance.AdicionaRetiraFornecedorDosFavoritos(idFornecedor);
        }


    }
}
