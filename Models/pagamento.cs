using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class Pagamento
    {
        [Key]
        public int idPagamento { get; set; }
        [ForeignKey("fkConta")]
        public int idConta { get; set; }
        public virtual Conta? fkConta { get; set; }

        [StringLength(50)]
        public string? tipo { get; set; }

    }
}