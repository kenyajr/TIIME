using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IAccountabilityRepository
    {
        /* This repository will be implemented by an EF datasource and a SQL data source
        It will provide the controller with TransactionLogs, AccountabilityHours
        */

        IEnumerable<TransactionLog> TransLogs { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<CatetoryType> CatetoryTypes { get; }
        IEnumerable<Log> Logs { get; }
        IEnumerable<DateDimension> DateTable {get;}
        

    }
}
