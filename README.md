# TangramGame
Copy mobile tangram game

2023-01-30 / font add
2023-01-30 / Setup Tangram
2023-01-30 / Title scene setup

Issue.
 - Summary : 유니티 2D 프로젝트에서 오브젝트 드래그를 구현할 때 IPointerMoveHandler를 사용해서 구현하는 중에 이슈발생
 - Detail : 
	1. IPointerMoveHandler에서 구현하는 OnPointermove 메서드는 아이드래그핸들러에서 구현하는 온드래그 메서드보다 호출속도가 느려서 드래그 도중 오브젝트를 놓친다. 이후에는 온드래그 메서드를 사용해서 구현하는 것이 더 나은 방식으로 추정된다.
	2. 포인터이벤트데이터에서 가지고 오는 마우스 포지션을 기준으로 오브젝트 위치를 계산할 때 오브젝트 자신의 피벗 위치만큼의 오차가 발생했다. 오브젝트의 로컬 포지션을 마우스 포인터를 기준으로 절대좌표로 재설정 했을 때 피벗 이슈가 발생하는 것을 확인했다. 이후에는 오브젝트를 움직일 때 절대좌표가 아닌 상대적인 움직임(즉, Delta)을 더해서 연산하는 방식이 오차가 적을 것으로 추청된다.
	3. 캔버스 하위에 위치한 오브젝트를 움직일 때 로컬 포지션을 연산해서 움직이면 앵커의 피벗과 캔버스의 스케일팩터 값 만큼의 오차가 발생하게 된다. 이후에는 로컬 포지션이 아닌, 앵커드 포지션과 스케일팩터 값을 고려해서 연산하는 것이 오차가 적을 것으로 예상된다.

2023-01-31 / Drag OK