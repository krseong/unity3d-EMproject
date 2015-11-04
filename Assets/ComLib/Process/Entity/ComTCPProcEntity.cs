using UnityEngine;
using System.Collections;

namespace ComLib
{
	public class ComTCPProcEntity : ComProcEntity
	{
		public override bool OnMakeDataForm (ref string dataForm){return true;}
		public override bool OnSuccess (string metaData) {return true;}
		public override void OnFailure () {}

		public override IEnumerator OnProcess ( ProcInfo pi )
		{
			yield return null;
		}
	}
}