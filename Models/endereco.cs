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

        [ForeignKey("fkCliente")]
        public int? idCliente { get; set; }
        public virtual Cliente? fkCliente { get; set; }

        [ForeignKey("fkFilialHotel")]
        public int? idFilial { get; set; }
        public virtual filialHotel? fkFilialHotel { get; set; }


    }
}