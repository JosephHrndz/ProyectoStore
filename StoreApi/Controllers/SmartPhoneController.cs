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
    public class SmartPhoneController : Controller
    {
        private SmartPhoneBL smartPhoneBL = new SmartPhoneBL();

        [HttpGet]
        public async Task<IEnumerable<SmartPhone>> Get()
        {
            return await smartPhoneBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<SmartPhone> Get(int id)
        {
            SmartPhone smartPhones = new SmartPhone();
            smartPhones.Id = id;
            return await smartPhoneBL.ObtenerPorIdAsync(smartPhones);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SmartPhone smartPhones)
        {
            try
            {
                await smartPhoneBL.CrearAsync(smartPhones);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SmartPhone smartPhones)
        {
            if (smartPhones.Id == id)
            {
                await smartPhoneBL.ModificarAsync(smartPhones);
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
                SmartPhone smartPhones = new SmartPhone();
                smartPhones.Id = id;
                await smartPhoneBL.EliminarAsync(smartPhones);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<SmartPhone>> Buscar([FromBody] object pSmartPhones)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string strSmartPhones = JsonSerializer.Serialize(pSmartPhones);
            SmartPhone smartPhones = JsonSerializer.Deserialize<SmartPhone>(strSmartPhones, option);
            return await smartPhoneBL.BuscarAsync(smartPhones);
        }
    }
}


