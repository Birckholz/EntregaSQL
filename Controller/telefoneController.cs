using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class telefoneController : Controller
    {
        [HttpPost("Cliente/{idCliente}/{telefone}")]
        public IActionResult InserirTelefoneCliente(int idCliente, char telefone)
        {
            Telefone telefone1 = new Telefone()
            {
                idCliente = idCliente,
                idFilial = null,
                telefone = telefone
            };
            using (var _context = new HotelIdisContext())
            {
                telefone1.clienteT = _context.Clientes.FirstOrDefault(Cliente => Cliente.idCliente == idCliente);
                _context.Telefones.Add(telefone1);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpPost("Filial/{idFilial}/{telefone}")]
        public IActionResult InserirTelefoneComercial(int idFilial, char telefone)
        {
            Telefone telefone1 = new Telefone()
            {
                idFilial = idFilial,
                telefone = telefone,
                idCliente = null
            };
            using (var _context = new HotelIdisContext())
            {
                telefone1.fkFilialHotel = _context.filiaisHoteis.FirstOrDefault(filialHotel => filialHotel.idFilial == idFilial);
                _context.Telefones.Add(telefone1);
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
        [HttpPut("Update/{id}/{comercial}")]
        public IActionResult Put(int id, bool comercial, char? telefone)
        {
            using (var _context = new HotelIdisContext())
            {
                var entityUpdate = (Telefone)null;
                if (comercial)
                {
                    entityUpdate = _context.Telefones.FirstOrDefault(t => t.idFilial == id);
                }
                else
                {
                    entityUpdate = _context.Telefones.FirstOrDefault(t => t.idCliente == id);
                }
                if (entityUpdate != null)
                {
                    if (telefone != null)
                    {
                        entityUpdate.telefone = telefone;

                    }

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