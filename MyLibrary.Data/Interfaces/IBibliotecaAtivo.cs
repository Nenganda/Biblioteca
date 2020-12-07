using MyLibrary.Data.Model;
using System.Collections.Generic;

namespace MyLibrary.Data.Interfaces
{
    public interface IBibliotecaAtivo
    {
        IEnumerable<BibliotecaAtivo> FiltrarTodos();
        BibliotecaAtivo FiltrarPorId(int id);

        void Adicionar(BibliotecaAtivo novoAtivo);
        string FiltrarAutorOuDirector(int id);
        string FiltrarDeweyIndex(int id);
        string FiltrarTipo(int id);
        string FiltrarTitulo(int id);
        string FiltrarISBN(int id);

        BibliotecaFilial FiltrarLocalizacaoAtual(int id);
    }
}
