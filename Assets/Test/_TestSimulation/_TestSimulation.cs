using UnityEngine;
using System.Collections;

public class _TestSimulation : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		EMSchedulerMgr.Instance.Init ();
		EMSchedulerMgr.Instance.DataSetting_Temp ();

		EMSchedulerMgr.Instance.RegisterSchedule (0, EMSchedulerMgr.Instance.GetSchedule (Define.EMScheduleType.JOB, 2000));
		EMSchedulerMgr.Instance.RegisterSchedule (1, EMSchedulerMgr.Instance.GetSchedule (Define.EMScheduleType.STUDY, 1000));
		EMSchedulerMgr.Instance.RegisterSchedule (2, EMSchedulerMgr.Instance.GetSchedule (Define.EMScheduleType.VACATION, 3000));

		EMSchedulerMgr.Instance.StartSimulation ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		EMSystemMgr.Instance.OnUpdate ();
	}

	void OnGUI ()
	{
		if(GUI.Button (new Rect(10, 10, 100, 100), "Reset"))
		{
			Application.LoadLevel("_TestSimulation");
		}
	}
}
