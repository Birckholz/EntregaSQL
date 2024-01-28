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
                    Conta conta = new Conta()
                    {
                        total = 0
                    };
                    _context.Reservas.Add(novaReserva);
                    _context.Contas.Add(conta);
                    _context.SaveChanges();
                    reservaQuarto reservaQuarto = new reservaQuarto()
                    {
                        idQuarto = idQuarto,
                        idReserva = novaReserva.idReserva
                    };
                    Cliente? cliente1 = _context.Clientes.FirstOrDefault(Clientes => Clientes.idCliente == novaReserva.idCliente);
                    Funcionario? funcionario1 = _context.Funcionarios.FirstOrDefault(Funcionario => Funcionario.idFuncionario == idFuncionario);
                    if (cliente1 != null)
                    {
                        novaReserva.fkCliente = cliente1;
                    }
                    if (funcionario1 != null)
                    {
                        novaReserva.fkFuncionario = funcionario1;
                    }

                    contaHospedagem contaHospedagem = new contaHospedagem()
                    {
                        idConta = conta.idConta,
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