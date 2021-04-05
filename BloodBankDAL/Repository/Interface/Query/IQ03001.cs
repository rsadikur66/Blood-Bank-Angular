using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Query
{
   public interface IQ03001
    {
        DataTable GridData(int pageIndex, int pageSize,string lang);
        DataTable GetPatientData_Search_Count(string searchValue, int pageIndex, int pageSize, string lang);
        DataTable GetPatientInfo_Search(string searchValue, int pageIndex, int pageSize, string lang);
    }
}
