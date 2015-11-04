using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ComLib
{
	public class ODBCExcel : ODBCBase
	{
		override protected string OnConnectionInformation(string fileFullPath) 
		{
			//return  "Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq="+fileFullPath+"; HDR=Yes; READONLY=FALSE;" ;
			return  "Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq="+fileFullPath+"; HDR=Yes;  READONLY=FALSE;" ;
		}
		override protected string OnGetTableName(string tableName) 
		{
			return "[" + tableName + "$]" ;
		}
	}
}
