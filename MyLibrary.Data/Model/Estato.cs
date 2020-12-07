using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class Estato
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }  //Name

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Descricao { get; set; } //Description
    }
}
