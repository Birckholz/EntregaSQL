using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class filialHotelController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] filialHotel filialHotel)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.filiaisHoteis.Add(filialHotel);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.filiaisHoteis.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.filiaisHoteis.FirstOrDefault(t => t.idFilial == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] filialHotel filialHotel)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.filiaisHoteis.FirstOrDefault(t => t.idFilial == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(filialHotel);
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
                var text = _context.filiaisHoteis.FirstOrDefault(t => t.idFilial == id);
                if (text != null)
                {
                    _context.filiaisHoteis.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}