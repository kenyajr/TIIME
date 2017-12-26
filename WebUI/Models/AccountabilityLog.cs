using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class AccountabilityLog
    {
        public bool completed { get; set; }
        public String Activity { get; set; }
        public String Goal { get; set; }
        public int timeactive { get; set; }
        public bool weekend { get; set; }
        public String effeciency { get; set; }
    }
}