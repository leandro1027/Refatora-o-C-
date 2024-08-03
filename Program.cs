using System;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();

            AdicionarClientes(biblioteca);
            AdicionarLivros(biblioteca);

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Emprestar Livro");
                Console.WriteLine("2. Devolver Livro");
                Console.WriteLine("3. Listar Empréstimos");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                var escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        EmprestarLivro(biblioteca);
                        break;
                    case "2":
                        DevolverLivro(biblioteca);
                        break;
                    case "3":
                        ListarEmprestimos(biblioteca);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarClientes(Biblioteca biblioteca)
        {
            biblioteca.AdicionarCliente(new Cliente
            {
                Id = 1,
                Nome = "Jorge e Mateus",
                DataNascimento = new DateTime(1980, 01, 01),
                Telefone = "62999999"
            });
        }

        static void AdicionarLivros(Biblioteca biblioteca)
        {
            biblioteca.AdicionarLivro(new Livro
            {
                Id = 1,
                Titulo = "Dom Casmurro",
                Autor = "Machado de Assis",
                Disponivel = true
            });

            biblioteca.AdicionarLivro(new Livro
            {
                Id = 2,
                Titulo = "Memórias Póstumas de Brás Cubas",
                Autor = "Machado de Assis",
                Disponivel = true
            });
        }

        static void EmprestarLivro(Biblioteca biblioteca)
        {
            Console.Write("Digite o ID do Cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idCliente)) //converter para int, armazena em id
            {
                Console.WriteLine("ID de Cliente inválido.");
                return;
            }

            Console.Write("Digite o ID do Livro: ");
            if (!int.TryParse(Console.ReadLine(), out int idLivro))
            {
                Console.WriteLine("ID de Livro inválido.");
                return;
            }

            biblioteca.EmprestarLivro(idCliente, idLivro);
        }

        static void DevolverLivro(Biblioteca biblioteca)
        {
            Console.Write("Digite o ID do Cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idCliente))
            {
                Console.WriteLine("ID de Cliente inválido.");
                return;
            }

            Console.Write("Digite o ID do Livro: ");
            if (!int.TryParse(Console.ReadLine(), out int idLivro))
            {
                Console.WriteLine("ID de Livro inválido.");
                return;
            }

            biblioteca.DevolverLivro(idCliente, idLivro);
        }

        static void ListarEmprestimos(Biblioteca biblioteca)
        {
            biblioteca.ListarEmprestimos();
        }
    }
}
 
