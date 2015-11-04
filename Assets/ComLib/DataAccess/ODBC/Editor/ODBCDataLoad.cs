using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

namespace ComLib
{
	public class ODBCDataLoad
	{
		private string fileFullName ;
		private string tableName ;
		
		public string TableName
		{
			get { return tableName ; }
		}
		
		public string FileFullName
		{
			get { return fileFullName ; }
		}
		
		public ODBCDataLoad(string fileFullName , string tableName)
		{
			this.fileFullName  = fileFullName ;
			this.tableName = tableName ;
		}
	}
}


