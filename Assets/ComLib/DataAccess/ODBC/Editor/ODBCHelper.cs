using UnityEngine;
using System.Collections;
using System; 
using System.Data; 
using System.Text ;
using System.Data.OleDb ;
using System.IO ;

namespace ComLib
{
	static public class ODBCHelper
	{
		public enum ODBC_TYPE
		{
			EXCEL,
			ACCESS,
		}
		
		static public bool Save(ODBCDataSave saveData , ODBC_TYPE type) 
		{
			ODBCBase odbc = null ;
			
			odbc = GetODBC(type) ;
			
			if ( !odbc.Save(saveData) )
				return false ;
		
			return true ;
		}
		static public bool Load(ODBCDataLoad loadData , ODBC_TYPE type,ref DataTable dataTable ) 
		{
			ODBCBase odbc = null ;
			
			odbc = GetODBC(type) ;
			
			if ( !odbc.Load( loadData,ref dataTable ) )
				return false ;
		
			return true ;
		}
		static public bool CreateDataToExcel(ODBCDataSave saveData,string copyPath ,ODBC_TYPE type) 
		{
			ODBCBase odbc = null ;
			
			odbc = GetODBC(type) ;
			
			try
			{
				File.Delete(saveData.FileFullName) ;
				File.Copy(copyPath,saveData.FileFullName) ;
			}
			catch( Exception e )
			{
				Debug.LogError(e.ToString()) ;
				return false ;
			}
			
//			if ( odbc.Connection(saveData.FileFullName ) )
//			{
//				if ( odbc.CreateTable(saveData) &&
//					 odbc.Insert(saveData) )
//				{
//					odbc.Close() ;
//					return true ;				
//				}
//			}
//			
//			odbc.Close() ;
			
			if ( !odbc.Save(saveData) )
				return false ;
			
			return true ;
		}
		
		static public bool CreateDataToExcelFromBlankExcel(ODBCDataSave saveData,string copyPath ,ODBC_TYPE type) 
		{
			ODBCBase odbc = null ;
			
			odbc = GetODBC(type) ;
			
			try
			{
				File.Delete(saveData.FileFullName) ;
				File.Copy(copyPath,saveData.FileFullName) ;
			}
			catch( Exception e )
			{
				Debug.LogError(e.ToString()) ;
				return false ;
			}
			
			if ( odbc.Connection(saveData.FileFullName ) )
			{
				if ( odbc.CreateTable(saveData) &&
					 odbc.Insert(saveData) )
				{
					odbc.Close() ;
					return true ;				
				}
			}
			
			return true ;
		}
		
		static private ODBCBase GetODBC(ODBC_TYPE type)
		{
			ODBCBase odbc = null ;
			
			switch ( type )
			{
				case ODBC_TYPE.EXCEL :
				{
					odbc = new ODBCExcel() ;
				}
				break;
				case ODBC_TYPE.ACCESS :
				{
					odbc = new ODBCAccess() ;
				}
				break;
			}
			
			return odbc ;
		}
	}
}
