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
/** Generated Model for VAB_AccountSubGroup
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAB_AccountSubGroup : PO
{
public X_VAB_AccountSubGroup (Context ctx, int VAB_AccountSubGroup_ID, Trx trxName) : base (ctx, VAB_AccountSubGroup_ID, trxName)
{
/** if (VAB_AccountSubGroup_ID == 0)
{
SetVAB_AccountGroup_ID (0);
SetVAB_AccountSubGroup_ID (0);
}
 */
}
public X_VAB_AccountSubGroup (Ctx ctx, int VAB_AccountSubGroup_ID, Trx trxName) : base (ctx, VAB_AccountSubGroup_ID, trxName)
{
/** if (VAB_AccountSubGroup_ID == 0)
{
SetVAB_AccountGroup_ID (0);
SetVAB_AccountSubGroup_ID (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_AccountSubGroup (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_AccountSubGroup (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_AccountSubGroup (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAB_AccountSubGroup()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27634044907810L;
/** Last Updated Timestamp 11/3/2012 10:43:11 AM */
public static long updatedMS = 1351919591021L;
/** VAF_TableView_ID=1000375 */
public static int Table_ID;
 // =1000375;

/** TableName=VAB_AccountSubGroup */
public static String Table_Name="VAB_AccountSubGroup";

protected static KeyNamePair model;
protected Decimal accessLevel = new Decimal(7);
/** AccessLevel
@return 7 - System - Client - Org 
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
StringBuilder sb = new StringBuilder ("X_VAB_AccountSubGroup[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set VAB_AccountGroup_ID.
@param VAB_AccountGroup_ID VAB_AccountGroup_ID */
public void SetVAB_AccountGroup_ID (int VAB_AccountGroup_ID)
{
if (VAB_AccountGroup_ID < 1) throw new ArgumentException ("VAB_AccountGroup_ID is mandatory.");
Set_ValueNoCheck ("VAB_AccountGroup_ID", VAB_AccountGroup_ID);
}
/** Get VAB_AccountGroup_ID.
@return VAB_AccountGroup_ID */
public int GetVAB_AccountGroup_ID() 
{
Object ii = Get_Value("VAB_AccountGroup_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set VAB_AccountSubGroup_ID.
@param VAB_AccountSubGroup_ID VAB_AccountSubGroup_ID */
public void SetVAB_AccountSubGroup_ID (int VAB_AccountSubGroup_ID)
{
if (VAB_AccountSubGroup_ID < 1) throw new ArgumentException ("VAB_AccountSubGroup_ID is mandatory.");
Set_ValueNoCheck ("VAB_AccountSubGroup_ID", VAB_AccountSubGroup_ID);
}
/** Get VAB_AccountSubGroup_ID.
@return VAB_AccountSubGroup_ID */
public int GetVAB_AccountSubGroup_ID() 
{
Object ii = Get_Value("VAB_AccountSubGroup_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID)
{
if (Export_ID != null && Export_ID.Length > 50)
{
log.Warning("Length > 50 - truncated");
Export_ID = Export_ID.Substring(0,50);
}
Set_ValueNoCheck ("Export_ID", Export_ID);
}
/** Get Export.
@return Export */
public String GetExport_ID() 
{
return (String)Get_Value("Export_ID");
}
/** Set Line No.
@param Line Unique line for this document */
public void SetLine (int Line)
{
Set_Value ("Line", Line);
}
/** Get Line No.
@return Unique line for this document */
public int GetLine() 
{
Object ii = Get_Value("Line");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Name.
@param Name Name */
public void SetName (String Name)
{
if (Name != null && Name.Length > 200)
{
log.Warning("Length > 200 - truncated");
Name = Name.Substring(0,200);
}
Set_Value ("Name", Name);
}
/** Get Name.
@return Name */
public String GetName() 
{
return (String)Get_Value("Name");
}
/** Set Print Text.
@param PrintName The label text to be printed on a document or correspondence. */
public void SetPrintName (String PrintName)
{
if (PrintName != null && PrintName.Length > 200)
{
log.Warning("Length > 200 - truncated");
PrintName = PrintName.Substring(0,200);
}
Set_Value ("PrintName", PrintName);
}
/** Get Print Text.
@return The label text to be printed on a document or correspondence. */
public String GetPrintName() 
{
return (String)Get_Value("PrintName");
}
/** Set Show In Balance Sheet.
@param ShowInBalanceSheet Show In Balance Sheet */
public void SetShowInBalanceSheet (Boolean ShowInBalanceSheet)
{
Set_Value ("ShowInBalanceSheet", ShowInBalanceSheet);
}
/** Get Show In Balance Sheet.
@return Show In Balance Sheet */
public Boolean IsShowInBalanceSheet() 
{
Object oo = Get_Value("ShowInBalanceSheet");
if (oo != null) 
{
 if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
 return "Y".Equals(oo);
}
return false;
}
/** Set Show In Cash Flow.
@param ShowInCashFlow Show In Cash Flow */
public void SetShowInCashFlow (Boolean ShowInCashFlow)
{
Set_Value ("ShowInCashFlow", ShowInCashFlow);
}
/** Get Show In Cash Flow.
@return Show In Cash Flow */
public Boolean IsShowInCashFlow() 
{
Object oo = Get_Value("ShowInCashFlow");
if (oo != null) 
{
 if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
 return "Y".Equals(oo);
}
return false;
}
/** Set Show In Profit Loss.
@param ShowInProfitLoss Show In Profit Loss */
public void SetShowInProfitLoss (Boolean ShowInProfitLoss)
{
Set_Value ("ShowInProfitLoss", ShowInProfitLoss);
}
/** Get Show In Profit Loss.
@return Show In Profit Loss */
public Boolean IsShowInProfitLoss() 
{
Object oo = Get_Value("ShowInProfitLoss");
if (oo != null) 
{
 if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
 return "Y".Equals(oo);
}
return false;
}
/** Set Search Key.
@param Value Search key for the record in the format required - must be unique */
public void SetValue (String Value)
{
if (Value != null && Value.Length > 50)
{
log.Warning("Length > 50 - truncated");
Value = Value.Substring(0,50);
}
Set_Value ("Value", Value);
}
/** Get Search Key.
@return Search key for the record in the format required - must be unique */
public String GetValue() 
{
return (String)Get_Value("Value");
}
}

}
