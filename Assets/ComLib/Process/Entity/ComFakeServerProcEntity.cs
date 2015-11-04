using UnityEngine;
using System.Collections;

namespace ComLib
{
	public class ComFakeServerProcEntity : ComProcEntity
	{
		public override bool OnMakeDataForm (ref string dataForm){return true;}
		public override bool OnSuccess (string metaData) {return true;}
		public override void OnFailure () {}	// not use this function

		public override IEnumerator OnProcess ( ProcInfo pi )
		{
			string form = "";

			if (OnMakeDataForm (ref form)) 
			{
				OnSuccess (form);
			}
			else
			{
				ComDebug.Log(string.Format("{0}.OnMakeDataForm = false : {1}", this.GetType().ToString(), errorMsg));
				yield break;
			}

			if(string.IsNullOrEmpty(errorMsg) == false)
			{
				ComDebug.Log(string.Format("{0}.OnSuccess = false : {1}", this.GetType().ToString(), errorMsg));
				yield break;
			}

			yield return null;
		}
	}
}