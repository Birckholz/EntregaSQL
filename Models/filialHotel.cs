using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace EntregaSql
{
    public class filialHotel
    {
        [Key]
        public int idFilial { get; set; }

        [StringLength(100)]
        public string? nome { get; set; }
        public int numQuartosSolteiro { get; set; } = 0;
        public int numQuartosCasal { get; set; } = 0;
        public int numQuartosFamilia { get; set; } = 0;
        public int numQuartosPresidencial { get; set; } = 0;

        public virtual ICollection<Telefone>? TelefonesHotel { get; set; }
        public virtual ICollection<Quarto>? Quartos { get; set; }

        public filialHotel()
        {
            TelefonesHotel = new List<Telefone>();
            Quartos = new List<Quarto>();
        }

    }
}