using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiliza.Usuario.Model;

namespace Utiliza.Usuario.Servicos
{
    public class ProcuraFornecedor
    {
       
        public ProcuraFornecedor()
        {
            
        }

        public Fornecedor GetFornecedor(int idFornecedor)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.IdFornecedor = idFornecedor;
            fornecedor.Codigo = 123;
            fornecedor.NomeRazaoSocial = "Total Dog Ltda";
            fornecedor.NomeFantasia = "Total Dog - Seu cão mais feliz!";
            fornecedor.Chamada = "O melhor hotel para cães da grande São Paulo";
            fornecedor.Endereco = "Rod. Arão Sahm, 1750 - Km 31";
            fornecedor.Bairro = "Votorantim";
            fornecedor.Cep = "07600-000";
            fornecedor.Cidade = "Mairiporã";
            fornecedor.Estado = "SP";
            fornecedor.TipoDePessoa = "J";
            fornecedor.CnpjCpf = "123.123.123/0001-00";
            fornecedor.DataContrato=DateTime.Parse("20/02/2017", new CultureInfo("pt-br"));
            fornecedor.DataExpiracao = DateTime.Parse("20/02/2018",new CultureInfo("pt-br"));
            fornecedor.Site = "http:\\www.totaldog.com.br";
            fornecedor.Resumo = "Hotel para cães, adestramento e agility, com 6.500 m2 de área verde a 20 min de São Paulo pela Fernão Dias, com total segurança e área totalmente murada. Administrado por pessoas que são apaixonados por cães. Aqui nós prezamos em primeiro lugar a felicidade do seu melhor amigo. Temos uma infraestrutura voltada para seu cão, muito próxima da natureza mas com toda a segurança e conforto que seu amigo merece. Esperamos ter você como novo membro da nossa família usufruindo do nosso paraíso canino. Equipe especializada no tratamento com cães de todas as raças e preparada para tornar a estadia aqui na Total Dog a mais feliz e agradável possível.";
            fornecedor.Descricao = @"<html>
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
                                    </html>";
            fornecedor.Localizacao = Tuple.Create(-23.343091,-46.574892);
            fornecedor.Logo = "totaldog.png";
            fornecedor.DataCriacao = DateTime.Parse("15/01/2017", new CultureInfo("pt-br"));
            fornecedor.DataModificacao = DateTime.Now;
            fornecedor.Avaliacao = 4.95;
            return fornecedor;
        }
    }
}
