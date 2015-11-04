using UnityEngine ;
using System.Collections ;
public class BaseFormula
{
	public static DataFormula Formula_1 ( DataFormula result, DataFormula owner, params DataFormula[] other )
	{
		result = new DataFormula(owner) ;
		result.Atk = owner.Atk-other[0].Def ;
		return result ;
	}
	public static DataFormula Formula_2 ( DataFormula result, DataFormula owner, params DataFormula[] other )
	{
		result = new DataFormula(owner) ;
		result.Atk = owner.Atk*(other[0].AtkBuff1+1) ;
		return result ;
	}
	public static DataFormula Formula_3 ( DataFormula result, DataFormula owner, params DataFormula[] other )
	{
		result = new DataFormula(owner) ;
		result.Def = owner.Def/(other[0].DefDeBuff1+1) ;
		return result ;
	}
}


delegate DataFormula DelegateFormula (DataFormula result, DataFormula owner, params DataFormula[] other);