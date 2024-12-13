namespace Projeto03.Configurations
{
    public class SqlServerConfiguration
    {
        /// <summary>
        /// Método para retornar o endereço da connection string do banco de dados
        /// </summary>
        public static string GetConnectionString()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projeto03;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
