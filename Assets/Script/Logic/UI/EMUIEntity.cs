using UnityEngine;
using System.Collections;
using Define;

public class EMUIEntity : MonoBehaviour 
{
	public bool m_ActiveOnInit = false;
	public EMUIType m_UIType = EMUIType.NULL;

	public int GetUIType ()
	{
		return (int)m_UIType;
	}

	public void OnInit ()
	{
		SetActive (m_ActiveOnInit);
	}

	public void SetActive ( bool p_IsActive )
	{
		gameObject.SetActive (p_IsActive);
	}

	public virtual void OnReset ()
	{

	}
}
