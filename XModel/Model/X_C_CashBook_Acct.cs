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
/** Generated Model for VAB_CashBook_Acct
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAB_CashBook_Acct : PO
{
public X_VAB_CashBook_Acct (Context ctx, int VAB_CashBook_Acct_ID, Trx trxName) : base (ctx, VAB_CashBook_Acct_ID, trxName)
{
/** if (VAB_CashBook_Acct_ID == 0)
{
SetCB_Asset_Acct (0);
SetCB_CashTransfer_Acct (0);
SetCB_Differences_Acct (0);
SetCB_Expense_Acct (0);
SetCB_Receipt_Acct (0);
SetVAB_AccountBook_ID (0);
SetVAB_CashBook_ID (0);
}
 */
}
public X_VAB_CashBook_Acct (Ctx ctx, int VAB_CashBook_Acct_ID, Trx trxName) : base (ctx, VAB_CashBook_Acct_ID, trxName)
{
/** if (VAB_CashBook_Acct_ID == 0)
{
SetCB_Asset_Acct (0);
SetCB_CashTransfer_Acct (0);
SetCB_Differences_Acct (0);
SetCB_Expense_Acct (0);
SetCB_Receipt_Acct (0);
SetVAB_AccountBook_ID (0);
SetVAB_CashBook_ID (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_CashBook_Acct (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_CashBook_Acct (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_CashBook_Acct (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAB_CashBook_Acct()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514371090L;
/** Last Updated Timestamp 7/29/2010 1:07:34 PM */
public static long updatedMS = 1280389054301L;
/** VAF_TableView_ID=409 */
public static int Table_ID;
 // =409;

/** TableName=VAB_CashBook_Acct */
public static String Table_Name="VAB_CashBook_Acct";

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
StringBuilder sb = new StringBuilder ("X_VAB_CashBook_Acct[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Cash Book Asset.
@param CB_Asset_Acct Cash Book Asset Account */
public void SetCB_Asset_Acct (int CB_Asset_Acct)
{
Set_Value ("CB_Asset_Acct", CB_Asset_Acct);
}
/** Get Cash Book Asset.
@return Cash Book Asset Account */
public int GetCB_Asset_Acct() 
{
Object ii = Get_Value("CB_Asset_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Cash Transfer.
@param CB_CashTransfer_Acct Cash Transfer Clearing Account */
public void SetCB_CashTransfer_Acct (int CB_CashTransfer_Acct)
{
Set_Value ("CB_CashTransfer_Acct", CB_CashTransfer_Acct);
}
/** Get Cash Transfer.
@return Cash Transfer Clearing Account */
public int GetCB_CashTransfer_Acct() 
{
Object ii = Get_Value("CB_CashTransfer_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Cash Book Differences.
@param CB_Differences_Acct Cash Book Differences Account */
public void SetCB_Differences_Acct (int CB_Differences_Acct)
{
Set_Value ("CB_Differences_Acct", CB_Differences_Acct);
}
/** Get Cash Book Differences.
@return Cash Book Differences Account */
public int GetCB_Differences_Acct() 
{
Object ii = Get_Value("CB_Differences_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Cash Book Expense.
@param CB_Expense_Acct Cash Book Expense Account */
public void SetCB_Expense_Acct (int CB_Expense_Acct)
{
Set_Value ("CB_Expense_Acct", CB_Expense_Acct);
}
/** Get Cash Book Expense.
@return Cash Book Expense Account */
public int GetCB_Expense_Acct() 
{
Object ii = Get_Value("CB_Expense_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Cash Book Receipt.
@param CB_Receipt_Acct Cash Book Receipts Account */
public void SetCB_Receipt_Acct (int CB_Receipt_Acct)
{
Set_Value ("CB_Receipt_Acct", CB_Receipt_Acct);
}
/** Get Cash Book Receipt.
@return Cash Book Receipts Account */
public int GetCB_Receipt_Acct() 
{
Object ii = Get_Value("CB_Receipt_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
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
/** Set Cash Book.
@param VAB_CashBook_ID Cash Book for recording petty cash transactions */
public void SetVAB_CashBook_ID (int VAB_CashBook_ID)
{
if (VAB_CashBook_ID < 1) throw new ArgumentException ("VAB_CashBook_ID is mandatory.");
Set_ValueNoCheck ("VAB_CashBook_ID", VAB_CashBook_ID);
}
/** Get Cash Book.
@return Cash Book for recording petty cash transactions */
public int GetVAB_CashBook_ID() 
{
Object ii = Get_Value("VAB_CashBook_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}
