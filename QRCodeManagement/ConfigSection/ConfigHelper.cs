using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeManagement.ConfigSection
{
    public class ConfigHelper
    {
        private static IConfiguration configuration;

        public static void Configure(IConfiguration config)
        {
            configuration = config;
        }

        public static string WebApiUrl
        {
            get
            {
                return configuration["custom:webApiUrl"];
            }
        }

    }
}
