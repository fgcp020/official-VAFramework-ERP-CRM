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
/** Generated Model for VAB_Currency_Acct
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAB_Currency_Acct : PO
{
public X_VAB_Currency_Acct (Context ctx, int VAB_Currency_Acct_ID, Trx trxName) : base (ctx, VAB_Currency_Acct_ID, trxName)
{
/** if (VAB_Currency_Acct_ID == 0)
{
SetVAB_AccountBook_ID (0);
SetVAB_Currency_ID (0);
SetRealizedGain_Acct (0);
SetRealizedLoss_Acct (0);
SetUnrealizedGain_Acct (0);
SetUnrealizedLoss_Acct (0);
}
 */
}
public X_VAB_Currency_Acct (Ctx ctx, int VAB_Currency_Acct_ID, Trx trxName) : base (ctx, VAB_Currency_Acct_ID, trxName)
{
/** if (VAB_Currency_Acct_ID == 0)
{
SetVAB_AccountBook_ID (0);
SetVAB_Currency_ID (0);
SetRealizedGain_Acct (0);
SetRealizedLoss_Acct (0);
SetUnrealizedGain_Acct (0);
SetUnrealizedLoss_Acct (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_Currency_Acct (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_Currency_Acct (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_Currency_Acct (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAB_Currency_Acct()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514371545L;
/** Last Updated Timestamp 7/29/2010 1:07:34 PM */
public static long updatedMS = 1280389054756L;
/** VAF_TableView_ID=638 */
public static int Table_ID;
 // =638;

/** TableName=VAB_Currency_Acct */
public static String Table_Name="VAB_Currency_Acct";

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
StringBuilder sb = new StringBuilder ("X_VAB_Currency_Acct[").Append(Get_ID()).Append("]");
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
/** Set Currency.
@param VAB_Currency_ID The Currency for this record */
public void SetVAB_Currency_ID (int VAB_Currency_ID)
{
if (VAB_Currency_ID < 1) throw new ArgumentException ("VAB_Currency_ID is mandatory.");
Set_ValueNoCheck ("VAB_Currency_ID", VAB_Currency_ID);
}
/** Get Currency.
@return The Currency for this record */
public int GetVAB_Currency_ID() 
{
Object ii = Get_Value("VAB_Currency_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Realized Gain Acct.
@param RealizedGain_Acct Realized Gain Account */
public void SetRealizedGain_Acct (int RealizedGain_Acct)
{
Set_Value ("RealizedGain_Acct", RealizedGain_Acct);
}
/** Get Realized Gain Acct.
@return Realized Gain Account */
public int GetRealizedGain_Acct() 
{
Object ii = Get_Value("RealizedGain_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Realized Loss Acct.
@param RealizedLoss_Acct Realized Loss Account */
public void SetRealizedLoss_Acct (int RealizedLoss_Acct)
{
Set_Value ("RealizedLoss_Acct", RealizedLoss_Acct);
}
/** Get Realized Loss Acct.
@return Realized Loss Account */
public int GetRealizedLoss_Acct() 
{
Object ii = Get_Value("RealizedLoss_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Unrealized Gain Acct.
@param UnrealizedGain_Acct Unrealized Gain Account for currency revaluation */
public void SetUnrealizedGain_Acct (int UnrealizedGain_Acct)
{
Set_Value ("UnrealizedGain_Acct", UnrealizedGain_Acct);
}
/** Get Unrealized Gain Acct.
@return Unrealized Gain Account for currency revaluation */
public int GetUnrealizedGain_Acct() 
{
Object ii = Get_Value("UnrealizedGain_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Unrealized Loss Acct.
@param UnrealizedLoss_Acct Unrealized Loss Account for currency revaluation */
public void SetUnrealizedLoss_Acct (int UnrealizedLoss_Acct)
{
Set_Value ("UnrealizedLoss_Acct", UnrealizedLoss_Acct);
}
/** Get Unrealized Loss Acct.
@return Unrealized Loss Account for currency revaluation */
public int GetUnrealizedLoss_Acct() 
{
Object ii = Get_Value("UnrealizedLoss_Acct");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}
