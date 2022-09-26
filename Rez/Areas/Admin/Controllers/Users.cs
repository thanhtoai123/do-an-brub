using Microsoft.AspNetCore.Mvc;

namespace Rez.Areas.Admin.Controllers;

[Area("Admin")]
public class UsersController : Controller
{
    public async Task<IActionResult> TatCa()
    {
        return View();
    }
}