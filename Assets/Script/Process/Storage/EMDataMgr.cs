using UnityEngine;
using System.Collections;

public class EMDataMgr
{
	private EMGameDocument m_GameDocument = new EMGameDocument();

	private int m_ProcessState;
	public Define.EMGameProcess Process
	{
		get{ return (Define.EMGameProcess)m_ProcessState; }
		set{ m_ProcessState = (int)value; }
	}
}
