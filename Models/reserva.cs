using System.ComponentModel.DataAnnotations;

namespace EntityORM
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set; }
        public int idQuarto { get; set; }
        public int idCliente { get; set; }
        public int idFuncionario { get; set; }

        [StringLength(20)]
        public string? statusPedido { get; set; }
        [StringLength(64)]
        public DateTime dataCheckIn { get; set; }
        public DateTime dataCheckOut { get; set; }
        public DateTime dataModificacao { get; set; }


    }
}