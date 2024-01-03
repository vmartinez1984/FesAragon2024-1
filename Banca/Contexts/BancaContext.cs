using Microsoft.EntityFrameworkCore;
using Banca.Dtos;

namespace Banca.Entities;

public partial class BancaContext : DbContext
{
    private readonly string conectionString;
    public BancaContext(IConfiguration configuration)
    {
        conectionString = configuration.GetConnectionString("SqlServer");
    }

    public BancaContext(DbContextOptions<BancaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ahorro> Ahorro { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Transaccion> Transaccion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        //conectionString = "Data Source=192.168.1.86;Initial Catalog=Banca; Persist Security Info=True;User ID=sa;Password=Macross#2012; TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(conectionString);

        //conectionString = "Server=localhost; Port=3306; Database=Banca; Uid=root; Pwd=;";

        //optionsBuilder.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));
    }

    public DbSet<Banca.Dtos.BuscarClienteDto> BuscarClienteDto { get; set; }

}
