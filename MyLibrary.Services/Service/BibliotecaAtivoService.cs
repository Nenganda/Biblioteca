using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Data.Interfaces;
using MyLibrary.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Services.Service
{
    public class BibliotecaAtivoService : IBibliotecaAtivo
    {
        private readonly MyLibraryContext _context;

        public BibliotecaAtivoService(MyLibraryContext context)
        {
            _context = context;
        }

        public void Adicionar(BibliotecaAtivo novoAtivo)
        {
            _context.Add(novoAtivo);
            _context.SaveChanges();
        }

        public string FiltrarAutorOuDirector(int id)
        {
            /*
            var isLivro = _context.BibliotecaAtivos
                .OfType<Livro>().Any(a => a.Id == id);

            return isLivro
                ? FiltrarAutor(id)
                : FiltrarDiretor(id);
            */
            var seLivro = _context.BibliotecaAtivos.OfType<Livro>()
                    .Where(asset => asset.Id == id).Any();
            var seVideo = _context.BibliotecaAtivos.OfType<Video>()
                    .Where(asset => asset.Id == id).Any();

            return seLivro ?
                _context.Livros.FirstOrDefault(livro => livro.Id == id).Autor :
                _context.Videos.FirstOrDefault(video => video.Id == id).Diretor
                ?? "Desconhece";
        }

        public string FiltrarDeweyIndex(int id)
        {
            /*
            if (FiltrarTipo(id) != "Livro") return "N/A";
            var livro = (Livro)FiltrarPorId(id);
            return livro.DeweyIndex;
            */

            if (_context.Livros.Any(livro => livro.Id == id))
            {
                return _context.Livros.FirstOrDefault(livro => livro.Id == id).DeweyIndex;
            }
            else return "";
        }

        public string FiltrarISBN(int id)
        {
            //if (FiltrarTipo(id) != "Livro") return "N/A";
            //var Livro = (Livro)FiltrarPorId(id);
            //return Livro.ISBN;

            if (_context.Livros.Any(a => a.Id == id))
            {
                return _context.Livros
                    .FirstOrDefault(a => a.Id == id).ISBN;
            }
            else return "";
        }

        public BibliotecaFilial FiltrarLocalizacaoAtual(int id)
        {
            //return _context.BibliotecaAtivos.First(a => a.Id == id).Localizacao;
            return FiltrarPorId(id).Localizacao;
        }

        public BibliotecaAtivo FiltrarPorId(int id)
        {
            /*
            return _context.BibliotecaAtivos
                .Include(a => a.Estato)
                .Include(a => a.Localizacao)
                .FirstOrDefault(a => a.Id == id);
            
            */

            return
                FiltrarTodos()
                    .FirstOrDefault(a => a.Id == id);
        }

        public string FiltrarTipo(int id)
        {
            /*
            // Hackear
            var Livro = _context.BibliotecaAtivos
                .OfType<Livro>().SingleOrDefault(a => a.Id == id);
            return Livro != null ? "Livro" : "Video";
            */

            var livro = _context.BibliotecaAtivos.OfType<Livro>()
                .Where(l => l.Id == id);

            return livro.Any() ? "Livro" : "Video";
        }

        public string FiltrarTitulo(int id)
        {
            return _context.BibliotecaAtivos
                .First(t => t.Id == id)
                .Titulo;
        }

        public IEnumerable<BibliotecaAtivo> FiltrarTodos()
        {
            return _context.BibliotecaAtivos
                .Include(asset => asset.Estato)
                .Include(asset => asset.Localizacao);

        }

        /*
        private string FiltrarAutor(int id)
        {
            var livro = (Livro)FiltrarPorId(id);
            return Livro.Autor;
        }

        private string FiltrarDiretor(int id)
        {
            var video = (Video)FiltrarPorId(id);
            return video.Diretor;
        }
        */
    }
}
