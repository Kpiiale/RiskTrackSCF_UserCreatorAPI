using Microsoft.AspNetCore.Mvc;

namespace RiskTrackSCF_UserCreatorAPI.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
