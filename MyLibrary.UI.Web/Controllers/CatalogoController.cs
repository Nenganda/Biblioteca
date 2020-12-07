using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data.Interfaces;
using MyLibrary.UI.Web.Models.Catalogo;
using System.Linq;

namespace MyLibrary.UI.Web.Controllers
{
    public class CatalogoController : Controller
    {
        private IBibliotecaAtivo _ativos;
        private ICheckOut _checkOuts;

        public CatalogoController(IBibliotecaAtivo ativos, ICheckOut checkOut)
        {
            _ativos = ativos;
            _checkOuts = checkOut;
        }
        public IActionResult Index()
        {
            var ativoModels = _ativos.FiltrarTodos();

            var listarResultado = ativoModels
                .Select(result => new AtivoIndexListarModel
                {
                    Id = result.Id,
                    ImagemUrl = result.ImagemUrl,
                    AutorOuDiretor = _ativos.FiltrarAutorOuDirector(result.Id),
                    DeweyChamarNumero = _ativos.FiltrarDeweyIndex(result.Id),
                    Titulo = result.Titulo,
                    Tipo = _ativos.FiltrarTipo(result.Id)
                });
            var model = new AtivoIndexModel()
            {
                Ativos = listarResultado
            };
            return View(model);
        }

        public IActionResult Details(int Id)
        {
            var ativo = _ativos.FiltrarPorId(Id);

            var dataEsperas = _checkOuts.FIltrarEsperaAtualmente(Id)
                .Select(a => new AtivoEsperaModel
                {
                    //DataEspera = _checkOuts.FiltrarDataEsperaCorrente(a.Id),
                    DataEspera = _checkOuts.FiltrarDataEsperaCorrente(a.Id).ToString("d"),
                    PatronoNome = _checkOuts.FiltrarDataCorrenteDeEsperaPatronoNome(a.Id)
                });

            var ativoDomain = new AtivoDetailModel
            {
                AtivoId = Id,
                Titulo = ativo.Titulo,
                Ano = ativo.Ano,
                Custo = ativo.Custo,
                Estatos = ativo.Estato.Nome,
                ImagemURL = ativo.ImagemUrl,
                AutorOuDiretor = _ativos.FiltrarAutorOuDirector(Id),
                LocalizacaoAtual = _ativos.FiltrarLocalizacaoAtual(Id).Nome,
                DeweyChamarPorNumero = _ativos.FiltrarDeweyIndex(Id),
                CheckoutHistorico = _checkOuts.FiltrarCheckOutHistorico(Id),
                ISBN = _ativos.FiltrarISBN(Id),
                UltimoCheckOut = _checkOuts.FiltrarPorUltimoCheckOut(Id),
                PatronoNome = _checkOuts.FiltrarAtualCheckOutPatrono(Id),
                //EsperaAtualmente = dataEsperas
            };

            return View(ativoDomain);
        }
    }
}