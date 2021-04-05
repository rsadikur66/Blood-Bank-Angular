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
    public class T12263Repository : IT12263
    {
        private readonly T12263 obj = new T12263();
        public T12263Repository(T12263 _obj)
        {
            obj = _obj;
        }
        public T12263Repository()
        {

        }
        public DataTable GetSiteList(string siteCode, string refCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetSiteList(siteCode, refCode, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetSiteList(siteCode, lang);
            //return data;
        }
        public DataTable GetRequestedData(string siteCode, string requestNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetRequestedData(siteCode, requestNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetRequestedData(requestNo);
            //return data;
        }
        public DataTable GetRequestList(string siteCode, string refCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetRequestList(siteCode, refCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetRequestList();
            //return data;
        }
        public DataTable GetGridData(string bldGrp, string proCode, string empCode, string userName)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetGridData(bldGrp, proCode, empCode, userName);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var data = obj.GetGridData(bldGrp, proCode, empCode, userName);
            //return data;
        }
        public DataTable CrossmatchCheck(string reqNo, string bldGrp, string proCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CrossmatchCheck(reqNo, bldGrp, proCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var data = obj.CrossmatchCheck(reqNo, bldGrp, proCode);
            //return data;
        }

        public string T12263insert(List<M12263> t12263, string user, string siteCode)
        {

            string msg = "";
            try
            {
                Boolean chkT91 = obj.checkT91(t12263[0]);
                obj.BeginTransaction();


                if (obj.UpdateT12065(t12263[0], "3"))
                {
                    if (obj.InsertT12091(t12263[0], user))
                    {
                        if (!chkT91)
                        {

                            foreach (var t63 in t12263)
                            {
                                if (!obj.T12067Check(t63, siteCode))
                                {
                                    if (obj.T12263insertT12067(t63, user, siteCode))
                                    {
                                        if (obj.UpdateT12019(t63))
                                        {
                                            obj.CommitTransaction();
                                            msg = "Data Insert Successfully";
                                        }
                                    }
                                }
                                else
                                {
                                    obj.RollbackTransaction();
                                    msg = "Data Not Saved";
                                }

                            }
                        }
                        else
                        {
                            obj.CommitTransaction();
                            msg = "Data Insert Successfully";
                        }
                    }

                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data Not Saved";
                }



                //=============================


            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;
        }

        public DataTable GetCourierServiceData(string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetCourierServiceData(siteCode, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetdeliveryByData(string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetdeliveryByData(siteCode, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetDeliveryManLocation(string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDeliveryManLocation(siteCode, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }

    }
}