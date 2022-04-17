using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    float speed = 7.0f;

    public Button m_LButton;
    public Button m_RButton;

    private bool isRBtnDown = false;
    private bool isLBtnDown = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 초당 60프레임으로 고정
        QualitySettings.vSyncCount = 0; // 모니터 주사율이 다른 컴퓨터일 경우, 캐릭터 조작시 빠르게 움직일 수 있다.
        /*
        if (m_LButton != null)
            m_LButton.onClick.AddListener(LButtonDown);
        if (m_RButton != null)
            m_RButton.onClick.AddListener(RButtonDown);
        */
        //-----------Right Button 처리 부분
        EventTrigger a_trigger = m_RButton.GetComponent<EventTrigger>(); // Inspector에서 GameObject.Find("Button"); 에 꼭 AddComponent--> EventTrigger 가 되어 있어야 한다.
        EventTrigger.Entry a_entry = new EventTrigger.Entry();
        a_entry.eventID = EventTriggerType.PointerDown;
        a_entry.callback.AddListener((data) => { OnRBtnDownDelegate((PointerEventData)data); });
        a_trigger.triggers.Add(a_entry);

        a_entry = new EventTrigger.Entry();
        a_entry.eventID = EventTriggerType.PointerUp;
        a_entry.callback.AddListener((data) => { OnRBtnUpDelegate((PointerEventData)data); });
        a_trigger.triggers.Add(a_entry);
        //-----------Right Button 처리 부분

        //-----------Left Button 처리 부분
        a_trigger = m_LButton.GetComponent<EventTrigger>(); // Inspector에서 GameObject.Find("Button"); 에 꼭 AddComponent--> EventTrigger 가 되어 있어야 한다.
        a_entry = new EventTrigger.Entry();
        a_entry.eventID = EventTriggerType.PointerDown;
        a_entry.callback.AddListener((data) => { OnLBtnDownDelegate((PointerEventData)data); });
        a_trigger.triggers.Add(a_entry);

        a_entry = new EventTrigger.Entry();
        a_entry.eventID = EventTriggerType.PointerUp;
        a_entry.callback.AddListener((data) => { OnLBtnUpDelegate((PointerEventData)data); });
        a_trigger.triggers.Add(a_entry);
        //-----------Left Button 처리 부분
    }

    // Update is called once per frame
    void Update()
    {
        // 왼쪽 화살표가 눌렸을때
        if ((transform.position.x > -8.0f) && 
            (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A) || 
            isLBtnDown == true))
            transform.Translate(-3.0f * Time.deltaTime * speed, 0, 0);

        // 오른쪽 화살표가 눌렸을때
        if ((transform.position.x < 8.0f) &&
            (Input.GetKey(KeyCode.RightArrow) || 
            Input.GetKey(KeyCode.D) ||
            isRBtnDown == true))
            transform.Translate(3.0f * Time.deltaTime * speed, 0, 0);

        if (GameDirector.s_State == GameState.GameOver) // 게임오버시 캐릭터의 포지션을 원점으로 초기화
            transform.position = new Vector3(0, -3.6f, 0);
    }
    public void LButton()
    {
        transform.Translate(-3, 0, 0);
    }

    public void RButton()
    {
        transform.Translate(3, 0, 0);
    }

    //버튼이 눌려질 때 한번 발생되는 함수 
    public void OnRBtnDownDelegate(PointerEventData _data)
    {
        //마우스 왼쪽 버튼 누르고 있는 동안에만 발동되게...
        if (_data.button == PointerEventData.InputButton.Left)
            isRBtnDown = true;
    }

    //버튼을 뗄때 한번 발생되는 함수 
    public void OnRBtnUpDelegate(PointerEventData _data)
    {
        //마우스 왼쪽 버튼 누르고 있는 동안에만 발동되게...
        if (_data.button == PointerEventData.InputButton.Left)
            isRBtnDown = false;
    }

    //버튼이 눌려질 때 한번 발생되는 함수 
    public void OnLBtnDownDelegate(PointerEventData _data)
    {
        //마우스 왼쪽 버튼 누르고 있는 동안에만 발동되게...
        if (_data.button == PointerEventData.InputButton.Left)
            isLBtnDown = true;
    }

    //버튼을 뗄때 한번 발생되는 함수 
    public void OnLBtnUpDelegate(PointerEventData _data)
    {
        //마우스 왼쪽 버튼 누르고 있는 동안에만 발동되게...
        if (_data.button == PointerEventData.InputButton.Left)
            isLBtnDown = false;
    }
}
