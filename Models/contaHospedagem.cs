using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class contaHospedagem
    {
        [ForeignKey("fkConta")]
        public int idConta { get; set; }
        public virtual Conta? fkConta { get; set; }

        [ForeignKey("fkReserva")]
        public int idReserva { get; set; }
        public virtual Reserva? fkReserva { get; set; }
    }
}