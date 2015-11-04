using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using System; 
using System.Data; 
using System.Text ;
using System.Data.Odbc ; 

namespace ComLib
{
	public class ODBCDataSave
	{
		private string fileFullName ;
		private string tableName ;
		private List<ODBCDataField> fieldList = new List<ODBCDataField>() ;
		private List< List<object> > dataList = new List<List<object>>() ;

//		private bool isCompleteAddField = false ;
//		private bool isCallAddFieldName = false ;
		
		
		public ODBCDataSave(string fileFullName , string tableName )
		{
			this.fileFullName = fileFullName ;
			this.tableName = tableName ;
		}
		
		public ODBCDataSave( string tableName )
		{
			this.tableName = tableName ;
		}
		
		public string FileFullName
		{
			get { return fileFullName ; }
		}
		
		public string TableName
		{
			get { return tableName ; }
		}
		
		public List<ODBCDataField> FieldList
		{
			get { return fieldList ; }
		}
		
		public List< List<object> > DataList
		{
			get { return dataList ; }
		}
		
		public void AddFieldName(string fieldName,OdbcType type)
		{
//			isCallAddFieldName = true ;
			
			ODBCDataField field = new ODBCDataField( fieldName,type ) ;
			
			fieldList.Add(field) ;
		}
		
		public void CompleteAddField()
		{
//			isCompleteAddField = true ;
		}
		
		public bool AddData(List<object> datas)
		{
			if ( datas.Count != fieldList.Count )
				return false ;
			
			dataList.Add(datas) ;
			
			return true ;
		}
	}
}