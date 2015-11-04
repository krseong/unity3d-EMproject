using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System ;
using System.Data; 
using System.Text ;
using System.Data.Odbc; 

namespace ComLib
{
	public class ODBCAccess : ODBCBase
	{
		override protected string OnConnectionInformation(string fileFullPath) 
		{
			return "Driver={Microsoft Access Driver (*.mdb, *.accdb)}; DBQ=" + fileFullPath + "; READONLY=FALSE;" ;
		}
		
		override public bool DeleteAll(string tableName) 
		{
			string query = "DELETE * FROM " + tableName ;
			
			try
			{
				OdbcCommand cmd = new OdbcCommand(query,connection);
			
				cmd.ExecuteNonQuery() ;
			}
			catch (Exception ex )
			{
				Debug.Log(ex.ToString() ) ;
				
				return false ;
			}
			
			return true ;
		}
		
		override public bool Delete()  
		{
			
			return true ;
		}
	}
}