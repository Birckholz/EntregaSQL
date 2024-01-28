using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSql
{

    [Route("api/[controller]")]
    [ApiController]
    public class enderecoController : Controller
    {
        [HttpPost("Cliente/{idCliente}/{rua}/{uf}/{cidade}")]
        public IActionResult InserirEnderecoCliente(int idCliente, string cidade, string rua, char uf)
        {
            Endereco endereco = new Endereco()
            {
                idCliente = idCliente,
                cidade = cidade,
                rua = rua,
                UF = uf,
                idFilial = null
            };
            using (var _context = new HotelIdisContext())
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return Ok("Dados Inseridos");
            }
        }
        [HttpPost("Filial/{idFilial}/{rua}/{uf}/{cidade}")]
        public IActionResult InserirEnderecoComercial(int idFilial, string cidade, string rua, char uf)
        {
            Endereco endereco = new Endereco()
            {
                idFilial = idFilial,
                cidade = cidade,
                rua = rua,
                UF = uf,
                idCliente = null
            };
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
        [HttpPut("Update/{id}/{comercial}")]
        public IActionResult Put(int id, bool comercial, string rua, char? UF, string cidade)
        {
            using (var _context = new HotelIdisContext())
            {
                var entityUpdate = (Endereco)null;
                if (comercial)
                {
                    entityUpdate = _context.Enderecos.FirstOrDefault(t => t.idFilial == id);
                }
                else
                {
                    entityUpdate = _context.Enderecos.FirstOrDefault(t => t.idCliente == id);
                }
                if (entityUpdate != null)
                {
                    if (UF != null)
                    {
                        entityUpdate.UF = UF;

                    }
                    if (cidade != null)
                    {
                        entityUpdate.cidade = cidade;

                    }
                    if (rua != null)
                    {
                        entityUpdate.rua = rua;

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