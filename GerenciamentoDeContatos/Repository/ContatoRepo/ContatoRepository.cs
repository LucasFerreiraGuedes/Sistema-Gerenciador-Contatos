using GerenciamentoDeContatos.Data;
using GerenciamentoDeContatos.Models;
using System;
using System.Linq;

namespace GerenciamentoDeContatos.Repository.ContatoRepo
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _context;

        public ContatoRepository(BancoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
           if (entity is Contato)
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
           

        }

        public void ApagarContato(int id)
        {
            var contato = GetContatoById(id);

            if (contato == null) throw new Exception("O usuário informado não existe no banco de dados");

            _context.Remove(contato);
            _context.SaveChanges();

        }

        public Contato AtualizarContato(Contato contato)
        {
            var contatoDb = GetContatoById(contato.Id);

            if (contatoDb == null) throw new Exception("O usuário informado não existe no banco de dados");

            contatoDb.Nome = contato.Nome;
            contatoDb.Sobrenome = contato.Sobrenome;
            contatoDb.Telefone = contato.Telefone;
            contatoDb.Email = contato.Email;

            _context.Update(contatoDb);
            _context.SaveChanges();

            return contatoDb;
        }

        public IQueryable<Contato> GetAllContatos()
        {
            return _context.Contatos.AsQueryable();
        }

        public Contato GetContatoById(int id)
        {
            return _context.Contatos.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
