using Lemonstacks.Websites.Models;
using Lemonstacks.Websites.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lemonstacks.Websites.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected IWebHostEnvironment _hostingEnvironment;
        protected IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.Msg = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(DataModels quotation)
        {
            string personId = quotation.FullName;

            string webRootPath = _hostingEnvironment.WebRootPath;
            string webpath = Path.Combine(webRootPath, "Report","Quotation.txt");
            using (StreamWriter writer = new StreamWriter(webpath,true,System.Text.Encoding.UTF8))
            {
                writer.WriteLine(String.Format("{0} : {1} | {2} | {3} | {4} | {5} | {6}",DateTime.Now,quotation.FullName,quotation.MobilePhone,
                    quotation.Email,quotation.Company,quotation.Detail,quotation.Service));
            }
            ViewBag.Msg= "Success";
            ModelState.Clear();
            return View();
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