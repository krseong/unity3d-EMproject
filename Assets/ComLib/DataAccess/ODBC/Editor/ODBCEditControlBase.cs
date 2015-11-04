using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using UnityEditor;
using System.Data;
using System.Data.Odbc ;

// 2014.04.04 added by krseong
// 엑셀 데이터 값 체크레인지 하는 체크로직 추가 ;
// 검색코드 : ETCEComBSSData.check1 ;
namespace ComLib
{
	abstract public class ODBCEditControlBase : Editor 
	{
		abstract public void OnSetScript() ;
		abstract public void OnSetConnectionInfo(ref string fileFullName,ref string tableName) ;
		abstract public void OnAddFieldInfo(ODBCDataSave saveData) ;
		abstract public void OnAddSaveData(ODBCDataSave saveData) ;
		abstract public bool OnFetchData(DataTable dataTable,int count) ;
		
		public override void OnInspectorGUI () 
		{
			if ( GUILayout.Button("Load Excel") )
			{
				if ( EditorUtility.DisplayDialog("Load Excel","you want to load this data from excel file ?   " ,"OK" ,"Cancel") )
				{
					if ( LoadODBC() )
					{
						EditorUtility.SetDirty(target) ;
						EditorUtility.DisplayDialog("Load Excel","complete load " ,"OK") ;
					}
					else
						EditorUtility.DisplayDialog("Load Excel","error load " ,"OK") ;
				}
			}
				
			base.OnInspectorGUI() ;
		}

		void OnEnable() {
			
			OnSetScript() ;
		}
		
		public bool SaveODBC()
		{
			string fileFullName = null ;
			string tableName = null ;
			
			OnSetConnectionInfo(ref fileFullName ,ref tableName ) ;
			
			if ( fileFullName == null || tableName == null )
				return false ;

			ODBCDataSave saveData = new ODBCDataSave(fileFullName, tableName ) ;
			
			/// table에 맞는 field와 type을 정의 한다. int , real ,text 이렇게 3개만 현재 지원하게 코드 되어 있다. 
			/// 만약 short 을 쓰고 있다면 int형으로 넘기고 short형으로 형변환 하면 된다.
			
			OnAddFieldInfo(saveData) ;
			
			/// field 추가가 완료 되면 이 함수를 호출 해야 한다.
			saveData.CompleteAddField() ;
			
			/// 기입될 데이타를 List에 추가한다.
			OnAddSaveData(saveData) ;
			
			/// access에 저장한다.
			if ( !ODBCHelper.Save(saveData,ODBCHelper.ODBC_TYPE.EXCEL) )
			{
				Debug.Log( " error save ") ;
				return false ;
			}
			
			return true ;
		}
		
		public bool LoadODBC()
		{
			string 	fileFullName = null ;
			string 	tableName = null ;
			int		totalDataRow = 0;
			
			OnSetConnectionInfo(ref fileFullName ,ref tableName ) ;
			
			if ( fileFullName == null || tableName == null )
				return false ;
			
			// (ETCEComBSSData.check1) {
			checkEnabled = LoadCheckDataTable(fileFullName); // }
			
			DataTable dataTable = null ;
			
			/// access에서 데이타를 로드 한다.
			if ( ODBCHelper.Load( new ODBCDataLoad(fileFullName,tableName ),
									ODBCHelper.ODBC_TYPE.EXCEL,ref dataTable ) )
			{
				totalDataRow = GetRowCount(dataTable);
				
				if ( OnFetchData(dataTable,totalDataRow)  )
				{
					EditorUtility.SetDirty(target) ;
					
					// (ETCEComBSSData.check1) {
					CheckDataTable(dataTable, totalDataRow);
					InitCheckDataTable(); // }
					
					return true ;
				}
				else
					return false ;
				
			}
			
			return false ;
		}
		
		public int GetRowCount(DataTable dataTable)
		{
			int count = 0 ;
			for ( ; count < dataTable.Rows.Count; count++)
			{
				if ( dataTable.Rows[count][dataTable.Columns[0].ColumnName].ToString() == "" )
					return count ;
			}
			
			return count ;
		}
		
		// (ETCEComBSSData.check1) {
		private DataTable checkDataTable = null;
		private bool		checkEnabled = false;
		
		private void InitCheckDataTable ()
		{
			checkDataTable = null;
			checkEnabled = false;
		}
		
		private bool LoadCheckDataTable ( string fileName_, string tableName_ = "checkDataTable")
		{
			InitCheckDataTable();
			
			if ( fileName_ == null)
				return false ;
			
			/// access에서 데이타를 로드 한다.
			if ( ODBCHelper.Load( new ODBCDataLoad(fileName_,tableName_ ),
									ODBCHelper.ODBC_TYPE.EXCEL,ref checkDataTable ) )
			{
				return true;			
			}
			
			return false;
		} 
		
		private int GetColumnCount(DataTable dataTable)
		{
			int count = 0 ;
			for ( ; count < dataTable.Columns.Count; count++)
			{
				if ( dataTable.Rows[0][count].ToString() == "" )
					return count ;
			}
			
			return count ;
		}
		
		private bool GetCheckValue (string columnName_, out string valType_, out object minRange_, out object maxRange_)
		{	
			valType_ = "NULL";
			minRange_ = null;
			maxRange_ = null;
			
			int intVal = 0;
			float floatVal = 0;
			
			// check min
			if(!checkDataTable.Columns.Contains(columnName_ + "_min"))
			{
				Debug.Log ("(GetCheckValue) " + columnName_ + "_min is not defined");
				return false;
			}
			
			// check max
			if(!checkDataTable.Columns.Contains(columnName_ + "_max"))
			{
				Debug.Log ("(GetCheckValue) " + columnName_ + "_max is not defined");
				return false;
			}
			
			// int or float ?
			if(!checkDataTable.Rows[0][checkDataTable.Columns[columnName_ + "_min"]].ToString().Contains("."))
			{
				// int
				if ( !int.TryParse( checkDataTable.Rows[0][checkDataTable.Columns[columnName_ + "_min"]].ToString() , out intVal ) )
				{
					Debug.Log("checkDataTable <Row[0], int Columns[" + columnName_ + "_min]> parsing error minRange_ ") ;
					return false ;
				}
				
				minRange_ = (object) intVal;
				
				if ( !int.TryParse( checkDataTable.Rows[0][checkDataTable.Columns[columnName_ + "_max"]].ToString() , out intVal ) )
				{
					Debug.Log("checkDataTable <Row[0], int Columns[" + columnName_ + "_max]> parsing error minRange_ ") ;
					return false ;
				}
				
				maxRange_ = (object) intVal;
				valType_ = "INT";
			}
			else
			{
				// float
				if ( !float.TryParse( checkDataTable.Rows[0][checkDataTable.Columns[columnName_ + "_min"]].ToString() , out floatVal ) )
				{
					Debug.Log("checkDataTable <Row[0], float Columns[" + columnName_ + "_min]> parsing error minRange_ ") ;
					return false ;
				}
				
				minRange_ = (object) floatVal;
				
				if ( !float.TryParse( checkDataTable.Rows[0][checkDataTable.Columns[columnName_ + "_max"]].ToString() , out floatVal ) )
				{
					Debug.Log("checkDataTable <Row[0], float Columns[" + columnName_ + "_max]> parsing error minRange_ ") ;
					return false ;
				}
				
				maxRange_ = (object) floatVal;
				valType_ = "FLOAT";
			}
			
			return true;
		}
		
		private void CheckDataTable ( DataTable dataTable_, int dataRowCnt_ )
		{
			// dataTable.Rows[count][dataTable.Columns[0].ColumnName].ToString() count 번째 row 의 데이터 ;
			// count = 0, 데이터 타입 ;
			// count = 1, 데이터 최소범위 ; 
			// count = 2, 데이터 최대범위 ;
			
			if(checkEnabled == false)
				return;
			
			// 체크할 컬럼의 개수;
			//int checkColumnsCnt = GetColumnCount(checkDataTable);
			int dataColumnsCnt = GetColumnCount(dataTable_);
			
			string valColumn = null;
			string valType = null;
			object minRange = null;
			object maxRange = null;
			
			string log = "";
			
			for(int j = 0; j < dataColumnsCnt; j++)
			{
				valColumn = dataTable_.Columns[j].ColumnName;
				
				if( ! GetCheckValue(valColumn, out valType, out minRange, out maxRange))
				{
					if(valType == "NULL")
					{
						continue;
					}
					else
					{
						EditorUtility.DisplayDialog("CheckDataTable error","checkDataTable " + j + " column error " ,"OK") ;
						return;
					}
				}
				
				for(int i = 0; i < dataRowCnt_; i++)
				{
					if(!CheckData(valType, minRange, maxRange, 
						dataTable_.Rows[i][dataTable_.Columns[j]].ToString()))
					{
						// range over
						EditorUtility.DisplayDialog("Check Range error","dataTable (" + valColumn + " column : " + i + " row )" + " is out of range " ,"OK") ;
						//return;
						log += "dataTable (" + valColumn + " column : " + i + " row )" + " is out of range \n";
					}
				}
			}
			
			Debug.Log (log);
		}
		
		private bool CheckData ( string valType_, object minRange_, object maxRange_, string data_ )
		{
			bool res = false;
			
			if(valType_ == "INT")
			{
				int minValInt = (int)minRange_;
				int maxValInt = (int)maxRange_;
				int dataValInt;
				
				if ( !int.TryParse( data_ , out dataValInt) )
				{
					Debug.Log("(CheckData) parsing error") ;
					return false;
				}
				
				if(dataValInt >= minValInt && dataValInt <= maxValInt)
				{
					res = true;
				}
			}
			else if(valType_ == "FLOAT")
			{
				float minValFloat = (float)minRange_;
				float maxValFloat = (float)maxRange_;
				float dataValFloat;
				
				if ( !float.TryParse( data_ , out dataValFloat) )
				{
					Debug.Log("(CheckData) parsing error") ;
					return false;
				}
				
				if(dataValFloat >= minValFloat && dataValFloat <= maxValFloat)
				{
					res = true;
				}
			}
			
			return res;
		}
		
		// }
	}
}

