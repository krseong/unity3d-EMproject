오전 12:42 2015-10-05
작성자 : 성경린
작성내용 : Process
목적 : 
	1. 계산을 하는 프로세스

종류 :
	1. ComProcessMgr 에서 각각의 Entity 들을 등록, 사용 가능하다.
		> 우선순위 설정
		> 
	2. 3개의 프로세스 스텝으로 나뉘며 아래의 ProcEntity 를 상속 받아서 구현하면 된다.
		> 가상 서버(클라이언트 계산) : ComFakeServerProcEntity
		> HTTP 서버 : ComHTTPProcEntity
		> TCP 서버 : ComTCPProcEntity
	
namespace ComLib