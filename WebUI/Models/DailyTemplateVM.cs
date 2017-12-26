using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DailyTemplateVM
    {
        public bool teeth { get; set; }
        public bool shwr { get; set; }
        public bool wshdryClothes { get; set; }
        public bool weekend { get; set; }
        public bool water5 { get; set; }
        public bool water6 { get; set; }
        public bool water8 { get; set; }
        public bool water17 { get; set; }
        public bool water18 { get; set; }
        public bool pnemon { get; set; }
        public String pnemoncomment { get; set; }
        public bool ccc { get; set; }
        public bool ccm { get; set; }
        public bool penff { get; set; }



        public List<AccountabilityLog> DailyActivities { get; set; }


    }
}