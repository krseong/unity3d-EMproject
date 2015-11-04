using UnityEditor;
using UnityEngine;
using System.Collections;
using System;

public static class EMTestRunner_Editor
{
	[MenuItem("Tools/CommandLine/Test/UnitTest")]
	static void UnitTest()
	{
		Console.Out.WriteLine("[EMTestRunner_Editor].(UnitTest) start");
		
		EMTestRunner.UnitTest();
		
		Console.Out.WriteLine("[EMTestRunner_Editor].(UnitTest) end");
	}
}
