using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class DataFormula
{
	public int	Atk	;
	public int	Def	;
	public int	AtkBuff1	;
	public int	DefDeBuff1	;

	public DataFormula (DataFormula orgData)
	{
		Atk = orgData.Atk ;
		Def = orgData.Def ;
		AtkBuff1 = orgData.AtkBuff1 ;
		DefDeBuff1 = orgData.DefDeBuff1 ;
	}
}