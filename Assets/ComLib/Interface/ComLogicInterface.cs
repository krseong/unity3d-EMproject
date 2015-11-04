
namespace ComLib
{
	public interface ComLogicInterface
	{
		void OnReset ();
		bool OnInit ();
		void OnRegister ();
		void OnStart ();

		void OnRelease ();
		void OnDestroy ();

		void OnPause (bool isPause);
		void OnMessage (object arg);
		void OnUpdate ();
		void OnWaitForEndOfFrame ();

		void OnEnable ();
		void OnDisable ();
	}
}