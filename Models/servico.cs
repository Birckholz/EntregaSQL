using System.ComponentModel.DataAnnotations;

namespace EntityORM
{
    public class Servico
    {
        [Key]
        public int idServico { get; set; }

        [StringLength(100)]
        public string? nomeServ { get; set; }
        public int idContaHosp { get; set; }
        public float valor { get; set; }
        public int quantidade { get; set; }
    }
}