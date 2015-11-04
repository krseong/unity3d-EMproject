using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using System.Data.Odbc ;

namespace ComLib
{
	public class ODBCDataField
	{
		private string 		fieldName ;
		private OdbcType 	type ;
		
		public string FieldName
		{
			get { return fieldName ; }
		}
		
		public OdbcType Type
		{
			get { return type ; }
		}
		
		public ODBCDataField(string fieldName,OdbcType type)
		{
			this.fieldName = fieldName ;
			this.type = type ;
		}
	}
}
