﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Classes;
////using VAdvantage.Common;
using ViennaAdvantage.Process;
//////using System.Windows.Forms;
//using ViennaAdvantage.Model;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using VAdvantage.Utility;
using System.Data;
using VAdvantage.Logging;
using VAdvantage.ProcessEngine;


using VAdvantage.Process;

namespace ViennaAdvantage.Process
{
    public class CreateAPInvoice : SvrProcess
    {
        #region Private Variable
        private int _VAB_BusinessPartner_ID = 0;
        private DateTime? _DateFrom = null;
        private DateTime? _DateTo = null;
        //private int _noInvoices = 0;
        string sql = "";
        //string msg = "";
        string fromDate = "";
        string toDate = "";
        List<int> VAB_BusinessPartner_ID = new List<int>();
        List<int> M_Product_ID = new List<int>();
        Dictionary<int, int> BPInvoice = new Dictionary<int, int>();
        private List<int> invoices = new List<int>();
        #endregion

        /// <summary>
        /// Prepare - e.g., get Parameters.
        /// </summary>
        protected override void Prepare()
        {
            ProcessInfoParameter[] para = GetParameter();
            for (int i = 0; i < para.Length; i++)
            {
                String name = para[i].GetParameterName();
                if (para[i].GetParameter() == null)
                {
                    ;
                }
                else if (name.Equals("VAB_BusinessPartner_ID"))
                {
                    _VAB_BusinessPartner_ID = para[i].GetParameterAsInt();
                }
                else if (name.Equals("FromDate"))
                {
                    _DateFrom = (DateTime?)para[i].GetParameter();
                    // _DateTo = (DateTime?)para[i].GetParameter_To();
                }
                else if (name.Equals("ToDate"))
                {
                    // _DateFrom = (DateTime?)para[i].GetParameter();
                    _DateTo = (DateTime?)para[i].GetParameter();
                }
                else
                {
                    log.Log(Level.SEVERE, "Unknown Parameter: " + name);
                }
            }
        }

        /// <summary>
        /// Generate Shipments
        /// </summary>
        /// <returns>info</returns>
        protected override String DoIt()
        {
            //string sqlSelect = "select * from s_timeexpenseline where processed = 'Y' and (APInvoice = 'Y' or expenseinvoice = 'Y') and C_Invoice_ID is null";
            //string sqlSelect = "select * from s_timeexpenseline where APInvoice = 'Y' and C_Invoice_ID is null";
            string sqlSelect = "SELECT res.VAB_BusinessPartner_ID, tl.s_timeexpenseline_ID FROM s_timeexpenseline tl inner join s_resource res on (res.s_resource_id = tl.s_resource_id) "
                           + " WHERE tl.processed = 'Y' AND (tl.APInvoice = 'Y' OR tl.expenseinvoice = 'Y') AND tl.C_Invoice_ID IS NULL";
            StringBuilder sqlWhere = new StringBuilder();
            if (_VAB_BusinessPartner_ID != 0)
            {
                sqlWhere.Append(" AND res.VAB_BusinessPartner_ID = " + _VAB_BusinessPartner_ID);
            }

            if (_DateFrom != null && _DateTo != null)
            {
                fromDate = _DateFrom.Value.ToString("dd-MMM-yyyy");
                toDate = _DateTo.Value.ToString("dd-MMM-yyyy");
                sqlWhere.Append(" AND tl.dateexpense between '" + fromDate + "' and '" + toDate + "'");
            }
            else if (_DateFrom != null && _DateTo == null)
            {
                fromDate = _DateFrom.Value.ToString("dd-MMM-yyyy");
                sqlWhere.Append(" AND tl.dateexpense > '" + fromDate + "'");
            }
            else if (_DateFrom == null && _DateTo != null)
            {
                toDate = _DateTo.Value.ToString("dd-MMM-yyyy");
                sqlWhere.Append(" AND tl.dateexpense < '" + toDate + "'");
            }

            if (sqlWhere.Length > 0)
            {
                sql = sqlSelect + sqlWhere.ToString();
            }
            else
            {
                sql = sqlSelect;
            }

            sql = sql + " order by res.VAB_BusinessPartner_id";

            IDataReader idr = null;
            try
            {
                idr = DB.ExecuteReader(sql, null, null);
                while (idr.Read())
                {
                    if (VAB_BusinessPartner_ID.Contains(Util.GetValueOfInt(idr["VAB_BusinessPartner_ID"])))
                    {

                    }
                    else
                    {
                        VAB_BusinessPartner_ID.Add(Util.GetValueOfInt(idr["VAB_BusinessPartner_ID"]));
                        VAdvantage.Model.X_S_TimeExpenseLine tLine = new VAdvantage.Model.X_S_TimeExpenseLine(GetCtx(), Util.GetValueOfInt(idr["s_timeexpenseline_id"]), null);
                        VAdvantage.Model.X_S_TimeExpense tExp = new VAdvantage.Model.X_S_TimeExpense(GetCtx(), Util.GetValueOfInt(tLine.GetS_TimeExpense_ID()), null);
                        int C_Invoice_ID = GenerateInvoice(tLine, tExp);

                        BPInvoice.Add(Util.GetValueOfInt(idr["VAB_BusinessPartner_ID"]), C_Invoice_ID);
                        invoices.Add(C_Invoice_ID);
                    }
                }
                if (idr != null)
                {
                    idr.Close();
                    idr = null;
                }

                if (BPInvoice.Count > 0)
                {
                    foreach (KeyValuePair<int, int> pair in BPInvoice)
                    {
                        sqlWhere = new StringBuilder();
                        sqlWhere.Append(" AND res.VAB_BusinessPartner_ID = " + Util.GetValueOfInt(pair.Key));
                        if (_DateFrom != null && _DateTo != null)
                        {
                            fromDate = _DateFrom.Value.ToString("dd-MMM-yyyy");
                            toDate = _DateTo.Value.ToString("dd-MMM-yyyy");
                            sqlWhere.Append(" AND tl.dateexpense between '" + fromDate + "' and '" + toDate + "'");
                        }
                        else if (_DateFrom != null && _DateTo == null)
                        {
                            fromDate = _DateFrom.Value.ToString("dd-MMM-yyyy");
                            sqlWhere.Append(" AND tl.dateexpense > '" + fromDate + "'");
                        }
                        else if (_DateFrom == null && _DateTo != null)
                        {
                            toDate = _DateTo.Value.ToString("dd-MMM-yyyy");
                            sqlWhere.Append(" AND tl.dateexpense < '" + toDate + "'");
                        }
                        sql = "";
                        if (sqlWhere.Length > 0)
                        {
                            sql = sqlSelect + sqlWhere.ToString();
                        }

                        DataSet ds = DB.ExecuteDataset(sql, null, null);
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    CreateLine(Util.GetValueOfInt(ds.Tables[0].Rows[j]["S_TimeExpenseLine_ID"]), Util.GetValueOfInt(pair.Value));
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                if (idr != null)
                {
                    idr.Close();
                    idr = null;
                }
            }

            string docNo = "";
            for (int i = 0; i < invoices.Count; i++)
            {
                VAdvantage.Model.MInvoice inv = new VAdvantage.Model.MInvoice(GetCtx(), Util.GetValueOfInt(invoices[i]), null);
                docNo = docNo + ", " + inv.GetDocumentNo();
            }
            if (docNo != "")
            {
                docNo = docNo.Remove(0, 2);
            }
            return Msg.GetMsg(GetCtx(), "InvoicesCreated" + " : " + docNo);

            //return Msg.GetMsg(GetCtx(),"ProcessCompleted");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void CreateLine(int S_TimeExpenseLine_ID, int C_Invoice_ID)
        {
            VAdvantage.Model.X_S_TimeExpenseLine tLine = new VAdvantage.Model.X_S_TimeExpenseLine(GetCtx(), S_TimeExpenseLine_ID, null);
            VAdvantage.Model.X_S_TimeExpense tExp = new VAdvantage.Model.X_S_TimeExpense(GetCtx(), Util.GetValueOfInt(tLine.GetS_TimeExpense_ID()), null);

            if (tLine.IsAPInvoice())
            {
                if (Util.GetValueOfInt(tLine.GetM_Product_ID()) != 0)
                {
                    sql = "select max(line) from c_invoiceline where c_invoice_id = " + C_Invoice_ID;
                    int lineNo = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));


                    sql = "select C_Invoiceline_ID from C_InvoiceLine where c_invoice_ID = " + C_Invoice_ID + " and m_product_id = " + tLine.GetM_Product_ID();
                    int C_InvoiceLine_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
                    if (C_InvoiceLine_ID != 0)
                    {

                        sql = "select c_uom_id from c_orderline where c_orderline_id = " + tLine.GetC_OrderLine_ID();
                        int C_UOM_IDTo = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                        sql = "select c_uom_id from m_product where m_product_id = " + tLine.GetM_Product_ID();
                        int C_UOM_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                        Decimal? qty = 0;
                        if (C_UOM_IDTo != 0 && C_UOM_ID != 0)
                        {
                            //qty = MUOMConversion.Convert(C_UOM_ID, C_UOM_IDTo, tLine.GetAPApprovedHrs(), true);
                            qty = VAdvantage.Model.MUOMConversion.ConvertProductTo(GetCtx(), tLine.GetM_Product_ID(), C_UOM_IDTo, tLine.GetAPApprovedHrs());
                        }

                        VAdvantage.Model.MInvoiceLine iLine = new VAdvantage.Model.MInvoiceLine(GetCtx(), C_InvoiceLine_ID, null);
                        iLine.SetQtyEntered(Decimal.Add(iLine.GetQtyEntered(), qty.Value));
                        iLine.SetQtyInvoiced(Decimal.Add(iLine.GetQtyInvoiced(), qty.Value));
                        // iLine.SetTaxAmt(Decimal.Add(iLine.GetTaxAmt(), tLine.GetTaxAmt()));
                        iLine.SetLineNetAmt(Decimal.Multiply(iLine.GetQtyEntered(), iLine.GetPriceEntered()));
                        iLine.SetLineTotalAmt(Decimal.Add(iLine.GetLineNetAmt(), iLine.GetTaxAmt()));
                        if (!iLine.Save())
                        {

                        }
                    }
                    else
                    {
                        lineNo = lineNo + 10;
                        Decimal? price = 0;
                        //sql = "select s_resource_id from s_resource where VAB_BusinessPartner_id = " + tLine.GetVAB_BusinessPartner_ID()
                        //    + " and VAF_UserContact_id = " + tExp.GetVAF_UserContact_ID() + " and m_product_id = " + tLine.GetM_Product_ID() + " and isactive = 'Y'";
                        //sql = "select s_resource_id from  where VAB_BusinessPartner_id = " + tLine.GetVAB_BusinessPartner_ID();



                        sql = "select c_uom_id from c_orderline where c_orderline_id = " + tLine.GetC_OrderLine_ID();
                        int C_UOM_IDTo = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                        sql = "select c_uom_id from m_product where m_product_id = " + tLine.GetM_Product_ID();
                        int C_UOM_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                        Decimal? qty = 0;

                        //qty = MUOMConversion.Convert(C_UOM_ID, C_UOM_IDTo, tLine.GetAPApprovedHrs(), true);

                        qty = VAdvantage.Model.MUOMConversion.ConvertProductTo(GetCtx(), tLine.GetM_Product_ID(), C_UOM_IDTo, tLine.GetAPApprovedHrs());
                        //Decimal? qty2 = MUOMConversion.ConvertProductFrom(GetCtx(), tLine.GetM_Product_ID(), C_UOM_IDTo, tLine.GetAPApprovedHrs());
                        //Decimal? qty3 = MUOMConversion.GetProductRateTo(GetCtx(), tLine.GetM_Product_ID(), C_UOM_IDTo);
                        //Decimal? qty4 = MUOMConversion.GetProductRateFrom(GetCtx(), tLine.GetM_Product_ID(), C_UOM_ID);


                        int S_Resource_ID = Util.GetValueOfInt(tLine.GetS_Resource_ID());

                        if (S_Resource_ID != 0)
                        {
                            sql = "select HourlyRate from s_resource where s_resource_id = " + S_Resource_ID;
                            price = Util.GetValueOfDecimal(DB.ExecuteScalar(sql, null, null));
                            price = VAdvantage.Model.MUOMConversion.ConvertProductFrom(GetCtx(), tLine.GetM_Product_ID(), C_UOM_IDTo, price.Value);
                        }
                        else
                        {
                            sql = "select m_pricelist_version_id from m_pricelist_version where isactive = 'Y' and m_pricelist_id = " + tExp.GetM_PriceList_ID();
                            int plv_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
                            if (plv_ID != 0)
                            {
                                sql = "select pricestd from m_productprice where m_pricelist_version_id = " + plv_ID + " and m_product_ID = " + tLine.GetM_Product_ID();
                                price = Util.GetValueOfDecimal(DB.ExecuteScalar(sql, null, null));
                            }
                        }



                        VAdvantage.Model.MInvoiceLine iLine = new VAdvantage.Model.MInvoiceLine(GetCtx(), 0, null);
                        iLine.SetVAF_Client_ID(GetCtx().GetVAF_Client_ID());
                        iLine.SetVAF_Org_ID(GetCtx().GetVAF_Org_ID());
                        iLine.SetC_Invoice_ID(C_Invoice_ID);
                        iLine.SetC_Tax_ID(tLine.GetC_Tax_ID());
                        iLine.SetC_UOM_ID(tLine.GetC_UOM_ID());
                        iLine.SetDescription(tLine.GetDescription());
                        iLine.SetM_Product_ID(tLine.GetM_Product_ID());
                        iLine.SetQtyEntered(qty);
                        iLine.SetQtyInvoiced(qty);
                        iLine.SetPriceEntered(price);
                        iLine.SetPriceList(price);
                        iLine.SetPriceLimit(price);
                        iLine.SetPriceActual(price);

                        //  iLine.SetTaxAmt(tLine.GetTaxAmt());
                        iLine.SetLineNetAmt(Decimal.Multiply(iLine.GetQtyEntered(), iLine.GetPriceEntered()));
                        iLine.SetLineTotalAmt(Decimal.Add(iLine.GetLineNetAmt(), iLine.GetTaxAmt()));
                        iLine.SetLine(lineNo);
                        if (!iLine.Save())
                        {

                        }
                    }
                    sql = "update S_TimeExpenseLine set C_Invoice_ID = " + C_Invoice_ID + " where S_TimeExpenseLine_ID = " + S_TimeExpenseLine_ID;
                    int res = Util.GetValueOfInt(DB.ExecuteQuery(sql, null, null));
                }
            }

            if (tLine.IsExpenseInvoice())
            {
                if (Util.GetValueOfInt(tLine.GetVAB_Charge_ID()) != 0)
                {
                    sql = "select max(line) from c_invoiceline where c_invoice_id = " + C_Invoice_ID;
                    int lineNo = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                    sql = "select C_Invoiceline_ID from C_InvoiceLine where c_invoice_ID = " + C_Invoice_ID + " and VAB_Charge_ID = " + tLine.GetVAB_Charge_ID() + " and c_tax_id = " + tLine.GetC_Tax_ID();
                    int C_InvoiceLine_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
                    if (C_InvoiceLine_ID != 0)
                    {
                        VAdvantage.Model.MInvoiceLine iLine = new VAdvantage.Model.MInvoiceLine(GetCtx(), C_InvoiceLine_ID, null);
                        iLine.SetPriceEntered(Decimal.Add(tLine.GetApprovedExpenseAmt(), iLine.GetPriceEntered()));
                        iLine.SetPriceActual(Decimal.Add(tLine.GetApprovedExpenseAmt(), iLine.GetPriceActual()));
                        iLine.SetPriceLimit(Decimal.Add(tLine.GetApprovedExpenseAmt(), iLine.GetPriceLimit()));
                        iLine.SetPriceList(Decimal.Add(tLine.GetApprovedExpenseAmt(), iLine.GetPriceList()));
                        // iLine.SetTaxAmt(Decimal.Add(tLine.GetTaxAmt(), iLine.GetTaxAmt()));
                        //  iLine.SetLineNetAmt(Decimal.Multiply(iLine.GetQtyEntered(), iLine.GetPriceEntered()));
                        //  iLine.SetLineTotalAmt(Decimal.Add(iLine.GetLineNetAmt(), iLine.GetTaxAmt()));
                        if (!iLine.Save())
                        {

                        }
                    }
                    else
                    {
                        lineNo = lineNo + 10;
                        VAdvantage.Model.MInvoiceLine iLine = new VAdvantage.Model.MInvoiceLine(GetCtx(), 0, null);
                        iLine.SetVAF_Client_ID(GetCtx().GetVAF_Client_ID());
                        iLine.SetVAF_Org_ID(GetCtx().GetVAF_Org_ID());
                        iLine.SetC_Invoice_ID(C_Invoice_ID);
                        iLine.SetC_Tax_ID(tLine.GetC_Tax_ID());
                        iLine.SetC_UOM_ID(tLine.GetC_UOM_ID());
                        iLine.SetDescription(tLine.GetDescription());
                        iLine.SetVAB_Charge_ID(tLine.GetVAB_Charge_ID());
                        iLine.SetQtyEntered(Decimal.One);
                        iLine.SetQtyInvoiced(Decimal.One);
                        iLine.SetPriceEntered(tLine.GetApprovedExpenseAmt());
                        iLine.SetPriceActual(tLine.GetApprovedExpenseAmt());
                        iLine.SetPriceLimit(tLine.GetApprovedExpenseAmt());
                        iLine.SetPriceList(tLine.GetApprovedExpenseAmt());
                        //   iLine.SetTaxAmt(tLine.GetTaxAmt());
                        //   iLine.SetLineNetAmt(Decimal.Multiply(iLine.GetQtyEntered(), iLine.GetPriceEntered()));
                        //  iLine.SetLineTotalAmt(Decimal.Add(iLine.GetLineNetAmt(), iLine.GetTaxAmt()));
                        iLine.SetLine(lineNo);
                        if (!iLine.Save())
                        {

                        }

                    }

                    sql = "update S_TimeExpenseLine set C_Invoice_ID = " + C_Invoice_ID + " where S_TimeExpenseLine_ID = " + S_TimeExpenseLine_ID;
                    int res = Util.GetValueOfInt(DB.ExecuteQuery(sql, null, null));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tLine"></param>
        private int GenerateInvoice(VAdvantage.Model.X_S_TimeExpenseLine tLine, VAdvantage.Model.X_S_TimeExpense tExp)
        {
            int C_PaymentTerm_ID = 0;
            VAdvantage.Model.X_C_Order ord = null;
            if (tLine.GetC_Order_ID() != 0)
            {
                ord = new VAdvantage.Model.X_C_Order(GetCtx(), tLine.GetC_Order_ID(), null);
            }

            //sql = "select s_resource_id from s_resource where VAB_BusinessPartner_id = " + tLine.GetVAB_BusinessPartner_ID()
            //               + " and VAF_UserContact_id = " + tExp.GetVAF_UserContact_ID() + " and m_product_id = " + tLine.GetM_Product_ID() + " and isactive = 'Y'";
            //int S_Resource_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
            int S_Resource_ID = Util.GetValueOfInt(tLine.GetS_Resource_ID());
            int VAB_Currency_ID = 0;
            int VAB_BusinessPartner_ID = 0;
            if (S_Resource_ID != 0)
            {
                sql = "select VAB_Currency_ID from s_resource where s_resource_id = " + S_Resource_ID;
                VAB_Currency_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                sql = "select VAB_BusinessPartner_ID from s_resource where s_resource_id = " + S_Resource_ID;
                VAB_BusinessPartner_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
            }
            else
            {
                sql = "select VAB_Currency_ID from m_pricelist where isactive = 'Y' and m_pricelist_id = " + tExp.GetM_PriceList_ID();
                VAB_Currency_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
            }

            sql = "select VAB_DocTypes_ID from VAB_DocTypes where docbasetype = 'API' and vaf_client_id = " + GetCtx().GetVAF_Client_ID();
            int VAB_DocTypes_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

            sql = "select VAB_BPart_Location_ID from VAB_BPart_Location where VAB_BusinessPartner_ID = " + VAB_BusinessPartner_ID;
            int VAB_BPart_Location_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

            VAdvantage.Model.X_C_Invoice inv = new VAdvantage.Model.X_C_Invoice(GetCtx(), 0, null);
            inv.SetVAF_Client_ID(GetCtx().GetVAF_Client_ID());
            inv.SetVAF_Org_ID(GetCtx().GetVAF_Org_ID());
            inv.SetVAF_UserContact_ID(tExp.GetVAF_UserContact_ID());
            inv.SetVAB_BusinessPartner_ID(VAB_BusinessPartner_ID);
            inv.SetVAB_BPart_Location_ID(VAB_BPart_Location_ID);
            inv.SetVAB_Currency_ID(VAB_Currency_ID);
            inv.SetVAB_DocTypes_ID(VAB_DocTypes_ID);
            inv.SetVAB_DocTypesTarget_ID(VAB_DocTypes_ID);
            inv.SetDateInvoiced(System.DateTime.Now);
            inv.SetM_PriceList_ID(tExp.GetM_PriceList_ID());
            inv.SetDateAcct(System.DateTime.Now);
            inv.SetIsApproved(true);
            //inv.SetPaymentRule();

            inv.SetIsSOTrx(false);
            //inv.SetSalesRep_ID();
            inv.SetDocAction("CO");
            inv.SetDocStatus("DR");
            if (ord != null)
            {
                inv.SetC_PaymentTerm_ID(ord.GetC_PaymentTerm_ID());
                inv.SetSalesRep_ID(ord.GetSalesRep_ID());
                // inv.SetC_Order_ID(ord.GetC_Order_ID());
                // inv.SetM_PriceList_ID(ord.GetM_PriceList_ID());
            }
            else
            {
                sql = " select c_paymentterm_id from VAB_BusinessPartner where VAB_BusinessPartner_id = " + tLine.GetVAB_BusinessPartner_ID();
                C_PaymentTerm_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));

                if (C_PaymentTerm_ID == 0)
                {
                    sql = "select c_paymentterm_id from c_paymentterm where isdefault = 'Y' and vaf_client_id= " + GetCtx().GetVAF_Client_ID();
                    C_PaymentTerm_ID = Util.GetValueOfInt(DB.ExecuteScalar(sql, null, null));
                }
                inv.SetC_PaymentTerm_ID(C_PaymentTerm_ID);
                inv.SetSalesRep_ID(tExp.GetSalesRep_ID());
            }

            if (!inv.Save())
            {
                log.SaveError("InvoiceNotSaved", "InvoiceNotSaved");
                return 0;
            }
            return inv.GetC_Invoice_ID();
        }



    }
}
