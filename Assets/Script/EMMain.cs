using UnityEngine;
using System.Collections;
using Define;

public class EMMain : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		EMGameManager.Instance.OnInit ();	
	}

	void Start ()
	{
		EMGameManager.Instance.OnStart ();
	}

	void OnDestroy ()
	{
		EMGameManager.Instance.OnDestroy ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		EMGameManager.Instance.OnUpdate ();
	}

#if _Sample_
	void OnGUI ()
	{
		EMGameManager.Instance.OnGUI ();
	}
#endif

#if UNITY_EDITOR

	void LateUpdate ()
	{
		TestInput ();
	}

	void TestInput ()
	{
		if(Input.GetKeyUp(KeyCode.N))
		{
			/*
			if(EMGameManager.Instance.GetCurProcess() == EMGameProcess.START)
			{
				EMGameManager.Instance.ChangeProcess(EMGameProcess.SAMPLE);
			}
			else
			{
				EMGameManager.Instance.ChangeProcess(EMGameProcess.START);
			}
			*/
		}
	}
#endif
}
