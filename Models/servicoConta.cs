using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntregaSql
{
    [PrimaryKey(nameof(idServico), nameof(idContaHosp))]
    public class ServicoConta
    {

        [ForeignKey("fkServico")]
        public int idServico { get; set; }
        public virtual Servico? fkServico { get; set; }

        [ForeignKey("fkContaHosp")]
        public int idContaHosp { get; set; }
        public virtual contaHospedagem? fkContaHosp { get; set; }


        public int quantidade { get; set; }
    }
}