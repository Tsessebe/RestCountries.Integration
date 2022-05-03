﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestCountries.Integration.Contracts;
using SampleWeb.Models;

namespace SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestCountriesService countriesService;
        public HomeController(IRestCountriesService countriesService)
        {
            this.countriesService = countriesService;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await countriesService.GetAllAsync();
            var model = new HomeViewModel
            {
                Countries = countries.ToList(),
            };

            return View(model);
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
