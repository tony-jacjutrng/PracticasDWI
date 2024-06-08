


using Microsoft.EntityFrameworkCore;
using practicaV1.Models;

namespace practicaV1.Context
{
    public partial class HotelJacjContext:DbContext
    {

        public HotelJacjContext() { }

        public HotelJacjContext(DbContextOptions<HotelJacjContext> options) : base(options)
        {
        }
        public DbSet<cAlquiler> tAlquiler { get; set; }
        public DbSet<cCliente> tCliente { get; set; }
        public DbSet<cNacionalidad> tNacionalidad { get; set; }
        public DbSet<cHabitacion> tHabitacion { get; set; }
        public DbSet<cTipoHabitacion> tTipoHabitacion { get; set; }
        public DbSet<cEstado> tEstado { get; set; }
        public DbSet<cRegistrador> tRegistrador { get; set; }
    }
}
