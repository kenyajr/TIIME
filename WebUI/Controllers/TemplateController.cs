using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowWeekdayTemplate()
        {
            TIIMETemplate weekday = new TIIMETemplate();
            

            AccountabilityVM vm = new AccountabilityVM();

            weekday.current = vm;



            List<AccountabilityUnit> dailyAccountability = new List<AccountabilityUnit>()
          {  new AccountabilityUnit { Number=1, Goal = "General", Activity = "WRP-TTH,WSHCLS,DSH,GRT,As",Time = 20 },
             new AccountabilityUnit { Number=4, Goal="Work", Activity="Work", Time=120},
             new AccountabilityUnit { Number=2, Goal="Software", Activity="EfficientCoding", Time=60 },
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Special Project-Facial Recognition", Time=40},
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Cheatsheets-JQuery", Time=40},
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Cheatsheets-Javascript", Time=40},
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Cheatsheets-CSS", Time=40},
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Cheatsheets-HTML", Time=40},
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Cheatsheets-Debug", Time=40},
             new AccountabilityUnit { Number=1,Goal="Software", Activity="Special Project-CemeteryWeb", Time=40},
             new AccountabilityUnit { Number=1,Goal="Travel", Activity="Car-Library of Congress", Time=40},
             new AccountabilityUnit { Number=2,Goal="Health", Activity="Jog", Time=20},
             new AccountabilityUnit { Number=1,Goal="AppsWitSoul", Activity="Special Project-Crosswords", Time=15},
             new AccountabilityUnit { Number=1,Goal="AppsWithSoul", Activity="Special Project-Woke", Time=15},
             new AccountabilityUnit { Number=1,Goal="RSolutions", Activity="Special Project-TIIME", Time=20},
             new AccountabilityUnit { Number=1,Goal="RSolutions", Activity="Special Project-Rsolutions Web", Time=20},
             new AccountabilityUnit { Number=1,Goal="StreborFarms", Activity="Knit", Time=40},
             new AccountabilityUnit { Number=1,Goal="Home", Activity="Storage", Time=10}
          };

            List<LogUnit> dailyLogs = new List<LogUnit>()
          {
              new LogUnit {Name="Penalty-Water1",Pattern="Pattern-R", Complete=0, Comment=""},
              new LogUnit {Name="Penalty-Water2",Pattern="Pattern-I",Complete=0,Comment=""},
              new LogUnit {Name="Penalty-Water3",Pattern="Pattern-S",Complete=0,Comment=""},
              new LogUnit {Name="Penalty-Water4",Pattern="Pattern-I",Complete=0,Comment=""},
              new LogUnit {Name="COINCIDENCE",Pattern="Pattern-R",Complete=0,Comment=""},
              new LogUnit {Name="Bowling",Pattern="Pattern",Complete=0,Comment=""},
              new LogUnit {Name="Penalty-FF",Pattern="Pattern-S",Complete=0,Comment=""},
              new LogUnit {Name="Penalty-FB",Pattern="Pattern-S",Complete=0,Comment=""},
              new LogUnit {Name="Penalty-TV",Pattern="Pattern-S",Complete=0,Comment=""},
              new LogUnit {Name="BodyEcologyWDrkCh",Pattern="Pattern",Complete=0,Comment=""},
             new LogUnit {Name="Penalty-CCC",Pattern="Pattern-S",Complete=0,Comment=""},
             new LogUnit {Name="Penalty-CCM",Pattern="Pattern-S",Complete=0,Comment=""},
             new LogUnit {Name="Supp-Syn",Pattern="Pattern",Complete=0,Comment=""},
             new LogUnit {Name="Supp-C",Pattern="Pattern",Complete=0,Comment=""},
             new LogUnit {Name="Supp-Multi",Pattern="Pattern",Complete=0,Comment=""}
          };


          vm.DailyA = dailyAccountability;
          vm.DailyL = dailyLogs;




            return View(weekday);



        }













        }
    }
