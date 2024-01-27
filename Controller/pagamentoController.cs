using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class pagamentoController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Pagamento pagamento)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Pagamentos.Add(pagamento);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Pagamentos.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Pagamentos.FirstOrDefault(t => t.idPagamento == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Pagamento pagamento)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Pagamentos.FirstOrDefault(t => t.idPagamento == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(pagamento);
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
                var text = _context.Pagamentos.FirstOrDefault(t => t.idPagamento == id);
                if (text != null)
                {
                    _context.Pagamentos.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}