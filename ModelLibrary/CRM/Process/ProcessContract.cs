﻿/********************************************************
 * Project Name   : ViennaAdvantage
 * Class Name     : CreateContractInvoice
 * Purpose        : 
 * Class Used     : SvrProcess
 * Chronological    Development
 * Lokesh Chauhan   02-Feb-2012
  ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Process;
using VAdvantage.Classes;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using System.Data;
using System.Data.SqlClient;
using VAdvantage.Logging;
using VAdvantage.Utility;
using System.Security.Policy;
using VAdvantage.ProcessEngine;
//using ViennaAdvantage.Model;

namespace VAdvantage.Process
{
    public class ProcessContract : SvrProcess
    {

        #region Private Variables
        //string msg = "";
        string sql = "";
        //VAdvantage.Model.X_VAB_Contract cont = null;
        #endregion

        protected override void Prepare()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string DoIt()
        {
            int VAB_Contract_ID = GetRecord_ID();
            VAdvantage.Model.X_VAB_Contract con = new VAdvantage.Model.X_VAB_Contract(GetCtx(), VAB_Contract_ID, null);
            DateTime? start=con.GetStartDate();
            DateTime? end=con.GetEndDate();
            if(end>start)
            {
            sql = "update VAB_Contract set processed = 'Y' where VAB_Contract_id = " + VAB_Contract_ID;
            int res = DB.ExecuteQuery(sql, null, null);
            if (res > 0)
            {
                return Msg.GetMsg(GetCtx(), "Processed");
            }
            else
            {
                return Msg.GetMsg(GetCtx(), "NotProcessed");
            }
            }
            else
                return Msg.GetMsg(GetCtx(), "NotValidDatePeriod");

        }
    }
}
