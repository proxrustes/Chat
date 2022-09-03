using Chat_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Chat_FrontEnd.APIControllers;
using Chat_FrontEnd.ObjectModel;

namespace Chat_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ChatApiService chatController = new ChatApiService();
        private UserApiService userController = new UserApiService();
        private MessageApiService messageController = new MessageApiService();
        private UserModel currentuser;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{username}")]
        public IActionResult Main(string username)
        {
            List<UserModel> users = userController.GetAll();
            UserModel currentUser = users.Where(x => x.userName == username).FirstOrDefault();

            return View(currentUser);
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