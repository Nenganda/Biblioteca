using MyLibrary.Data.Model;
using System;
using System.Collections.Generic;

namespace MyLibrary.Data.Interfaces
{
    public interface ICheckOut
    {
        IEnumerable<CheckOut> FiltrarTodos();
        CheckOut FiltrarPorId(int checkOutId);
        void Adicionar(CheckOut novoVerificarSaida);
        void CheckOutItem(int ativoId, int bibliotecaCartaoId);
        void CheckInItem(int ativoId, int bibliotecaCartaoId);
        CheckOut FiltrarPorUltimoCheckOut(int ativoId);
        IEnumerable<CheckOutHistorico> FiltrarCheckOutHistorico(int Id);
        string FiltrarAtualCheckOutPatrono(int ativoId);

        void DataEspera(int ativoId, int bibliotecaCartaoId);
        string FiltrarDataCorrenteDeEsperaPatronoNome(int esperaId);
        DateTime FiltrarDataEsperaCorrente(int esperaId);
        IEnumerable<Espera> FIltrarEsperaAtualmente(int Id);

        void MarcarPerdido(int ativoId);
        void MarcarEncontrado(int ativoId);
    }
}
