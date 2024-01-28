using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntregaSql;

public class reservaQuarto
{
    [ForeignKey("fkReserva")]
    [Required]
    public int idReserva { get; set; }
    public virtual Reserva? fkReserva { get; set; }

    [ForeignKey("fkQuarto")]
    [Required]
    public int idQuarto { get; set; }
    public virtual Quarto? fkQuarto { get; set; }
}