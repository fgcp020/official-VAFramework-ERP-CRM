namespace VAdvantage.Model
{

/** Generated Model - DO NOT CHANGE */
using System;
using System.Text;
using VAdvantage.DataBase;
using VAdvantage.Common;
using VAdvantage.Classes;
using VAdvantage.Process;
using VAdvantage.Model;
using VAdvantage.Utility;
using System.Data;
/** Generated Model for C_BP_Customer_Acct
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_C_BP_Customer_Acct : PO
{
public X_C_BP_Customer_Acct (Context ctx, int C_BP_Customer_Acct_ID, Trx trxName) : base (ctx, C_BP_Customer_Acct_ID, trxName)
{
/** if (C_BP_Customer_Acct_ID == 0)
{
SetVAB_AccountBook_ID (0);
SetVAB_BusinessPartner_ID (0);
SetC_Prepayment_Acct (0);
SetC_Receivable_Acct (0);
SetC_Receivable_Services_Acct (0);
}
 */
}
public X_C_BP_Customer_Acct (Ctx ctx, int C_BP_Customer_Acct_ID, Trx trxName) : base (ctx, C_BP_Customer_Acct_ID, trxName)
{
/** if (C_BP_Customer_Acct_ID == 0)
{
SetVAB_AccountBook_ID (0);
SetVAB_BusinessPartner_ID (0);
SetC_Prepayment_Acct (0);
SetC_Receivable_Acct (0);
SetC_Receivable_Services_Acct (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_C_BP_Customer_Acct (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_C_BP_Customer_Acct (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_C_BP_Customer_Acct (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_C_BP_Customer_Acct()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514369930L;
/** Last Updated Timestamp 7/29/2010 1:07:33 PM */
public static long updatedMS = 1280389053141L;
/** VAF_TableView_ID=183 */
public static int Table_ID;
 // =183;

/** TableName=C_BP_Customer_Acct */
public static String Table_Name="C_BP_Customer_Acct";

protected static KeyNamePair model;
protected Decimal accessLevel = new Decimal(3);
/** AccessLevel
@return 3 - Client - Org 
*/
protected override int Get_AccessLevel()
{
return Convert.ToInt32(accessLevel.ToString());
}
/** Load Meta Data
@param ctx context
@return PO Info
*/
protected override POInfo InitPO (Ctx ctx)
{
POInfo poi = POInfo.GetPOInfo (ctx, Table_ID);
return poi;
}
/** Load Meta Data
@param ctx context
@return PO Info
*/
protected override POInfo InitPO(Context ctx)
{
POInfo poi = POInfo.GetPOInfo (ctx, Table_ID);
return poi;
}
/** Info
@return info
*/
public override String ToString()
{
StringBuilder sb = new StringBuilder ("X_C_BP_Customer_Acct[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Accounting Schema.
@param VAB_AccountBook_ID Rules for accounting */
public void SetVAB_AccountBook_ID (int VAB_AccountBook_ID)
{
if (VAB_AccountBook_ID < 1) throw new ArgumentException ("VAB_AccountBook_ID is mandatory.");
Set_ValueNoCheck ("VAB_AccountBook_ID", VAB_AccountBook_ID);
}
/** Get Accounting Schema.
@return Rules for accounting */
public int GetVAB_AccountBook_ID() 
{
Object ii = Get_Value("VAB_AccountBook_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Get Record ID/ColumnName
@return ID/ColumnName pair */
public KeyNamePair GetKeyNamePair() 
{
return new KeyNamePair(Get_ID(), GetVAB_AccountBook_ID().ToString());
}
/** Set Business Partner.
@param VAB_BusinessPartner_ID Identifies a Business Partner */
public void SetVAB_BusinessPartner_ID (int VAB_BusinessPartner_ID)
{
if (VAB_BusinessPartner_ID < 1) throw new ArgumentException ("VAB_BusinessPartner_ID is mandatory.");
Set_ValueNoCheck ("VAB_BusinessPartner_ID", VAB_BusinessPartner_ID);
}
/** Get Business Partner.
@return Identifies a Business Partner */
public int GetVAB_BusinessPartner_ID() 
{
Object ii = Get_Value("VAB_BusinessPartner_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Customer Prepayment.
@param C_Prepayment_Acct Account for customer prepayments */
public void SetC_Prepayment_Acct (int C_Prepayment_Acct)
{
Set_Value ("C_Prepayment_Acct", C_Prepayment_Acct);
}
/** Get Customer Prepayment.
@return Account for customer prepayments */
public int GetC_Prepayment_Acct() 
{
Object ii = Get_Value("C_Prepayment_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Customer Receivables.
@param C_Receivable_Acct Account for Customer Receivables */
public void SetC_Receivable_Acct (int C_Receivable_Acct)
{
Set_Value ("C_Receivable_Acct", C_Receivable_Acct);
}
/** Get Customer Receivables.
@return Account for Customer Receivables */
public int GetC_Receivable_Acct() 
{
Object ii = Get_Value("C_Receivable_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Receivable Services.
@param C_Receivable_Services_Acct Customer Accounts Receivables Services Account */
public void SetC_Receivable_Services_Acct (int C_Receivable_Services_Acct)
{
Set_Value ("C_Receivable_Services_Acct", C_Receivable_Services_Acct);
}
/** Get Receivable Services.
@return Customer Accounts Receivables Services Account */
public int GetC_Receivable_Services_Acct() 
{
Object ii = Get_Value("C_Receivable_Services_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}
