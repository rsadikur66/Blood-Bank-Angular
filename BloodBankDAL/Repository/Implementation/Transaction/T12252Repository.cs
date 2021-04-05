using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12252Repository: IT12252
    {
        T12252 obj = new T12252();
        CommonDAL common= new CommonDAL();
       public DataTable getGridData(string lang, string unitId)
       {
           var data = obj.getGridData(lang,unitId);
           return data;
       }

      public string SaveData(List<T12223> t23List, string welId)
        {
            string msg = "";
            bool isInsert = false;
            int cont1 = 0;
            int cont2 = t23List.Count;
            obj.BeginTransaction();
            var seq = common.Query($"SELECT  NVL(T_POOL_SEQ,0)+1 T_POOL_SEQ FROM T12035 WHERE T_HOSPITAL ='1' AND T_WS_CODE    ='12'").Rows[0]["T_POOL_SEQ"].ToString();
            foreach (var i in t23List)
            {
                if (i.T_UNIT_NO != null)
                {
                    i.T_SEQ_NO = "P"+seq;
                   
                    if (obj.UpdateT12223(i, welId))
                    {
                        cont1= cont1+ 1;

                    }
                    
                }
                
            }
            if (cont1== cont2)
             {
                isInsert = obj.updateT12035(seq);
                if (isInsert)
                {
                    obj.CommitTransaction();
                    msg = "Save Successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "f";
                }
            }
            
            //var data = obj.SaveData(unitId);
            return msg;
        }

     public DataTable pickUpData(string fdate, string tdate, string Seq, string lang)
     {
         var data = obj.pickUpData( fdate, tdate, Seq, lang);
         return data;
     }
    }
}