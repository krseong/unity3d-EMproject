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

	public class EMDataCharacterStatus
	{
		public int Hp;
		public int Stress;
		public int Concentration;
		public int Mathmatics;
		public int ForeignLanguage;
		public int NativeLanguage;
		public int CommonSense;

		public int Luck;

		public EMDataCharacterStatus ()
		{
			this.Hp = 100;
			this.Stress = 0;
			this.Concentration = 0;
			this.Mathmatics = 0;
			this.ForeignLanguage = 0;
			this.NativeLanguage = 0;
			this.CommonSense = 0;
			this.Luck = 0;
		}

		public void Copy (EMDataCharacterStatus p_Data)
		{
			this.Hp = p_Data.Hp;
			this.Stress = p_Data.Stress;
			this.Concentration = p_Data.Concentration;
			this.Mathmatics = p_Data.Mathmatics;
			this.ForeignLanguage = p_Data.ForeignLanguage;
			this.NativeLanguage = p_Data.NativeLanguage;
			this.CommonSense = p_Data.CommonSense;
			this.Luck = p_Data.Luck;
		}
	}

	public class EMDataCharacter
	{				
		private Dictionary<EMScheduleType, EMDataScheduleStatus> m_ScheduleStatus = new Dictionary<EMScheduleType, EMDataScheduleStatus>();
		private EMDataCharacterStatus m_UserStatus = new EMDataCharacterStatus();

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
		//-GetUserStatus-
		public EMDataCharacterStatus GetUserStatus ()
		{
			return m_UserStatus;
		}
		//-SetUserStatus-
		public void SetUserStatus (EMDataCharacterStatus p_UserStatus)
		{
			m_UserStatus.Copy (p_UserStatus);
		}
	}
}
