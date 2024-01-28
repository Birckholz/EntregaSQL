using Microsoft.EntityFrameworkCore;

namespace EntregaSql
{
    public class HotelIdisContext : DbContext
    {
        public DbSet<ServicoConta> servicosConta { get; set; } = null!;
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
        public DbSet<Conta> Contas { get; set; } = null!;
        public DbSet<reservaQuarto> ReservaQuartos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=COMPUTADORDEGUI\SQLEXPRESS;Database=HotelIdis;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<contaHospedagem>()
                .HasKey(ch => new { ch.idConta, ch.idReserva });

            modelBuilder.Entity<reservaQuarto>()
                .HasKey(rq => new { rq.idReserva, rq.idQuarto });

            modelBuilder.Entity<reservaQuarto>()
                .HasOne(rq => rq.fkReserva)
                .WithMany(r => r.quartosDaReserva)
                .HasForeignKey(rq => rq.idReserva);
            modelBuilder.Entity<reservaQuarto>()
                .HasOne(rq => rq.fkQuarto)
                .WithMany(r => r.quartosDaReserva)
                .HasForeignKey(rq => rq.idQuarto);


            modelBuilder.Entity<ServicoConta>()
                .HasKey(cs => new { cs.idServico, cs.idConta });

            modelBuilder.Entity<ServicoConta>()
                .HasOne(cs => cs.fkServico)
                .WithMany(c => c.servicosPorConta)
                .HasForeignKey(cs => cs.idServico);

            modelBuilder.Entity<ServicoConta>()
                .HasOne(cs => cs.fkConta)
                .WithMany(c => c.servicosPorConta)
                .HasForeignKey(cs => cs.idConta);



            base.OnModelCreating(modelBuilder);

        }
    }


}