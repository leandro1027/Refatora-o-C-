namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();

            AdicionarClientes(biblioteca);
            AdicionarLivros(biblioteca);
            EmprestarEDevolverLivros(biblioteca);
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
        }

        static void EmprestarEDevolverLivros(Biblioteca biblioteca)
        {
            biblioteca.EmprestarLivro(1, 1);
            biblioteca.DevolverLivro(1, 1);
            biblioteca.EmprestarLivro(1, 2);
        }
    }
}

