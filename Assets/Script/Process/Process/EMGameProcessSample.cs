using UnityEngine;
using System.Collections;
using ComLib;

public class EMGameProcessSample : ComFSMEntity<EMDataMgr> 
{
	public override bool OnAwake (EMDataMgr p_Owner)
	{
		Debug.Log ("[EMGameProcessSample] OnAwake");
		return true;
	}

	public override bool OnEnter (EMDataMgr p_Owner)
	{
		Debug.Log ("[EMGameProcessSample] OnEnter");
		return true;
	}

	public override bool OnProcess (EMDataMgr p_Owner)
	{
		return true;
	}

	public override void OnExit (EMDataMgr p_Owner)
	{
		Debug.Log ("[EMGameProcessSample] OnExit");
	}

	public override void OnGUI (EMDataMgr p_Owner)
	{
		if(GUI.Button(new Rect(10, 10, 70, 70), "Simulation"))
		{
			EMGameManager.Instance.ChangeProcess(Define.EMGameProcess.SIMULATION);
		}
	}
}
