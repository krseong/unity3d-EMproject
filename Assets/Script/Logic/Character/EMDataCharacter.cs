using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Define;

namespace Character
{
	public class EMDataScheduleStatus
	{
		private int m_Level;
		public int Level
		{
			get{ return m_Level;}
			set{ m_Level = value;}
		}
	}

	public class EMDataCharacter
	{				
		private Dictionary<EMScheduleType, EMDataScheduleStatus> m_ScheduleStatus = new Dictionary<EMScheduleType, EMDataScheduleStatus>();

		//-GetScheduleStatus-
		public EMDataScheduleStatus GetScheduleStatus ( EMScheduleType p_Type)
		{
			return m_ScheduleStatus[p_Type];
		}
		//-SetScheduleStatus-
		public void SetScheduleStatus (EMScheduleType p_Type, EMDataScheduleStatus p_ScheduleStatus)
		{
			m_ScheduleStatus.Add (p_Type, p_ScheduleStatus);
		}
	}
}
