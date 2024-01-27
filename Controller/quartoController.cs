using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class quartoController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Quarto quarto)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Quartos.Add(quarto);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Quartos.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Quartos.FirstOrDefault(t => t.idQuarto == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Quarto quarto)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Quartos.FirstOrDefault(t => t.idQuarto == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(quarto);
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
                var text = _context.Quartos.FirstOrDefault(t => t.idQuarto == id);
                if (text != null)
                {
                    _context.Quartos.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}