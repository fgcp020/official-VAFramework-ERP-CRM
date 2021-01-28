﻿/********************************************************
 * Project Name   : VAdvantage
 * Class Name     : MVAFIssueProject
 * Purpose        : Issue Project Model
 * Class Used     : X_R_IssueProject
 * Chronological    Development
 * Deepak           27-Jan-2010
  ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Process;
using VAdvantage.Classes;
using VAdvantage.Model;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using System.Data;
using System.Data.SqlClient;
using VAdvantage.Logging;
using VAdvantage.Utility;
namespace VAdvantage.Model
{
    public class MVAFIssueProject : X_R_IssueProject
    {
  /// <summary>
  /// Get/Set Project
  /// </summary>
  /// <param name="issue">issue</param>
  /// <returns>project</returns>
	static public MVAFIssueProject Get (MVAFIssue issue)
	{
		if (issue.GetName() == null)
        {
			return null;
        }
		MVAFIssueProject pj = null;
		String sql = "SELECT * FROM R_IssueProject WHERE Name=@param";
		SqlParameter[] param=new SqlParameter[1];
        IDataReader idr=null;
		try
		{
			//pstmt = DataBase.prepareStatement (sql, null);
			//pstmt.setString (1, issue.getName());
			param[0]=new SqlParameter("@param",issue.GetName());
            idr=DataBase.DB.ExecuteReader(sql,param,null);
            if (idr.Read())
            {
				pj = new MVAFIssueProject(issue.GetCtx(),idr, null);
            }
			idr.Close();
		}
		catch (Exception e)
		{
            if(idr!=null)
            {
                idr.Close();
            }
			_log.Log (Level.SEVERE, sql, e);
		}
			//	New
		if (pj == null)
		{
			pj = new MVAFIssueProject(issue.GetCtx(), 0, null);
			pj.SetName(issue.GetName());
			pj.SetA_Asset_ID(issue);
		}
		pj.SetSystemStatus(issue.GetSystemStatus());
		pj.SetStatisticsInfo(issue.GetStatisticsInfo());
		pj.SetProfileInfo(issue.GetProfileInfo());
		if (!pj.Save())
        {
			return null;
        }
		
		//	Set 
		issue.SetR_IssueProject_ID(pj.GetR_IssueProject_ID());
		if (pj.GetA_Asset_ID() != 0)
        {
			issue.SetA_Asset_ID(pj.GetA_Asset_ID());
        }
		return pj;
	}	//	get
	
	/**	Logger	*/
	private static VLogger _log = VLogger.GetVLogger (typeof(MVAFIssueProject).FullName);
	
	
	/// <summary>
	///  	Standard Constructor
	/// </summary>
	/// <param name="ctx">context</param>
	/// <param name="R_IssueProject_ID">id</param>
	/// <param name="trxName">trx</param>
	public MVAFIssueProject (Ctx ctx, int R_IssueProject_ID, Trx trxName):base(ctx, R_IssueProject_ID, trxName)
	{
		//super (ctx, R_IssueProject_ID, trxName);
	}	//	MVAFIssueProject

	/// <summary>
	/// Load Constructor
	/// </summary>
	/// <param name="ctx">context</param>
	/// <param name="rs">datarow</param>
	/// <param name="trxName">trx</param>
	public MVAFIssueProject (Ctx ctx, DataRow dr, Trx trxName):base (ctx, dr, trxName)
	{
		//super (ctx, rs, trxName)
	}	//	MVAFIssueProject

        /// <summary>
	/// Load Constructor
	/// </summary>
	/// <param name="ctx">context</param>
	/// <param name="rs">datarow</param>
	/// <param name="trxName">trx</param>
	public MVAFIssueProject (Ctx ctx,IDataReader idr, Trx trxName):base(ctx, idr, trxName)
	{
		//super (ctx, rs, trxName);
	}
	/// <summary>
	///	Set VAA_Asset_ID
	/// </summary>
	/// <param name="issue"></param>
	public void SetA_Asset_ID (MVAFIssue issue)
	{
		int VAA_Asset_ID = 0;
        //String sql = "SELECT * FROM VAA_Asset a "
        //    + "WHERE EXISTS (SELECT * FROM VAA_AssetGroup ag "	//	Tracking Assets
        //        + "WHERE a.VAA_AssetGroup_ID=ag.VAA_AssetGroup_ID AND ag.IsTrackIssues='Y')"
        //    + " AND EXISTS (SELECT * FROM VAF_UserContact u "
        //        + "WHERE (a.VAB_BusinessPartner_ID=u.VAB_BusinessPartner_ID OR a.VAB_BusinessPartnerSR_ID=u.VAB_BusinessPartner_ID)"
        //        + " AND u.EMail=@param1)"					//	#1 EMail
        //    + " AND (SerNo IS NULL OR SerNo=@param2)";	//	#2 Name
		
		
		
		
		base.SetA_Asset_ID (VAA_Asset_ID);
	}	//	setA_Asset_ID
	
	/// <summary>
	///	String Representation
	/// </summary>
	/// <returns>info</returns>
	public override String ToString ()
	{
		StringBuilder sb = new StringBuilder ("MVAFIssueProject[");
		sb.Append (Get_ID())
			.Append ("-").Append (GetName())
			.Append(",VAA_Asset_ID=").Append(GetA_Asset_ID())
			.Append(",VAB_Project_ID=").Append(GetVAB_Project_ID())
			.Append ("]");
		return sb.ToString ();
	}	//	toString
	
}	//	MVAFIssueProject

}
