using UnityEngine;

namespace ComLib
{
	public class ComDefine
	{
		//============================ variable ============================
		public static int ComProcessMgr_Default_ID = -1;

		//============================== enum ==============================
		//ComProcessMgr
		public enum ComProcessMgr_ProcessType
		{
			FAKE_SERVER = 0,
			HTTP = 1,
			TCP = 2,
		}
	}

	public delegate void ComVoidDelegate();
	public delegate void ComVoidDelegateObjParam( object arg );
	public delegate bool ComBoolDelegate();
}