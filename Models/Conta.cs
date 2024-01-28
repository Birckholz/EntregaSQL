using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaSql
{
    public class Conta
    {
        [Key]
        public int idConta { get; set; }
        public float total { get; set; }

        public virtual ICollection<ServicoConta>? servicosPorConta { get; set; }

        public Conta()
        {
            servicosPorConta = new List<ServicoConta>();
        }

    }
}