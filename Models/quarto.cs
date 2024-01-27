using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class Quarto
    {
        [Key]
        public int idQuarto { get; set; }

        [StringLength(64)]
        public bool acomadaEsp { get; set; }
        [StringLength(11)]
        public string? tipo { get; set; }

        public float valor { get; set; }

        public int maxCap { get; set; }

    }
}