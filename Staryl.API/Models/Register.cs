using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.API.Models
{
    public class Register
    {
        public int UserType { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string MobileYzm { get; set; }
    }
}