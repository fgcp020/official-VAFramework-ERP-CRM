namespace VAdvantage.Model
{
    /** Generated Model - DO NOT CHANGE */
    using System;
    using System.Text;
    using VAdvantage.DataBase;
    using VAdvantage.Classes;
    using VAdvantage.Process;
    using VAdvantage.Model;
    using VAdvantage.Utility;
    using System.Data;/** Generated Model for AD_ActionLog
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
    public class X_AD_ActionLog : PO
    {
        public X_AD_ActionLog(Context ctx, int AD_ActionLog_ID, Trx trxName) : base(ctx, AD_ActionLog_ID, trxName)
        {/** if (AD_ActionLog_ID == 0){SetAD_ActionLog_ID (0);} */
        }
        public X_AD_ActionLog(Ctx ctx, int AD_ActionLog_ID, Trx trxName) : base(ctx, AD_ActionLog_ID, trxName)
        {/** if (AD_ActionLog_ID == 0){SetAD_ActionLog_ID (0);} */
        }/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
        public X_AD_ActionLog(Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName) { }/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
        public X_AD_ActionLog(Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName) { }/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
        public X_AD_ActionLog(Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName) { }/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
        static X_AD_ActionLog() { Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID, Table_Name); }/** Serial Version No */
        static long serialVersionUID = 27883142468540L;/** Last Updated Timestamp 9/25/2020 8:59:12 AM */
        public static long updatedMS = 1601017151751L;/** VAF_TableView_ID=1001065 */
        public static int Table_ID; // =1001065;
        /** TableName=AD_ActionLog */
        public static String Table_Name = "AD_ActionLog";
        protected static KeyNamePair model; protected Decimal accessLevel = new Decimal(7);/** AccessLevel
@return 7 - System - Client - Org 
*/
        protected override int Get_AccessLevel() { return Convert.ToInt32(accessLevel.ToString()); }/** Load Meta Data
@param ctx context
@return PO Info
*/
        protected override POInfo InitPO(Context ctx) { POInfo poi = POInfo.GetPOInfo(ctx, Table_ID); return poi; }/** Load Meta Data
@param ctx context
@return PO Info
*/
        protected override POInfo InitPO(Ctx ctx) { POInfo poi = POInfo.GetPOInfo(ctx, Table_ID); return poi; }/** Info
@return info
*/
        public override String ToString() { StringBuilder sb = new StringBuilder("X_AD_ActionLog[").Append(Get_ID()).Append("]"); return sb.ToString(); }/** Set AD_ActionLog_ID.
@param AD_ActionLog_ID AD_ActionLog_ID */
        public void SetAD_ActionLog_ID(int AD_ActionLog_ID) { if (AD_ActionLog_ID < 1) throw new ArgumentException("AD_ActionLog_ID is mandatory."); Set_ValueNoCheck("AD_ActionLog_ID", AD_ActionLog_ID); }/** Get AD_ActionLog_ID.
@return AD_ActionLog_ID */
        public int GetAD_ActionLog_ID() { Object ii = Get_Value("AD_ActionLog_ID"); if (ii == null) return 0; return Convert.ToInt32(ii); }/** Set Role.
@param VAF_Role_ID Responsibility Role */
        public void SetVAF_Role_ID(int VAF_Role_ID)
        {
            if (VAF_Role_ID <= 0) Set_Value("VAF_Role_ID", null);
            else
                Set_Value("VAF_Role_ID", VAF_Role_ID);
        }/** Get Role.
@return Responsibility Role */
        public int GetVAF_Role_ID() { Object ii = Get_Value("VAF_Role_ID"); if (ii == null) return 0; return Convert.ToInt32(ii); }/** Set Session.
@param VAF_Session_ID User Session Online or Web */
        public void SetVAF_Session_ID(int VAF_Session_ID)
        {
            if (VAF_Session_ID <= 0) Set_Value("VAF_Session_ID", null);
            else
                Set_Value("VAF_Session_ID", VAF_Session_ID);
        }/** Get Session.
@return User Session Online or Web */
        public int GetVAF_Session_ID() { Object ii = Get_Value("VAF_Session_ID"); if (ii == null) return 0; return Convert.ToInt32(ii); }/** Set Table/View.
@param VAF_TableView_ID Database Table information */
        public void SetVAF_TableView_ID(int VAF_TableView_ID)
        {
            if (VAF_TableView_ID <= 0) Set_Value("VAF_TableView_ID", null);
            else
                Set_Value("VAF_TableView_ID", VAF_TableView_ID);
        }/** Get Table/View.
@return Database Table information */
        public int GetVAF_TableView_ID() { Object ii = Get_Value("VAF_TableView_ID"); if (ii == null) return 0; return Convert.ToInt32(ii); }
        /** Action VAF_Control_Ref_ID=104 */
        public static int ACTION_VAF_Control_Ref_ID = 104;/** Workbench = B */
        public static String ACTION_Workbench = "B";/** WorkFlow = F */
        public static String ACTION_WorkFlow = "F";/** Process = P */
        public static String ACTION_Process = "P";/** Report = R */
        public static String ACTION_Report = "R";/** Task = T */
        public static String ACTION_Task = "T";/** Window = W */
        public static String ACTION_Window = "W";/** Form = X */
        public static String ACTION_Form = "X";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
        public bool IsActionValid(String test) { return test == null || test.Equals("B") || test.Equals("F") || test.Equals("P") || test.Equals("R") || test.Equals("T") || test.Equals("W") || test.Equals("X"); }/** Set Action.
@param Action Indicates the Action to be performed */
        public void SetAction(String Action)
        {
            if (!IsActionValid(Action))
                throw new ArgumentException("Action Invalid value - " + Action + " - Reference_ID=104 - B - F - P - R - T - W - X"); if (Action != null && Action.Length > 1) { log.Warning("Length > 1 - truncated"); Action = Action.Substring(0, 1); }
            Set_Value("Action", Action);
        }/** Get Action.
@return Indicates the Action to be performed */
        public String GetAction() { return (String)Get_Value("Action"); }/** Set Action origin.
@param ActionOrigin Action origin */
        public void SetActionOrigin(String ActionOrigin) { if (ActionOrigin != null && ActionOrigin.Length > 100) { log.Warning("Length > 100 - truncated"); ActionOrigin = ActionOrigin.Substring(0, 100); } Set_Value("ActionOrigin", ActionOrigin); }/** Get Action origin.
@return Action origin */
        public String GetActionOrigin() { return (String)Get_Value("ActionOrigin"); }
        /** ActionType VAF_Control_Ref_ID=1000491 */
        public static int ACTIONTYPE_VAF_Control_Ref_ID = 1000491;/** Download = D */
        public static String ACTIONTYPE_Download = "D";/** View = V */
        public static String ACTIONTYPE_View = "V";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
        public bool IsActionTypeValid(String test) { return test == null || test.Equals("D") || test.Equals("V"); }/** Set ActionType.
@param ActionType ActionType */
        public void SetActionType(String ActionType)
        {
            if (!IsActionTypeValid(ActionType))
                throw new ArgumentException("ActionType Invalid value - " + ActionType + " - Reference_ID=1000491 - D - V"); if (ActionType != null && ActionType.Length > 1) { log.Warning("Length > 1 - truncated"); ActionType = ActionType.Substring(0, 1); }
            Set_Value("ActionType", ActionType);
        }/** Get ActionType.
@return ActionType */
        public String GetActionType() { return (String)Get_Value("ActionType"); }/** Set Description.
@param Description Optional short description of the record */
        public void SetDescription(String Description) { if (Description != null && Description.Length > 500) { log.Warning("Length > 500 - truncated"); Description = Description.Substring(0, 500); } Set_Value("Description", Description); }/** Get Description.
@return Optional short description of the record */
        public String GetDescription() { return (String)Get_Value("Description"); }/** Set Export.
@param Export_ID Export */
        public void SetExport_ID(String Export_ID) { if (Export_ID != null && Export_ID.Length > 50) { log.Warning("Length > 50 - truncated"); Export_ID = Export_ID.Substring(0, 50); } Set_Value("Export_ID", Export_ID); }/** Get Export.
@return Export */
        public String GetExport_ID() { return (String)Get_Value("Export_ID"); }/** Set Record ID.
@param Record_ID Direct internal record ID */
        public void SetRecord_ID(int Record_ID)
        {
            if (Record_ID <= 0) Set_Value("Record_ID", null);
            else
                Set_Value("Record_ID", Record_ID);
        }/** Get Record ID.
@return Direct internal record ID */
        public int GetRecord_ID() { Object ii = Get_Value("Record_ID"); if (ii == null) return 0; return Convert.ToInt32(ii); }
    }
}