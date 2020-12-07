using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLibrary.Data.Model
{
    public class Espera
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        public virtual BibliotecaAtivo BibliotecaAtivo  { get; set; } //LibraryAsset
        public virtual BibliotecaCartao BibliotecaCartao { get; set; } //LibraryCard
        public DateTime DataEspera { get; set; } //HoldPlaced
    }
}
