using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Data.Model
{
    public class CheckOutHistorico
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Required] public BibliotecaAtivo BibliotecaAtivo { get; set; } //LibraryAsset

        [Required] public BibliotecaCartao BibliotecaCartao { get; set; } //LibraryCard

        [Required] public DateTime CheckedOut { get; set; } //CheckedOut

        public DateTime? CheckedIn { get; set; } //CheckedIn
    }
}
