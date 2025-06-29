using Microsoft.AspNetCore.Mvc;

namespace RiskTrackSCF_UserCreatorAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
