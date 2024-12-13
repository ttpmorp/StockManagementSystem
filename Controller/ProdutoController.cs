using System.Xml.Linq;
using Projeto03.Entities;
using Projeto03.Repositories;

namespace Projeto03.Controllers
{
    public class ProdutoController

    {
        #region MÉTODO PARA REALIZAR O CADASTRO DE UM PRODUTO

        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE PRODUTO: \n");

                var produto = new Produto();

                Console.Write("Entre com o nome do produto: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Entre com o preço do produto: ");
                produto.Preco = Decimal.Parse(Console.ReadLine());

                Console.Write("Entre com a quantidade de produto: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Create(produto);

                Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
            }
            catch (Exception ex) {
                
                Console.WriteLine($"FALHA AO CADASTRAR PRODUTO: {ex.Message}");


            }

        }

        #endregion


        #region METODO PARA ATUALIZAR O PRODUTO
        public void AtualizarProduto()
        {

            try

            {
                Console.WriteLine("\nEDIÇÃO DE PRODUTO: \n");

                Console.Write("Informe o ID do produto desejado: ");
                var idProduto = Guid.Parse(Console.ReadLine());


                #region CONSULTAR O PRODUTO NO BANCO DE DADOS ATRAVÉS DO ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                #endregion

                #region VERIFICAR SE O PRODUTO FOI ENCONTRADO
                if (produto != null)
                {
                    Console.Write("Entre com o nome do produto: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Entre com o preço do produto: ");
                    produto.Preco = Decimal.Parse(Console.ReadLine());

                    Console.Write("Entre com a quantidade de produto: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());


                    #region ATUALIZAR O PRODUTO NO BANCO DE DADOS

                    produtoRepository.Update(produto);

                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO!");

                    #endregion


                }
                else
                {
                    Console.WriteLine("\nPRODUTO NÃO ENCONTRADO, VERIFIQUE O ID INFORMADO.");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine($"FALHA AO ATUALIZAR PRODUTO: {e.Message}");
            }
        }


        #endregion

        #endregion

        #region MÉTODO PARA EXCLUIR O PRODUTO
        public void ExcluirProduto()
        {


            try

            {
                Console.WriteLine("\nEXCLUSÃO DE PRODUTO: \n");

                Console.Write("Informe o ID do produto desejado: ");
                var idProduto = Guid.Parse(Console.ReadLine());


                #region CONSULTAR O PRODUTO NO BANCO DE DADOS ATRAVÉS DO ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                #endregion

                #region VERIFICAR SE O PRODUTO FOI ENCONTRADO
                if (produto != null)
                {

                    #region EXCLUIR O PRODUTO NO BANCO DE DADOS

                    produtoRepository.Delete(produto);

                    #endregion

                    Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO!");

                }
                else
                {
                    Console.WriteLine("\nPRODUTO NÃO ENCONTRADO, VERIFIQUE O ID INFORMADO");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine($"FALHA AO ATUALIZAR PRODUTO: {e.Message}");
            }
        }

                #endregion


            #endregion


        #region MÉTODO PARA CONSULTAR OS PRODUTOS NO BANCO DE DADOS  
             public void ConsultarProdutos()
        {
            try
            {


                Console.WriteLine("\nCONSULTA DE PRODUTOS: \n");

                Console.Write("Entre com o preço MÍNIMO: ");
                var precoMin = decimal.Parse(Console.ReadLine());

                Console.Write("Entre com o preço MÁXIMO: ");
                var precoMax = decimal.Parse(Console.ReadLine());

                //Consultando os produtos no bando de dados através dos preços:
                var produtoRepository = new ProdutoRepository();
                var lista = produtoRepository.GetByPrecos(precoMin, precoMax);

                //Imprimir a quantidade de produtos encontrados:
                Console.WriteLine($"\nQuantidade de produtos obtidos: {lista.Count}\n");


                foreach (var item in lista)
                {
                    Console.WriteLine($"Id do produto: {item.IdProduto}");
                    Console.WriteLine($"Nome: {item.Nome}");
                    Console.WriteLine($"Preço: {item.Preco}");
                    Console.WriteLine($"Quantidade: {item.Quantidade}");
                    Console.WriteLine($"Data de Cadastro: {item.DataCadastro}");
                    Console.WriteLine($"-------");

                }


            }

            


            catch (Exception ex)
            {
                Console.WriteLine($"FALHA AO CONSULTAR PRODUTO: {ex.Message}");
            }
            #endregion

        }
    }
}

