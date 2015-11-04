using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic ;
using System.Data ;
using System.Data.Odbc ;

namespace ComLib
{
	[CustomEditor(typeof(BaseFormulaGenerator))]
	public class EVBaseFormulaGenerator : ODBCEditControlBase
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
			tableName = script.tableName;	// "BaseFormula"
		}

		override public bool OnFetchData(DataTable dataTable,int rowCount) 
		{
			string fullPath = string.Format ("{0}/{1}/{2}.cs", Application.dataPath, script.targetPath, script.tableName);
			string header = CSharpSentence.USING_Layout(CSharpSentence.USING_UnityEngine) + CSharpSentence.USING_Layout(CSharpSentence.USING_Collections);
			string layout = "";
			string className = "DataFormula";
			string method = "";

			if( rowCount > 0) 
			{ 
				layout = header;

				for (int i = 0; i < rowCount; i++) 
				{
					string ID = dataTable.Rows[i][dataTable.Columns["ID"]].ToString();
					string Formula = dataTable.Rows[i][dataTable.Columns["Formula"]].ToString();
					string Result = dataTable.Rows[i][dataTable.Columns["Result"]].ToString();

					method += CSharpSentence.METHOD_RESULT_Layout("static", className, "Formula_" + ID, Result + " = " + Formula);
				}

				layout += CSharpSentence.CLASS_Layout(script.tableName, method);
				layout = string.Format("{0}\n\ndelegate {1} DelegateFormula ({1} result, {1} owner, params {1}[] other);", layout, className);

				ComSystemIO.Create (fullPath, layout);

				string fullPath1 = string.Format ("{0}/{1}/FormulaMgr_SetBase.cs", Application.dataPath, script.targetPath);
				string data1 = string.Format ("using UnityEngine;\nusing System.Collections;\n\npublic partial class FormulaMgr\n{0}", "{");

				data1 = string.Format (
					"{0}\n" + 
					"\tpublic void Init ()\n" +
					"\t{1}",
					data1, "{");

				for (int i = 0; i < rowCount; i++) 
				{
					string ID = dataTable.Rows[i][dataTable.Columns["ID"]].ToString();

					data1 = string.Format(
						"{0}\n" +
						"\t\tbaseFormulaDic.Add({1}, {2}.Formula_{1});"
						, data1, ID, script.tableName);
				}

				data1 = string.Format ("{0}\n\t{1}", data1, "}");
				data1 = string.Format ("{0}\n{1}", data1, "}");
				ComSystemIO.Create (fullPath1, data1);
			}
			
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
