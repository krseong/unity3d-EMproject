using UnityEngine;
using System.Collections;
using ComLib;
using Define;

public class EMResult
{
	public EMResultType type;
}

public class EMSimulationResult : EMResult
{}

public class EMEventResult : EMResult
{}

public class EMGameClearResult : EMResult
{}

public class EMSelectUniversityResult : EMResult
{}

public class EMEnableReturnResult : EMResult
{}

public class EMUIResult
{
	/// <summary>
	/// 결과 데이터를 받는 함수, Show Result.
	/// </summary>
	/// <param name="result">Result.</param>
	private void Show ( EMResult result )
	{}

	/// <summary>
	/// UI결과연출이후 UIMain으로 돌아 가는코드.
	/// </summary>
	private void ReadyUIMain ()
	{
		EMUIMainMgr.Instance.Show (null);
	}
}

public class EMUIResultMgr : Singleton<EMUIResult>
{
}
