using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebChuKy.Models;

namespace WebChuKy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id = null)
        {
            Signature signature = new Signature()
            {
                SignatureID = id,
            };
            return View(signature);
        }

        public JsonResult SendSignature(Signature signature)
        {
            string message = String.Empty;
            string title = String.Empty;
            string result = String.Empty;
            try
            {
                result = "OK";
                if (result == "OK")
                {
                    message = $"Đã ký thành công";
                    title = "Thành công!";
                    result = "success";
                }
                else
                {
                    message = result;
                    title = "Lỗi!";
                    result = "error";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
