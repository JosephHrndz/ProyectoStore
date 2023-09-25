using Microsoft.AspNetCore.Mvc;
using ProyectoStore.BL;
using ProyectoStore.EN;
using System.Text.Json;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registrar : Controller
    {

        private RegistroBL registroBL = new RegistroBL();

        [HttpGet]
        public async Task<IEnumerable<Registro>> Get()
        {
            return await registroBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Registro> Get(int id)
        {
            Registro registro = new Registro();
            registro.Id = id;
            return await registroBL.ObtenerPorIdAsync(registro);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Registro registro)
        {
            try
            {
                await registroBL.CrearAsync(registro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Registro registro)
        {
            if (registro.Id == id)
            {
                await registroBL.ModificarAsync(registro);
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
                Registro registro = new Registro();
                registro.Id = id;
                await registroBL .EliminarAsync(registro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Registro>> Buscar([FromBody] object pRegistro)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string strRegistro = JsonSerializer.Serialize(pRegistro);
            Registro registro = JsonSerializer.Deserialize<Registro>(strRegistro, option);
            return await registroBL.BuscarAsync(registro);
        }
    }
}
