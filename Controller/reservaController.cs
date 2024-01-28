using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class reservaController : Controller
    {
        [HttpPost("{idCliente}/{idQuarto}/{idFuncionario}/{status}/{dataCheckin}/{dataCheckout}/")]
        public IActionResult Post(int idCliente, int idFuncionario, DateTime dataCheckin, DateTime dataCheckout, string status, int idQuarto)
        {
            using (var _context = new HotelIdisContext())
            {
                Reserva novaReserva = new Reserva()
                {
                    idCliente = idCliente,
                    idFuncionario = idFuncionario,
                    dataCheckIn = dataCheckin,
                    dataCheckOut = dataCheckout,
                    statusPedido = status
                };



                if (novaReserva.checarReservaPossivel(_context.ReservaQuartos.ToList(), novaReserva.dataCheckIn, novaReserva.dataCheckOut))
                {
                    _context.Reservas.Add(novaReserva);
                    _context.SaveChanges();
                    contaHospedagem contaHospedagem = new contaHospedagem()
                    {
                        idReserva = novaReserva.idReserva,
                        total = 0
                    };
                    reservaQuarto reservaQuarto = new reservaQuarto()
                    {
                        idQuarto = idQuarto,
                        idReserva = novaReserva.idReserva
                    };
                    _context.contaHospedagems.Add(contaHospedagem);
                    _context.ReservaQuartos.Add(reservaQuarto);
                    _context.SaveChanges();
                    return Ok("Dados Inseridos");
                }
                return NotFound("Quarto esta alugado nesse periodo");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Reservas.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Reservas.FirstOrDefault(t => t.idReserva == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Reserva reserva)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Reservas.FirstOrDefault(t => t.idReserva == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(reserva);
                    _context.SaveChanges();
                    Ok("Dados Atualizados");
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Reservas.FirstOrDefault(t => t.idReserva == id);
                if (text != null)
                {
                    _context.Reservas.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}