using chatServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace chatServer.Controllers;

public class RatingController : Controller
{
    // GET
    public IActionResult Index()
    {
        List<Rating> ratings = null;//service.GetAllRatings();
        return View(ratings);
    }
}