using System.ComponentModel.DataAnnotations;

namespace EntityORM
{
    public class contaHospedagem
    {
        [Key]
        public int idContaHosp { get; set; }
        public int idReserva { get; set; }
        public float total { get; set; }
    }
}