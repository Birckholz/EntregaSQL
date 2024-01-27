using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class servicoController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Servico servico)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Servicos.Add(servico);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Servicos.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Servicos.FirstOrDefault(t => t.idServico == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Servico servico)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Servicos.FirstOrDefault(t => t.idServico == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(servico);
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
                var text = _context.Servicos.FirstOrDefault(t => t.idServico == id);
                if (text != null)
                {
                    _context.Servicos.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}