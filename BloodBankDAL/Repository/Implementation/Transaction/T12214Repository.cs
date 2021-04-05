using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    using System.Data;

    using BloodBankDAL.Model;
    using BloodBankDAL.Repository.Interface.Transaction;
    using BloodBankDAL.Repository.Query.Transaction;

    public class T12214Repository : IT12214
    {
        private readonly T12214 obj = new T12214();

        CommonDAL _CommonData = new CommonDAL();

        private String nationalityMessage = "";
        public T12214Repository(T12214 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetTitle(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                 dt = obj.GetTitle(lang);
               
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }

        public DataTable GetAllRelation(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetRelation(lang);
                
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetAllERRelation(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetERRelation(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetERRelation(lang);
            //return obj;
        }

        public DataTable GetAllNationality(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetAllNationality(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetAllNationality(lang);
            //return obj;
        }
        public DataTable GetAllReligion(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetAllReligion(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetAllReligion(lang);
            //return obj;
        }
        public DataTable GetAllGender(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetAllGender(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        //    var obj = this.obj.GetAllGender(lang);
        //    return obj;
        }

        public DataTable GetAllMrtlStatus(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetAllMrtlStatus(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetAllMrtlStatus(lang);
            //return obj;
        }
        public DataTable CheckNationalityCode(string T_NTNLTY_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.CheckNationalityCode(T_NTNLTY_ID);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.CheckNationalityCode(T_NTNLTY_ID);
            //return obj;
        }

        public DataTable GetArabicName(string englishName)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetArabicName(englishName.ToUpper());

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetArabicName(englishName.ToUpper());
            //return obj;
        }
        public DataTable GetEnglishName(string arabicName)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetEnglishName(arabicName);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetEnglishName(arabicName);
            //return obj;
        }


        public string insert(T03001 t03001, string T_EMP_CODE)
        {
            string msg = "";
            string user = T_EMP_CODE;
            bool isInsert = false;
            
            DataTable dtExistingPat = this.obj.CheckExtistingPatient(t03001.T_PAT_NO);
            obj.BeginTransaction();
            if (dtExistingPat.Rows.Count > 0)
            {
                isInsert = this.obj.update03001(
                    user,
                    t03001.T_BIRTH_DATE,
                    t03001.T_PAT_NO,
                    t03001.T_FAMILY_LANG1_NAME,
                    t03001.T_FAMILY_LANG2_NAME,
                    t03001.T_FATHER_LANG1_NAME,
                    t03001.T_FATHER_LANG2_NAME,
                    t03001.T_GFATHER_LANG1_NAME,
                    t03001.T_GFATHER_LANG2_NAME,
                    t03001.T_FIRST_LANG1_NAME,
                    t03001.T_FIRST_LANG2_NAME,
                    t03001.T_MOTHER_LANG1_NAME,
                    t03001.T_MOTHER_LANG2_NAME,
                    t03001.T_NTNLTY_CODE,
                    t03001.T_NTNLTY_ID,
                    t03001.T_ADDRESS1,
                    t03001.T_ADDRESS2,
                    t03001.T_RLGN_CODE,
                    t03001.T_RLTN_CODE,
                    t03001.T_GENDER,
                    t03001.T_MOBILE_NO,
                    t03001.T_POSTAL_CODE,
                    t03001.T_POBOX_NO,
                    t03001.T_EMAIL_ID,
                    t03001.T_ER_RLTN_CODE,
                    t03001.T_ER_MOBILE,
                    t03001.T_PAT_TITLE, t03001.T_MRTL_STATUS);

                msg = "Data Update Successfully";

            }
            if (dtExistingPat.Rows.Count == 0)
            {
                string maxPatNo = obj.GetMaxPatNo().Rows[0][0].ToString();
                string maxId = obj.GetMaxId();
                DataTable dtNationalitychech =  this.obj.CheckNationalityCode(t03001.T_NTNLTY_ID);
                if (dtNationalitychech.Rows.Count > 0)
                {
                    
                   return msg = "Invalid Iqama #";
                }
                    isInsert = this.obj.insert03001(user, maxId, t03001.T_BIRTH_DATE, maxPatNo, t03001.T_FAMILY_LANG1_NAME, t03001.T_FAMILY_LANG2_NAME,
                        t03001.T_FATHER_LANG1_NAME, t03001.T_FATHER_LANG2_NAME, t03001.T_GFATHER_LANG1_NAME,
                        t03001.T_GFATHER_LANG2_NAME, t03001.T_FIRST_LANG1_NAME, t03001.T_FIRST_LANG2_NAME,
                        t03001.T_MOTHER_LANG1_NAME, t03001.T_MOTHER_LANG2_NAME, t03001.T_NTNLTY_CODE,
                        t03001.T_NTNLTY_ID, t03001.T_ADDRESS1, t03001.T_ADDRESS2, t03001.T_RLGN_CODE,
                        t03001.T_RLTN_CODE, t03001.T_GENDER, t03001.T_MOBILE_NO, t03001.T_POSTAL_CODE,
                        t03001.T_POBOX_NO, t03001.T_EMAIL_ID, t03001.T_ER_RLTN_CODE, t03001.T_ER_MOBILE, t03001.T_PAT_TITLE, t03001.T_MRTL_STATUS);

                    msg = "Data Insert Successfully";
            }
            if (isInsert)
            {
                obj.CommitTransaction();
            }
            else
            {
                obj.RollbackTransaction();
                msg = "Data faild to save";
            }

            return msg;
        }

        public DataTable GetExistingPat(string pat, string nat, string fisName, string fathName, string graName, string famName, string gendr, string natnl, string regn, string mrists,string year)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetExistingPat(pat, nat, fisName, fathName, graName, famName, gendr, natnl, regn, mrists, year, HttpContext.Current.Session["T_LANG"].ToString());

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetExistingPat(pat, nat, fisName, fathName, graName, famName, gendr, natnl, regn, mrists, year, HttpContext.Current.Session["T_LANG"].ToString());
            //return obj;
        }

        public String GetPatNo()
        {
            var dt = "";
            try
            {
               dt = this.obj.GetPatNo();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
           
            return dt;
        }

        public string GetUserMsg(string T_MSG_CODE, string LANG)
        {
            var dt = "";
            try
            {
                dt = this.obj.GetUserMsg(T_MSG_CODE, LANG);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var obj = this.obj.GetUserMsg(T_MSG_CODE, LANG);
            //return obj;
        }
    }
}