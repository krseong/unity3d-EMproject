using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ComLib;

public class GameManager : Singleton<GameManager>
{
	private EMDataMgr m_DataMgr = new EMDataMgr();
	private Dictionary<int, ComFSMEntity<EMDataMgr>> m_ProcessDic;
	private ComFSMEntity<EMDataMgr> m_CurProcess = null;

	public bool OnInit ()
	{
		OnRegister ();
		return true;
	}

	public void OnStart ()
	{
		SetStartProcess ();
	}

	private void OnRegister ()
	{
		if(m_ProcessDic != null)
		{
			m_ProcessDic = new Dictionary<int, ComFSMEntity<EMDataMgr>>();
		}

		m_ProcessDic.Add ((int)Define.EMGameProcess.START, new EMGameProcessStart ());
		m_ProcessDic.Add ((int)Define.EMGameProcess.SAMPLE, new EMGameProcessSample ());
	}

	private void SetStartProcess ()
	{
		m_DataMgr.Process = Define.EMGameProcess.START;

		ChangeProcess (m_DataMgr.Process);
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
		m_CurProcess = m_ProcessDic [(int)p_Process];

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


}