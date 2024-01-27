using Microsoft.EntityFrameworkCore;

namespace EntregaSql
{
    public class HotelIdisContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<contaHospedagem> contaHospedagems { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<filialHotel> filiaisHoteis { get; set; } = null!;
        public DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public DbSet<Pagamento> Pagamentos { get; set; } = null!;
        public DbSet<Quarto> Quartos { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Servico> Servicos { get; set; } = null!;
        public DbSet<Telefone> Telefones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=COMPUTADORDEGUI\SQLEXPRESS;Database=HotelIdis;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}