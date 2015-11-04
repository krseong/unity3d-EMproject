using UnityEngine;
using System.Collections;

public enum Formula_Type
{
	NULL 			= 0,
	ATTACK_NORMAL 	= 1,
	ATTACK_BUFF1	= 2,
	DEFENSE_BUFF1	= 3,
}

public class MainFormula : MonoBehaviour 
{
	public Formula_Type		formulaType = Formula_Type.ATTACK_NORMAL;
	public DataFormula		ownerData;
	public DataFormula[]	otherData;
	public bool				action;

	// Use this for initialization
	void Start () 
	{
		FormulaMgr.Instance.Init ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(action)
		{
			action = false;

			DataFormula resultData = null;

			resultData = FormulaMgr.Instance.CallFuncFormula((int) formulaType, resultData, ownerData, otherData);

			Log (resultData);
		}
	}

	void Log ( DataFormula result )
	{
		Debug.Log (string.Format("{0}\n{1}\n{2}\n{3}", result.Atk, result.Def, result.AtkBuff1, result.DefDeBuff1));
	}
}
