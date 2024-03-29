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
                var text = _context.contaHospedagems.FirstOrDefault(t => t.idConta == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{idReserva}/{total}")]
        public IActionResult Put(int idReserva, int? total)
        {
            using (var _context = new HotelIdisContext())
            {
                var updateEntity = _context.contaHospedagems.FirstOrDefault(t => t.idReserva == idReserva);
                if (updateEntity != null)
                {
                    if (total != null)
                    {
                        // updateEntity.total = Convert.ToInt32(total);

                    }
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
                var text = _context.contaHospedagems.FirstOrDefault(t => t.idConta == id);
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