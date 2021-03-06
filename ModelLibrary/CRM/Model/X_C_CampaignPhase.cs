namespace VAdvantage.Model
{

/** Generated Model - DO NOT CHANGE */
using System;
using System.Text;
using VAdvantage.DataBase;
//using VAdvantage.Common;
using VAdvantage.Classes;
using VAdvantage.Process;
using VAdvantage.Model;
using VAdvantage.Utility;
using System.Data;
/** Generated Model for C_CampaignPhase
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_C_CampaignPhase : PO
{
public X_C_CampaignPhase (Context ctx, int C_CampaignPhase_ID, Trx trxName) : base (ctx, C_CampaignPhase_ID, trxName)
{
/** if (C_CampaignPhase_ID == 0)
{
SetC_CampaignPhase_ID (0);
SetC_CampaignType_ID (0);
SetName (null);
SetSeqNo (0);	// @SQL=SELECT NVL(MAX(SeqNo),0)+10 AS DefaultValue FROM C_CampaignPhase WHERE C_CampaignType_ID=@C_CampaignType_ID@
}
 */
}
public X_C_CampaignPhase (Ctx ctx, int C_CampaignPhase_ID, Trx trxName) : base (ctx, C_CampaignPhase_ID, trxName)
{
/** if (C_CampaignPhase_ID == 0)
{
SetC_CampaignPhase_ID (0);
SetC_CampaignType_ID (0);
SetName (null);
SetSeqNo (0);	// @SQL=SELECT NVL(MAX(SeqNo),0)+10 AS DefaultValue FROM C_CampaignPhase WHERE C_CampaignType_ID=@C_CampaignType_ID@
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_C_CampaignPhase (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_C_CampaignPhase (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_C_CampaignPhase (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_C_CampaignPhase()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27610475605771L;
/** Last Updated Timestamp 2/4/2012 3:41:28 PM */
public static long updatedMS = 1328350288982L;
/** AD_Table_ID=1000259 */
public static int Table_ID;
 // =1000259;

/** TableName=C_CampaignPhase */
public static String Table_Name="C_CampaignPhase";

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
StringBuilder sb = new StringBuilder ("X_C_CampaignPhase[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set C_CampaignPhase_ID.
@param C_CampaignPhase_ID C_CampaignPhase_ID */
public void SetC_CampaignPhase_ID (int C_CampaignPhase_ID)
{
if (C_CampaignPhase_ID < 1) throw new ArgumentException ("C_CampaignPhase_ID is mandatory.");
Set_ValueNoCheck ("C_CampaignPhase_ID", C_CampaignPhase_ID);
}
/** Get C_CampaignPhase_ID.
@return C_CampaignPhase_ID */
public int GetC_CampaignPhase_ID() 
{
Object ii = Get_Value("C_CampaignPhase_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set C_CampaignType_ID.
@param C_CampaignType_ID C_CampaignType_ID */
public void SetC_CampaignType_ID (int C_CampaignType_ID)
{
if (C_CampaignType_ID < 1) throw new ArgumentException ("C_CampaignType_ID is mandatory.");
Set_ValueNoCheck ("C_CampaignType_ID", C_CampaignType_ID);
}
/** Get C_CampaignType_ID.
@return C_CampaignType_ID */
public int GetC_CampaignType_ID() 
{
Object ii = Get_Value("C_CampaignType_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
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
/** Set Sequence.
@param SeqNo Method of ordering elements;
 lowest number comes first */
public void SetSeqNo (int SeqNo)
{
Set_Value ("SeqNo", SeqNo);
}
/** Get Sequence.
@return Method of ordering elements;
 lowest number comes first */
public int GetSeqNo() 
{
Object ii = Get_Value("SeqNo");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}
