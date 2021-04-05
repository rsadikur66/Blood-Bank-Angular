using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Model
{
    public class CommonModel
    {   //Common------------------------------------
        public DateTime T_ENTRY_DATE { get; set; }
        public string T_ENTRY_USER { get; set; }
        public DateTime T_UPD_DATE { get; set; }
        public string T_UPD_USER { get; set; }
        //T03001---------------------------------
        public string T_GENDER { get; set; }

        //T12071------------------------------------
        public string T_ENTRY_TIME { get; set; }
        public string T_UPD_TIME { get; set; }
        public string T_COLOR_CODE { get; set; }
        public int T_DIFFERAL_DAY { get; set; }
        public string T_DISP_SEQ { get; set; }
        public string T_DONOR_EPISODE { get; set; }
        public string T_DONOR_ID { get; set; }
        public string T_DONOR_PATNO { get; set; }
        public string T_QHEAD_NO { get; set; }
        public string T_QNO { get; set; }
        public string T_QNO_ANS { get; set; }
        public string T_QUES_ID { get; set; }
        //T12017------------------------------------
        public string T_PAT_NO { get; set; }
        public string T_EPISODE_NO { get; set; }
        public string T_DONOR_NTNLTY_ID { get; set; }
        public string T_BLOOD_DONATION_STATUS { get; set; }
        public string T_RESEARCH_STTS { get; set; }
        public DateTime T_ARRIVAL_DATE { get; set; }
        public string T_DOTN_RSN_CODE { get; set; }
        public int T_REQUEST_ID { get; set; }
        public string T_REF_PAT_NO { get; set; }
        public string T_OTHER_PAT_NAME { get; set; }
        public string T_SITE_CODE { get; set; }

        // ------- for T12204 No Form -------
        public string T_UNIT_NO { get; set; }
        public string T_SEQ_NO { get; set; }
        public string MAX_EPISODE { get; set; }
     //   public string T_DONOR_PATNO { get; set; }
        public string ChkGenlApp { get; set; }
        public string ChkbxDHQ { get; set; }
        public string ChkbxLetArm { get; set; }
        public string ChkbxRightArm { get; set; }
        public string ChkbxBag { get; set; }
        
        public string ChkAPheresis { get; set; }
        public string ChkPLT { get; set; }
        public string ChkRBCS { get; set; }
        public string ChkPlasma { get; set; }
        public string DonationStartTime { get; set; }
        public string DonationEndTime { get; set; }
        public string Phebotomy { get; set; }


        public string T_BED_CODE { get; set; }
        public string T_COMMENTS { get; set; }
        public string T_BAG_WEIGHT { get; set; }
        public string CancelReason { get; set; }
        public string T_DONATION_COMPLETION_STATUS { get; set; }
        public string T_BAG_USED_CODE { get; set; }
        public string T_ACTION { get; set; }
        public string Marks { get; set; }
        public string T_PIN { get; set; }
        public string DISCARD_REASON_CODE { get; set; }
        public string T_BLD_STORE_ID { get; set; }
        public string T_BAG_BARCODE { get; set; }
        public string T_SEGMENT_NO { get; set; }


        public string T_TACD_USED { get; set; }
        public string T_ER_TIME { get; set; }
        public string T_LR_TIME { get; set; }
        public string T_POST_PLT { get; set; }
        public string T_POST_HCT { get; set; }
        public string T_AACD_DONOR { get; set; }
        public string T_BLOOD_PROCESSED { get; set; }
        public string T_TSAL_USED { get; set; }
        public string T_KIT_LOT { get; set; }
        public string T_LOT_EXPIRY { get; set; }
        public string T_ACD_LOT { get; set; }
        public string T_ACD_EXPIRY { get; set; }


        public string T_PLT_M_V { get; set; }
        public string T_YLD_PLT { get; set; }
        public string T_ACD_PLT_V { get; set; }
        public string T_PLSMA_M_V { get; set; }
        public string T_ACD_V_PLASMA { get; set; }
        public string T_RBCS_M_V { get; set; }
        public string T_ACD_V_RBC { get; set; }
        public string T_HTC_RBC { get; set; }
        public string T_HOUR_MIN { get; set; }
        public string T_DATE { get; set; }
        public string T_COMPLETE { get; set; }

        //public string T_DIFFERAL_DAY { get; set; }

        public  string T_WEIGHT_CODE { get; set; }
        public  string T_UNIT_WEIGHT { get; set; }
        public  string T_RECEIVED_USER { get; set; }
        public DateTime T_RECEIVED_DATE { get; set; }
        public  DateTime T_DONATION_DATE { get; set; }
        public string T_BAG_TYPE{ get; set; }
        // public string T_BLOOD_DONATION_STATUS { get; set; }
       //  public string T_REQUEST_ID { get; set; }








    }

    public class T12013
    {
        public string T_ENTRY_USER { get; set; }
        public string T_ENTRY_DATE { get; set; }
        public string T_UPD_USER { get; set; }
        public DateTime T_UPD_DATE { get; set; }
        public string T_REQUEST_NO { get; set; }
        public string T_PAT_NO { get; set; }
        public string T_PRODUCT_CODE { get; set; }
        public string T_UNITS_ISSUED { get; set; }
        public string T_ANTI_A { get; set; }
        public string T_ANTI_B { get; set; }
        public string T_ANTI_D { get; set; }
        public string T_CELLS_A { get; set; }
        public string T_CELLS_B { get; set; }
        public string T_BLOOD_GROUP { get; set; }
        public string T_SC_I { get; set; }
        public string T_SC_II { get; set; }
        public string T_SC_III { get; set; }
        public string T_AUTO_CONTROL { get; set; }
        public string T_DCT { get; set; }
        public string T_INTERPRETATION { get; set; }
        public string T_CONTROL { get; set; }
        public string T_TECH_CODE { get; set; }
        public string T_REMARKS { get; set; }
        public string T_ICT { get; set; }
        public string T_TS_START_TIME { get; set; }
        public string T_TS_END_TIME { get; set; }
        public string T_AUTO_ANTI { get; set; }
        public string T_ALLO_ANTI { get; set; }
        public string T_NON_SPEC { get; set; }
        public string T_AUTO_OTHERS { get; set; }
        public string T_ALLO_OTHERS { get; set; }
        public string T_NONS_OTHERS { get; set; }
        public string T_ANTI_TYPE_AUTO { get; set; }
        public string T_ANTI_FINAL { get; set; }
        public string T_PHENO { get; set; }
        public string T_ANTI_TYPE_ALLO { get; set; }
        public string T_D { get; set; }
        public string T_CC { get; set; }
        public string T_CS { get; set; }
        public string T_EC { get; set; }
        public string T_ES { get; set; }
        public string T_KC { get; set; }
        public string T_KS { get; set; }
        public string T_JKA { get; set; }
        public string T_JKB { get; set; }
        public string T_FYA { get; set; }
        public string T_FYB { get; set; }
        public string T_M { get; set; }
        public string T_N { get; set; }
        public string T_SC { get; set; }
        public string T_SS { get; set; }
        public string T_LEA { get; set; }
        public string T_LEB { get; set; }
        public string T_ANTI_FINAL1 { get; set; }
        public string T_ANTI_FINAL2 { get; set; }
        public string T_BG_ND { get; set; }
        public string T_BG_N { get; set; }
        public string T_SITE_CODE { get; set; }
        public int T_AUTO_ISSUE_ID { get; set; }
    }

    public class T12256
    {
        public string T_ENTRY_USER { get; set; }
        public DateTime T_ENTRY_DATE { get; set; }
        public string T_ISSUED_BY { get; set; }
        public string T_ISSUE_DATE { get; set; }
        public string T_ISSUE_TIME { get; set; }
        public int T_AUTO_ISSUE_ID { get; set; }
        public string T_BB_STOCK_ID { get; set; }
        public string T_IS { get; set; }
        public string T_C { get; set; }
        public string T_AHG { get; set; }
        public string T_CCC { get; set; }
        public string T_GEL_AHG { get; set; }
        public string T_COMPATIBLE { get; set; }
        public int T_AUTO_ISSUE_DET_ID { get; set; }
    }

    public class T12223
    {
        public int T_BB_STOCK_ID { get; set; }
        public string T_UNIT_NO { get; set; }
        public string T_PRODUCT_CODE { get; set; }
        public string T_BLOOD_GROUP { get; set; }
        public string T_SEQ_NO { get; set; }
        
    }
    public class T12320
    {
        public string T_UNIT_NO { get; set; }
        public string T_PRODUCT_CODE { get; set; }
        public string T_SELECTED { get; set; }
        public string T_REASON_CODE { get; set; }
        public string T_REMARKS { get; set; }
        public string T_EXPIRY_DATE { get; set; }
        public string DONATION_DATE { get; set; }
        
    }
}