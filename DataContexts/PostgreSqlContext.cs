using ASP.NET_CRUD_example_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CRUD_example_2.DataContexts
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        { }

        public DbSet<AlumnoDTO> Alumnos { get; set; }
        public DbSet<AsignaturaDTO> Asignaturas { get; set; }
        public DbSet<RelAlumAsigDTO> RelAlumAsigs { get; set; }
    }
}
