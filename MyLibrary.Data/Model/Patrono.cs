using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class Patrono
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PrimeiroNome { get; set; } //FirstName

        [Required]
        [Column(TypeName = "varchar(50)")] 
        public string SobreNome { get; set; } //LastName

        [Column(TypeName = "varchar(50)")]
        public string Endereco { get; set; } //Address

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; } //DateOfBirth

        [Column(TypeName = "varchar(30)")]
        public string Telefone { get; set; } //Telephone

        [Column(TypeName = "varchar(15)")]
        public string Genero { get; set; } //Gender

        [Required]
        [Display(Name = "Catão da Biblioteca")]
        public BibliotecaCartao BibliotecaCartao { get; set; } //LibraryCard
        public BibliotecaFilial BibliotecaFilial { get; set; } //HomeLibraryBranch
    }
}
