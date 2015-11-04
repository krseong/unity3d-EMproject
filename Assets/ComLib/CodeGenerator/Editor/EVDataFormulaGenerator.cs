using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic ;
using System.Data ;
using System.Data.Odbc ;

namespace ComLib
{
	[CustomEditor(typeof(DataFormulaGenerator))]
	public class EVDataFormulaGenerator : ODBCEditControlBase
	{
		CodeGenerator script ;
		
		override public void OnSetScript() 
		{
			script = (CodeGenerator) target;
		}
			
		/// file 위치 와 table 명을 기입 한다.
		override public void OnSetConnectionInfo(ref string fileFullName,ref string tableName) 
		{
			fileFullName = string.Format("{0}/{1}", Application.dataPath, script.fullFilePath) ;
			tableName = script.tableName;	// "DataFormula"
		}

		override public bool OnFetchData(DataTable dataTable,int rowCount) 
		{
			string[] ColumnArray = new string[dataTable.Columns.Count-1];
			string fullPath = string.Format ("{0}/{1}/{2}.cs", Application.dataPath, script.targetPath, script.tableName);
			string data = string.Format ("using UnityEngine;\nusing System.Collections;\nusing System;\n\n[Serializable]\npublic class {0}\n{1}", script.tableName, "{");

			for(int i = 1; i < dataTable.Columns.Count; i++)
			{
				if( string.IsNullOrEmpty(dataTable.Columns[i].ColumnName) )
					continue;
				
				data = string.Format("{0}\n\tpublic {1}\t{2}\t{3}", 
				                     data, dataTable.Rows[0][dataTable.Columns[i].ColumnName].ToString(), dataTable.Columns[i].ColumnName, ";");

				ColumnArray[i-1] = dataTable.Columns[i].ColumnName;
			}

			data = string.Format ("{0}\n\n\tpublic {1} ({1} orgData)\n\t{2}\n", data, script.tableName, "{");

			for(int i = 0; i < ColumnArray.Length; i++)
			{
				data = string.Format ("{0}\t\t{1} = orgData.{1} ;\n", data, ColumnArray[i]);
			}

			data = string.Format ("{0}\t{1}", data, "}");
			data = string.Format ("{0}\n{1}", data, "}");

//			Debug.Log (AssetDatabase.AssetPathToGUID (string.Format ("Assets/{0}/{1}.cs", script.targetPath, script.tableName)));

			ComSystemIO.Create (fullPath, data);

//			Debug.Log (AssetDatabase.AssetPathToGUID (string.Format ("Assets/{0}/{1}.cs", script.targetPath, script.tableName)));
			
			return true ;
		}

		public override void OnAddFieldInfo (ODBCDataSave saveData)
		{
		}

		public override void OnAddSaveData (ODBCDataSave saveData)
		{
		}
	}
}
