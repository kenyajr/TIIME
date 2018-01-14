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

        public List<AccountabilityUnit> DailyA { get; internal set; }
        public List<LogUnit> DailyL { get; internal set; }
    }
}