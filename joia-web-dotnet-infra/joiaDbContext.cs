using joia_web_dotnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace joia_web_dotnet_infra
{
    public class joiaDbContext : DbContext
    {

        public joiaDbContext(DbContextOptions<joiaDbContext> options) : base(options)
        {
        }
    
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Metal> Metais { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

    }

    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }
}