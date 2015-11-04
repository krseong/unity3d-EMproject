using UnityEngine;

namespace ComLib
{
	public class ComUIEntity : ComLogicInterface
	{
		// call by system
		private bool init;

		private void OnInit_System () 
		{
			ComDebug.Log (string.Format("OnInit_Prev > {0}", this.GetType()));
			init = OnInit ();
		}
		private void OnReset_System () 
		{
			ComDebug.Log (string.Format("OnReset_Prev > {0}", this.GetType()));
			OnReset ();
			if(init == false)
			{
				OnInit_System();
				OnRegister();
				OnStart();
			}
		}

		// call by ComUIManager
		public static T OnCreate<T> () where T : ComUIEntity, new()
		{
			T instance = new T ();
			instance.OnReset_System ();
			return instance;
		}
		public void OnDestroy ()
		{
			ComDebug.Log (string.Format("OnDestroy > {0}", this.GetType()));
			init = false;
			OnRelease ();
		}
		public virtual void OnPause (bool isPause)
		{
			ComDebug.Log (string.Format("OnPause > {0}", this.GetType()));
		}
		public virtual void OnMessage ( object arg )
		{
			ComDebug.Log (string.Format("OnMessage > {0}", this.GetType()));
		}
		public virtual void OnUpdate ()
		{
			ComDebug.Log (string.Format("OnUpdate > {0}", this.GetType()));
		}
		public virtual void OnWaitForEndOfFrame ()
		{
			ComDebug.Log (string.Format("OnWaitForEndOfFrame > {0}", this.GetType()));
		}
		public virtual bool OnInit ()
		{
			ComDebug.Log (string.Format("OnInit > {0}", this.GetType()));
			return true;
		}
		public virtual void OnRegister ()
		{
			ComDebug.Log (string.Format("OnRegister > {0}", this.GetType()));
		}
		public virtual void OnStart ()
		{
			ComDebug.Log (string.Format("OnStart > {0}", this.GetType()));
		}
		public virtual void OnRelease ()
		{
			ComDebug.Log (string.Format("OnRelease > {0}", this.GetType()));
		}

		// call by user (optional)
		public virtual void OnReset () 
		{
			ComDebug.Log (string.Format("OnReset > {0}", this.GetType()));
		}

		// call by mono(UI GameObject) (optional)
		public virtual void OnEnable ()
		{
			ComDebug.Log (string.Format("OnEnable > {0}", this.GetType()));
		}
		public virtual void OnDisable ()
		{
			ComDebug.Log (string.Format("OnDisable > {0}", this.GetType()));
		}
	}
}