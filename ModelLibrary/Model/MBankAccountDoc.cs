﻿/********************************************************
 * Module Name    : 
 * Purpose        : 
 * Class Used     : X_VAB_Bank_AcctDoc
 * Chronological Development
 * Mohit          4-March-2020
 ******************************************************/

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VAdvantage.Classes;
using VAdvantage.Utility;
using VAdvantage.DataBase;
using VAdvantage.Common;

namespace VAdvantage.Model
{
    class MBankAccountDoc : X_VAB_Bank_AcctDoc
    {
        public MBankAccountDoc(Ctx ctx, int VAB_Bank_Acct_ID, Trx trxName)
            : base(ctx, VAB_Bank_Acct_ID, trxName)
        {
        }

        public MBankAccountDoc(Ctx ctx, DataRow dr, Trx trxName)
            : base(ctx, dr, trxName)
        {
        }

        protected override bool BeforeSave(bool newRecord)
        {
            // Validation : no duplicate record for priortiy on bank account and payment method combination.
            if (newRecord)
            {
                if (Util.GetValueOfInt(DB.ExecuteScalar("SELECT COUNT(VAB_Bank_AcctDoc_ID) FROM VAB_Bank_AcctDoc WHERE IsActive = 'Y' AND VA009_PaymentMethod_ID=" + Util.GetValueOfInt(Get_Value("VA009_PaymentMethod_ID")) + " AND VAB_Bank_Acct_ID = " + GetVAB_Bank_Acct_ID() + " AND Priority = " + GetPriority())) > 0)
                {
                    log.SaveError("Error:", Msg.GetMsg(GetCtx(), "RecSamePriority"));
                    return false;
                }
            }
            else
            {
                if (Util.GetValueOfInt(DB.ExecuteScalar("SELECT COUNT(VAB_Bank_AcctDoc_ID) FROM VAB_Bank_AcctDoc WHERE IsActive = 'Y' AND VA009_PaymentMethod_ID=" + Util.GetValueOfInt(Get_Value("VA009_PaymentMethod_ID")) + " AND VAB_Bank_Acct_ID = " + GetVAB_Bank_Acct_ID() + " AND Priority = " + GetPriority() + " AND VAB_Bank_AcctDoc_ID !=" + GetVAB_Bank_AcctDoc_ID())) > 0)
                {
                    log.SaveError("Error:", Msg.GetMsg(GetCtx(), "RecSamePriority"));
                    return false;

                }
            }
            // Validation : end check number cant be less than curent next.
            if (newRecord)
            {

                if (Util.GetValueOfInt(GetEndChkNumber()) < Util.GetValueOfInt(GetCurrentNext()))
                {                   
                    log.SaveError("Error:", Msg.GetMsg(GetCtx(), "CurrNextGrtr"));
                    return false;
                }
            }
            else
            {
                if (Is_ValueChanged("CurrentNext") || Is_ValueChanged("EndChkNumber"))
                {
                    if (Util.GetValueOfInt(GetEndChkNumber()) < Util.GetValueOfInt(GetCurrentNext()))
                    {
                        log.SaveError("Error:", Msg.GetMsg(GetCtx(), "CurrNextGrtr"));
                        return false;

                    }
                }
            }
            // Validation : Start check number cant be greater than end check number
            if (GetStartChkNumber() > 0 && GetEndChkNumber() > 0)
            {
                if (GetStartChkNumber() > GetEndChkNumber())
                {
                    log.SaveError("Error:", Msg.GetMsg(GetCtx(), "StrtNoGrtEndNo"));                    
                    return false;
                }
            }
            // Validation : Start check number cant be greater than current next
            if (GetStartChkNumber() > GetCurrentNext())
            {
                log.SaveError("Error:", Msg.GetMsg(GetCtx(), "StrtNoGrtCurrnext"));                
                return false;
            }

            return true;
        }
    }
}
