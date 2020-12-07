using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class Video : BibliotecaAtivo
    {
        [Required]

        [Column(TypeName = "varchar(50)")] 
        public string Diretor { get; set; } //Director
    }
}
