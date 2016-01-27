using UnityEngine;
using System.Collections;

public class EMDataMgr
{
	private EMGameDocument m_GameDocument = new EMGameDocument();

	private int m_ProcessState;
	public Define.EMGameProcess GetProcess ()
	{
		return (Define.EMGameProcess)m_ProcessState;
	}
	public Define.EMGameProcess SetProcess ( Define.EMGameProcess p_ProcessState )
	{
		m_ProcessState = (int)p_ProcessState;

		return GetProcess();
	}
}
