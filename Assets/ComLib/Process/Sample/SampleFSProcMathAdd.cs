using UnityEngine;
using System.Collections;
using ComLib;

// FSProc = FakeServerProcess
public class SampleFSProcMathAdd : ComFakeServerProcEntity
{
	int _param1;
	int _param2;
	ComVoidDelegateObjParam _cbFunc;

	public SampleFSProcMathAdd ( int param1, int param2, ComVoidDelegateObjParam cbFunc )
	{
		_param1 = param1;
		_param2 = param2;
		_cbFunc = cbFunc;
	}

	public override bool OnMakeDataForm (ref string dataForm)
	{
		return base.OnMakeDataForm(ref dataForm);
	}

	public override bool OnSuccess (string metaData)
	{
		int add = _param1 + _param2;

		if(_cbFunc != null)
		{
			_cbFunc((object) add);
		}

		return true;
	}

	public override void OnFailure ()
	{
		// not use
	}
}
