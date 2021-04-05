using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
  public interface IT12003
    {
        DataTable GetHospitalListData();
        DataTable GetProductWithUnitNo(string unitNo);
        DataTable GetProductListData(string unitNo);
    }
}
