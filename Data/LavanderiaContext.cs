namespace LavanderiaApp.Data;

using LavanderiaApp.Models;
using Microsoft.EntityFrameworkCore;

    public class LavanderiaContext : DbContext
    {
    public LavanderiaContext(DbContextOptions<LavanderiaContext> options)
       : base(options)
    { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Prenda> Prendas { get; set; }
    public DbSet<TipoPrenda> TiposPrenda { get; set; }
    public DbSet<TipoTela> TiposTela { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<EstadoServicio> EstadosServicio { get; set; }

}

