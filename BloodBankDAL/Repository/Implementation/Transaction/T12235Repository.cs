using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Initialization;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12235Repository : IT12235
    {
        private readonly T12235 obj = new T12235();

        public T12235Repository(T12235 _obj) : base()
        {
            obj = _obj;
        }

        public T12235Repository()
        {
        }

        //For Unit From and Unit To Data
        public DataTable GetUnitData(string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetUnitData(siteCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetUnitData(siteCode);
            //return obj;
        }

        //For Blood Data
        public DataTable GetBloodData(string language)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetBloodData(language);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetBloodData(language);
            //return obj;
        }

        //For Antibody Data

        public DataTable GetAntibodyData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetAntibodyData();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetAntibodyData();
            //return obj;
        }

        //For Dropdown Du Data
        public DataTable GetDuData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetDuData();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetDuData();
            //return obj;
        }

        //For Grid Data
        public DataTable GetGridData(string language, string unitFrom, string unitTo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetGridData(language, unitFrom, unitTo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetGridData(language, unitFrom, unitTo);
            //return obj;
        }

        //For Get Verifid Data
        public DataTable GetVerifidData(string entryUser, string empCode, string roleCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetVerifidData(entryUser, empCode, roleCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetVerifidData(entryUser, empCode, roleCode);
            //return obj;
        }


        //For Insert
        public string InsertT12220(List<t12220> t12235,string user, string lang)
        {
            string unitList = "";
            string msg = "";
            obj.BeginTransaction();
            int count = 0; int count1 = 0;
            int i ;
            try
            {
                for (i = 0; i < t12235.Count; i++)
                {
                    t12235[i].T_ENTRY_USER = user;
                    if (obj.chkVerify19(t12235[i].T_UNIT_NO) == "1")
                    {
                        count++;
                        unitList += t12235[i].T_UNIT_NO + ",";
                    }
                    else
                    {
                        if (t12235[i].isInsert != 1)
                        {
                            if (obj.InsertT12220(t12235[i].T_ENTRY_USER, t12235[i].T_UNIT_NO, t12235[i].T_BLOOD_GROUP)
                                && obj.InsertT12163(t12235[i].ABO, t12235[i].T_UNIT_NO, t12235[i].T_ANTIBODY, t12235[i].T_DU, t12235[i].RH_KELL, t12235[i].RH_PHENO) && obj.UpdateT12019(t12235[i].T_ENTRY_USER, t12235[i].T_ANTIBODY, t12235[i].T_ANTIBODY_1, t12235[i].T_DU, t12235[i].T_VERIFY, t12235[i].T_VERIFIED_BY, t12235[i].T_NOTES, t12235[i].T_BLOOD_GROUP, t12235[i].T_UNIT_NO))
                            {
                                count++;
                                count1 = 1;
                            }
                        }
                        else
                        {
                            if (obj.UpdateT12220(t12235[i].T_ENTRY_USER, t12235[i].T_UNIT_NO, t12235[i].T_BLOOD_GROUP) && obj.UpdateT12163(t12235[i].ABO, t12235[i].T_UNIT_NO, t12235[i].T_ANTIBODY, t12235[i].T_DU, t12235[i].RH_KELL, t12235[i].RH_PHENO) && obj.UpdateT12019(t12235[i].T_ENTRY_USER, t12235[i].T_ANTIBODY, t12235[i].T_ANTIBODY_1, t12235[i].T_DU, t12235[i].T_VERIFY, t12235[i].T_VERIFIED_BY, t12235[i].T_NOTES, t12235[i].T_BLOOD_GROUP, t12235[i].T_UNIT_NO))
                            {
                                count++;
                                count1 = 1;
                            }
                        }
                    }

                }
                if (i == count && i > 0)
                {
                    obj.CommitTransaction();
                    msg = obj.GetUserMsg("N0040", "LANG" + lang);
                    if (unitList != "")
                    {

                        unitList = unitList.Remove(unitList.Length - 1);
                        if (count1 == 0)
                        {
                            msg = " This " + unitList + " units cannot be updated";
                        }
                        else
                        {
                            msg += " This " + unitList + " units cannot be updated";
                        }

                    }

                }
                else
                {
                    obj.RollbackTransaction();
                    msg = obj.GetUserMsg("N0071", "LANG" + lang);
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            //for (i = 0; i < t12235.Count; i++)
            //{
            //    t12235[i].T_ENTRY_USER = user;
            //    if (obj.chkVerify19(t12235[i].T_UNIT_NO)=="1")
            //    {
            //        count++;
            //        unitList += t12235[i].T_UNIT_NO + ",";
            //    }
            //    else
            //    {
            //        if (t12235[i].isInsert != 1)
            //        {
            //            if (obj.InsertT12220(t12235[i].T_ENTRY_USER, t12235[i].T_UNIT_NO, t12235[i].T_BLOOD_GROUP)
            //                && obj.InsertT12163(t12235[i].ABO, t12235[i].T_UNIT_NO, t12235[i].T_ANTIBODY, t12235[i].T_DU, t12235[i].RH_KELL, t12235[i].RH_PHENO) && obj.UpdateT12019(t12235[i].T_ENTRY_USER, t12235[i].T_ANTIBODY, t12235[i].T_ANTIBODY_1, t12235[i].T_DU, t12235[i].T_VERIFY, t12235[i].T_VERIFIED_BY, t12235[i].T_NOTES, t12235[i].T_BLOOD_GROUP, t12235[i].T_UNIT_NO))
            //            {
            //                count++;
            //                count1 = 1;
            //            }
            //        }
            //        else
            //        {
            //            if (obj.UpdateT12220(t12235[i].T_ENTRY_USER, t12235[i].T_UNIT_NO, t12235[i].T_BLOOD_GROUP) && obj.UpdateT12163(t12235[i].ABO, t12235[i].T_UNIT_NO, t12235[i].T_ANTIBODY, t12235[i].T_DU, t12235[i].RH_KELL, t12235[i].RH_PHENO) && obj.UpdateT12019(t12235[i].T_ENTRY_USER, t12235[i].T_ANTIBODY, t12235[i].T_ANTIBODY_1, t12235[i].T_DU, t12235[i].T_VERIFY, t12235[i].T_VERIFIED_BY, t12235[i].T_NOTES, t12235[i].T_BLOOD_GROUP, t12235[i].T_UNIT_NO))
            //            {
            //                count++;
            //                count1 = 1;
            //            }
            //        }
            //    }
                
            //}
            //if (i==count&&i>0)
            //{
            //    obj.CommitTransaction();
            //    msg = obj.GetUserMsg("N0040", "LANG"+lang);
            //    if (unitList!="")
            //    {

            //    unitList = unitList.Remove(unitList.Length - 1);
            //        if (count1==0)
            //        {
            //            msg= " This " + unitList + " units cannot be updated";
            //        }
            //        else
            //        {
            //            msg += " This " + unitList + " units cannot be updated";
            //        }
                   
            //    }
                
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = obj.GetUserMsg("N0071", "LANG" + lang);
            //}
            
            return msg;
        }

        
    }
}