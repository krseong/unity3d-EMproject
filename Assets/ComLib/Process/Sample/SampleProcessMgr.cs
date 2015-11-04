using UnityEngine;
using System.Collections;
using ComLib;

public class SampleProcessMgr : ComProcessMgr
{
	public override void OnRegister ()
	{
		base.OnRegister ();
	}

	public override ProcInfo GetProcInfo (int id)
	{
		return base.GetProcInfo (id);
	}
}
