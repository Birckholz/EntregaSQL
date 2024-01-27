using System.ComponentModel.DataAnnotations;

namespace EntityORM
{
    public class Telefone
    {
        [Key]
        public int idTelefone { get; set; }

        [MaxLength(11)]
        public char? telefone { get; set; }

        public int idCliente { get; set; }



    }
}