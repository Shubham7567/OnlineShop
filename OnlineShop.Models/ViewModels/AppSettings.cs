using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ViewModels
{
        public class AppSettings
        {
            public IList<string> AllowedOriginUrls { get; set; }
            public string Secret { get; set; }
            public string EncryptionKey { get; set; }
            public bool EnableSwaggerDoc { get; set; }
            public string FromAccountEmail { get; set; }
            public string FromAccountPassword { get; set; }
            public string SmtpHost { get; set; }
            public string SmtpClientPort { get; set; }
        }
}
