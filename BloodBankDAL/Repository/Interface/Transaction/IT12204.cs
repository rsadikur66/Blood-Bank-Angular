using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12204
    {
        DataTable GatCompStatusData(string lang, string d);
        DataTable GetBedUsedData(string lang, string id);
        DataTable GetPatDetails(string lang,string siteCode, string patNo,string patId);
        DataTable GetReson_AcStatus(string lang, int bagWet);
        DataTable GetBed(string lang);
        DataTable GetDiscurtReason(string lang);
        DataTable GetbodyMermt(string pat, string epst);
        DataTable GetQuestion(string pat, string epst);
        DataTable GetImages(string pat, string epst);
        DataTable getUnit_SegmNo();
        DataTable Getpin( string emNo);
        string SaveData(CommonModel t12022);
        DataTable GetMaxBidStoreId();
        DataTable GetComment(int phel, string lang);
        string Update(CommonModel t12022);
        DataTable GetComntT12328(string lang, int ple);
        DataTable showDataFromT12022(string lang, string patNo, string epsort);
    }
}