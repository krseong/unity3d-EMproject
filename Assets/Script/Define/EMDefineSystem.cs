using UnityEngine;
using System.Collections;

namespace Define
{
	public enum EMGameProcess
	{
		NULL,
		SAMPLE,
		START,
		SIMULATION,
	}

	public enum EMResultType
	{
		SIMULATION,
		EVENT,
		GAME_CLEAR,
		SELECT_UNIVERSITY,
		ENABLE_RETURN,
	}

	public enum EMScheduleType
	{
		STUDY,
		JOB,
		VACATION,
	}

	public enum EMUIType
	{
		NULL,
		SIMULATION,
	}
}