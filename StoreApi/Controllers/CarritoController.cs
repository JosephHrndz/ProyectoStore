using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using ProyectoStore.BL;
using ProyectoStore.EN;
using System.Text.Json;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : Controller
    {
        private CarritoBL carritoBL = new CarritoBL();

        [HttpGet]
        public async Task<IEnumerable<Carrito>> Get()
        {
            return await carritoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Carrito> Get(int id)
        {
            Carrito carrito = new Carrito();
            carrito.Id = id;
            return await carritoBL.ObtenerPorIdAsync(carrito);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Carrito carrito)
        {
            try
            {
                await carritoBL.CrearAsync(carrito);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Carrito carrito)
        {
            if (carrito.Id == id)
            {
                await carritoBL.ModificarAsync(carrito);
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
                Carrito carrito = new Carrito();
                carrito.Id = id;
                await carritoBL.EliminarAsync(carrito);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Carrito>> Buscar([FromBody] object pCarrito)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string strCarrito = JsonSerializer.Serialize(pCarrito);
            Carrito carrito = JsonSerializer.Deserialize<Carrito>(strCarrito, option);
            return await carritoBL.BuscarAsync(carrito);
        }
    }
}
