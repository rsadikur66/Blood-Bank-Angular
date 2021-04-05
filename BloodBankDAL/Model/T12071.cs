using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Model
{
    public class T12071
    {
        public DateTime T_ENTRY_DATE  { get; set; }
        public string T_ENTRY_USER { get; set; }
        public DateTime T_UPD_DATE { get; set; }
        public string T_UPD_USER { get; set; }
        public string T_DONOR_ID { get; set; }
        public string T_QNO { get; set; }
        public string T_QNO_ANS { get; set; }
        public string T_QHEAD_NO { get; set; }
        public string T_ENTRY_TIME { get; set; }
        public string T_UPD_TIME { get; set; }
        public string T_DISP_SEQ { get; set; }
        public string T_DONOR_PATNO { get; set; }
        public string T_DONOR_EPISODE { get; set; }
        public string T_COLOR_CODE { get; set; }
        public int T_DIFFERAL_DAY { get; set; }
        public int T_REQUEST_ID { get; set; }
        public int T_QUES_ID { get; set; }
    }
}