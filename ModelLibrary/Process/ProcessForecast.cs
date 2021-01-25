﻿/********************************************************
 * Project Name   : ViennaAdvantage
 * Class Name     : ProcessForecast
 * Purpose        : 
 * Class Used     : SvrProcess
 * Chronological    Development
 * Lokesh Chauhan   25-Jan-2012
  ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Process;
using VAdvantage.Classes;
using VAdvantage.Model;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using System.Data;
using System.Data.SqlClient;
using VAdvantage.Logging;
using VAdvantage.Utility;
using System.Security.Policy;
using VAdvantage.ProcessEngine;
//using ViennaAdvantage.Model;

namespace ViennaAdvantageServer.Process
{
    public class ProcessForecast : SvrProcess
    {
        #region Private Variables
        string msg = "";
        //string sql = "";
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
            X_VAB_Forecast fore = new X_VAB_Forecast(GetCtx(), Util.GetValueOfInt(GetRecord_ID()), null);
            
            int[] allIds = X_VAB_ForecastLine.GetAllIDs("VAB_ForecastLine", "VAB_Forecast_ID = " + Util.GetValueOfInt(GetRecord_ID()), null);

            for (int i = 0; i < allIds.Length; i++)
            {
                X_VAB_ForecastLine foreLine = new X_VAB_ForecastLine(GetCtx(), Util.GetValueOfInt(allIds[i]), null);
                foreLine.SetProcessed(true);
                if (!foreLine.Save())
                {
                    log.SaveError("ForecastLineNotSaved", "ForecastLineNotSaved");
                    msg = Msg.GetMsg(GetCtx(), "NotProcessed");
                    return msg;
                }
            }
            fore.SetProcessed(true);
            if (!fore.Save())
            {
                log.SaveError("ForecastNotSaved", "ForecastNotSaved");
                msg = Msg.GetMsg(GetCtx(), "NotProcessed");
                return msg;
            }

            //sql = "update VAB_Forecastline set processed = 'Y' where VAB_Forecast_id = " + Util.GetValueOfInt(GetRecord_ID());
            //int res = Util.GetValueOfInt(DB.ExecuteQuery(sql, null, null));
            //sql = "update VAB_Forecast set processed = 'Y' where VAB_Forecast_id = " + Util.GetValueOfInt(GetRecord_ID());
            //res = Util.GetValueOfInt(DB.ExecuteQuery(sql, null, null));
            msg = Msg.GetMsg(GetCtx(), "Processed");
            return msg;
        }
    }
}
