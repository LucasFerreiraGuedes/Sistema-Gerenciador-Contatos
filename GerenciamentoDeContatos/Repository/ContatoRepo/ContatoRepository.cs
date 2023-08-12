using GerenciamentoDeContatos.Data;
using GerenciamentoDeContatos.Models;
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

        public IQueryable<Contato> GetAllContatos()
        {
            return _context.Contatos.AsQueryable();
        }
    }
}
