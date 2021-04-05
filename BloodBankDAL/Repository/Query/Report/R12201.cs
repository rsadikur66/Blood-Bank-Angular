using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Report
{
    public class R12201:CommonDAL
    {
        public string GetArabicName(string patNo)
        {
            return Query($"SELECT T_FIRST_LANG1_NAME||' '||T_FATHER_LANG1_NAME||' '|| T_GFATHER_LANG1_NAME||' '|| T_MOTHER_LANG1_NAME|| ' '|| T_FAMILY_LANG1_NAME T_PAT_NAME FROM T03001 WHERE t_pat_no ='{patNo}'").Rows[0][0].ToString();
        }
    }
}