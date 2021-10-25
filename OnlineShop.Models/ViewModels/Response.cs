using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ViewModels
{
    public class Response
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public bool IsSuccess { get; set; }
    }
}
