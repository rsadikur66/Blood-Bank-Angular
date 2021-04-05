using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Query
{
    public interface IQ12200
    {
        DataTable GetGridData(string dateParam);
        DataTable GetReportInfo();
        DataTable GetReportData();
    }
}
