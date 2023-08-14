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
			try
			{
                _contatoRepository.ApagarContato(id);
                TempData["MensagemSucesso"] = "O contato foi apagado com sucesso!";
                return RedirectToAction("Index");
            }
			catch (System.Exception erro)
			{
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar apagar o contato, favor tentar novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
			
        }

		[HttpPost]
		public IActionResult Criar(Contato contato)
		{
			try
			{
                _contatoRepository.Add(contato);
				TempData["MensagemSucesso"] = "O contato foi salvo com sucesso!";
                return RedirectToAction("Index");
            }
			catch (System.Exception erro)
			{
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar salvar o contato, favor tentar novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
			
		}
        [HttpPost]
        public IActionResult Atualizar(Contato contato)
        {
			try
			{
                _contatoRepository.AtualizarContato(contato);
                TempData["MensagemSucesso"] = "O contato foi atualizado com sucesso!";
                return RedirectToAction("Index");
            }
			catch (System.Exception erro)
			{
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar atualizar o contato, favor tentar novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
           
        }
    }
}
