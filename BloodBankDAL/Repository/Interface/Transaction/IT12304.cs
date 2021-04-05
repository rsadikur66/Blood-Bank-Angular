using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12304
    {
        DataTable reqList(string lang,string site,string req);
        DataTable GetReqNoList(string site);
        DataTable Griddatalist(string req);
        DataTable get_Issuedbyname(string lang,string empCode);
        string Insert(string user,List<t12304> t12304,string lang);

        //------------------------------------Report----------------------------
        DataTable GetSite(string siteCode);
        DataTable getR12046_xMatch(string reqno, string site, string lang);
        DataTable getR12046_Issue(string reqno, string site, string lang);

        DataTable RequestNoList(string siteCode);


    }
}
