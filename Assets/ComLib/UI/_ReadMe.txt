���� 11:18 2015-09-30
�ۼ��� : ���渰
�ۼ����� : UIManager
���� : 
	1. ���ϵ� UI frame ����
	2. ����ȭ ��� ���뿡 ���������� ���� �ϸ� ���ڴ�.
		> SendMessage �� ������Ʈ, string ������ ����ϴ�.

�۾� :
	ComUIManager.cs 
		> ��� UIFrame �� ��ϵǰ� �����ȴ�.
		> UIFrame ��ȯ �������ؾ��Ѵ�.
		> ��ư�� ó���ϴ°�? ��ư�� �̺�Ʈ�� ��� �������� �;� �Ѵ�.
		> �̺�Ʈ�� ������ UIFrame �� �����ϴ°�? �´�.
	ComUIEntity.cs
		> UIFrame entity (virtual ����)
		> (UIGameObject)->ComUIManager->OnCreate->OnReset_System->OnReset->OnInit_System->OnInit->OnRegister->OnStart
		> (UIGameObject)->ComUIManager->OnDestroy->OnRelease
		> (UIGameObject)->ComUIManager->OnMessage
		> (UIGameObject)->ComUIManager->OnUpdate & OnWaitForEndOfFrame
		> ComUIManager->OnPause (optional)
		> UIGameObject->OnEnable (optional)
		> UIGameObject->OnDisable (optional)
		> UserScript->OnReset (optional)

namespace ComLib