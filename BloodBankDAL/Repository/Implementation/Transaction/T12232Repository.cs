using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    using BloodBankDAL.Model;

    public class T12232Repository : IT12232
    {
        private readonly T12232 obj = new T12232();

        public T12232Repository(T12232 _obj) : base()
        {
            obj = _obj;
        }

        //public DataTable GetCentrifugeList(string lang)
        //{

        //    var Data = obj.GetCentrifugeList(lang);
        //    return Data;
        //}
        public DataTable GetVirusList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetVirusList();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetVirusList();
            //return Data;
        }

        public DataTable GetDonationDate(string unitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDonationDate(unitNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetDonationDate(unitNo);
            //return Data;
        }
        public DataTable ValidateUnitNo(string unitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.ValidateUnitNo(unitNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.ValidateUnitNo(unitNo);
            //return Data;
        }
        public DataTable GetAllData(string T_UNIT_NO, string T_LANG, string empCode)
        {
            var language = "";
            if (T_LANG == "2") language = "";
            else language = "2";
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetAllData(T_UNIT_NO, language, empCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetAllData(T_UNIT_NO, language, empCode);
            //return Data;
        }

        public DataTable CheckDoctorUser(string T_EMP_CODE, string T_LANG)
        {
            var language = "";
            if (T_LANG == "2") language = "";
            else language = "2";
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckDoctorUser(T_EMP_CODE, language);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckDoctorUser(T_EMP_CODE, language);
            //return Data;
        }
        public string UpdateT12034(List<M12034> M12034, string T_POS1_VERIFIED_BY)
        {
            string msg = "";
            //  string user = T_POS1_VERIFIED_BY;
            bool isInsert = false;
            obj.BeginTransaction();
            string unitNo = "";

           
            try
            {
                for (int i = 0; i < M12034.Count; i++)
                {
                    if (unitNo == string.Empty)
                        unitNo = M12034[i].T_UNIT_NO;
                    isInsert = this.obj.updateT12034(M12034[i].T_UNIT_NO, T_POS1_VERIFIED_BY, M12034[i].T_VIRUS_CODE);
                }
                if (isInsert)
                    isInsert = this.obj.updateT12019(unitNo, T_POS1_VERIFIED_BY);
                if (isInsert)
                    isInsert = this.obj.updateT12075(unitNo, T_POS1_VERIFIED_BY);

                if (isInsert)
                {
                    obj.CommitTransaction();
                    msg = "Data update successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data faild to save";
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;

            //for (int i = 0; i < M12034.Count; i++)
            //{
            //    if (unitNo == string.Empty)
            //        unitNo = M12034[i].T_UNIT_NO;
            //    isInsert = this.obj.updateT12034(M12034[i].T_UNIT_NO, T_POS1_VERIFIED_BY, M12034[i].T_VIRUS_CODE);
            //}
            //if (isInsert)
            //    isInsert = this.obj.updateT12019(unitNo, T_POS1_VERIFIED_BY);
            //if (isInsert)
            //    isInsert = this.obj.updateT12075(unitNo, T_POS1_VERIFIED_BY);

            //if (isInsert)
            //{
            //    obj.CommitTransaction();
            //    msg = "Data update successfully";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data faild to save";
            //}
            //return msg;
        }

        public DataTable CheckT12022(string T_UNIT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckT12022(T_UNIT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckT12022(T_UNIT_NO);
            //return Data;
        }
        public DataTable CheckT12075(string T_UNIT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckT12075(T_UNIT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckT12075(T_UNIT_NO);
            //return Data;
        }
        public DataTable CheckT12019(string T_UNIT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckT12019(T_UNIT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckT12019(T_UNIT_NO);
            //return Data;
        }
        public DataTable CheckT12075_T_VIROLOGY_RESULT(string T_UNIT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckT12075_T_VIROLOGY_RESULT(T_UNIT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckT12075_T_VIROLOGY_RESULT(T_UNIT_NO);
            //return Data;
        }
        public DataTable CheckT12075_T_UNIT_DISCARD(string T_UNIT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckT12075_T_UNIT_DISCARD(T_UNIT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckT12075_T_UNIT_DISCARD(T_UNIT_NO);
            //return Data;
        }

        public DataTable CheckT12034_T_POS1_VERIFY(string T_UNIT_NO, string T_VIRUS_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckT12034_T_POS1_VERIFY(T_UNIT_NO, T_VIRUS_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckT12034_T_POS1_VERIFY(T_UNIT_NO, T_VIRUS_CODE);
            //return Data;
        }


    }
}