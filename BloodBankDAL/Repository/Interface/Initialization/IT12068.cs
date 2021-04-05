using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Interface.Initialization
{
   public interface IT12068
   {
       DataTable GetAllGender(string language);

       DataTable GetQstHeadData(string language);

       DataTable GetFailData();

       DataTable GetGridData(int PageIndex, int PageSize);

       DataTable GetGridData_Search(string searchValue, int PageIndex, int PageSize);

       DataTable GetGridData_Count(string searchValue, int PageIndex, int PageSize);

       DataTable GetGridData_Search_Count(string searchValue, int PageIndex, int PageSize);

       string InsertT12068(t12068 t12068);

       string UpdateT12068(t12068 t12068);

       string DeleteT12068(t12068 t12068);

       string InsertT12069(t12068 t12069);
   }
}
