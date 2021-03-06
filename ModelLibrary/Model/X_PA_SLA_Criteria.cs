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
/** Generated Model for PA_SLA_Criteria
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_PA_SLA_Criteria : PO
{
public X_PA_SLA_Criteria (Context ctx, int PA_SLA_Criteria_ID, Trx trxName) : base (ctx, PA_SLA_Criteria_ID, trxName)
{
/** if (PA_SLA_Criteria_ID == 0)
{
SetIsManual (true);	// Y
SetName (null);
SetPA_SLA_Criteria_ID (0);
}
 */
}
public X_PA_SLA_Criteria (Ctx ctx, int PA_SLA_Criteria_ID, Trx trxName) : base (ctx, PA_SLA_Criteria_ID, trxName)
{
/** if (PA_SLA_Criteria_ID == 0)
{
SetIsManual (true);	// Y
SetName (null);
SetPA_SLA_Criteria_ID (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_PA_SLA_Criteria (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_PA_SLA_Criteria (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_PA_SLA_Criteria (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_PA_SLA_Criteria()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514382296L;
/** Last Updated Timestamp 7/29/2010 1:07:45 PM */
public static long updatedMS = 1280389065507L;
/** AD_Table_ID=744 */
public static int Table_ID;
 // =744;

/** TableName=PA_SLA_Criteria */
public static String Table_Name="PA_SLA_Criteria";

protected static KeyNamePair model;
protected Decimal accessLevel = new Decimal(6);
/** AccessLevel
@return 6 - System - Client 
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
StringBuilder sb = new StringBuilder ("X_PA_SLA_Criteria[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Classname.
@param Classname Java Classname */
public void SetClassname (String Classname)
{
if (Classname != null && Classname.Length > 60)
{
log.Warning("Length > 60 - truncated");
Classname = Classname.Substring(0,60);
}
Set_Value ("Classname", Classname);
}
/** Get Classname.
@return Java Classname */
public String GetClassname() 
{
return (String)Get_Value("Classname");
}
/** Set Description.
@param Description Optional short description of the record */
public void SetDescription (String Description)
{
if (Description != null && Description.Length > 255)
{
log.Warning("Length > 255 - truncated");
Description = Description.Substring(0,255);
}
Set_Value ("Description", Description);
}
/** Get Description.
@return Optional short description of the record */
public String GetDescription() 
{
return (String)Get_Value("Description");
}
/** Set Comment.
@param Help Comment, Help or Hint */
public void SetHelp (String Help)
{
if (Help != null && Help.Length > 2000)
{
log.Warning("Length > 2000 - truncated");
Help = Help.Substring(0,2000);
}
Set_Value ("Help", Help);
}
/** Get Comment.
@return Comment, Help or Hint */
public String GetHelp() 
{
return (String)Get_Value("Help");
}
/** Set Manual.
@param IsManual This is a manual process */
public void SetIsManual (Boolean IsManual)
{
Set_Value ("IsManual", IsManual);
}
/** Get Manual.
@return This is a manual process */
public Boolean IsManual() 
{
Object oo = Get_Value("IsManual");
if (oo != null) 
{
 if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
 return "Y".Equals(oo);
}
return false;
}
/** Set Name.
@param Name Alphanumeric identifier of the entity */
public void SetName (String Name)
{
if (Name == null) throw new ArgumentException ("Name is mandatory.");
if (Name.Length > 60)
{
log.Warning("Length > 60 - truncated");
Name = Name.Substring(0,60);
}
Set_Value ("Name", Name);
}
/** Get Name.
@return Alphanumeric identifier of the entity */
public String GetName() 
{
return (String)Get_Value("Name");
}
/** Get Record ID/ColumnName
@return ID/ColumnName pair */
public KeyNamePair GetKeyNamePair() 
{
return new KeyNamePair(Get_ID(), GetName());
}
/** Set SLA Criteria.
@param PA_SLA_Criteria_ID Service Level Agreement Criteria */
public void SetPA_SLA_Criteria_ID (int PA_SLA_Criteria_ID)
{
if (PA_SLA_Criteria_ID < 1) throw new ArgumentException ("PA_SLA_Criteria_ID is mandatory.");
Set_ValueNoCheck ("PA_SLA_Criteria_ID", PA_SLA_Criteria_ID);
}
/** Get SLA Criteria.
@return Service Level Agreement Criteria */
public int GetPA_SLA_Criteria_ID() 
{
Object ii = Get_Value("PA_SLA_Criteria_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}
