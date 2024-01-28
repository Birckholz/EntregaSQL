using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntregaSql
{
    public class ServicoConta
    {
        [ForeignKey("fkServico")]
        public int idServico { get; set; }
        public virtual Servico? fkServico { get; set; }

        [ForeignKey("fkConta")]
        public int idConta { get; set; }
        public virtual Conta? fkConta { get; set; }

        public int quantidade { get; set; }
    }
}