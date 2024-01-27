using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class enderecoController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Enderecos.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Enderecos.FirstOrDefault(t => t.idEndereco == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Endereco endereco)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Enderecos.FirstOrDefault(t => t.idEndereco == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(endereco);
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
                var text = _context.Enderecos.FirstOrDefault(t => t.idEndereco == id);
                if (text != null)
                {
                    _context.Enderecos.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}