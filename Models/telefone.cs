using System.ComponentModel.DataAnnotations;

namespace EntregaSql
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