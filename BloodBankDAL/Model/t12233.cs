using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace BloodBankDAL.Model
{
    public class t12233
    {
        //Common Field
        public DateTime T_ENTRY_DATE { get; set; }
        public string T_ENTRY_USER { get; set; }
        public DateTime T_UPD_DATE { get; set; }
        public string T_UPD_USER { get; set; }
        public string T_UNIT_NO { get; set; }
        public string T_VIRUS_CODE { get; set; }

        //T12034
        public string T_VERIFY { get; set; }
        public string T_POS2_VERIFY { get; set; }
        
        public string T_POS2_VERIFIED_BY_CODE { get; set; }
        public string T_POS1_VERIFIED_BY { get; set; }
        public DateTime T_POS1_VERIFIED_DATE { get; set; }
        public string T_POS2_VERIFIED_BY { get; set; }
        public DateTime T_POS2_VERIFIED_DATE { get; set; }
        public string T_SEND_FLAG { get; set; }
        public string T_LAB_REQ_NO { get; set; }
        public DateTime T_LAB_REQ_DATE { get; set; }

        //T13016 Table
        public string T_ANALYSIS_CODE { get; set; }
        public string T_WS_CODE { get; set; }
        public string T_REQUEST_NO { get; set; }

        //T12019,T12075 Table
        public string T_VIOROLOGY_RESULT { get; set; }
        public string T_VIRO_TIME { get; set; }
        public DateTime T_VIRO_DATE { get; set; }

        
            
        



    }
}