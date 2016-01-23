using UnityEngine;
using System.Collections;

namespace ComLib
{
	public abstract class ComFSMEntity<T>
	{
		public abstract bool OnEnter ( T p_Owner );
		public abstract bool OnProcess ( T p_Owner );
		public abstract void OnExit ( T p_Owner );
	}
}