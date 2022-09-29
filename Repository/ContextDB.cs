using CRUDBASICO.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDBASICO.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
