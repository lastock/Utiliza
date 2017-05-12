namespace Utiliza.Infra.Data.Config
{
    public class Helper
    {
        public static string ConnextionString(string name)
        {
            //string retorno = ConfigurationManager.ConnectionStrings["Utiliza"].ConnectionString;
            return @"Data Source=LASTOCK\MSSQLSERVER_2016;Initial Catalog=Utiliza;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
