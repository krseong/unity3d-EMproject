using UnityEngine;
using System;

namespace ComLib
{
	public class SingletonGameObject<T> : MonoBehaviour where T : MonoBehaviour {
	    private static WeakReference<T> _instance;
	    private static bool quit = false;

	    void OnApplicationQuit() {
	        quit = true;
	    }

	    public static bool HasInstance() {
	        if (_instance == null || _instance.Target == null) {
	            return false;
	        }

	        return true;
	    }

	    public static T Instance {
	        get {
	            if (quit) {
	                return null;
	            }

	            if (_instance != null && _instance.Target != null) {
	                return _instance.Target;
	            }

	            GameObject container = new GameObject();
	            container.name = "_" + typeof(T).Name;
	            T instance = container.AddComponent(typeof(T)) as T;
	            _instance = new WeakReference<T>(instance);
	            return instance;
	        }
	    }
	}


	public class Singleton<T> where T : new() {
	    private static T _instance;

	    public static T Instance {
	        get {
	            if( _instance == null ) {
	                _instance = new T();
					ComDebug.Log (string.Format("create singleton[{0}]", typeof(T).Name));
	            }
	            
	            return _instance;
	        }
			set
			{
				if(value != null)
					return;

				_instance = value;
			}
	    }
	}
}