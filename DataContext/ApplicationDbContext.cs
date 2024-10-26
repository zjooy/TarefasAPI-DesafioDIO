using agendamentoTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace agendamentoTarefas.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}
