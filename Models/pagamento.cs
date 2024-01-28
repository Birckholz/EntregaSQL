using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class Pagamento
    {
        [Key]
        public int idPagamento { get; set; }
        [ForeignKey("fkContaHosp")]
        public int idContaHosp { get; set; }
        public virtual contaHospedagem? fkContaHosp { get; set; }

        [StringLength(50)]
        public string? tipo { get; set; }

    }
}