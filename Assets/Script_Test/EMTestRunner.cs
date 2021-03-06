/**
 * @file TestRunner.cs
 * 
 * Unity3D unit test runner.
 * Sets up the unit testing suite and executes all unit tests.
 * Drag this onto an empty GameObject to run tests.
 */

using UnityEngine;
using System.Collections;
using SharpUnit;

public class EMTestRunner 
{
    /**
     * Initialize class resources.
     */
	public static void UnitTest() 
    {
        // Create test suite
        TestSuite suite = new TestSuite();

        // Example: Add tests to suite
        suite.AddAll(new EMScheduler_Test());

        // Run the tests
        TestResult res = suite.Run(null);

        // Report results
        Unity3D_TestReporter reporter = new Unity3D_TestReporter();
        reporter.LogResults(res);
	}
}
