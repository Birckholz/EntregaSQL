using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class Telefone
    {
        [Key]
        public int idTelefone { get; set; }

        [MaxLength(11)]
        public char? telefone { get; set; }

        [ForeignKey("fkCliente")]
        public int? idCliente { get; set; } = null;
        public virtual Cliente? clienteT { get; set; } = null;
        [ForeignKey("fkFilialHotel")]
        public int? idFilial { get; set; } = null;
        public virtual filialHotel? fkFilialHotel { get; set; } = null;



    }
}