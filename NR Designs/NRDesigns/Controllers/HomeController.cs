using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NRDesigns.Models;

namespace NRDesigns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        // -------------------------------
        // POST: Handle Contact Form
        // -------------------------------
        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactForm form)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            await SendEmail(form);

            TempData["Success"] = "Your message has been sent successfully!";
            return RedirectToAction("Index");
        }

        // -------------------------------
        // Brevo Email Sending Logic
        // -------------------------------
        private async Task SendEmail(ContactForm form)
        {
            var apiKey = _config["Brevo:ApiKey"];
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api-key", apiKey);

            var emailBody = new
            {
                sender = new { email = "ishkar.singh.108@gmail.com", name = "NR Designs Contact Form" },
                to = new[] { new { email = "ishkar.singh.108@gmail.com", name = "Website Owner" } },
                replyTo = new { email = form.Email, name = form.Name },
                subject = "New Contact Form Submission",
                htmlContent = $@"
                    <h2>New Contact Form Submission</h2>
                    <p><strong>Name:</strong> {form.Name}</p>
                    <p><strong>Email:</strong> {form.Email}</p>
                    <p><strong>Phone:</strong> {form.Phone}</p>
                    <p><strong>Message:</strong><br>{form.Message}</p>"
            };


            string json = JsonConvert.SerializeObject(emailBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("https://api.brevo.com/v3/smtp/email", content);
        }

        // --------------------------------
        // Error handling (unchanged)
        // --------------------------------
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
