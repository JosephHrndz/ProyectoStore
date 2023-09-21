using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

//sssssssssssssssssssssssssssssssssssssss

using ProyectoStore.BL;
using ProyectoStore.EN;
using System.Globalization;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprarController : Controller
    {
        private ComprarBL comprarBL = new ComprarBL();

        [HttpGet]
        public async Task<IEnumerable<Comprar>> Get()
        {
            return await comprarBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Comprar> Get(int id)
        {
            Comprar comprar = new Comprar();
            comprar.Id = id;
            return await comprarBL.ObtenerPorIdAsync(comprar);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Comprar comprar)
        {
            try
            {
                await comprarBL.CrearAsync(comprar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Comprar comprar)
        {
            if (comprar.Id == id)
            {
                await comprarBL.ModificarAsync(comprar);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Comprar comprar = new Comprar();
                comprar.Id = id;
                await comprarBL.EliminarAsync(comprar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Comprar>> Buscar([FromBody] object pComprar)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string strComprar = JsonSerializer.Serialize(pComprar);
            Comprar comprar = JsonSerializer.Deserialize<Comprar>(strComprar, option);
            return await comprarBL.BuscarAsync(comprar);
        }
    }
}
