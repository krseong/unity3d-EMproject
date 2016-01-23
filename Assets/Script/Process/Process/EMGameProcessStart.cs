using UnityEngine;
using System.Collections;
using ComLib;

public class EMGameProcessStart : ComFSMEntity<EMDataMgr> 
{
	public override bool OnEnter (EMDataMgr p_Owner)
	{
		Debug.Log ("[EMGameProcessStart] OnEnter");
		return true;
	}

	public override bool OnProcess (EMDataMgr p_Owner)
	{
		return true;
	}

	public override void OnExit (EMDataMgr p_Owner)
	{
		Debug.Log ("[EMGameProcessStart] OnExit");
	}
}
