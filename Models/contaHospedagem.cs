using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class contaHospedagem
    {
        [Key]
        public int idContaHosp { get; set; }
        [ForeignKey("fkReserva")]
        public int idReserva { get; set; }
        public virtual Reserva? fkReserva { get; set; }
        public float total { get; set; }

        public virtual ICollection<ServicoConta>? servicosPorConta { get; set; }

        public contaHospedagem()
        {
            servicosPorConta = new List<ServicoConta>();
        }

    }
}