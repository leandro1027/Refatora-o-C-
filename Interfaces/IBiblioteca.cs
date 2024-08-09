using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public interface IBiblioteca
    {
        void AdicionarCliente(Cliente cliente);
        void AdicionarLivro(Livro livro);
        void EmprestarLivro(int idCliente, int idLivro);
        void DevolverLivro(int idCliente, int idLivro);
        void ListarEmprestimos();
    }
}

