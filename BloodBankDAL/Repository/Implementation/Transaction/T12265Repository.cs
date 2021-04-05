using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12265Repository : IT12265
    {
        public T12265 _dal = new T12265();

        public DataTable GetRequestListData(string empCode)
        {
            var data = _dal.GetRequestListData(empCode);
            return data;
        }
        public DataTable GetHandOverDataFromCenter(string empCode)
        {
            var data = _dal.GetHandOverDataFromCenter(empCode);
            return data;
        }
        public DataTable GetLocationDeliveryMan(string bldReqNo)
        {
            var data = _dal.GetLocationDeliveryMan(bldReqNo);
            return data;
        }
        public DataTable GetAllDeliveryManLocation(string bldReqNo)
        {
            var data = _dal.GetAllDeliveryManLocation(bldReqNo);
            return data;
        }

        public string updateT12091(string acpt, string reqId, string user)
        {
            string msg = "";
            try
            {
                _dal.BeginTransaction();
                if (_dal.updateT12091(acpt, reqId, user))
                {
                    if (_dal.updateT12092(user))
                    {
                        _dal.CommitTransaction();
                        msg = "1";
                    }

                }
                else
                {
                    _dal.RollbackTransaction();
                    msg = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        public string updateT12091ForReceived(string reqNo, string user)
        {
            string msg = "";
            try
            {
                _dal.BeginTransaction();
                if (_dal.updateT12091ForReceived(reqNo, user))
                {
                    if (_dal.updateT12092ForReceived(user))
                    {
                        _dal.CommitTransaction();
                        msg = "1";
                    }

                }
                else
                {
                    _dal.RollbackTransaction();
                    msg = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
          public string updateT91T92ForDrop(string reqNo, string user)
        {
            string msg = "";
            try
            {
                _dal.BeginTransaction();
                if (_dal.updatet91ForDrop(reqNo, user))
                {
                    if (_dal.updateT92ForDrop(user))
                    {
                        _dal.CommitTransaction();
                        msg = "1";
                    }

                }
                else
                {
                    _dal.RollbackTransaction();
                    msg = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }

        public string insertT91(string reqId, string reqNo, string devMan, string estDelDis, string estDelTime, string entryuser, string siteCode, string canReason)
        {
            string msg = "";
            try
            {
                _dal.BeginTransaction();
                if (_dal.insertT91(reqId, reqNo, devMan, estDelDis, estDelTime, entryuser, siteCode) && _dal.updateT65(siteCode, devMan, reqNo) && _dal.updateT91(canReason, reqId) && _dal.updateT92(entryuser, devMan))
                {
                    _dal.CommitTransaction();
                    msg = "1";

                }
                else
                {
                    _dal.RollbackTransaction();
                    msg = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        public string updT65unassign(string reqId, string reqNo, string siteCode, string empCode)
        {
            string msg = "";
            try
            {
                _dal.BeginTransaction();
                if (_dal.updT65unassign(reqId,reqNo,siteCode,empCode))
                {
                    _dal.CommitTransaction();
                    msg = "1";

                }
                else
                {
                    _dal.RollbackTransaction();
                    msg = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        public string UpdateActiveStatus(string entryuser)
        {
            string msg = "";
            try
            {
                _dal.BeginTransaction();
                if (_dal.UpdateActiveStatus(entryuser))
                {
                    _dal.CommitTransaction();
                    msg = "1";

                }
                else
                {
                    _dal.RollbackTransaction();
                    msg = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }

    }
}