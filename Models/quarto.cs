using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class Quarto
    {
        [Key]
        public int idQuarto { get; set; }
        [ForeignKey("fkIdFilial")]
        public int idFilial { get; set; }
        public virtual filialHotel? filialHotel { get; set; }

        [StringLength(64)]
        public bool acomadaEsp { get; set; }
        [StringLength(11)]
        public string? tipo { get; set; }

        public float valor { get; set; }

        public int maxCap { get; set; }

        public virtual ICollection<reservaQuarto>? quartosDaReserva { get; set; }


    }
}