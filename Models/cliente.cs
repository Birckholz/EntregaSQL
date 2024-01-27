using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [StringLength(100)]
        public string? nome { get; set; }
        [StringLength(50)]
        public string? nacionalidade { get; set; }
        [StringLength(100)]
        public string? email { get; set; }


    }
}