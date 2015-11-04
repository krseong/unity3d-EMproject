using UnityEngine;
using System.Collections;

namespace ComLib
{
	public class ComUIMgr : Singleton<ComUIMgr>
	{
		public void Log()
		{
			ComDebug.Log ("ComUIManager Log");
		}

		public void Create<T> () where T : ComUIEntity, new()
		{
			T uiFrame = ComUIEntity.OnCreate<T> ();
			if(uiFrame != null)
			{
				// register
			}
			else
			{
				// null error
			}
		}
	}
}