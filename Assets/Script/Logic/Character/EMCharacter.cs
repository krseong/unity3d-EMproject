using UnityEngine;
using System.Collections;
using Define;

namespace Character
{
	public class EMCharacter
	{
		/// <summary>
		/// 캐릭터 상태값, 처음시작하는경우 초기값이 설정된다.
		/// </summary>
		private EMDataCharacter m_Data;

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init()
		{
		}


		public void DataSetting_Temp ()
		{
			m_Data = new EMDataCharacter ();

			// EMScheduleType.STUDY
			m_Data.SetScheduleStatus(EMScheduleType.STUDY, MakeData_Temp(1));
			
			// EMScheduleType.JOB
			m_Data.SetScheduleStatus(EMScheduleType.JOB, MakeData_Temp(1));
			
			// EMScheduleType.VACATION
			m_Data.SetScheduleStatus(EMScheduleType.VACATION, MakeData_Temp(1));

			EMDataCharacterStatus userStatus = new EMDataCharacterStatus ();

			m_Data.SetUserStatus (userStatus);
		}

		private EMDataScheduleStatus MakeData_Temp ( int p_Level )
		{
			EMDataScheduleStatus data = new EMDataScheduleStatus ();
			data.Level = p_Level;
			
			return data;
		}

		
		/// <summary>
		/// 캐릭터의 설정값을 기준으로 가능한 스케쥴을 설정한다.
		/// </summary>
		public void ScheduleSetting ()
		{
		#if _Log_
			Debug.Log ("[EMCharacter].(ScheduleSetting) call");
		#endif
			EMSchedulerMgr.Instance.ReqScheduleList (m_Data);
		}
	}
}
