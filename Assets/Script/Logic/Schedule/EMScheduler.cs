using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Character;
using Define;

namespace Schedule
{
	public class EMScheduler
	{
		private class EMDataSchedule
		{
			public Dictionary<EMScheduleType, Dictionary<int, EMSchedule>> m_Data = new Dictionary<EMScheduleType, Dictionary<int, EMSchedule>>();

			//-Get-
			public List<EMSchedule> Get ( EMScheduleType p_Type )
			{
				List<EMSchedule> list = new List<EMSchedule> ();

				foreach(EMSchedule schedule in m_Data[p_Type].Values)
				{
					list.Add(schedule);
				}

				return list;
			}
			public EMSchedule Get ( EMScheduleType p_Type, int p_ID )
			{
				List<EMSchedule> list = Get (p_Type);

				foreach(EMSchedule schedule in list)
				{
					if(schedule.ID == p_ID)
						return schedule;
				}

				return null;
			}
			//-Set-
			private void Set ( EMScheduleType p_Type, EMSchedule p_Schedule )
			{
				if(m_Data.ContainsKey(p_Type) == false)
				{
					m_Data.Add (p_Type, new Dictionary<int, EMSchedule> ());
				}

				m_Data [p_Type].Add (p_Schedule.ID, p_Schedule);
			}
			public void Set ( EMSchedule p_Schedule )
			{
				Set (p_Schedule.Type, p_Schedule);
			}
			public void Set ( List<EMSchedule> p_List )
			{
				foreach(EMSchedule schedule in p_List)
				{
					Set(schedule);
				}
			}
		}
		/// <summary>
		/// 스케쥴데이터 Get, Set 클래스.
		/// </summary>
		private EMDataSchedule m_Data;

		public List<EMSchedule> GetScheduleList ( EMScheduleType p_Type )
		{
			return m_Data.Get (p_Type);
		}

		public EMSchedule GetSchedule ( EMScheduleType p_Type, int p_ID )
		{
			return m_Data.Get (p_Type, p_ID);
		}

		private EMSchedule[] m_Schedule;

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init()
		{
			m_Data = new EMDataSchedule ();
			m_Schedule = new EMSchedule[3];
		}

		public void DataSetting_Temp ()
		{
			if(m_Data == null)
			{
				m_Data = new EMDataSchedule ();
			}
			
			// EMScheduleType.STUDY
			m_Data.Set(MakeData_Temp(1000, EMScheduleType.STUDY, 1, false));
			m_Data.Set(MakeData_Temp(1001, EMScheduleType.STUDY, 2, false));
			m_Data.Set(MakeData_Temp(1002, EMScheduleType.STUDY, 3, false));
			
			// EMScheduleType.JOB
			m_Data.Set(MakeData_Temp(2000, EMScheduleType.JOB, 1, false));
			m_Data.Set(MakeData_Temp(2001, EMScheduleType.JOB, 2, false));
			m_Data.Set(MakeData_Temp(2002, EMScheduleType.JOB, 3, false));
			
			// EMScheduleType.VACATION
			m_Data.Set(MakeData_Temp(3000, EMScheduleType.VACATION, 1, false));
			m_Data.Set(MakeData_Temp(3001, EMScheduleType.VACATION, 2, false));
			m_Data.Set(MakeData_Temp(3002, EMScheduleType.VACATION, 3, false));
		}

		/// <summary>
		/// 임시 스케쥴 데이터 생성 함수.
		/// </summary>
		/// <returns>The schedule.</returns>
		private EMSchedule MakeData_Temp ( int p_ID, EMScheduleType p_Type, int p_Level, bool p_IsOpen )
		{
			EMSchedule data = new EMSchedule ();
			data.ID = p_ID;
			data.Type = p_Type;
			data.Level = p_Level;
			data.IsOpen = p_IsOpen;

			return data;
		}

		/// <summary>
		/// 캐릭터가 할 수 있는 스케쥴 리스트를 요청하다.
		/// </summary>
		/// <param name="character">캐릭터 데이터를 받아야 한다.</param>
		public void ReqScheduleList (EMDataCharacter p_Character)
		{
		#if _Log_
			Debug.Log ("[EMScheduler].(ReqScheduleList) call arg : " + p_Character);
		#endif
			// process
			CheckScheduleOpen (EMScheduleType.STUDY, p_Character.GetScheduleStatus(EMScheduleType.STUDY));
			CheckScheduleOpen (EMScheduleType.JOB, p_Character.GetScheduleStatus(EMScheduleType.JOB));
			CheckScheduleOpen (EMScheduleType.VACATION, p_Character.GetScheduleStatus(EMScheduleType.VACATION));
			
			// show scheduler list
			EMUISchedulerMgr.Instance.ShowSchduleList (EMScheduleType.STUDY, m_Data.Get(EMScheduleType.STUDY).ToArray());
			EMUISchedulerMgr.Instance.ShowSchduleList (EMScheduleType.JOB, m_Data.Get(EMScheduleType.JOB).ToArray());
			EMUISchedulerMgr.Instance.ShowSchduleList (EMScheduleType.VACATION, m_Data.Get(EMScheduleType.VACATION).ToArray());
		}

		/// <summary>
		/// 캐릭터 데이터를 기준으로 스케쥴 오픈상태를 결정한다.
		/// </summary>
		/// <param name="p_Type">P_ type.</param>
		/// <param name="p_Character">P_ character.</param>
		public void CheckScheduleOpen ( EMScheduleType p_Type, EMDataScheduleStatus p_ScheduleStatus )
		{
			List<EMSchedule> schedule_list = m_Data.Get (p_Type);

			foreach(EMSchedule schedule in schedule_list)
			{
				schedule.CheckOpen(p_ScheduleStatus);
			}
		}
		
		/// <summary>
		/// 스케쥴 3개를 등록하고 스케쥴 생성
		/// </summary>
		/// <param name="schedule">선택한 스케쥴 3개를 받는다</param>
		public void RegisterSchedule (int p_Order, EMSchedule p_Schedules)
		{
			m_Schedule [p_Order] = p_Schedules;
		}
		
		/// <summary>
		/// 시뮬레이션을 시작한다.
		/// </summary>
		public void StartSimulation ()
		{
			EMSystemMgr.Instance.PlaySimulation (null);
		}
	}
}
