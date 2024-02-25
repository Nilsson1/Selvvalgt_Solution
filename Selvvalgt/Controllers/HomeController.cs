using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Selvvalgt.Models;
using System.Diagnostics;

namespace Selvvalgt.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersRepository _userRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UsersRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetUsers();
            UsersModel usersModel = new UsersModel();
            usersModel.users = users;
            _logger.LogError(usersModel.users[0].Username.ToString());
            return View(usersModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
