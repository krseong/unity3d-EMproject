using System;
using System.IO;
using UnityEngine;
using System.Collections;

namespace ComLib
{
	public class ComCSVReader
	{
		static public string[] ReadFile(string path)
		{
			try
			{
				Debug.Log (path);
				
				TextAsset RF = (TextAsset)Resources.LoadAssetAtPath(path, typeof(TextAsset));
				if (RF == null)
				{
					return null;
				}

				string[] bufferArray = RF.text.Split("\r"[0]);

				return bufferArray;
			}
			catch(System.Exception ex)
			{
				Debug.Log("Exception  : " + ex);
				return null;
			}
		}
		
		static public string[] SplitMetaData ( string metaData_, string splitStr_ )
		{
			try
			{
				string[] bufferArray = metaData_.Split(splitStr_[0]);
				int line = bufferArray.Length;
				string[] allData = new string[line];
				
				for (int i = 0; i < line; ++i)
				{
					allData[i] = bufferArray[i].Replace("\r", "");
				}
				
				return allData;
			}
			catch(Exception e)
			{
				Debug.Log("Exception : " + e);
				return null;
			}
		}
		
		static public string[] ReadFileOut(string path)
		{
			try
			{
				StreamReader sr = new StreamReader(path);
				string lineCount = sr.ReadLine();
				int line = Convert.ToInt32(lineCount);
				string[] allData = new string[line + 1];
				allData[0] = lineCount;
				for(int i=0; i < line; ++i)
				{
					allData[i+1] = sr.ReadLine();
				}
				
				sr.Close();
				
				return allData;
			}
			catch (System.Exception ex)
			{
				Debug.Log("Exception  : " + ex);
				return null;
			}
		}
	}
}