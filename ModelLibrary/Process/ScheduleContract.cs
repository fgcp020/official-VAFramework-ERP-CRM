﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.ProcessEngine;
using VAdvantage.Utility;
using VAdvantage.Logging;
//using ViennaAdvantage.Model;
using VAdvantage.DataBase;
using System.Data;
using VAdvantage.Model;

/* Process: Create Contract Schedule 
 * Writer :Arpit Singh
 * Date   : 31/1/12 
 */
namespace ViennaAdvantageServer.Process
{
    class ScheduleContract : SvrProcess
    {
        int contractID;
        protected override void Prepare()
        {
            contractID = GetRecord_ID();
        }

        protected override String DoIt()
        {
            VAdvantage.Model.X_VAB_Contract contract = new VAdvantage.Model.X_VAB_Contract(GetCtx(), contractID, Get_TrxName());
            DateTime start = (DateTime)contract.GetBillStartDate();
            DateTime end = (DateTime)contract.GetEndDate();
            int frequency = contract.GetVAB_Frequency_ID();

            string Sql = "SELECT NoofMonths FROM VAB_Frequency WHERE VAB_Frequency_ID=" + frequency;
            int months = Util.GetValueOfInt(DB.ExecuteScalar(Sql, null, Get_TrxName()));
            int count = Util.GetValueOfInt(contract.GetTotalInvoice());

            for (int i = 1; i <= count; i++)
            {

                VAdvantage.Model.X_VAB_ContractSchedule CSchedule = new VAdvantage.Model.X_VAB_ContractSchedule(GetCtx(), 0, Get_TrxName());
                //Neha ---Set Tenant, Organization On Invoice Schedule when we create Invoice Schedule from Schedule Contract button on header--12 Sep,2018
                CSchedule.SetVAF_Client_ID(contract.GetVAF_Client_ID());
                CSchedule.SetVAF_Org_ID(contract.GetVAF_Org_ID());
                //-----------------------End--------------------
                CSchedule.SetVAB_Contract_ID(contractID);
                CSchedule.SetVAB_BusinessPartner_ID(contract.GetVAB_BusinessPartner_ID());
                CSchedule.SetFROMDATE(start);
                CSchedule.SetProcessed(true);
                CSchedule.SetUnitsDelivered(contract.GetQtyEntered());
                CSchedule.SetFROMDATE(start);
                DateTime toDate = start.AddMonths(months);
                toDate = toDate.AddDays(-1);
                CSchedule.SetEndDate(toDate);
                start = start.AddMonths(months);
                // if (i != count)
                // {

                // CSchedule.SetNoOfDays(days);
                // }
                // else
                // {
                //     CSchedule.SetEndDate(end);
                //     CSchedule.SetNoOfDays((end - start).Days+1);
                // }
                CSchedule.SetM_Product_ID(contract.GetM_Product_ID());
                // Added by Vivek on 21/11/2017 asigned by Pradeep
                CSchedule.SetM_AttributeSetInstance_ID(contract.GetM_AttributeSetInstance_ID());
                CSchedule.SetTotalAmt(contract.GetLineNetAmt()); 
                CSchedule.SetGrandTotal(contract.GetGrandTotal());
                CSchedule.SetTaxAmt(contract.GetTaxAmt());

                // if Surcharge Tax is selected on Tax, then set value in Surcharge Amount
                if (CSchedule.Get_ColumnIndex("SurchargeAmt") > 0)
                {
                    CSchedule.SetSurchargeAmt(contract.GetSurchargeAmt());
                }

                CSchedule.SetC_UOM_ID(contract.GetC_UOM_ID());
                CSchedule.SetPriceEntered(contract.GetPriceEntered());
                if (CSchedule.Save())
                {
                    contract.SetProcessed(true);
                    contract.SetScheduleContract("Y");
                    contract.Save();
                }
                else
                {
                    //Neha----If Invoice Shedule not saved then will show the exception---12 Sep,2018
                    ValueNamePair pp = VAdvantage.Logging.VLogger.RetrieveError();
                    if (pp != null)
                        throw new ArgumentException("Cannot save Invoice Schedule. " + pp.GetName());
                    throw new ArgumentException("Cannot save Invoice Schedule.");
                }
                 
            }

            return Msg.GetMsg(GetCtx(), "ContractScheduleDone");

        }

        //protected override String DoIt()
        //{
        //    X_VAB_Contract contract = new X_VAB_Contract(GetCtx(), contractID, null);
        //    DateTime start = (DateTime)contract.GetStartDate();
        //    DateTime end = (DateTime)contract.GetEndDate();
        //    int frequency = contract.GetVAB_Frequency_ID();

        //    string Sql = "Select NoofDays from VAB_Frequency where VAB_Frequency_ID=" + frequency;
        //    int days = Util.GetValueOfInt(DB.ExecuteScalar(Sql, null, null));
       
        //    int count = Util.GetValueOfInt(contract.GetTotalInvoice());

        //    for (int i = 1; i <= count; i++)
        //    {

        //        X_VAB_ContractSchedule CSchedule = new X_VAB_ContractSchedule(GetCtx(), 0, null);
        //        CSchedule.SetVAB_Contract_ID(contractID);
        //        CSchedule.SetVAB_BusinessPartner_ID(contract.GetVAB_BusinessPartner_ID());

        //        CSchedule.SetFROMDATE(start);
        //        CSchedule.SetProcessed(true);

        //        CSchedule.SetUnitsDelivered(contract.GetQtyEntered());
        //        CSchedule.SetFROMDATE(start);
        //        CSchedule.SetEndDate(start.AddDays(days - 1));
        //        start = start.AddDays(days);
        //        // if (i != count)
        //        // {

        //        // CSchedule.SetNoOfDays(days);
        //        // }
        //        // else
        //        // {
        //        //     CSchedule.SetEndDate(end);
        //        // CSchedule.SetNoOfDays((end - start).Days+1);
        //        // }
        //        CSchedule.SetM_Product_ID(contract.GetM_Product_ID());
        //        CSchedule.SetTotalAmt(contract.GetLineNetAmt());
        //        CSchedule.SetGrandTotal(contract.GetGrandTotal());
        //        CSchedule.SetTaxAmt(contract.GetTaxAmt());
        //        CSchedule.SetC_UOM_ID(contract.GetC_UOM_ID());
        //        CSchedule.SetPriceEntered(contract.GetPriceEntered());
        //        if (CSchedule.Save())
        //        {
        //            contract.SetProcessed(true);
        //            contract.SetScheduleContract("Y");
        //            contract.Save();
        //        }

        //    }





        //    return Msg.GetMsg(GetCtx(), "ContractScheduledDone ");

        //}

    }
}
