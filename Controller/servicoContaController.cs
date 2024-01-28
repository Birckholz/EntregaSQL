using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class servicoContaController : Controller
    {
        [HttpPost("{idContaHosp}/{idServico}")]
        public IActionResult Post(int idContaHosp, int idServico)
        {
            ServicoConta servicoConta = new ServicoConta()
            {
                idContaHosp = idContaHosp,
                idServico = idServico
            };
            using (var _context = new HotelIdisContext())
            {
                _context.servicosConta.Add(servicoConta);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.servicosConta.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.servicosConta.FirstOrDefault(t => t.idServico == id);
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
                var text = _context.servicosConta.FirstOrDefault(t => t.idServico == id);
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
                var text = _context.servicosConta.FirstOrDefault(t => t.idServico == id);
                if (text != null)
                {
                    _context.servicosConta.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}
