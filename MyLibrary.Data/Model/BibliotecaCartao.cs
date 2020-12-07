    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class BibliotecaCartao
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Display(Name = "Taxa Atrasadas")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Honorarios { get; set; } //Fees

        [Display(Name = "Data de Emissão do Cartão")] public DateTime DataEmissaoCartao { get; set; }

        [Display(Name = "Materiais Emprestados")] public virtual IEnumerable<CheckOut> CheckOuts { get; set; }
    }
}
