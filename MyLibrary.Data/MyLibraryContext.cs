using Microsoft.EntityFrameworkCore;
using MyLibrary.Data.Model;

namespace MyLibrary.Data
{
    public class MyLibraryContext : DbContext
    {
        public MyLibraryContext(DbContextOptions options) : base(options) { }
        
        public DbSet<BibliotecaAtivo> BibliotecaAtivos { get; set; } //Ativo da Biblioteca
        public DbSet<BibliotecaFilial> BibliotecaFilias { get; set; } //Ativo da Biblioteca
        public DbSet<BibliotecaCartao> BibliotecaCartaos { get; set; } //cartão da Biblioteca
        public DbSet<Espera> Esperas { get; set; } //Aguardar
        public DbSet<Estato> Estatos { get; set; } //Estados
        public DbSet<FilialHora> FilialHoras { get; set; } //Filial Hora
        public DbSet<Livro> Livros { get; set; } //Livros
        public DbSet<Patrono> Patronos { get; set; } //Empregador
        public DbSet<TipoAtivo> TipoAtivos { get; set; } //Tipo Ativo
        public DbSet<CheckOutHistorico> CheckOutHistoricos { get; set; } //Verificar Historico
        public DbSet<CheckOut> CheckOuts { get; set; } //Verificar Saida
        public DbSet<Video> Videos { get; set; } //Videos
    }
}
