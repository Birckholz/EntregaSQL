using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class Servico
    {
        [Key]
        public int idServico { get; set; }

        [StringLength(100)]
        public string? nomeServ { get; set; }
        public float valor { get; set; }

        public virtual ICollection<ServicoConta>? servicosPorConta { get; set; }
    }
}