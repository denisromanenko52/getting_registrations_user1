using getting_registrations_user1.Models;
using getting_registrations_user1.Models.DAL;
using getting_registrations_user1.Models.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace getting_registrations_user1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataService _dataService;
        private readonly RabbitMQService _rabbitMQService;

        public HomeController(DataService dataService, RabbitMQService rabbitMQService)
        {
            _dataService = dataService;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<IActionResult> Index()
        {
            _rabbitMQService.ReceiveMessage("registration_queue", message =>
            {
                Console.WriteLine($"Полученное сообщение: {message}");
            });

            var users = await _dataService.GetRegistrationsUsers();

            return View(users);
        }
    }
}