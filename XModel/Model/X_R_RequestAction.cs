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
/** Generated Model for VAR_Req_History
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAR_Req_History : PO
{
public X_VAR_Req_History (Context ctx, int VAR_Req_History_ID, Trx trxName) : base (ctx, VAR_Req_History_ID, trxName)
{
/** if (VAR_Req_History_ID == 0)
{
SetVAR_Req_History_ID (0);
SetVAR_Request_ID (0);
}
 */
}
public X_VAR_Req_History (Ctx ctx, int VAR_Req_History_ID, Trx trxName) : base (ctx, VAR_Req_History_ID, trxName)
{
/** if (VAR_Req_History_ID == 0)
{
SetVAR_Req_History_ID (0);
SetVAR_Request_ID (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAR_Req_History (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAR_Req_History (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAR_Req_History (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAR_Req_History()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514383158L;
/** Last Updated Timestamp 7/29/2010 1:07:46 PM */
public static long updatedMS = 1280389066369L;
/** VAF_TableView_ID=418 */
public static int Table_ID;
 // =418;

/** TableName=VAR_Req_History */
public static String Table_Name="VAR_Req_History";

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
StringBuilder sb = new StringBuilder ("X_VAR_Req_History[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Role.
@param VAF_Role_ID Responsibility Role */
public void SetVAF_Role_ID (int VAF_Role_ID)
{
if (VAF_Role_ID <= 0) Set_ValueNoCheck ("VAF_Role_ID", null);
else
Set_ValueNoCheck ("VAF_Role_ID", VAF_Role_ID);
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
@param VAF_UserContact_ID User within the system - Internal or Business Partner Contact */
public void SetVAF_UserContact_ID (int VAF_UserContact_ID)
{
if (VAF_UserContact_ID <= 0) Set_ValueNoCheck ("VAF_UserContact_ID", null);
else
Set_ValueNoCheck ("VAF_UserContact_ID", VAF_UserContact_ID);
}
/** Get User/Contact.
@return User within the system - Internal or Business Partner Contact */
public int GetVAF_UserContact_ID() 
{
Object ii = Get_Value("VAF_UserContact_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Asset.
@param VAA_Asset_ID Asset used internally or by customers */
public void SetA_Asset_ID (int VAA_Asset_ID)
{
if (VAA_Asset_ID <= 0) Set_ValueNoCheck ("VAA_Asset_ID", null);
else
Set_ValueNoCheck ("VAA_Asset_ID", VAA_Asset_ID);
}
/** Get Asset.
@return Asset used internally or by customers */
public int GetA_Asset_ID() 
{
Object ii = Get_Value("VAA_Asset_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Activity.
@param VAB_BillingCode_ID Business Activity */
public void SetVAB_BillingCode_ID (int VAB_BillingCode_ID)
{
if (VAB_BillingCode_ID <= 0) Set_ValueNoCheck ("VAB_BillingCode_ID", null);
else
Set_ValueNoCheck ("VAB_BillingCode_ID", VAB_BillingCode_ID);
}
/** Get Activity.
@return Business Activity */
public int GetVAB_BillingCode_ID() 
{
Object ii = Get_Value("VAB_BillingCode_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Business Partner.
@param VAB_BusinessPartner_ID Identifies a Business Partner */
public void SetVAB_BusinessPartner_ID (int VAB_BusinessPartner_ID)
{
if (VAB_BusinessPartner_ID <= 0) Set_ValueNoCheck ("VAB_BusinessPartner_ID", null);
else
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
/** Set Invoice.
@param VAB_Invoice_ID Invoice Identifier */
public void SetVAB_Invoice_ID (int VAB_Invoice_ID)
{
if (VAB_Invoice_ID <= 0) Set_ValueNoCheck ("VAB_Invoice_ID", null);
else
Set_ValueNoCheck ("VAB_Invoice_ID", VAB_Invoice_ID);
}
/** Get Invoice.
@return Invoice Identifier */
public int GetVAB_Invoice_ID() 
{
Object ii = Get_Value("VAB_Invoice_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Order.
@param VAB_Order_ID Order */
public void SetVAB_Order_ID (int VAB_Order_ID)
{
if (VAB_Order_ID <= 0) Set_ValueNoCheck ("VAB_Order_ID", null);
else
Set_ValueNoCheck ("VAB_Order_ID", VAB_Order_ID);
}
/** Get Order.
@return Order */
public int GetVAB_Order_ID() 
{
Object ii = Get_Value("VAB_Order_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Payment.
@param VAB_Payment_ID Payment identifier */
public void SetVAB_Payment_ID (int VAB_Payment_ID)
{
if (VAB_Payment_ID <= 0) Set_ValueNoCheck ("VAB_Payment_ID", null);
else
Set_ValueNoCheck ("VAB_Payment_ID", VAB_Payment_ID);
}
/** Get Payment.
@return Payment identifier */
public int GetVAB_Payment_ID() 
{
Object ii = Get_Value("VAB_Payment_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Project.
@param VAB_Project_ID Financial Project */
public void SetVAB_Project_ID (int VAB_Project_ID)
{
if (VAB_Project_ID <= 0) Set_ValueNoCheck ("VAB_Project_ID", null);
else
Set_ValueNoCheck ("VAB_Project_ID", VAB_Project_ID);
}
/** Get Project.
@return Financial Project */
public int GetVAB_Project_ID() 
{
Object ii = Get_Value("VAB_Project_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}

/** ConfidentialType VAF_Control_Ref_ID=340 */
public static int CONFIDENTIALTYPE_VAF_Control_Ref_ID=340;
/** Public Information = A */
public static String CONFIDENTIALTYPE_PublicInformation = "A";
/** Partner Confidential = C */
public static String CONFIDENTIALTYPE_PartnerConfidential = "C";
/** Internal = I */
public static String CONFIDENTIALTYPE_Internal = "I";
/** Private Information = P */
public static String CONFIDENTIALTYPE_PrivateInformation = "P";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsConfidentialTypeValid (String test)
{
return test == null || test.Equals("A") || test.Equals("C") || test.Equals("I") || test.Equals("P");
}
/** Set Confidentiality.
@param ConfidentialType Type of Confidentiality */
public void SetConfidentialType (String ConfidentialType)
{
if (!IsConfidentialTypeValid(ConfidentialType))
throw new ArgumentException ("ConfidentialType Invalid value - " + ConfidentialType + " - Reference_ID=340 - A - C - I - P");
if (ConfidentialType != null && ConfidentialType.Length > 1)
{
log.Warning("Length > 1 - truncated");
ConfidentialType = ConfidentialType.Substring(0,1);
}
Set_ValueNoCheck ("ConfidentialType", ConfidentialType);
}
/** Get Confidentiality.
@return Type of Confidentiality */
public String GetConfidentialType() 
{
return (String)Get_Value("ConfidentialType");
}
/** Set Complete Plan.
@param DateCompletePlan Planned Completion Date */
public void SetDateCompletePlan (DateTime? DateCompletePlan)
{
Set_Value ("DateCompletePlan", (DateTime?)DateCompletePlan);
}
/** Get Complete Plan.
@return Planned Completion Date */
public DateTime? GetDateCompletePlan() 
{
return (DateTime?)Get_Value("DateCompletePlan");
}
/** Set Date next action.
@param DateNextAction Date that this request should be acted on */
public void SetDateNextAction (DateTime? DateNextAction)
{
Set_ValueNoCheck ("DateNextAction", (DateTime?)DateNextAction);
}
/** Get Date next action.
@return Date that this request should be acted on */
public DateTime? GetDateNextAction() 
{
return (DateTime?)Get_Value("DateNextAction");
}
/** Set Start Plan.
@param DateStartPlan Planned Start Date */
public void SetDateStartPlan (DateTime? DateStartPlan)
{
Set_Value ("DateStartPlan", (DateTime?)DateStartPlan);
}
/** Get Start Plan.
@return Planned Start Date */
public DateTime? GetDateStartPlan() 
{
return (DateTime?)Get_Value("DateStartPlan");
}
/** Set End Date.
@param EndDate Last effective date (inclusive) */
public void SetEndDate (DateTime? EndDate)
{
Set_Value ("EndDate", (DateTime?)EndDate);
}
/** Get End Date.
@return Last effective date (inclusive) */
public DateTime? GetEndDate() 
{
return (DateTime?)Get_Value("EndDate");
}

/** IsEscalated VAF_Control_Ref_ID=319 */
public static int ISESCALATED_VAF_Control_Ref_ID=319;
/** No = N */
public static String ISESCALATED_No = "N";
/** Yes = Y */
public static String ISESCALATED_Yes = "Y";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsIsEscalatedValid (String test)
{
return test == null || test.Equals("N") || test.Equals("Y");
}
/** Set Escalated.
@param IsEscalated This request has been escalated */
public void SetIsEscalated (String IsEscalated)
{
if (!IsIsEscalatedValid(IsEscalated))
throw new ArgumentException ("IsEscalated Invalid value - " + IsEscalated + " - Reference_ID=319 - N - Y");
if (IsEscalated != null && IsEscalated.Length > 1)
{
log.Warning("Length > 1 - truncated");
IsEscalated = IsEscalated.Substring(0,1);
}
Set_ValueNoCheck ("IsEscalated", IsEscalated);
}
/** Get Escalated.
@return This request has been escalated */
public String GetIsEscalated() 
{
return (String)Get_Value("IsEscalated");
}

/** IsInvoiced VAF_Control_Ref_ID=319 */
public static int ISINVOICED_VAF_Control_Ref_ID=319;
/** No = N */
public static String ISINVOICED_No = "N";
/** Yes = Y */
public static String ISINVOICED_Yes = "Y";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsIsInvoicedValid (String test)
{
return test == null || test.Equals("N") || test.Equals("Y");
}
/** Set Invoiced.
@param IsInvoiced Is this invoiced? */
public void SetIsInvoiced (String IsInvoiced)
{
if (!IsIsInvoicedValid(IsInvoiced))
throw new ArgumentException ("IsInvoiced Invalid value - " + IsInvoiced + " - Reference_ID=319 - N - Y");
if (IsInvoiced != null && IsInvoiced.Length > 1)
{
log.Warning("Length > 1 - truncated");
IsInvoiced = IsInvoiced.Substring(0,1);
}
Set_ValueNoCheck ("IsInvoiced", IsInvoiced);
}
/** Get Invoiced.
@return Is this invoiced? */
public String GetIsInvoiced() 
{
return (String)Get_Value("IsInvoiced");
}

/** IsSelfService VAF_Control_Ref_ID=319 */
public static int ISSELFSERVICE_VAF_Control_Ref_ID=319;
/** No = N */
public static String ISSELFSERVICE_No = "N";
/** Yes = Y */
public static String ISSELFSERVICE_Yes = "Y";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsIsSelfServiceValid (String test)
{
return test == null || test.Equals("N") || test.Equals("Y");
}
/** Set Self-Service.
@param IsSelfService This is a Self-Service entry or this entry can be changed via Self-Service */
public void SetIsSelfService (String IsSelfService)
{
if (!IsIsSelfServiceValid(IsSelfService))
throw new ArgumentException ("IsSelfService Invalid value - " + IsSelfService + " - Reference_ID=319 - N - Y");
if (IsSelfService != null && IsSelfService.Length > 1)
{
log.Warning("Length > 1 - truncated");
IsSelfService = IsSelfService.Substring(0,1);
}
Set_ValueNoCheck ("IsSelfService", IsSelfService);
}
/** Get Self-Service.
@return This is a Self-Service entry or this entry can be changed via Self-Service */
public String GetIsSelfService() 
{
return (String)Get_Value("IsSelfService");
}
/** Set Shipment/Receipt.
@param M_InOut_ID Material Shipment Document */
public void SetM_InOut_ID (int M_InOut_ID)
{
if (M_InOut_ID <= 0) Set_ValueNoCheck ("M_InOut_ID", null);
else
Set_ValueNoCheck ("M_InOut_ID", M_InOut_ID);
}
/** Get Shipment/Receipt.
@return Material Shipment Document */
public int GetM_InOut_ID() 
{
Object ii = Get_Value("M_InOut_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}

/** M_ProductSpent_ID VAF_Control_Ref_ID=162 */
public static int M_PRODUCTSPENT_ID_VAF_Control_Ref_ID=162;
/** Set Product Used.
@param M_ProductSpent_ID Product/Resource/Service used in Request */
public void SetM_ProductSpent_ID (int M_ProductSpent_ID)
{
if (M_ProductSpent_ID <= 0) Set_Value ("M_ProductSpent_ID", null);
else
Set_Value ("M_ProductSpent_ID", M_ProductSpent_ID);
}
/** Get Product Used.
@return Product/Resource/Service used in Request */
public int GetM_ProductSpent_ID() 
{
Object ii = Get_Value("M_ProductSpent_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Product.
@param M_Product_ID Product, Service, Item */
public void SetM_Product_ID (int M_Product_ID)
{
if (M_Product_ID <= 0) Set_ValueNoCheck ("M_Product_ID", null);
else
Set_ValueNoCheck ("M_Product_ID", M_Product_ID);
}
/** Get Product.
@return Product, Service, Item */
public int GetM_Product_ID() 
{
Object ii = Get_Value("M_Product_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Null Columns.
@param NullColumns Columns with NULL value */
public void SetNullColumns (String NullColumns)
{
if (NullColumns != null && NullColumns.Length > 255)
{
log.Warning("Length > 255 - truncated");
NullColumns = NullColumns.Substring(0,255);
}
Set_ValueNoCheck ("NullColumns", NullColumns);
}
/** Get Null Columns.
@return Columns with NULL value */
public String GetNullColumns() 
{
return (String)Get_Value("NullColumns");
}

/** Priority VAF_Control_Ref_ID=154 */
public static int PRIORITY_VAF_Control_Ref_ID=154;
/** Urgent = 1 */
public static String PRIORITY_Urgent = "1";
/** High = 3 */
public static String PRIORITY_High = "3";
/** Medium = 5 */
public static String PRIORITY_Medium = "5";
/** Low = 7 */
public static String PRIORITY_Low = "7";
/** Minor = 9 */
public static String PRIORITY_Minor = "9";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsPriorityValid (String test)
{
return test == null || test.Equals("1") || test.Equals("3") || test.Equals("5") || test.Equals("7") || test.Equals("9");
}
/** Set Priority.
@param Priority Indicates if this request is of a high, medium or low priority. */
public void SetPriority (String Priority)
{
if (!IsPriorityValid(Priority))
throw new ArgumentException ("Priority Invalid value - " + Priority + " - Reference_ID=154 - 1 - 3 - 5 - 7 - 9");
if (Priority != null && Priority.Length > 1)
{
log.Warning("Length > 1 - truncated");
Priority = Priority.Substring(0,1);
}
Set_ValueNoCheck ("Priority", Priority);
}
/** Get Priority.
@return Indicates if this request is of a high, medium or low priority. */
public String GetPriority() 
{
return (String)Get_Value("Priority");
}

/** PriorityUser VAF_Control_Ref_ID=154 */
public static int PRIORITYUSER_VAF_Control_Ref_ID=154;
/** Urgent = 1 */
public static String PRIORITYUSER_Urgent = "1";
/** High = 3 */
public static String PRIORITYUSER_High = "3";
/** Medium = 5 */
public static String PRIORITYUSER_Medium = "5";
/** Low = 7 */
public static String PRIORITYUSER_Low = "7";
/** Minor = 9 */
public static String PRIORITYUSER_Minor = "9";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsPriorityUserValid (String test)
{
return test == null || test.Equals("1") || test.Equals("3") || test.Equals("5") || test.Equals("7") || test.Equals("9");
}
/** Set User Priority.
@param PriorityUser Priority of the issue for the User */
public void SetPriorityUser (String PriorityUser)
{
if (!IsPriorityUserValid(PriorityUser))
throw new ArgumentException ("PriorityUser Invalid value - " + PriorityUser + " - Reference_ID=154 - 1 - 3 - 5 - 7 - 9");
if (PriorityUser != null && PriorityUser.Length > 1)
{
log.Warning("Length > 1 - truncated");
PriorityUser = PriorityUser.Substring(0,1);
}
Set_ValueNoCheck ("PriorityUser", PriorityUser);
}
/** Get User Priority.
@return Priority of the issue for the User */
public String GetPriorityUser() 
{
return (String)Get_Value("PriorityUser");
}
/** Set Quantity Invoiced.
@param QtyInvoiced Invoiced Quantity */
public void SetQtyInvoiced (Decimal? QtyInvoiced)
{
Set_Value ("QtyInvoiced", (Decimal?)QtyInvoiced);
}
/** Get Quantity Invoiced.
@return Invoiced Quantity */
public Decimal GetQtyInvoiced() 
{
Object bd =Get_Value("QtyInvoiced");
if (bd == null) return Env.ZERO;
return  Convert.ToDecimal(bd);
}
/** Set Quantity Plan.
@param QtyPlan Planned Quantity */
public void SetQtyPlan (Decimal? QtyPlan)
{
Set_Value ("QtyPlan", (Decimal?)QtyPlan);
}
/** Get Quantity Plan.
@return Planned Quantity */
public Decimal GetQtyPlan() 
{
Object bd =Get_Value("QtyPlan");
if (bd == null) return Env.ZERO;
return  Convert.ToDecimal(bd);
}
/** Set Quantity Used.
@param QtySpent Quantity used for this event */
public void SetQtySpent (Decimal? QtySpent)
{
Set_Value ("QtySpent", (Decimal?)QtySpent);
}
/** Get Quantity Used.
@return Quantity used for this event */
public Decimal GetQtySpent() 
{
Object bd =Get_Value("QtySpent");
if (bd == null) return Env.ZERO;
return  Convert.ToDecimal(bd);
}
/** Set Category.
@param VAR_Category_ID Request Category */
public void SetVAR_Category_ID (int VAR_Category_ID)
{
if (VAR_Category_ID <= 0) Set_ValueNoCheck ("VAR_Category_ID", null);
else
Set_ValueNoCheck ("VAR_Category_ID", VAR_Category_ID);
}
/** Get Category.
@return Request Category */
public int GetVAR_Category_ID() 
{
Object ii = Get_Value("VAR_Category_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Group.
@param VAR_Group_ID Request Group */
public void SetR_Group_ID (int VAR_Group_ID)
{
if (VAR_Group_ID <= 0) Set_ValueNoCheck ("VAR_Group_ID", null);
else
Set_ValueNoCheck ("VAR_Group_ID", VAR_Group_ID);
}
/** Get Group.
@return Request Group */
public int GetR_Group_ID() 
{
Object ii = Get_Value("VAR_Group_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Request History.
@param VAR_Req_History_ID Request has been changed */
public void SetVAR_Req_History_ID (int VAR_Req_History_ID)
{
if (VAR_Req_History_ID < 1) throw new ArgumentException ("VAR_Req_History_ID is mandatory.");
Set_ValueNoCheck ("VAR_Req_History_ID", VAR_Req_History_ID);
}
/** Get Request History.
@return Request has been changed */
public int GetVAR_Req_History_ID() 
{
Object ii = Get_Value("VAR_Req_History_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Request Type.
@param VAR_Req_Type_ID Type of request (e.g. Inquiry, Complaint, ..) */
public void SetVAR_Req_Type_ID (int VAR_Req_Type_ID)
{
if (VAR_Req_Type_ID <= 0) Set_ValueNoCheck ("VAR_Req_Type_ID", null);
else
Set_ValueNoCheck ("VAR_Req_Type_ID", VAR_Req_Type_ID);
}
/** Get Request Type.
@return Type of request (e.g. Inquiry, Complaint, ..) */
public int GetVAR_Req_Type_ID() 
{
Object ii = Get_Value("VAR_Req_Type_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Request.
@param VAR_Request_ID Request from a Business Partner or Prospect */
public void SetVAR_Request_ID (int VAR_Request_ID)
{
if (VAR_Request_ID < 1) throw new ArgumentException ("VAR_Request_ID is mandatory.");
Set_ValueNoCheck ("VAR_Request_ID", VAR_Request_ID);
}
/** Get Request.
@return Request from a Business Partner or Prospect */
public int GetVAR_Request_ID() 
{
Object ii = Get_Value("VAR_Request_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Resolution.
@param VAR_Resolution_ID Request Resolution */
public void SetR_Resolution_ID (int VAR_Resolution_ID)
{
if (VAR_Resolution_ID <= 0) Set_ValueNoCheck ("VAR_Resolution_ID", null);
else
Set_ValueNoCheck ("VAR_Resolution_ID", VAR_Resolution_ID);
}
/** Get Resolution.
@return Request Resolution */
public int GetR_Resolution_ID() 
{
Object ii = Get_Value("VAR_Resolution_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Status.
@param VAR_Req_Status_ID Request Status */
public void SetVAR_Req_Status_ID (int VAR_Req_Status_ID)
{
if (VAR_Req_Status_ID <= 0) Set_ValueNoCheck ("VAR_Req_Status_ID", null);
else
Set_ValueNoCheck ("VAR_Req_Status_ID", VAR_Req_Status_ID);
}
/** Get Status.
@return Request Status */
public int GetVAR_Req_Status_ID() 
{
Object ii = Get_Value("VAR_Req_Status_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}

/** SalesRep_ID VAF_Control_Ref_ID=110 */
public static int SALESREP_ID_VAF_Control_Ref_ID=110;
/** Set Representative.
@param SalesRep_ID Company Agent like Sales Representitive, Purchase Agent, Customer Service Representative, ... */
public void SetSalesRep_ID (int SalesRep_ID)
{
if (SalesRep_ID <= 0) Set_ValueNoCheck ("SalesRep_ID", null);
else
Set_ValueNoCheck ("SalesRep_ID", SalesRep_ID);
}
/** Get Representative.
@return Company Agent like Sales Representitive, Purchase Agent, Customer Service Representative, ... */
public int GetSalesRep_ID() 
{
Object ii = Get_Value("SalesRep_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Start Date.
@param StartDate First effective day (inclusive) */
public void SetStartDate (DateTime? StartDate)
{
Set_Value ("StartDate", (DateTime?)StartDate);
}
/** Get Start Date.
@return First effective day (inclusive) */
public DateTime? GetStartDate() 
{
return (DateTime?)Get_Value("StartDate");
}
/** Set Summary.
@param Summary Textual summary of this request */
public void SetSummary (String Summary)
{
if (Summary != null && Summary.Length > 2000)
{
log.Warning("Length > 2000 - truncated");
Summary = Summary.Substring(0,2000);
}
Set_ValueNoCheck ("Summary", Summary);
}
/** Get Summary.
@return Textual summary of this request */
public String GetSummary() 
{
return (String)Get_Value("Summary");
}

/** TaskStatus VAF_Control_Ref_ID=366 */
public static int TASKSTATUS_VAF_Control_Ref_ID=366;
/** 0% Not Started = 0 */
public static String TASKSTATUS_0NotStarted = "0";
/** 20% Started = 2 */
public static String TASKSTATUS_20Started = "2";
/** 40% Busy = 4 */
public static String TASKSTATUS_40Busy = "4";
/** 60% Good Progress = 6 */
public static String TASKSTATUS_60GoodProgress = "6";
/** 80% Nearly Done = 8 */
public static String TASKSTATUS_80NearlyDone = "8";
/** 90% Finishing = 9 */
public static String TASKSTATUS_90Finishing = "9";
/** 95% Almost Done = A */
public static String TASKSTATUS_95AlmostDone = "A";
/** 99% Cleaning up = C */
public static String TASKSTATUS_99CleaningUp = "C";
/** 100% Complete = D */
public static String TASKSTATUS_100Complete = "D";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsTaskStatusValid (String test)
{
return test == null || test.Equals("0") || test.Equals("2") || test.Equals("4") || test.Equals("6") || test.Equals("8") || test.Equals("9") || test.Equals("A") || test.Equals("C") || test.Equals("D");
}
/** Set Task Status.
@param TaskStatus Status of the Task */
public void SetTaskStatus (String TaskStatus)
{
if (!IsTaskStatusValid(TaskStatus))
throw new ArgumentException ("TaskStatus Invalid value - " + TaskStatus + " - Reference_ID=366 - 0 - 2 - 4 - 6 - 8 - 9 - A - C - D");
if (TaskStatus != null && TaskStatus.Length > 1)
{
log.Warning("Length > 1 - truncated");
TaskStatus = TaskStatus.Substring(0,1);
}
Set_Value ("TaskStatus", TaskStatus);
}
/** Get Task Status.
@return Status of the Task */
public String GetTaskStatus() 
{
return (String)Get_Value("TaskStatus");
}
        /** Set Changed Values.
@param ChangedValues Changed Values */
        public void SetChangedValues(String ChangedValues) { if (ChangedValues != null && ChangedValues.Length > 255) { log.Warning("Length > 255 - truncated"); ChangedValues = ChangedValues.Substring(0, 255); } Set_Value("ChangedValues", ChangedValues); }/** Get Changed Values.
@return Changed Values */
        public String GetChangedValues() { return (String)Get_Value("ChangedValues"); }
    }

}