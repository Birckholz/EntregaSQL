using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class filialHotel
    {
        [Key]
        public int idFilial { get; set; }

        [StringLength(100)]
        public string? nome { get; set; }
        public int numQuartosSolteiro { get; set; }
        public int numQuartosCasal { get; set; }
        public int numQuartosFamília { get; set; }
        public int numQuartosPresidencial { get; set; }

    }
}