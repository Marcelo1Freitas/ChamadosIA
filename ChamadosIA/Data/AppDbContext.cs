using Microsoft.EntityFrameworkCore;
using ChamadosIA.Models; // ou o namespace onde está sua classe Usuario

namespace ChamadosIA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}