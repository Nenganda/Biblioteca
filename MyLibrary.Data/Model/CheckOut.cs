using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Data.Model
{
    public class CheckOut
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        public BibliotecaAtivo BibliotecaAtivo { get; set; }

        public BibliotecaCartao BibliotecaCartao { get; set; }

        public DateTime Desde { get; set; } //Since
        public DateTime Ate { get; set; } //Until
    }
}
