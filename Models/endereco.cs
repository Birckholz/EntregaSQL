using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class Endereco
    {
        [Key]
        public int idEndereco { get; set; }

        [StringLength(50)]
        public string? rua { get; set; }
        [MaxLength(2)]
        public char? UF { get; set; }
        [StringLength(50)]
        public string? cidade { get; set; }

        public int idDonoEnd { get; set; }

    }
}