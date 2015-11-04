using UnityEngine;
using System.Collections;
using Define;
using Character;

namespace Schedule
{
	public class EMSchedule
	{
		private int m_ID;
		public int ID 
		{ 
			get{ return m_ID;} 
			set{ m_ID = value;}
		}

		private EMScheduleType m_Type;
		public EMScheduleType Type 
		{ 
			get{ return m_Type;} 
			set{ m_Type = value;}
		}

		private bool m_IsOpen;
		public bool IsOpen 
		{ 
			get{ return m_IsOpen;} 
			set{ m_IsOpen = value;}
		}

		private int m_Level;
		public int Level
		{
			get{ return m_Level;} 
			set{ m_Level = value;}
		}

		public virtual void CheckOpen ( EMDataScheduleStatus p_ScheduleStatus )
		{
			// base level
			IsOpen = (p_ScheduleStatus.Level >= Level);
		}
	}
}