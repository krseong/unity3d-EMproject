using System.Collections;
using System.Collections.Generic;

namespace ComLib
{
	public abstract class ComProcEntity
	{
		public string errorMsg;

		public abstract bool OnMakeDataForm ( ref string dataForm );
		public abstract bool OnSuccess ( string metaData );
		public abstract void OnFailure ();

		public abstract IEnumerator OnProcess ( ProcInfo pi ) ;
	}
}