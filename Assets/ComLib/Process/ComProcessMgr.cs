using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ComLib
{
	public class ProcInfo
	{
		public int id;
		public string url;

		public ProcInfo ()
		{
		}
		public ProcInfo (int id, string url)
		{
			this.id = id;
			this.url = url;
		}
	}

	public class ComProcessMgr : Singleton<ComProcessMgr>
	{
		protected List<Dictionary<int, ProcInfo>> comProcList = new List<Dictionary<int, ProcInfo>>();

		protected MonoBehaviour Mono
		{
			get
			{
				return SingletonGameObject<ComMonoBehaviour>.Instance.Mono;
			}
		}

		public void OnInit ()
		{
			comProcList.Add(new Dictionary<int, ProcInfo>());
			comProcList.Add(new Dictionary<int, ProcInfo>());
			comProcList.Add(new Dictionary<int, ProcInfo>());

			OnRegister ();
		}

		protected Dictionary<int, ProcInfo> GetDic ( ComDefine.ComProcessMgr_ProcessType procType )
		{
			return comProcList [(int)procType];
		}

		public virtual void OnRegister()
		{
			GetDic(ComDefine.ComProcessMgr_ProcessType.FAKE_SERVER).Add (ComDefine.ComProcessMgr_Default_ID, new ProcInfo ());
		}

		public virtual ProcInfo GetProcInfo( int id )
		{
			if(GetDic(ComDefine.ComProcessMgr_ProcessType.FAKE_SERVER).ContainsKey(id))
			{
				return GetDic(ComDefine.ComProcessMgr_ProcessType.FAKE_SERVER)[id];
			}
			return null;
		}

		public void Process ( int id, ComProcEntity entity )
		{
			ProcInfo pi = GetProcInfo (id);

			if(pi == null)
			{
				ComDebug.Log(string.Format("{0}.Process : pi = null", this.GetType().ToString()));
				return;
			}

			Mono.StartCoroutine(entity.OnProcess(pi));
		}
	}
}