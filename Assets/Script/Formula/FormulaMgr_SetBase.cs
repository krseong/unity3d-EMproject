using UnityEngine;
using System.Collections;

public partial class FormulaMgr
{
	public void Init ()
	{
		baseFormulaDic.Add(1, BaseFormula.Formula_1);
		baseFormulaDic.Add(2, BaseFormula.Formula_2);
		baseFormulaDic.Add(3, BaseFormula.Formula_3);
	}
}