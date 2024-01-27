using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class contaHospedagem
    {
        [Key]
        public int idContaHosp { get; set; }
        public int idReserva { get; set; }
        public float total { get; set; }
    }
}