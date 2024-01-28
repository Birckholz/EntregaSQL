using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class filialHotelController : Controller
    {
        [HttpPost("{nome}")]
        public IActionResult Post(string nome, int? numQuartosCasal, int? numQuartoSolteiro, int? numQuartosFamilia, int? numQuartosPresidencial)
        {
            int numQuartosCasalT = 0, numQuartosFamiliaT = 0, numQuartoSolteiroT = 0, numQuartosPresidencialT = 0;
            if (numQuartosCasal != null)
            {
                numQuartosCasalT = Convert.ToInt32(numQuartosCasal);
            }
            if (numQuartosFamilia != null)
            {
                numQuartosFamiliaT = Convert.ToInt32(numQuartosFamilia);
            }
            if (numQuartoSolteiro != null)
            {
                numQuartoSolteiroT = Convert.ToInt32(numQuartoSolteiro);
            }
            if (numQuartosPresidencial != null)
            {
                numQuartosPresidencialT = Convert.ToInt32(numQuartosPresidencial);
            }
            filialHotel filialHotel = new filialHotel()
            {
                nome = nome,
                numQuartosCasal = numQuartosCasalT,
                numQuartosFamilia = numQuartosFamiliaT,
                numQuartosPresidencial = numQuartosPresidencialT,
                numQuartosSolteiro = numQuartoSolteiroT


            };
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
        public IActionResult Put(int id, string nome, int? numQuartosCasal, int? numQuartosFamilia, int? numQuartoSolteiro, int? numQuartosPresidencial)
        {
            using (var _context = new HotelIdisContext())
            {
                var entityUpdate = _context.filiaisHoteis.FirstOrDefault(t => t.idFilial == id);
                if (entityUpdate != null)
                {
                    if (nome != null)
                    {
                        entityUpdate.nome = nome;
                    }
                    if (numQuartosCasal != null)
                    {
                        entityUpdate.numQuartosCasal = Convert.ToInt32(numQuartosCasal);
                    }
                    if (numQuartosFamilia != null)
                    {
                        entityUpdate.numQuartosFamilia = Convert.ToInt32(numQuartosFamilia);
                    }
                    if (numQuartoSolteiro != null)
                    {
                        entityUpdate.numQuartosSolteiro = Convert.ToInt32(numQuartoSolteiro);
                    }
                    if (numQuartosPresidencial != null)
                    {
                        entityUpdate.numQuartosPresidencial = Convert.ToInt32(numQuartosPresidencial);
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