using Projeto03.Controllers;
using System;

namespace Projeto03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Instanciando o controlador
            var produtoController = new ProdutoController();

            try
            {
                Console.WriteLine("(1) - CADASTRAR PRODUTO");
                Console.WriteLine("(2) - ATUALIZAR PRODUTO");
                Console.WriteLine("(3) - EXCLUIR PRODUTO");
                Console.WriteLine("(4) - CONSULTAR PRODUTO");

                Console.Write("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: produtoController.CadastrarProduto(); break;
                    case 2: produtoController.AtualizarProduto(); break;
                    case 3: produtoController.ExcluirProduto(); break;
                    case 4: produtoController.ConsultarProdutos(); break;

                    default:
                        Console.WriteLine("\nOpção inválida!"); break;


                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"\nFALHA: {ex.Message}");

            }
            finally
            {
                Console.Write("\nDESEJA CONTINUAR? (S) OU (N): ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    //limpar a tela do DOS
                    Console.Clear();


                    //Recursividade
                    Main(args);



                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }


                produtoController.CadastrarProduto();

                // Pausar para leitura de saída
                Console.ReadKey();
            }
        }
    }

}
