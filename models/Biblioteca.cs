using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Biblioteca : IBiblioteca
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Livro> livros = new List<Livro>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void AdicionarLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void EmprestarLivro(int idCliente, int idLivro)
        {
            var livro = livros.Find(l => l.Id == idLivro && l.Disponivel);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado ou indisponível.");
                return;
            }

            var cliente = clientes.Find(c => c.Id == idCliente);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var emprestimo = new Emprestimo
            {
                Id = emprestimos.Count + 1,
                ClienteEmprestimo = cliente,
                LivroEmprestado = livro,
                DataDoEmprestimo = DateTime.Today,
                DataDevolucaoPrevista = DateTime.Today.AddDays(15)
            };

            livro.Disponivel = false;
            emprestimos.Add(emprestimo);

            Console.WriteLine("Livro emprestado com sucesso!");
        }

        public void DevolverLivro(int idCliente, int idLivro)
        {
            var livro = livros.Find(l => l.Id == idLivro);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            var emprestimo = emprestimos.Find(e => e.ClienteEmprestimo.Id == idCliente && e.LivroEmprestado.Id == idLivro);
            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado.");
                return;
            }

            emprestimo.LivroEmprestado.Disponivel = true;
            emprestimo.DataDevolucao = DateTime.Today;

            Console.WriteLine("Livro devolvido com sucesso.");
        }

        public void ListarEmprestimos()
        {
            if (emprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo encontrado.");
                return;
            }

            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"ID do Empréstimo: {emprestimo.Id}");
                Console.WriteLine($"Cliente: {emprestimo.ClienteEmprestimo.Nome}");
                Console.WriteLine($"Livro: {emprestimo.LivroEmprestado.Titulo}");
                Console.WriteLine($"Data do Empréstimo: {emprestimo.DataDoEmprestimo.ToShortDateString()}");
                Console.WriteLine($"Data de Devolução Prevista: {emprestimo.DataDevolucaoPrevista.ToShortDateString()}");
                if (emprestimo.DataDevolucao.HasValue)
                {
                    Console.WriteLine($"Data de Devolução: {emprestimo.DataDevolucao.Value.ToShortDateString()}");
                }
                Console.WriteLine();
            }
        }
    }
}
