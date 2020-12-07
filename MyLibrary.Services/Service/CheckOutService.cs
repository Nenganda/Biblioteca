using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Data.Interfaces;
using MyLibrary.Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyLibrary.Services.Service
{
    public class CheckOutService : ICheckOut
    {
        private MyLibraryContext _context;

        public CheckOutService(MyLibraryContext context)
        {
            _context = context;
        }
        public void Adicionar(CheckOut novoVerificarSaida)
        {
            _context.Add(novoVerificarSaida);
            _context.SaveChanges();
        }

        public void CheckInItem(int ativoId, int bibliotecaCartaoId)
        {
            var dataCorrente = DateTime.Now;

            var item = _context.BibliotecaAtivos
                .FirstOrDefault(a => a.Id == ativoId);
            _context.Update(item);

            //remove any existing checkouts on the item
            RemoverExistenteCheckOuts(ativoId);

            //close any existing checkout history
            FecharExistenteCheckOutHistorico(ativoId, dataCorrente);

            //look for existing holds on the item
            var dataAtualEsperas = _context.Esperas
                .Include(h => h.BibliotecaAtivo)
                .Include(h => h.BibliotecaCartao)
                .Where(h => h.BibliotecaAtivo.Id == ativoId);

            //if there are holds, checkout the item to the 
            //BibliotecaCartao with the earliest hold.
            if (dataAtualEsperas.Any())
            {
                CheckOutPrimeirosListadosEmEspera(ativoId, dataAtualEsperas);
            }

            //otherwise, update the item status to available
        }

        private void CheckOutPrimeirosListadosEmEspera(int ativoId, IEnumerable<Espera> dataAtualEsperas)
        {
            var primeiroListadosEspera = dataAtualEsperas
                .OrderBy(esperas => esperas.DataEspera)
                .FirstOrDefault();

            var cartao = primeiroListadosEspera.BibliotecaCartao;

            _context.Remove(primeiroListadosEspera);
            _context.SaveChanges();
            CheckInItem(ativoId, cartao.Id);
        }

        public IEnumerable<CheckOutHistorico> FiltrarCheckOutHistorico(int Id)
        {
            return _context.CheckOutHistoricos
                .Include(h => h.BibliotecaAtivo)
                .Include(h => h.BibliotecaCartao)
                .Where(h => h.BibliotecaAtivo.Id == Id);

        }

        public void CheckOutItem(int ativoId, int bibliotecaCartaoId)
        {
            if(IsCheckedOut(ativoId))
            {
                return;
                //Add logic here to handle feedback to the user:
            }

            var item = _context.BibliotecaAtivos
                .FirstOrDefault(a => a.Id == ativoId);

            AlterarAtivoEstato(ativoId, "Checked Out");

            var bibliotecaCartao = _context.BibliotecaCartaos
                .Include(card => card.Id == ativoId)
                .FirstOrDefault(card => card.Id == bibliotecaCartaoId);

            var dataCorrente = DateTime.Now;

            var checkout = new CheckOut
            {
                BibliotecaAtivo = item,
                BibliotecaCartao = bibliotecaCartao,
                Desde = dataCorrente,
                Ate = FiltrarPadraoCheckOutTempo(dataCorrente)
            };

            _context.Add(checkout);

            var checkoutHistorico = new CheckOutHistorico
            {
                CheckedIn = dataCorrente,
                BibliotecaAtivo = item,
                BibliotecaCartao = bibliotecaCartao
            };

            _context.Add(checkoutHistorico);
            _context.SaveChanges();
        }

        private DateTime FiltrarPadraoCheckOutTempo(DateTime dataCorrente)
        {
            return dataCorrente.AddDays(30);
        }

        private bool IsCheckedOut(int ativoId)
        {
            return _context.CheckOuts
                .Where(co => co.BibliotecaAtivo.Id == ativoId)
                .Any();
        }

        public void DataEspera(int ativoId, int bibliotecaCartaoId)
        {
            var dataCorrente = DateTime.Now;

            var ativo = _context.BibliotecaAtivos
                .FirstOrDefault(a => a.Id == ativoId);

            var card = _context.BibliotecaCartaos
                .FirstOrDefault(c => c.Id == bibliotecaCartaoId);

            if(ativo.Estato.Nome == "Available")
            {
                AlterarAtivoEstato(ativoId, "On Hold");
            }

            var espera = new Espera
            {
                DataEspera = dataCorrente,
                BibliotecaAtivo = ativo,
                BibliotecaCartao = card
            };

            _context.Add(espera);
            _context.SaveChanges();
        }

        public string FiltrarDataCorrenteDeEsperaPatronoNome(int esperaId)
        {
            var espera = _context.Esperas
                .Include(h => h.BibliotecaAtivo)
                .Include(h => h.BibliotecaCartao)
                .FirstOrDefault(h => h.Id == esperaId);

            var cartaoId = espera?.BibliotecaCartao.Id;

            var patrono = _context.Patronos.Include(p => p.BibliotecaCartao)
                .FirstOrDefault(p => p.BibliotecaCartao.Id == cartaoId);

            return patrono?.PrimeiroNome + " " + patrono?.SobreNome;
        }

        public DateTime FiltrarDataEsperaCorrente(int esperaId)
        {
            return
                _context.Esperas
                .Include(h => h.BibliotecaAtivo)
                .Include(h => h.BibliotecaCartao)
                .FirstOrDefault(h => h.Id == esperaId)
                .DataEspera;
        }

        public IEnumerable<Espera> FIltrarEsperaAtualmente(int Id)
        {
            return _context.Esperas
                .Include(h => h.BibliotecaAtivo)
                .Include(h => h.BibliotecaAtivo.Id == Id);
        }

        public CheckOut FiltrarPorId(int checkOutId)
        {
            return FiltrarTodos()
                .FirstOrDefault(checkout => checkout.Id == checkOutId);
        }

        public CheckOut FiltrarPorUltimoCheckOut(int ativoId)
        {
            return _context.CheckOuts
                .Where(c => c.BibliotecaAtivo.Id == ativoId)
                .OrderByDescending(c => c.Desde)
                .FirstOrDefault();
        }

        public IEnumerable<CheckOut> FiltrarTodos()
        {
            return _context.CheckOuts;
        }

        public void MarcarEncontrado(int ativoId)
        {
            var dataCorrente = DateTime.Now;
            
            AlterarAtivoEstato(ativoId, "Available");
            RemoverExistenteCheckOuts(ativoId); //principio de responsabilidade Unica
            FecharExistenteCheckOutHistorico(ativoId, dataCorrente); //principio de responsabilidade Unica

            #region Sem principio de responsabilidade Unica
            /*
                //remover por checkouts existentes no item 

                var checkout = _context.CheckOuts
                    .FirstOrDefault(co => co.BibliotecaAtivo.Id == ativoId);

                if (checkout != null)
                {
                    _context.Remove(checkout);
                }
             
                //Fechar qlqr histórico de checkout existente
                var historico = _context.CheckOutHistoricos
                    .FirstOrDefault(h => h.BibliotecaAtivo.Id == ativoId
                        && h.Verificado == null);
                if (historico != null)
                {
                    _context.Update(historico);
                    historico.Verificado = dataCorrente;
                }
             */
            #endregion

            _context.SaveChanges();
        }

        #region Principio de responsabilidade Unica
        private void AlterarAtivoEstato(int ativoId, string v)
        {
            var item = _context.BibliotecaAtivos
                .FirstOrDefault(a => a.Id == ativoId);

            _context.Update(item);

            item.Estato = _context.Estatos
                .FirstOrDefault(estatos => estatos.Nome == v);
        }

        private void FecharExistenteCheckOutHistorico(int ativoId, DateTime dataCorrente)
        {
            //Fechar qlqr histórico de checkout existente
            var historico = _context.CheckOutHistoricos
                .FirstOrDefault(h => h.BibliotecaAtivo.Id == ativoId
                    && h.CheckedIn == null);
            if (historico != null)
            {
                _context.Update(historico);
                historico.CheckedIn = dataCorrente;
            }
        }

        private void RemoverExistenteCheckOuts(int ativoId)
        {
            //remover por checkouts existentes no item 

            var checkout = _context.CheckOuts
                .FirstOrDefault(co => co.BibliotecaAtivo.Id == ativoId);

            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }
        #endregion

        public void MarcarPerdido(int ativoId)
        {
            /*
            var item = _context.BibliotecaAtivos
                .FirstOrDefault(a => a.Id == ativoId);

            _context.Update(item);

            item.Estato = _context.Estatos
                .FirstOrDefault(estatos => estatos.Nome == "Lost");
            */

            AlterarAtivoEstato(ativoId, "Lost");
            _context.SaveChanges();
        }

        public string FiltrarAtualCheckOutPatrono(int ativoId)
        {
            var checkOut = FiltrarCheckOutByAtivoId(ativoId);
            if(checkOut == null)
            {
                return "Não foi verificado a Saída";
            };

            var cartaoId = checkOut.BibliotecaCartao.Id;

            var patrono = _context.Patronos
                .Include(p => p.BibliotecaCartao)
                .FirstOrDefault(p => p.BibliotecaCartao.Id == cartaoId);

            return patrono.PrimeiroNome + " " + patrono.SobreNome;
        }

        /*
        public string FiltrarDataEsperaAtual(int esperaId)
        {
            var espera = _context.Esperas
                .Include(a => a.BibliotecaAtivo)
                .Include(a => a.BibliotecaCartao)
                .Where(v => v.Id == esperaId);

            return espera.Select(a => a.DataEspera)
                .FirstOrDefault().ToString(CultureInfo.InvariantCulture);
        }
        */

        private Espera FiltrarCheckOutByAtivoId(int ativoId)
        {
            return _context.Esperas
                .Include(co => co.BibliotecaAtivo)
                .Include(co => co.BibliotecaCartao)
                .FirstOrDefault(co => co.BibliotecaAtivo.Id == ativoId);
        }
    }
}
