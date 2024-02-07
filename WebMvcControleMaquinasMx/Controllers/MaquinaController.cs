using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc_Domain.Enum;
using WebMvcControleMaquinasMx.Models;
using WebMvcControleMaquinasMx.Models.Maquinas;
using WebMvcControleMaquinasMx.Services.Interfaces;

namespace WebMvcControleMaquinasMx.Controllers
{
    [Route("Maquinas")]
    public class MaquinaController : Controller
    {
        private readonly IMaquinaService _maquinaService;
        private readonly IPacoteService _pacoteService;

        public MaquinaController(IMaquinaService maquinaService, IPacoteService pacoteService)
        {
            _maquinaService = maquinaService;
            _pacoteService = pacoteService;
        }

        [Route("listar")]
        public async Task<IActionResult> Index()
        {
            var resp = await _maquinaService.BuscarMaquinas();
            return View(resp);
        }

        [Route("criar")]
        public IActionResult Create()
        {
            var model = new CriarMaquinaViewModel
            {
                Inventario = "",
                Hostname = "",
                Ondeso = false,
                Criticidade = Criticidade.C
            };
            return View(model);
        }

        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> Create(CriarMaquinaViewModel maquina)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("KeyErroMensagem", "Ocorreu um erro");
                return View(maquina);
            }
            var resp = await _maquinaService.CadastrarMaquinas(maquina);
            return RedirectToAction(nameof(Index));
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var pacote = await _pacoteService.BuscarPacotes();
            var maquina = await _maquinaService.BuscarMaquinas(id);
            var model = new EditarMaquinaViewModel
            {
                Id = maquina.Id,
                Inventario = maquina.Inventario,
                Hostname = maquina.Hostname,
                Ondeso = maquina.Ondeso,
                Criticidade = maquina.Criticidade,
                DataCadastro = maquina.DataCadastro,
                UltimaAtualizacao = DateTime.Now,
                PacoteOptionsDisponiveis = new SelectList(pacote, "Id", "NomeKb"),
                PacoteOptionsAssociados = new SelectList(pacote, "Id", "NomeKb")
            };
            return View(model);
        }

        [HttpPost]
        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(EditarMaquinaViewModel maquina, int id)
        {
            if (ModelState.IsValid)
            {
                await _maquinaService.AtualizarMaquina(maquina, id);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Error));
        }

        [Route("excluir/`{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pacote = await _pacoteService.BuscarPacotes();
            var maquina = await _maquinaService.BuscarMaquinas(id);
            var model = new MaquinaViewModel
            {
                Id = maquina.Id,
                Inventario = maquina.Inventario,
                Hostname = maquina.Hostname,
                Ondeso = maquina.Ondeso,
                Criticidade = maquina.Criticidade,
                DataCadastro = maquina.DataCadastro,
                UltimaAtualizacao = maquina.UltimaAtualizacao,
                PacoteOptions = new SelectList(pacote, "Id", "NomeKb")
            };
            return View(model);
        }

        [HttpPost]
        [Route("excluir/{id:int}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _maquinaService.DeletaMaquina(id);
            return RedirectToAction(nameof(Index));
        }

        [Route("erro")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
