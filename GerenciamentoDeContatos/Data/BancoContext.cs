using GerenciamentoDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options): base(options)
        {
            
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
