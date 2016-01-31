using UnityEngine;
using System.Collections;

namespace ComLib
{
	public abstract class ComFSMEntity<T>
	{
		public abstract bool OnAwake ( T p_Owner );

		public abstract bool OnEnter ( T p_Owner );
		public abstract bool OnProcess ( T p_Owner );
		public abstract void OnExit ( T p_Owner );

		// editor
		public abstract void OnGUI ( T p_Owner );
	}
}