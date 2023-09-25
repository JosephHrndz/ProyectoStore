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
    public class LaptonsController : Controller
    {
        private LaptopsBL laptonsBL = new LaptopsBL();

        [HttpGet]
        public async Task<IEnumerable<Laptops>> Get()
        {
            return await laptonsBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Laptops> Get(int id)
        {
            Laptops laptons = new Laptops();
            laptons.Id = id;
            return await laptonsBL.ObtenerPorIdAsync(laptons);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Laptops laptons)
        {
            try
            {
                await laptonsBL.CrearAsync(laptons);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Laptops laptons)
        {
            if (laptons.Id == id)
            {
                await laptonsBL.ModificarAsync(laptons);
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
                Laptops laptons = new Laptops();
                laptons.Id = id;
                await laptonsBL.EliminarAsync(laptons);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Laptops>> Buscar([FromBody] object pLaptons)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string strLaptons = JsonSerializer.Serialize(pLaptons);
            Laptops laptons = JsonSerializer.Deserialize<Laptops>(strLaptons, option);
            return await laptonsBL.BuscarAsync(laptons);
        }
    }
}

