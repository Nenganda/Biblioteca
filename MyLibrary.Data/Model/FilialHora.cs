using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Data.Model
{
    public class FilialHora
    {
        //[Column(TypeName = "int(11)")]
        public int Id { get; set; }

        public BibliotecaFilial Filial { get; set; } //Branch

        [Range(0, 6, ErrorMessage = "O dia da semana deve estar entre 0 e 6")]
        //[Column(TypeName = "int(11)")] 
        public int DiaDaSemana { get; set; } //DayOfWeek
        
        [Range(0, 23, ErrorMessage = "O horário de funcionamento deve estar entre 0 e 23")]
        //[Column(TypeName = "int(2)")] 
        public int HoradeAbertura { get; set; } //OpenTime

        [Range(0, 23, ErrorMessage = "A hora fechada deve estar entre 0 e 23")]
        //[Column(TypeName = "int(2)")]
        public int HoraDeFechar { get; set; } //
    }
}
