using Dapper;
using Projeto03.Configurations;
using Projeto03.Entities;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Projeto03.Repositories
{
    public class ProdutoRepository
    {
        public void Create(Produto produto)
        {
            // Escrevendo um comando SQL para gravar um produto na tabela
            var query = @"
                INSERT INTO PRODUTO(
                    IDPRODUTO,
                    NOME,
                    PRECO,
                    QUANTIDADE,
                    DATACADASTRO)
                VALUES (
                    NEWID(),
                    @Nome,
                    @Preco,
                    @Quantidade,
                    GETDATE())";

            try
            {
                // Conectando no banco de dados
                using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
                {
                    // Executar o comando SQL no banco, passando os dados do objeto
                    connection.Execute(query, produto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir produto no banco de dados: {ex.Message}");
            }
        }

        // Outros métodos (Update, Delete, GetAll, GetById) podem ser implementados aqui
        public void Update(Produto produto)
        {
            var query = @"
            UPDATE PRODUTO
            SET
                NOME - @Nome,
                PRECO = @Preco
                QUANTIDADE = @Quantidade
                WHERE
                    IDPRODUTO = #IdProduto
                    ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(query, produto);

            }

        }


        public void Delete(Produto produto)
        {

            var query = @"
                DELETE FROM PRODUTO
                WHRE IDPRODUTO =IdProduto
                
                ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(query, produto);
            }
        }

        public List<Produto> GetAll()
        {
            var query = @"
                SELECT * FROM PRODUTO
                ORDER BY NOME";


            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(query).ToList();
            }

        }

        public List<Produto> GetByPrecos(decimal precoMin, decimal precoMax)
        {
            var query = @" 
                SELECT * FROM PRODUTO
                WHERE PRECO BETWEEN @precoMin AND @precoMax
                ORDER BY PRECO DESC";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(query, new { precoMin, precoMax }).ToList();

            }
        }
        public Produto? GetById(Guid idProduto)
        {
            var query = @"
                SELECT * FROM PRODUTO
                WHERE IDPRODUTO = @idProduto";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(query, new { idProduto }).FirstOrDefault();
            }

        }

    }

}

