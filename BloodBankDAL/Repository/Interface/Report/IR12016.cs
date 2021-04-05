using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
    public interface IR12016
    {
        DataTable getUnit(string T_SITE_CODE);
        DataTable getPRCode(string l, string from, string to);
        DataTable getReport(string l, string from, string to, string prod);
    }
}
