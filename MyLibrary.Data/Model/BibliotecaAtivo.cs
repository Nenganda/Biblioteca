using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class BibliotecaAtivo  //LibraryAsset
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")] 
        public string Titulo { get; set; } //Title

        [Required]
        //[Column(TypeName = "int(11)")] 
        public int Ano { get; set; } //(Year) Just store as an int for BC(Apenas armazene como int para BC)

        [Required]
        [Column(TypeName = "varchar(50)")]
        public Estato Estato { get; set; } //Status

        [Required]
        [Column(TypeName = "decimal(10,2)")] 
        public decimal Custo { get; set; } //Cost

        [Column(TypeName = "varchar(120)")]
        public string ImagemUrl { get; set; } //ImageUrl

        //[Column(TypeName = "int(11)")]
        public int NumeroDeCopia { get; set; } //NumberOfCopies
        public virtual BibliotecaFilial Localizacao { get; set; } //LibraryBranch Location

        public virtual IEnumerable<CheckOut> CheckOuts { get; set; }
    }
}
