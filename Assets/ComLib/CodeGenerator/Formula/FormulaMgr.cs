using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ComLib;

public partial class FormulaMgr : Singleton<FormulaMgr>
{
	private Dictionary<int, DelegateFormula> baseFormulaDic = new Dictionary<int, DelegateFormula>();

	public DataFormula CallFuncFormula (int key, DataFormula result, DataFormula owner, params DataFormula[] other)
	{
		return result = baseFormulaDic[key](result, owner, other);
	}
}
