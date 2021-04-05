using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Query
{
    public interface IQ12018
    {
        DataTable GetFirstGrid(string unitNo);
        DataTable GetSecondGrid(string unitNo);
    }
}
