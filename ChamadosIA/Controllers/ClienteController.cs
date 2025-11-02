using Microsoft.AspNetCore.Mvc;

namespace ChamadosIA.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}