using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GerenciamentoDeContatos.Repository
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
    }
}
