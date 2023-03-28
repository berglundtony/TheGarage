using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheGarage.Web.Clients;
using TheGarage.Web.Models;

namespace TheGarage.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarHttpClient _httpClient;
        private readonly CarGraphClient _carGraphClient;

        public HomeController(CarGraphClient carGraphClient, CarHttpClient carHttpClient,ILogger<HomeController> logger)
        {
            _logger = logger;
            _carGraphClient = carGraphClient;
            _httpClient = carHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseModel = await _httpClient.GetCars();
            responseModel.ThrewErrors();
            List<CarModel> model = new List<CarModel>();
            model =  responseModel.Data.Cars;

            return View(model);
        }

        public async Task<IActionResult> CarDetail(string registryNumber)
        {
            var car= await _carGraphClient.GetCar(registryNumber);
            return View(car);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarModel carModel)
        {
            await _carGraphClient.AddCar(carModel);
            var car = await _carGraphClient.GetCar(carModel.RegistryNumber);
            return View("CarDetail", car);
        }

        public async Task<IActionResult> UpdateCar(string registryNumber)
        {
            var car = await _carGraphClient.GetCar(registryNumber);
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(CarModel carModel)
        {
            await _carGraphClient.UpdateCar(carModel);
            var car = await _carGraphClient.GetCar(carModel.RegistryNumber);

            return View("CarDetail", car);
        }

        public async Task<IActionResult> DeleteCar(string registryNumber)
        {
            var car = await _carGraphClient.GetCar(registryNumber);
            return View(car);
        }

        [HttpPost, ActionName("DeleteCar")]
        public async Task<IActionResult> DeleteCarConfirmed(string registryNumber)
        {
            await _carGraphClient.DeleteCar(registryNumber);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}