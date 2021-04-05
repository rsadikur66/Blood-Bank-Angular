using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
    public interface RI12204
    {
        DataTable GetReport(string pat, string ept);
    }
}
