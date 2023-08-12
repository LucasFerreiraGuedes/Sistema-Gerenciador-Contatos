using GerenciamentoDeContatos.Models;
using GerenciamentoDeContatos.Repository.ContatoRepo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GerenciamentoDeContatos.Controllers
{
	public class ContatoController : Controller
	{
		private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
			_contatoRepository = contatoRepository;
        }
        public IActionResult Index()
		{
			var contatos =  _contatoRepository.GetAllContatos().ToList();
			return View(contatos);
		}
		public IActionResult CriarContato()
		{
			return View();
		}
		public IActionResult Editar(int id)
		{
			Contato contato = _contatoRepository.GetContatoById(id);
			return View(contato);
		}
		public IActionResult Apagar(int id)
		{
			_contatoRepository.ApagarContato(id);
            return RedirectToAction("Index");
        }

		[HttpPost]
		public IActionResult Criar(Contato contato)
		{
			_contatoRepository.Add(contato);

			return RedirectToAction("Index");
		}
        [HttpPost]
        public IActionResult Atualizar(Contato contato)
        {
            _contatoRepository.AtualizarContato(contato);

            return RedirectToAction("Index");
        }
    }
}
