namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = IniciarBiblioteca();

            TestarOperacoes(biblioteca);
        }

        static Biblioteca IniciarBiblioteca()
        {
            Biblioteca biblioteca = new Biblioteca();

            // Adicionar clientes
            biblioteca.clientes.Add(new Cliente
            {
                Id = 1,
                Nome = "Jorge e Mateus",
                DataNascimento = new DateTime(1980, 1, 1),
                Telefone = "62999999"
            });

            // Adicionar livros
            biblioteca.livros.Add(new Livro
            {
                Id = 1,
                Titulo = "Dom Casmurro",
                Autor = "Machado de Assis",
                Disponivel = true
            });

            return biblioteca;
        }

        static void TestarOperacoes(Biblioteca biblioteca)
        {
            // Emprestar e devolver livro
            biblioteca.EmprestarLivro(1, 1);
            biblioteca.DevolverLivro(1, 1);
            biblioteca.EmprestarLivro(1, 2); // Note que o cliente e o livro devem existir para isso funcionar

            // Adicionar mais testes e operações conforme necessário
        }
    }
}
