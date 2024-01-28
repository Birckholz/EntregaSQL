using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class quartoController : Controller
    {
        [HttpPost("{idFilial}/{acomodaEsp}/{tipo}/{valor}/{maxCap}")]
        public IActionResult Post(int idFilial, bool acomodaEsp, string tipo, int maxCap, float valor)
        {
            Quarto quarto = new Quarto()
            {
                idFilial = idFilial,
                acomadaEsp = acomodaEsp,
                tipo = tipo,
                maxCap = maxCap,
                valor = valor
            };
            using (var _context = new HotelIdisContext())
            {
                quarto.fkfilialHotel = _context.filiaisHoteis.FirstOrDefault(filialHotel => filialHotel.idFilial == idFilial);
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
        public IActionResult Put(int id, string tipo, bool? acomadaEsp, int? maxCap, float? valor)
        {
            using (var _context = new HotelIdisContext())
            {

                var entityUpdate = _context.Quartos.FirstOrDefault(t => t.idQuarto == id);
                if (entityUpdate != null)
                {
                    if (tipo != null)
                    {
                        entityUpdate.tipo = tipo;
                    }
                    if (acomadaEsp != null)
                    {
                        entityUpdate.acomadaEsp = Convert.ToBoolean(acomadaEsp);
                    }
                    if (maxCap != null)
                    {
                        entityUpdate.maxCap = Convert.ToInt32(maxCap);
                    }
                    if (valor != null)
                    {
                        entityUpdate.valor = valor ?? entityUpdate.valor;
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