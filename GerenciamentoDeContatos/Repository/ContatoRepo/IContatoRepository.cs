using GerenciamentoDeContatos.Models;
using System.Linq;

namespace GerenciamentoDeContatos.Repository.ContatoRepo
{
    public interface IContatoRepository : IRepository
    {
        void ApagarContato(int id);
        Contato AtualizarContato(Contato contato);
        Contato GetContatoById(int id);
        IQueryable<Contato> GetAllContatos();
    }
}
