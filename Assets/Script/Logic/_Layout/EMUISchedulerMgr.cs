using UnityEngine;
using System.Collections;
using ComLib;
using Define;
using Schedule;

public class EMUIScheduler
{
	//-call-
	/// <summary>
	/// Show EMUIScheduler.
	/// </summary>
	/// <param name="arg">Argument.</param>
	public void Show ( object arg )
	{}

	//-action-
	/// <summary>
	/// UI 에서 버튼클릭으로 현재 사용할 스케쥴을 캐릭터기준으로 세팅한다.
	/// </summary>
	public void BNSchduleSetting ()
	{
	#if _Log_
		Debug.Log ("[EMUIScheduler].(BNSchduleSetting) call");
	#endif

		EMCharacterMgr.Instance.ScheduleSetting ();
	}
	
	/// <summary>
	/// 스케쥴을 등록한다.
	/// </summary>
	/// <param name="schedule">Schedule 3개.</param>
	public void BNRegisterSchedule (object schedules)
	{
	}
	
	/// <summary>
	/// 시뮬레이션을 시작한다.
	/// </summary>
	public void BNSimulation ()
	{
		EMSchedulerMgr.Instance.StartSimulation ();
	}
	
	//-request-
	/// <summary>
	/// 스케쥴리스트를 보여준다.
	/// 3가지 타입의 스케쥴을 따로 표시해야 하므로 타입별로 데이터를 받아서 표시해주도록 하자.
	/// </summary>
	/// <param name="p_Array">ID로 순차 정렬된 배열.</param>
	public void ShowSchduleList (EMScheduleType p_Type, EMSchedule[] p_Array)
	{
	#if _Log_
		Debug.Log (string.Format("[EMUIScheduler].(ShowSchduleList) type : {0}, arg cnt : {1}", p_Type.ToString(),p_Array.Length));
	#endif
	}
	
	/// <summary>
	/// 스케쥴설정이 완료 되었을때 호출된다.
	/// </summary>
	/// <param name="schedules">Schedules.</param>
	public void CompleteScheduleSetting (object schedules)
	{
		
	}
}

public class EMUISchedulerMgr : Singleton<EMUIScheduler>
{

}
