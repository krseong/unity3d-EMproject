using UnityEngine;
using System.Collections;
using ComLib;

public class EMSystem
{
	private float m_ProcessTime = 5.0f;
	private int m_ProcessMaxCnt = 3;

	private float m_ElapsedTime;
	private int m_ProcessCnt;

	private bool m_Play;

	public bool IsPlay ()
	{
		if(m_Play)
		{
			if((m_ProcessCnt >= m_ProcessMaxCnt) == true)
			{
				Finish();
			}
		}
		return m_Play;
	}

	public int ProcessCnt ()
	{
		return m_ProcessCnt;
	}

	public float ProcessPercent ()
	{
		return m_ElapsedTime / m_ProcessTime;
	}

	/// <summary>
	/// 플레이 시뮬레이션.
	/// </summary>
	/// <param name="schedules">Schedules.</param>
	public void PlaySimulation ( object schedules )
	{
		Debug.Log ("[EMSystem] PlaySimulation");

		Start ();
	}

	public void OnUpdate ()
	{
		if(IsPlay() == false)
			return;

		if(SingleScheduleProcess(Time.deltaTime))
		{
			Next();
		}
	}

	private bool SingleScheduleProcess ( float p_DeltaTime )
	{
		if(m_ElapsedTime > m_ProcessTime)
		{
			return true;
		}
		else
		{
			m_ElapsedTime += p_DeltaTime;
		}

		return false;
	}

	private void Start ()
	{
		m_ElapsedTime = 0.0f;
		m_ProcessCnt = 0;
		
		Debug.Log (string.Format("[EMSystem] Start ProcessCnt : {0}", m_ProcessCnt));
		m_Play = true;
	}

	private void Next ()
	{
		m_ElapsedTime = 0.0f;
		m_ProcessCnt++;

		if(IsPlay())
		{
			Debug.Log (string.Format("[EMSystem] Next ProcessCnt : {0}", m_ProcessCnt));
		}
	}

	private void Finish ()
	{
		m_ElapsedTime = 0.0f;

		Debug.Log (string.Format("[EMSystem] Finish ProcessCnt : {0}", m_ProcessCnt));
		m_Play = false;
	}
}

public class EMSystemMgr : Singleton<EMSystem>
{
}