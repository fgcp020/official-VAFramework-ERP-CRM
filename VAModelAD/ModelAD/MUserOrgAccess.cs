﻿/********************************************************
 * Project Name   : VAdvantage
 * Class Name     : MUserOrgAccess
 * Purpose        : User Org Access Info
 * Class Used     : X_VAF_UserContact_OrgRights
 * Chronological    Development
 * Deepak          17-Nov-2009
  ******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Classes;
using VAdvantage.Common;
using VAdvantage.Process;
using VAdvantage.Model;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using VAdvantage.Utility;
using System.Windows.Forms;
//using VAdvantage.Controls;
using System.Data;
using System.Data.SqlClient;
using VAdvantage.Logging;


namespace VAdvantage.Model
{
    public class MUserOrgAccess : X_VAF_UserContact_OrgRights
    {
        /// <summary>
        /// Get Organizational Access of User
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="VAF_UserContact_ID">user</param>
        /// <returns>array of User Org Access</returns>
        public static MUserOrgAccess[] GetOfUser(Ctx ctx, int VAF_UserContact_ID)
        {
            return Get(ctx, "SELECT * FROM VAF_UserContact_OrgRights WHERE VAF_UserContact_ID=@Param1", VAF_UserContact_ID);
        }	//	getOfUser

        /// <summary>
        /// Get Organizational Info
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="sql">sql Command</param>
        /// <param name="id">id</param>
        /// <returns> array of User Org Access</returns>
        private static MUserOrgAccess[] Get(Ctx ctx, String sql, int id)
        {
            //ArrayList<MUserOrgAccess> list = new ArrayList<MUserOrgAccess>();
            List<MUserOrgAccess> list = new List<MUserOrgAccess>();
            SqlParameter[] Param = new SqlParameter[1];
            IDataReader idr = null;
            DataTable dt = null;
            try
            {
                Param[0] = new SqlParameter("@Param1", id);
                idr = CoreLibrary.DataBase.DB.ExecuteReader(sql, Param, null);
                dt = new DataTable();
                dt.Load(idr);
                idr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MUserOrgAccess(ctx, dr, null));
                }
                dt = null;
            }
            catch (Exception e)
            {
                if (dt != null)
                {
                    dt = null;
                }
                if (idr != null)
                {
                    idr.Close();
                }
                _log.Log(Level.SEVERE, sql, e);
            }
            MUserOrgAccess[] retValue = new MUserOrgAccess[list.Count];
            //list.toArray (retValue);
            retValue = list.ToArray();
            return retValue;
        }	//	get

        //	Static Logger
        private static VLogger _log = VLogger.GetVLogger(typeof(MUserOrgAccess).FullName);
        /// <summary>
        ///Load Constructor 
        /// </summary>
        /// <param name="ctx">Ctx</param>
        /// <param name="dr">datarow</param>
        /// <param name="trxName"> transaction</param>
        public MUserOrgAccess(Ctx ctx, DataRow dr, Trx trxName)
            : base(ctx, dr, trxName)
        {
            //super(ctx, rs, trxName);
        }	//	MUserOrgAccess

        /// <summary>
        /// Persistency Constructor
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="ignored"> ignored</param>
        /// <param name="trxName">transaction</param>
        public MUserOrgAccess(Ctx ctx, int ignored, Trx trxName)
            : base(ctx, 0, trxName)
        {
            //super(ctx, 0, trxName);
            if (ignored != 0)
            {
                throw new ArgumentException("Multi-Key");
            }
            SetIsReadOnly(false);
        }	//	MUserOrgAccess

        /// <summary>
        /// Organization Constructor
        /// </summary>
        /// <param name="org">org</param>
        /// <param name="VAF_UserContact_ID"> role</param>
        public MUserOrgAccess(PO org, int VAF_UserContact_ID)
            : this(org.GetCtx(), 0, org.Get_TrxName())
        {
            //this (org.GetCtx(), 0, org.Get_TrxName());
            SetClientOrg(org);
            SetVAF_UserContact_ID(VAF_UserContact_ID);
        }	//	MUserOrgAccess

        /// <summary>
        ///  String Representation
        /// </summary>
        /// <returns>info</returns>
        public String toString()
        {
            StringBuilder sb = new StringBuilder("MUserOrgAccess[");
            sb.Append("VAF_UserContact_ID=").Append(GetVAF_UserContact_ID())
                .Append(",VAF_Client_ID=").Append(GetVAF_Client_ID())
                .Append(",VAF_Org_ID=").Append(GetVAF_Org_ID())
                .Append(",RO=").Append(IsReadOnly());
            sb.Append("]");
            return sb.ToString();
        }	//	toString


        /// <summary>
        /// Extended String Representation
        /// </summary>
        /// <param name="ctx">context</param>
        /// <returns>extended info</returns>
        public String ToStringX(Ctx ctx)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Msg.Translate(ctx, "VAF_Client_ID")).Append("=").Append(GetClientName()).Append(" - ")
                .Append(Msg.Translate(ctx, "VAF_Org_ID")).Append("=").Append(GetOrgName());
            return sb.ToString();
        }	//	toStringX

        private String _clientName;
        private String _orgName;

        /// <summary>
        ///Get Client Name
        /// </summary>
        /// <returns>name</returns>
        public String GetClientName()
        {
            if (_clientName == null)
            {
                String sql = "SELECT c.Name, o.Name "
                    + "FROM VAF_Client c INNER JOIN VAF_Org o ON (c.VAF_Client_ID=o.VAF_Client_ID) "
                    + "WHERE o.VAF_Org_ID=@Param1";
                SqlParameter[] Param = new SqlParameter[1];
                IDataReader idr = null;
                try
                {
                    Param[0] = new SqlParameter("@Param1", GetVAF_Org_ID());
                    idr = CoreLibrary.DataBase.DB.ExecuteReader(sql, Param, null);
                    if (idr.Read())
                    {
                        _clientName = Utility.Util.GetValueOfString(idr[0]); //rs.getString(1);
                        _orgName = Utility.Util.GetValueOfString(idr[1]);//   rs.getString(2);
                    }
                    idr.Close();
                }
                catch (Exception e)
                {
                    if (idr != null)
                    {
                        idr.Close();
                    }
                    _log.Log(Level.SEVERE, sql, e);
                }

            }
            return _clientName;
        }	//	getClientName

        /// <summary>
        /// Get Client Name
        /// </summary>
        /// <returns> name</returns>
        public String GetOrgName()
        {
            if (_orgName == null)
            {
                GetClientName();
            }
            return _orgName;
        }	//	getOrgName



        /// <summary>
        /// After Save
        /// </summary>
        /// <param name="newRecord">new</param>
        /// <param name="success">success</param>
        /// <returns>success</returns>
        protected override bool AfterSave(bool newRecord, bool success)
        {
            if (success)
            {
                if (!IsActive())
                {
                    UpdateLoginSettings();
                }
            }
            return success;
        }

        protected override bool AfterDelete(bool success)
        {
            if (success)
            {
                UpdateLoginSettings();
            }
            return success;
        }

        private void UpdateLoginSettings()
        {
            DataSet ds = DB.ExecuteDataset(@"SELECT VAF_Role_ID,ISUSEUSERORGACCESS From VAF_Role WHERE VAF_Role_ID IN 
                        (SELECT VAF_Role_ID FROM VAF_Loginsetting WHERE VAF_Org_ID=" + GetVAF_Org_ID() + " AND VAF_UserContact_ID=" + GetVAF_UserContact_ID() + ")");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ISUSEUSERORGACCESS"].ToString() == "Y" ? true : false)
                    {
                        deleteLoginDetails(Convert.ToInt32(ds.Tables[0].Rows[i]["VAF_Role_ID"]));
                    }
                    else
                    {
                        int roleOrgID = Convert.ToInt32(DB.ExecuteScalar(@"SELECT count(*) From VAF_Role_OrgRights WHERE VAF_Org_ID=" + GetVAF_Org_ID() +
                            " AND VAF_Role_ID=" + Convert.ToInt32(ds.Tables[0].Rows[i]["VAF_Role_ID"])));
                        if (roleOrgID == 0)
                        {
                            deleteLoginDetails(Convert.ToInt32(ds.Tables[0].Rows[i]["VAF_Role_ID"]));
                        }
                    }
                }
            }
        }

        private void deleteLoginDetails(int VAF_Role_ID)
        {
            DB.ExecuteQuery(@"DELETE FROM VAF_Loginsetting WHERE VAF_Role_ID=" + VAF_Role_ID +
                                                             " AND VAF_Org_ID=" + GetVAF_Org_ID() + " AND VAF_UserContact_ID=" + GetVAF_UserContact_ID());
        }






    }	//	MUserOrgAccess




}
