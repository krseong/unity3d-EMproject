오후 11:18 2015-09-30
작성자 : 성경린
작성내용 : UIManager
목적 : 
	1. 통일된 UI frame 제작
	2. 난독화 모듈 적용에 문제없도록 제작 하면 좋겠다.
		> SendMessage 에 오브젝트, string 있으면 곤란하다.

작업 :
	ComUIManager.cs 
		> 모든 UIFrame 이 등록되고 관리된다.
		> UIFrame 전환 연출담당해야한다.
		> 버튼도 처리하는가? 버튼등 이벤트가 모두 이쪽으로 와야 한다.
		> 이벤트를 각각의 UIFrame 에 전달하는가? 맞다.
	ComUIEntity.cs
		> UIFrame entity (virtual 정의)
		> (UIGameObject)->ComUIManager->OnCreate->OnReset_System->OnReset->OnInit_System->OnInit->OnRegister->OnStart
		> (UIGameObject)->ComUIManager->OnDestroy->OnRelease
		> (UIGameObject)->ComUIManager->OnMessage
		> (UIGameObject)->ComUIManager->OnUpdate & OnWaitForEndOfFrame
		> ComUIManager->OnPause (optional)
		> UIGameObject->OnEnable (optional)
		> UIGameObject->OnDisable (optional)
		> UserScript->OnReset (optional)

namespace ComLib