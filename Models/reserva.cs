using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntregaSql
{

    public class Reserva
    {

        [Key]
        public int idReserva { get; set; }
        public DateTime dataCheckIn { get; set; }
        public DateTime dataCheckOut { get; set; }

        [ForeignKey("fkCliente")]
        public int idCliente { get; set; }
        public virtual Cliente? fkCliente { get; set; }

        [ForeignKey("fkFuncionario")]
        public int idFuncionario { get; set; }
        public virtual Funcionario? fkFuncionario { get; set; }

        [StringLength(20)]
        public string? statusPedido { get; set; }
        public DateTime? dataModificacao { get; set; }


        public bool checarReservaPossivel(List<reservaQuarto> reservaQuartos, DateTime dataCheckIn, DateTime dataCheckOut)
        {

            reservaQuarto? reservaASerChecado = reservaQuartos.Find(reservaQuarto => reservaQuarto.idReserva == idReserva && reservaQuarto.fkReserva != null && dataCheckIn < reservaQuarto.fkReserva.dataCheckOut && dataCheckOut > reservaQuarto.fkReserva.dataCheckIn);
            return reservaASerChecado == null;
        }

        public virtual ICollection<reservaQuarto>? quartosDaReserva { get; set; }
    }
}