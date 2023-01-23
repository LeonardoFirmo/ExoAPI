using ExoAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ExoAPI.Contexts
{
    public class ChapterContext : DbContext
    {

        public ChapterContext()
        {
        }

        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação 
                //  - "Server=localhost,7205;Database=EXOPAI;TrustServerCertificate=True" User ID=sa;Password=1q2w3e4r@#$
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-A3D588Q; initial catalog = ExoAPI; Integrated Security = true");
            }
        }
        public DbSet<Projetos> PROJETOS { get; set; }
        public DbSet<Usuarios> USUARIOS { get; set; }
    }
}
