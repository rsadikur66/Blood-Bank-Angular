using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12245
    {
        DataTable GetCentrifugeList(string lang);
        DataTable GetProgramList(string lang);
        DataTable GetGridDataList(string UnitNo, string donationDate, string segmentNo);
        DataTable GetSegment(string UnitNo);

        DataTable CheckUnitNo(string UnitNo);
        DataTable SecondGetGridDataList(string UnitNo, string user);
        DataTable GetMessagesList();
        //DataTable GetGridDataList();
        string Insert(string user,t12135 T12135);

        bool UpdateT12135(string UnitNo);
        string DeleteRowData(string T_UNIT_NO, string T_PRODUCT_CODE);
    }
}
