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
    public class TabletsController : Controller
    {
        private TabletsBL tabletsBL = new TabletsBL();

        [HttpGet]
        public async Task<IEnumerable<Tablets>> Get()
        {
            return await tabletsBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Tablets> Get(int id)
        {
            Tablets tablets = new Tablets();
            tablets.Id = id;
            return await tabletsBL.ObtenerPorIdAsync(tablets);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tablets tablets)
        {
            try
            {
                await tabletsBL.CrearAsync(tablets);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tablets tablets)
        {
            if (tablets.Id == id)
            {
                await tabletsBL.ModificarAsync(tablets);
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
                Tablets tablets = new Tablets();
                tablets.Id = id;
                await tabletsBL.EliminarAsync(tablets);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Tablets>> Buscar([FromBody] object pTablets)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string strTablets = JsonSerializer.Serialize(pTablets);
            Tablets tablets = JsonSerializer.Deserialize<Tablets>(strTablets, option);
            return await tabletsBL.BuscarAsync(tablets);
        }
    }
}

