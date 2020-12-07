using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class Livro : BibliotecaAtivo //Book : LibraryAsset
    {

        [Required]
        [Column(TypeName = "varchar(15)")] 
        public string ISBN { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")] 
        public string Autor { get; set; } //Author

        [Required]
        [Column(TypeName = "varchar(15)")] 
        public string DeweyIndex { get; set; }
    }
}