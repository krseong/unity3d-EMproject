using UnityEngine;
using System.Collections;

namespace ComLib
{
	public class ComDebug : SingletonGameObject<ComDebug> 
	{
		void Awake ()
		{
			DontDestroyOnLoad (gameObject);
		}


		public static void Log ( string msg )
		{
			//Debug.Log (msg);
		}

	}
}