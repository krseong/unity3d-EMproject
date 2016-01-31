using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ComLib;

public class EMGameManager : Singleton<EMGameManager>
{
	private EMDataMgr m_DataMgr = new EMDataMgr();
	private Dictionary<int, ComFSMEntity<EMDataMgr>> m_ProcessDic;
	private ComFSMEntity<EMDataMgr> m_CurProcess = null;

	public Define.EMGameProcess GetCurProcess ()
	{
		if(m_DataMgr != null)
		{
			return m_DataMgr.GetProcess();
		}
		return Define.EMGameProcess.NULL;
	}

	public bool OnInit ()
	{
		OnRegister ();

		foreach(ComFSMEntity<EMDataMgr> fsm in m_ProcessDic.Values)
		{
			fsm.OnAwake(m_DataMgr);
		}

		return true;
	}

	public void OnStart ()
	{
#if _Sample_
		SetSampleProcess ();
		return;
#endif
		SetStartProcess ();
	}

	private void OnRegister ()
	{
		if(m_ProcessDic == null)
		{
			m_ProcessDic = new Dictionary<int, ComFSMEntity<EMDataMgr>>();
		}

		m_ProcessDic.Add ((int)Define.EMGameProcess.SAMPLE, new EMGameProcessSample ());
		m_ProcessDic.Add ((int)Define.EMGameProcess.START, new EMGameProcessStart ());
		m_ProcessDic.Add ((int)Define.EMGameProcess.SIMULATION, new EMGameProcessSimulation ());
	}

	private void SetSampleProcess ()
	{
		ChangeProcess (m_DataMgr.SetProcess(Define.EMGameProcess.SAMPLE));
	}

	private void SetStartProcess ()
	{
		ChangeProcess (m_DataMgr.SetProcess(Define.EMGameProcess.START));
	}

	public void ChangeProcess ( Define.EMGameProcess p_Process )
	{
		if(m_ProcessDic.ContainsKey((int)p_Process) == false)
		{
			Debug.Log (string.Format("[ChangeProcess] this process ({0}) is not found!", p_Process.ToString()));
			return;
		}

		if(m_CurProcess != null)
		{
			m_CurProcess.OnExit(m_DataMgr);
		}
		m_CurProcess = m_ProcessDic [(int)m_DataMgr.SetProcess(p_Process)];

		m_CurProcess.OnEnter (m_DataMgr);
	}

	public void OnDestroy ()
	{
		OnRelease ();

		m_CurProcess = null;
		m_ProcessDic = null;
		Instance = null;
	}

	public void OnRelease ()
	{
		if(m_ProcessDic != null)
		{
			m_ProcessDic.Clear();
		}
	}

	public void OnUpdate ()
	{
		if(m_CurProcess != null)
		{
			m_CurProcess.OnProcess(m_DataMgr);
		}
	}

	public void OnGUI ()
	{
		if(GUI.Button(new Rect(310, 10, 70, 70), "Back"))
		{
			SetSampleProcess();
		}

		if(m_CurProcess != null)
		{
			m_CurProcess.OnGUI(m_DataMgr);
		}
	}
}