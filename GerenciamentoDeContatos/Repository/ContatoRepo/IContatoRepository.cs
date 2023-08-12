using GerenciamentoDeContatos.Models;
using System.Linq;

namespace GerenciamentoDeContatos.Repository.ContatoRepo
{
    public interface IContatoRepository : IRepository
    {
        IQueryable<Contato> GetAllContatos();
    }
}
