using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class clienteController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Clientes.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Clientes.FirstOrDefault(t => t.idCliente == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Clientes.FirstOrDefault(t => t.idCliente == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(cliente);
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
                var text = _context.Clientes.FirstOrDefault(t => t.idCliente == id);
                if (text != null)
                {
                    _context.Clientes.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}