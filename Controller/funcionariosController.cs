using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class funcionarioController : Controller
    {
        [HttpPost()]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            using (var _context = new HotelIdisContext())
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new HotelIdisContext())
            {
                return Ok(_context.Funcionarios.ToList());
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Funcionarios.FirstOrDefault(t => t.idFuncionario == id);
                if (text != null)
                {
                    return Ok(text);
                }
                return NotFound("Não encontrado");
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Funcionario funcionario)
        {
            using (var _context = new HotelIdisContext())
            {
                var text = _context.Funcionarios.FirstOrDefault(t => t.idFuncionario == id);
                if (text != null)
                {
                    _context.Entry(text).CurrentValues.SetValues(funcionario);
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
                var text = _context.Funcionarios.FirstOrDefault(t => t.idFuncionario == id);
                if (text != null)
                {
                    _context.Funcionarios.Remove(text);
                    _context.SaveChanges();
                    Ok("Funcionario Removido");
                }
                return NotFound("Não encontrado");
            }
        }
    }
}