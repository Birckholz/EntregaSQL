using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class telefoneController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Telefone telefone)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Telefones.Add(telefone);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Telefones.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Telefones.FirstOrDefault(t => t.idTelefone == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Telefone telefone)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Telefones.FirstOrDefault(t => t.idTelefone == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(telefone);
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
                var text = _context.Telefones.FirstOrDefault(t => t.idTelefone == id);
                if (text != null)
                {
                    _context.Telefones.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}