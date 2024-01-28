using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class contaHospedagemController : Controller
    {
        //contaHospedagem sem geradas ao criar a reserva por isso está comentado 
        // [HttpPost("{idReserva}")]
        // public IActionResult Post(int idReserva)
        // {
        //     contaHospedagem contaHosp = new contaHospedagem()
        //     {
        //         idReserva = idReserva
        //     };
        //     using (var _context = new HotelIdisContext())
        //     {
        //         _context.contaHospedagems.Add(contaHosp);
        //         _context.SaveChanges();
        //         return Ok("Dados Inseridos");
        //     }
        // }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.contaHospedagems.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.contaHospedagems.FirstOrDefault(t => t.idContaHosp == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] contaHospedagem contaHospedagem)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.contaHospedagems.FirstOrDefault(t => t.idContaHosp == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(contaHospedagem);
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
                var text = _context.contaHospedagems.FirstOrDefault(t => t.idContaHosp == id);
                if (text != null)
                {
                    _context.contaHospedagems.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}