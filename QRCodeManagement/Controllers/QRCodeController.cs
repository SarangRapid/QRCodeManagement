using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRCodeManagement.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QRCodeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QRCodeController : ControllerBase
    {
        
        private readonly ILogger<QRCodeController> _logger;
        private readonly IQRCodeManageService qRCodeManageService;

        public QRCodeController(ILogger<QRCodeController> logger, IQRCodeManageService _qRCodeManageService)
        {
            _logger = logger;
            this.qRCodeManageService = _qRCodeManageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string filePath = "")
        {
            if(string.IsNullOrEmpty(filePath) || filePath.Contains("%3A%2F%2F"))
            {
                Response.StatusCode = new StatusCodeResult(404).StatusCode;
                return Content("Path is already encoded or incorrect");
            }

            string encodedURL = HttpUtility.UrlEncode(filePath);
            var model = await qRCodeManageService.ReadQRCode(encodedURL);
            
            if(model == null || model.symbol == null)
            {
                Response.StatusCode = new StatusCodeResult(400).StatusCode;
                return Content("Bad Request");
            }

            return new JsonResult(model.symbol?.FirstOrDefault()?.data);
        }
    }
}
