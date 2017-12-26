using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class AccountabilityVM
    {
        public IEnumerable<DisplayLog> currentLogs;
        public DateTime requestDate;

    }
}