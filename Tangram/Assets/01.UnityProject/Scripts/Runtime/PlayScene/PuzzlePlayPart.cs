using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isClicked = false;
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.gameObject.GetComponentMust<PuzzleInitZone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //! 마우스 버튼을 눌렀을 때 동작
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    //! 마우스 버튼에서 손을 뗐을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }
    //! 마우스 버튼을 누르고 드래그 했을 때 동작
    public void OnDrag(PointerEventData eventData)
    {
        if(isClicked == true)
        {
            // 절대좌표를 설정하는 로직에서 상대적 움직임을 현재 포지션에 더하는 로직으로 수정
            // 캔버스 스케일팩터 만큼 발생하는 오차를 수정하는 로직
            gameObject.AddAnchoredPos(eventData.delta/puzzleInitZone.parentCanvas.scaleFactor);
        }
    }

}
