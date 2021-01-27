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
/** Generated Model for VAVARC_KPIRights
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAVARC_KPIRights : PO
{
public X_VAVARC_KPIRights (Context ctx, int VAVARC_KPIRights_ID, Trx trxName) : base (ctx, VAVARC_KPIRights_ID, trxName)
{
/** if (VAVARC_KPIRights_ID == 0)
{
SetVAVARC_KPIRights_ID (0);
SetVARC_KPI_ID (0);
}
 */
}
public X_VAVARC_KPIRights (Ctx ctx, int VAVARC_KPIRights_ID, Trx trxName) : base (ctx, VAVARC_KPIRights_ID, trxName)
{
/** if (VAVARC_KPIRights_ID == 0)
{
SetVAVARC_KPIRights_ID (0);
SetVARC_KPI_ID (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAVARC_KPIRights (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAVARC_KPIRights (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAVARC_KPIRights (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAVARC_KPIRights()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27634330740979L;
/** Last Updated Timestamp 11/6/2012 6:07:04 PM */
public static long updatedMS = 1352205424190L;
/** VAF_TableView_ID=1000229 */
public static int Table_ID;
 // =1000229;

/** TableName=VAVARC_KPIRights */
public static String Table_Name="VAVARC_KPIRights";

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
StringBuilder sb = new StringBuilder ("X_VAVARC_KPIRights[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Role.
@param VAF_Role_ID Responsibility Role */
public void SetVAF_Role_ID (int VAF_Role_ID)
{
if (VAF_Role_ID <= 0) Set_Value ("VAF_Role_ID", null);
else
Set_Value ("VAF_Role_ID", VAF_Role_ID);
}
/** Get Role.
@return Responsibility Role */
public int GetVAF_Role_ID() 
{
Object ii = Get_Value("VAF_Role_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set User/Contact.
@param VAF_UserContact_ID User within the system - Internal or Customer/Prospect Contact. */
public void SetVAF_UserContact_ID (int VAF_UserContact_ID)
{
if (VAF_UserContact_ID <= 0) Set_Value ("VAF_UserContact_ID", null);
else
Set_Value ("VAF_UserContact_ID", VAF_UserContact_ID);
}
/** Get User/Contact.
@return User within the system - Internal or Customer/Prospect Contact. */
public int GetVAF_UserContact_ID() 
{
Object ii = Get_Value("VAF_UserContact_ID");
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
/** Set KPI Access.
@param VAVARC_KPIRights_ID KPI Access */
public void SetVAVARC_KPIRights_ID (int VAVARC_KPIRights_ID)
{
if (VAVARC_KPIRights_ID < 1) throw new ArgumentException ("VAVARC_KPIRights_ID is mandatory.");
Set_ValueNoCheck ("VAVARC_KPIRights_ID", VAVARC_KPIRights_ID);
}
/** Get KPI Access.
@return KPI Access */
public int GetVAVARC_KPIRights_ID() 
{
Object ii = Get_Value("VAVARC_KPIRights_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set KPI.
@param VARC_KPI_ID KPI */
public void SetVARC_KPI_ID (int VARC_KPI_ID)
{
if (VARC_KPI_ID < 1) throw new ArgumentException ("VARC_KPI_ID is mandatory.");
Set_ValueNoCheck ("VARC_KPI_ID", VARC_KPI_ID);
}
/** Get KPI.
@return KPI */
public int GetVARC_KPI_ID() 
{
Object ii = Get_Value("VARC_KPI_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}