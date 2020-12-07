using MyLibrary.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.UI.Web.Models.Catalogo
{
    public class AtivoDetailModel
    {
        public int AtivoId { get; set; }
        public string Titulo { get; set; }
        public string AutorOuDiretor { get; set; }
        public string Tipo { get; set; }
        public int Ano { get; set; }
        public string ISBN { get; set; }
        public string DeweyChamarPorNumero { get; set; }
        public string Estatos { get; set; }
        public decimal Custo { get; set; }
        public string LocalizacaoAtual { get; set; }
        public string ImagemURL { get; set; }
        public string PatronoNome { get; set; }
        public CheckOut UltimoCheckOut { get; set; }
        public IEnumerable<CheckOutHistorico> CheckoutHistorico { get; set; }
        public IEnumerable<AtivoEsperaModel> EsperaAtualmente { get; set; }
    }

    public class AtivoEsperaModel
    {
        public string PatronoNome { get; set; }
        public string DataEspera { get; set; }
    }
}
