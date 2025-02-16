using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Services.Services.Interfaces;
using SMNPastel.Repository.interfaces;
using SMNPastel.Services.Interfaces;
using SMNPastel.ViewModel;

namespace SMNPastel.Controllers
{    
    public class TarefaController : ControllerBase
    {
        private readonly ILogger<TarefaController> _logger;        
        private readonly ITarefaService _tarefaService;
        private readonly IEmailService _emailService;
        private readonly IUsuarioRepository _usuarioRepository;

        public TarefaController(ILogger<TarefaController> logger,
            IUsuarioRepository usuarioRepository,
             ITarefaService tarefaService,
             IEmailService emailService,
             IUsuarioRepository usuario)
            : base(usuarioRepository)
        {
            _logger = logger;            
            _tarefaService = tarefaService;
            _emailService = emailService;
            _usuarioRepository = usuario;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = await _tarefaService.GetTarefas();
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CriarTarefa()
        {            
            ViewBag.Subordinados = new SelectList(_usuarios, "Id", "Nome");
            return View("CriarOrEditarTarefa", new TarefaViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> CriarTarefa(TarefaViewModel model)
        {           
            if (!ModelState.IsValid)
            {                
                ViewBag.Subordinados = new SelectList(_usuarios, "Id", "Nome", model.SubordinadoId);
                return View("CriarOrEditarTarefa", model);
            }

            await _tarefaService.SaveOrUpdate(model);

            var usuario = await _usuarioRepository.FindUserById(model.SubordinadoId);

            var emailModel = new EnviarEmail()
            {
                Assunto = "Tarefa Criada",
                Mensagem = "Foi criado uma tarefa para voce executar, acesse o sistema para prosseguir com a demanda.",
                Destinatario = usuario.Email
            };

            var resultMsg = await _emailService.EnviarEmailAsync(emailModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]        
        public async Task<IActionResult> Editar(int id)
        {
            var model = await _tarefaService.GetTarefaById(id);

            if (model is null)
                return NotFound();

            ViewBag.Subordinados = new SelectList(_usuarios, "Id", "Nome", model.SubordinadoId);
            return View("CriarOrEditarTarefa", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(TarefaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Subordinados = new SelectList(_usuarios, "Id", "Nome", model.SubordinadoId);
                return View("CriarOrEditarTarefa", model);
            }

            await _tarefaService.SaveOrUpdate(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var model = await _tarefaService.GetTarefaById(id);

            if (model is null)
                return NotFound();

            await _tarefaService.Excluir(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
