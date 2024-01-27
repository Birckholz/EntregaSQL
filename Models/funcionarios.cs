using System.ComponentModel.DataAnnotations;

namespace EntregaSql
{
    public class Funcionario
    {
        [Key]
        public int idFuncionario { get; set; }

        [StringLength(100)]
        public string? nome { get; set; }
        [StringLength(50)]
        public string? tipo { get; set; }

    }
}