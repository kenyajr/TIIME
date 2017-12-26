using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFAccountabilityRepository : IAccountabilityRepository
    {
        private TIIMEEntitiesContext _context = new TIIMEEntitiesContext();

        public IEnumerable<TransactionLog> TransLogs
        {
            get { return _context.TransactionLogs; }
        }

        public IEnumerable<Log> Logs
        {
            get { return _context.Logs; }
        }

        public IEnumerable<Category> Categories
        {
            get { return _context.Categories; }
        }

        public IEnumerable<CatetoryType> CatetoryTypes
        {
            get { return _context.CatetoryTypes; }
        }
        public IEnumerable<DateDimension> DateTable
        {
            get { return _context.DateDimensions; }
        }

       
    }
}
