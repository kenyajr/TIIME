using Domain.Abstract;
using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountabilityController : Controller
    {
        private IAccountabilityRepository _repository;
        TIIMEEntitiesContext db = new TIIMEEntitiesContext();

        public AccountabilityController(IAccountabilityRepository repo)
        {
            this._repository = repo;

        }

        public ActionResult Index()
        {

            AccountabilityVM vm = new AccountabilityVM();
            vm.requestDate = DateTime.Now.Date;
            TempData["RequestedDate"] = DateTime.Now.Date;

            vm.currentLogs = (from t in _repository.TransLogs
                              join d in _repository.DateTable
                              on t.transactionDate equals d.Date
                              join c in _repository.Categories
                              on t.categoryID equals c.categoryId
                              join l in _repository.Logs
                              on t.logId equals l.logID
                              where t.transactionDate == vm.requestDate
                              select new DisplayLog() { transactionDate = d.Date, logName = l.logName, categoryName = c.categoryName, logsId = t.logsId, description = t.description }).ToList();
            ShowAllRequestedLogs();




            return View(vm);


        }

        [HttpPost]
        public ActionResult Index(DateTime requestDate)
        {
            TempData["RequestedDate"] = requestDate;
            AccountabilityVM vm = new AccountabilityVM();
            vm.requestDate = requestDate;

            ShowAllRequestedLogs();
            return View(vm);
        }



        public ActionResult ShowAllRequestedLogs()
        {
            //DateTime d = Convert.ToDateTime(TempData["RequestedDate"]);
            //String d = TempData["RequestedDate"].ToString();
            DateTime rd = DateTime.Now.Date;

            IEnumerable<DisplayLog> currentLogs = (from t in _repository.TransLogs
                                                   join d in _repository.DateTable
                                                   on t.transactionDate equals d.Date
                                                   join c in _repository.Categories
                                                   on t.categoryID equals c.categoryId
                                                   join l in _repository.Logs
                                                   on t.logId equals l.logID
                                                   where t.transactionDate == (DateTime)TempData["RequestedDate"]
                                                   select new DisplayLog() { transactionDate = d.Date, logName = l.logName, categoryName = c.categoryName, logsId = t.logsId, description = t.description }).ToList();

            return View(currentLogs);



        }
        public ActionResult AddorEditTransactionLog(int logsid = 0)
        {
            EditTransLogVM vm = new EditTransLogVM();
            TransactionLog t = new TransactionLog();

            ViewData["LogNames"] = new SelectList(GetAllLogNames());
            ViewData["CategoryNames"] = new SelectList(GetAllCateogryNames());
            if (logsid != 0)
            {
                t = GetTransLogById(logsid);
                vm.selectedCategory = t.Category.categoryName;
                vm.selectedLog = t.Log.logName;
            }

            if (logsid == 0)
            {
                t.transactionDate = DateTime.Now.Date;
            }


            vm.TransLog = t;



            return View(vm);
        }
        [HttpPost]
        public ActionResult AddorEditTransactionLog(EditTransLogVM vm, int logsid = 0)
        {



            if (logsid == 0)
            {
                TransactionLog t = new TransactionLog();
                t.categoryID = GetCategoryID(vm.selectedCategory);
                t.logId = GetLogID(vm.selectedLog);
                t.transactionDate = vm.TransLog.transactionDate;
                t.description = vm.TransLog.description;

                db.TransactionLogs.Add(t);

            }

            else
            {
                TransactionLog editedvm = db.TransactionLogs.Find(logsid);

                //TransactionLog editedvm = _repository.TransLogs.Where(e => e.logsId == logsid).Select(e => e).FirstOrDefault();
                editedvm.categoryID = GetCategoryID(vm.selectedCategory);
                editedvm.logId = GetLogID(vm.selectedLog);
                editedvm.transactionDate = vm.TransLog.transactionDate;
                editedvm.description = vm.TransLog.description;


                //db.TransactionLogs.
                db.Entry(editedvm).State = EntityState.Modified;

            }

            db.SaveChanges();

            //db.Entry(transactionLog).State = EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("Index");


        }

        private IEnumerable<String> GetAllLogNames()
        {
            return _repository.Logs.Select(e => e.logName);
        }

        private int GetLogID(String logname)
        {

            //return match;


            return _repository.Logs.Where(e => e.logName.Trim() == logname).Select(e => e.logID).FirstOrDefault();


        }
        private IEnumerable<String> GetAllCateogryNames()
        {
            return _repository.Categories.Select(e => e.categoryName);
        }

        private int GetCategoryID(String categoryName)
        {
            return _repository.Categories
                .Where(e => e.categoryName.Trim() == categoryName)
                .Select(e => e.categoryId).FirstOrDefault();


        }

        private TransactionLog GetTransLogById(int i)
        {
            TransactionLog t = new TransactionLog();
            t = _repository.TransLogs.Where(e => e.logsId == i).Select(e => e).FirstOrDefault();
            return (t);
        }

        public ActionResult Create()
        {

            return View();

        }

        public ActionResult ShowNumberOfDaysSinceLastCoincidence()
        {
            DateTime d = _repository.TransLogs.Where(e => e.Log.logName.Contains("Coincidence")).OrderByDescending(e => e.transactionDate).Select(e => e.transactionDate).First();
            int statisicsConincidence = Convert.ToInt32((DateTime.Now - d).TotalDays);


            return Content(statisicsConincidence.ToString());
        }

        public ActionResult ShowNumberOfDaysSinceLastCC()
        {
            DateTime d = _repository.TransLogs.Where(e => e.Log.logName.Contains("Penalty-CC")).OrderByDescending(e => e.transactionDate).Select(e => e.transactionDate).First();
            int statisic = Convert.ToInt32((DateTime.Now - d).TotalDays);


            return Content(statisic.ToString());
        }

        public ActionResult ShowNumberOfDaysSinceLastCCM()
        {
            DateTime d = _repository.TransLogs.Where(e => e.Log.logName.Contains("Penalty-CCM")).OrderByDescending(e => e.transactionDate).Select(e => e.transactionDate).First();
            int statisic = Convert.ToInt32((DateTime.Now - d).TotalDays);


            return Content(statisic.ToString());
        }
        public ActionResult ShowNumberOfDaysSinceLastCCC()
        {
            DateTime d = _repository.TransLogs.Where(e => e.Log.logName.Contains("Penalty-CCC")).OrderByDescending(e => e.transactionDate).Select(e => e.transactionDate).First();
            int statisic = Convert.ToInt32((DateTime.Now - d).TotalDays);


            return Content(statisic.ToString());
        }

        public ActionResult ShowNumberOfDaysSinceLastBicycle()
        {
            DateTime d = _repository.TransLogs.Where(e => e.Log.logName.Contains("Bicycle")).OrderByDescending(e => e.transactionDate).Select(e => e.transactionDate).First();
            int statisic = Convert.ToInt32((DateTime.Now - d).TotalDays);


            return Content(statisic.ToString());
        }

        public ActionResult ShowNumberOfDaysSinceLastSpt()
        {
            DateTime d = _repository.TransLogs.Where(e => e.Log.logName.Contains("SPT")).OrderByDescending(e => e.transactionDate).Select(e => e.transactionDate).First();
            int statisic = Convert.ToInt32((DateTime.Now - d).TotalDays);


            return Content(statisic.ToString());
        }

        public ActionResult GetTemplateData()
        {
            DailyTemplateVM vm = new DailyTemplateVM();
            vm.DailyActivities = new List<AccountabilityLog>
                {
                new AccountabilityLog { completed = false, Activity = "Jog", Goal="Health",timeactive=20,weekend=false  },
                new AccountabilityLog { completed = false, Activity = "Jog", Goal="Health",timeactive=20,weekend=false},
                new AccountabilityLog { completed = false, Activity = "Work", Goal="Finance",timeactive=480,weekend=false},
                new AccountabilityLog { completed = false, Activity = "TIIME", Goal="Software",timeactive=120,weekend=false},
                new AccountabilityLog { completed = false, Activity = "RSolutions", Goal="Software",timeactive=180,weekend=false},
                new AccountabilityLog { completed = false, Activity = "Crosswords", Goal="Software",timeactive=180,weekend=false};



            return View(vm);

            }
            





            

        }
    }
}