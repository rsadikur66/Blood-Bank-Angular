using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Model
{
    public class t12220
    {
        public DateTime T_ENTRY_DATE { get; set; }
        public string T_ENTRY_USER { get; set; }
        public DateTime T_UPD_DATE { get; set; }
        public string T_UPD_USER { get; set; }
        public string T_UNIT_NO { get; set; }
        public string T_BLOOD_GROUP { get; set; }
        public string T_ANTIBODY { get; set; }
        public string T_ANTIBODY_1 { get; set; }
        public string T_DU { get; set; }
        public string RH_KELL { get; set; }
        public string RH_PHENO { get; set; }
        public string T_EMP_CODE { get; set; }
        public string T_USER_NAME { get; set; }
        public string T_OLG_BLOOD_GROUP { get; set; }

        //for update
        public string T_VERIFY { get; set; }
        public string T_VERIFIED_BY { get; set; }
        public string T_NOTES { get; set; }
        public string ABO { get; set; }
        public int isInsert { get; set; }
    }
}