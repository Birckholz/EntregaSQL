using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class reservaController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Reserva reserva)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
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