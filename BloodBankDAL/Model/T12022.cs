using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Model
{
    public class T12022
    {

        public string T_PAT_NO { get; set; }
        public string T_EPISODE_NO { get; set; }
        public int T_REQUEST_ID { get; set; }
        public string T_SER_USE { get; set; }
        public DateTime T_MAX_DIFFERED_DATE { get; set; }
        public int T_MAX_DIFFERED_DAY { get; set; }
        public string T_WEIGHT { get; set; }
        public string T_HB { get; set; }
        public string T_TEMPTURE { get; set; }
        public string T_PULS { get; set; }
        public string T_BP_HIGH { get; set; }
        public string T_BP_LOW { get; set; }
        public string T_REJECT_REASON { get; set; }
        public int REC_DIF_DAY { get; set; }
        public string T_COMMENT { get; set; }
        public DateTime T_DIFFERED_DATE { get; set; }
        public string T_DIFFERED_STATUS { get; set; }
        public string T_ACCEPT_STATUS { get; set; }
        public int T_VITAL_ID { get; set; }

        public string T_ENTRY_USER { get; set; }
        public DateTime T_ENTRY_DATE { get; set; }
        public string T_UPD_USER { get; set; }
        public DateTime T_UPD_DATE { get; set; }

        //public string T_DONATION_NO { get; set; }
        //public DateTime T_DONATION_DATE { get; set; }
        //public string T_MEDICAL_TEST { get; set; }
        //public string T_BP { get; set; }
        //public string T_DOC_CODE { get; set; }
        //public string T_BLOOD_TAKING_STATUS { get; set; }
        //public string T_TEATMENT { get; set; }
        //public string T_BLOOD_GROUP { get; set; }
        //public string T_ANTIBODIES { get; set; }
        //public string T_TECH_CODE { get; set; }
        //public string T_TMP_PAT_FLAG { get; set; }
        //public string T_BB_CODE { get; set; }
        //public int T_AMOUNT { get; set; }
        //public string T_OS_SEROLOGY_YN { get; set; }
        //public string T_OS_UNIT_NO { get; set; }
        //public string T_NURSES_CODE { get; set; }
        //public string T_REJ_STATUS { get; set; }
        //public string T_REJ_REASON_CODE { get; set; }
        //public string T_TEC_ACCEPT_STATUS { get; set; }
        //public string T_UNIT_NO { get; set; }
        //public string T_BAG_QUANTITY { get; set; }
        //public string T_TEC_REJ_REASON { get; set; }
        //public string T_LAB_REQUEST_NO { get; set; }
        //public string T_BLOOD_PRODUCT { get; set; }
        //public string T_OUTSIDE_BLOOD_FLAG { get; set; }
        //public string T_DONATION_CANCEL_FLAG { get; set; }
        //public string T_UNIT_TAKEN_FLAG { get; set; }
        //public string T_UNIT_TAKEN_BY { get; set; }
        //public DateTime T_UNIT_TAKEN_DATE { get; set; }
        //public string T_DHQ_CHECK_YN { get; set; }
        //public string T_BAG_CHECK_YN { get; set; }
        //public string T_GENERAL_APP_CHECK_YN { get; set; }
        //public string T_LEFT_ARM_CHECK_YN { get; set; }
        //public string T_RIGHT_ARM_CHECK_YN { get; set; }
        //public string T_DONATION_DURATION { get; set; }
        //public string T_BAG_WEIGHT { get; set; }
        //public string T_REACTION_TYPE { get; set; }
        //public string T_COMMENTS { get; set; }
        //public string T_BAG_BARCODE { get; set; }
        //public string T_DEFERRAL_TYPE { get; set; }
        //public string T_DEFERRAL_REASON { get; set; }
        //public string T_DEFERRAL_STATUS { get; set; }
        //public string T_DONATION_STATUS { get; set; }
        //public string T_CANCEL_REASON { get; set; }
        //public string T_DONATION_COMPLETION_STATUS { get; set; }
        //public string T_VITAL_SIGN_TIME { get; set; }
        //public string T_DONATION_SEQ_NO { get; set; }
        //public string T_DIFFERED_REASON_CODE { get; set; }
        //public string T_ENTRY_TIME { get; set; }
        //public string T_BAG_USED_FLAG { get; set; }
        //public string T_DONATION_START_TIME { get; set; }
        //public string T_DONATION_END_TIME { get; set; }
        //public string T_REACTION_DESC { get; set; }
        //public string T_REMARKS { get; set; }
        //public string T_UNIT_ACCEPT_STATUS { get; set; }
        //public string DISCARD_REASON_CODE { get; set; }
        //public string T_SEGMENT_NO { get; set; }
        //public string T_PLSMA { get; set; }
        //public string T_PLT { get; set; }
        //public string T_RBCS { get; set; }
        //public int T_PLT_M_V { get; set; }
        //public int T_RBCS_M_V { get; set; }
        //public int T_PLSMA_M_V { get; set; }
        //public string T_DONATION_TIME { get; set; }
        //public string T_APHERESIS { get; set; }
        //public int T_PIN { get; set; }
        //public string T_MALARIYA { get; set; }
        //public string T_NAT { get; set; }
        //public string T_FTEST_DONE { get; set; }
        //public string T_RECEIVED { get; set; }
        //public DateTime T_RECEIVED_DATE { get; set; }
        //public string T_RECEIVED_USER { get; set; }
        //public int T_TACD_USED { get; set; }
        //public string T_ER_TIME { get; set; }
        //public int T_LR_TIME { get; set; }
        //public int T_POST_PLT { get; set; }
        //public int T_POST_HCT { get; set; }
        //public int T_AACD_DONOR { get; set; }
        //public int T_BLOOD_PROCESSED { get; set; }
        //public int T_TSAL_USED { get; set; }
        //public string T_KIT_LOT { get; set; }
        //public DateTime T_LOT_EXPIRY { get; set; }
        //public string T_ACD_LOT { get; set; }
        //public DateTime T_ACD_EXPIRY { get; set; }
        //public int T_YLD_PLT { get; set; }
        //public int T_ACD_PLT_V { get; set; }
        //public int T_ACD_V_PLASMA { get; set; }
        //public int T_ACD_V_RBC { get; set; }
        //public int T_HTC_RBC { get; set; }
        //public string T_COMPLETE { get; set; }
        //public int T_UNIT_WEIGHT { get; set; }
        //public string T_BED_NO { get; set; }
        
        

    }
}