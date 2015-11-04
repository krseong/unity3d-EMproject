using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SharpUnit;
using Schedule;
using Define;
using Character;

public class EMScheduler_Test : TestCase
{
	private EMScheduler scheduler = null;

	public override void SetUp ()
	{
		scheduler = new EMScheduler ();

		scheduler.DataSetting_Temp ();
	}

	public override void TearDown ()
	{
		scheduler = null;
	}

	[UnitTest]
	public void TestCheckScheduleOpen_STUDY ()
	{
		EMDataScheduleStatus character_status = new EMDataScheduleStatus ();
		character_status.Level = 1;

		scheduler.CheckScheduleOpen (EMScheduleType.STUDY, character_status);

		List<EMSchedule> schedule_list = scheduler.GetScheduleList (EMScheduleType.STUDY);

		foreach (EMSchedule schedule in schedule_list)
		{
			if(schedule.IsOpen == false)
			{
				Assert.True(character_status.Level < schedule.Level, "Schedule.ID = " + schedule.ID); 
			}
			else if(schedule.IsOpen == true)
			{
				Assert.True(character_status.Level >= schedule.Level, "Schedule.ID = " + schedule.ID); 
			}
		}
	}

	[UnitTest]
	public void TestCheckScheduleOpen_JOB ()
	{
		EMDataScheduleStatus character_status = new EMDataScheduleStatus ();
		character_status.Level = 2;
		
		scheduler.CheckScheduleOpen (EMScheduleType.JOB, character_status);

		List<EMSchedule> schedule_list = scheduler.GetScheduleList (EMScheduleType.JOB);

		foreach (EMSchedule schedule in schedule_list)
		{
			if(schedule.IsOpen == false)
			{
				Assert.True(character_status.Level < schedule.Level, "Schedule.ID = " + schedule.ID); 
			}
			else if(schedule.IsOpen == true)
			{
				Assert.True(character_status.Level >= schedule.Level, "Schedule.ID = " + schedule.ID); 
			}
		}
	}

	[UnitTest]
	public void TestCheckScheduleOpen_VACATION ()
	{
		EMDataScheduleStatus character_status = new EMDataScheduleStatus ();
		character_status.Level = 3;
		
		scheduler.CheckScheduleOpen (EMScheduleType.VACATION, character_status);

		List<EMSchedule> schedule_list = scheduler.GetScheduleList (EMScheduleType.VACATION);

		foreach (EMSchedule schedule in schedule_list)
		{
			if(schedule.IsOpen == false)
			{
				Assert.True(character_status.Level < schedule.Level, "Schedule.ID = " + schedule.ID); 
			}
			else if(schedule.IsOpen == true)
			{
				Assert.True(character_status.Level >= schedule.Level, "Schedule.ID = " + schedule.ID); 
			}
		}
	}
}
