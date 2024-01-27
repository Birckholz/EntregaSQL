using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class Pagamento
    {
        [Key]
        public int idPagamento { get; set; }
        public int idReserva { get; set; }

        [StringLength(50)]
        public string? tipo { get; set; }

    }
}