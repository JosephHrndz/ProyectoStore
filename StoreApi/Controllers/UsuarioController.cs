using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
