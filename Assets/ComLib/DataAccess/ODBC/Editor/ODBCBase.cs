using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using System; 
using System.Data; 
using System.Text ;
using System.Data.Odbc ;

namespace ComLib
{
	
	abstract public class ODBCBase
	{
		protected OdbcConnection 	connection 		= null ;
		protected string 			fileFullPath	= null ;
		protected string			connectionInfo 	= null ;
	
		abstract protected string OnConnectionInformation(string fileFullPath) ;
		
		virtual  protected string OnGetTableName(string tableName) 
		{
			return tableName ;
		}
		
		virtual public bool DeleteAll(string tableName) 
		{ 
			//Debug.Log("DeleteAll does not support ") ;
			return true ; 
		}
		virtual public bool Delete()  
		{ 
			//Debug.Log("Delete does not support ") ;
			return false ; 
		}
		
		public bool Connection(string fileFullPath) 
		{
			this.fileFullPath = fileFullPath ;
			
			connectionInfo = OnConnectionInformation(fileFullPath) ;
			
			try 
			{
				connection = new OdbcConnection(connectionInfo);
				connection.Open() ;
			}
			catch( Exception ex )
			{
				Debug.Log( ex.ToString() ) ;
				
				Close() ;
				
				return false ;
			}
			
			return true ;
		}
		
		public bool Select(string tableName , ref DataTable dataTable)  
		{
			if ( connection == null )
				return false ;
			
			try
			{
				dataTable = new DataTable("ODBCDataTable");
				
				string  query = "SELECT * FROM " + OnGetTableName(tableName) ;
				
				OdbcCommand cmd = new OdbcCommand(query, connection);
				
				OdbcDataReader dataReader = cmd.ExecuteReader(); 
				
				dataTable.Load(dataReader) ;
				
				dataReader.Close(); 
			}
			catch( Exception ex )
			{
				if(!tableName.Equals("checkDataTable"))
				{
					Debug.Log( ex.ToString() ) ;
				}
				
				Close() ;
				
				return false ;
			}
			
			return true ;
		}
		public bool Insert(ODBCDataSave myODBCDataSave)
		{
			StringBuilder query  = 	new StringBuilder() ;
			StringBuilder filed  = 	new StringBuilder() ;
			StringBuilder values = 	new StringBuilder() ;
			
			query.Append( "INSERT INTO " + OnGetTableName(myODBCDataSave.TableName) ) ;
			
			filed.Append(" (" ) ;
			values.Append(" (" ) ;
			
			if ( myODBCDataSave.FieldList.Count > 0 )
			{
				filed.Append( myODBCDataSave.FieldList[0].FieldName ) ;
				values.Append( "?" ) ;
			}
			
			for ( int i = 1 ; i < myODBCDataSave.FieldList.Count ; i++ )
			{
				filed.Append( "," + myODBCDataSave.FieldList[i].FieldName ) ;
				values.Append( ",?" ) ;
			}
			
			filed.Append(") " ) ;
			values.Append(") " ) ;
			
			query.Append(filed) ;
			query.Append(" VALUES " ) ;
			query.Append(values + " " ) ;
			
			
			try
			{
				OdbcCommand cmd = new OdbcCommand() ;
				
				cmd.Connection = connection ;
				
				for ( int i = 0 ; i < myODBCDataSave.FieldList.Count ; i++ ) 
				{
					OdbcParameter para = new OdbcParameter(i.ToString(),myODBCDataSave.FieldList[i].Type);
					cmd.Parameters.Add(para) ;
				}
				
				foreach ( List<object> datas in myODBCDataSave.DataList )
				{
					for ( int i = 0 ; i < myODBCDataSave.FieldList.Count ; i++ ) 
						cmd.Parameters[i].Value = datas[i].ToString() ;
						     
					cmd.CommandText = query.ToString() ;
					cmd.ExecuteNonQuery() ;
				}
			}
			catch( Exception ex )
			{
				Debug.Log( ex.ToString() ) ;
				
				Close() ;
				
				return false ;
			}
			
			return true ;	
		}
		public bool CreateTable(ODBCDataSave myODBCDataSave) 
		{
			//string yourQuery = "CREATE TABLE tableName ( MyName VARCHAR (30), MyNumber integer )";
			
			StringBuilder query  = 	new StringBuilder() ;
			StringBuilder filed  = 	new StringBuilder() ;
			
			query.Append( "CREATE TABLE " + myODBCDataSave.TableName ) ;
			filed.Append( " ( " ) ;
			
			if ( myODBCDataSave.FieldList.Count > 0 )
			{
				filed.Append( myODBCDataSave.FieldList[0].FieldName ) ;
				filed.Append( GetFiledTypeString(myODBCDataSave.FieldList[0].Type ) ) ;
			}
			for ( int i = 1 ; i < myODBCDataSave.FieldList.Count ; i++ ) 
			{
				filed.Append( " , " + myODBCDataSave.FieldList[i].FieldName ) ;
					
				filed.Append( GetFiledTypeString(myODBCDataSave.FieldList[i].Type ) ) ;
			}
			
			filed.Append( " ) " ) ;
			
			query.Append(filed) ;
			
			try
			{ 
				OdbcCommand cmd = new OdbcCommand(query.ToString() , connection);
				
				cmd.ExecuteNonQuery() ;
			}
			catch( Exception ex )
			{
				Debug.Log( ex.ToString() ) ;
				
				Close() ;
				
				return false ;
			}
			
			return true ;	
		}
		public bool DropTable(string tableName) 
		{
			string query = "DROP TABLE " + tableName ; //OnGetTableName(tableName) ;
			
			try
			{ 
				OdbcCommand cmd = new OdbcCommand(query, connection);
				
				cmd.ExecuteNonQuery() ;
			}
			catch( Exception ex )
			{
				Debug.Log( ex.ToString() ) ;
				
				Close() ;
				
				return false ;
			}
			
			return true ;
		}
		public bool Update() 
		{
			return true ;
		}
		public bool Save(ODBCDataSave saveData) 
		{
			if ( Connection(saveData.FileFullName ) && 
			     DeleteAll(saveData.TableName) && 
			     Insert(saveData)  )
			{
				Close() ;
				return true ;
			}
			
			
			return false ;
		}
			  
		public bool Load(ODBCDataLoad loadData,ref DataTable dataTable) 
		{
			if ( Connection(loadData.FileFullName) )
			{
				if ( Select(loadData.TableName,ref dataTable) )
					return true ;
			}
			
			return false ;
		}
		
//		public bool CreateTable(MyODBCDataSave saveData)
//		{
//			if ( Connection(saveData.FileFullName ) && 
//			     CreateTable(saveData.TableName) )
//			{
//				Close() ;
//				return true ;
//			}
//			
//			return false ;
//		}
//		
//		public bool DropTable(MyODBCDataSave saveData)
//		{
//			if ( Connection(saveData.FileFullName ) && 
//			     DropTable(saveData.TableName) )
//			{
//				Close() ;
//				return true ;
//			}
//			
//			return false ;
//		}
		
		public void Close()
		{
			if ( connection != null && connection.State != ConnectionState.Closed)
				connection.Close() ;
			
			connection.Dispose() ;
		}
		
		private string GetFiledTypeString(OdbcType type)
		{
			string val = "" ;
			switch ( type )
			{
				case OdbcType.Int :
				case OdbcType.SmallInt :
				{
					val = " integer " ;
				}
				break;
				
				case OdbcType.Real:
				{
					val = " REAL " ;
				}
				break;
				
				case OdbcType.Text :
				case OdbcType.NText :
				case OdbcType.VarChar :
				case OdbcType.NVarChar :
				{
					val = " VARCHAR (255) " ;
				}
				break;
				
				default :
				{
					val = " integer " ;
				}
				break ;
			}
			
			return val ;
		}
	}
}

