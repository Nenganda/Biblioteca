using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class BibliotecaFilial
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required] public string Nome { get; set; } //Name

        [Display(Name = "Endereço")]
        [Column(TypeName = "varchar(50)")]
        [Required] public string Endereco { get; set; } //Address

        [Column(TypeName = "varchar(30)")]
        public string Telefone { get; set; } //Telephone

        [Column(TypeName = "varchar(50)")]
        public string Descricao { get; set; } //Description

        public DateTime Dataabertura { get; set; } //OpenDate

        [Column(TypeName = "varchar(120)")]
        public string ImagemUrl { get; set; } //ImageUrl

        public virtual IEnumerable<Patrono> Patronos { get; set; }
        public virtual IEnumerable<BibliotecaAtivo> BibliotecaAtivos { get; set; }
    }
}
