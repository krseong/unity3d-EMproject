using UnityEngine;
using System.Collections;

public class EMUISimulation : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
	
	}
	
	public UISlider[] m_Schedlues;
	public UISpriteAnimation[] m_Animation;

	void Update ()
	{
		if(EMSystemMgr.Instance.IsPlay() == false)
		{
			SetAnimation(false);
			return;
		}

		m_Schedlues [EMSystemMgr.Instance.ProcessCnt ()].value = EMSystemMgr.Instance.ProcessPercent ();
		SetAnimation (true);
	}

	private void SetAnimation ( bool p_Enabled )
	{
		for(int i = 0; i < m_Animation.Length; i++)
		{
			if(EMSystemMgr.Instance.ProcessCnt () == i)
			{
				m_Animation [i].enabled = p_Enabled;
			}
			else
			{
				m_Animation [i].enabled = false;
			}
		}
	}
}
