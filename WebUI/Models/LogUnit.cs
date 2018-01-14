using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class LogUnit
    {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public int Complete { get; set; }
        public string Comment { get; set; }
    }
}