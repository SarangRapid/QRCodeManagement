using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeManagement.Service.Interface
{
    public interface IQRCodeManageService
    {
        /// <summary>
        /// Reads QR Code and returns the content in JSON format
        /// </summary>
        /// <param name="path">path of QR Code with HTTPS</param>
        /// <returns>content of QR code</returns>
        public Task<Root> ReadQRCode(string path);
    }
}
