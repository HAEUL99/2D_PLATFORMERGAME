using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscEvnt : MonoBehaviour
{
    /*
    //① 이벤트 생성을 위한 대리자 하나 생성
    public delegate void EventHandler(); //메서드를 여러 개 등록 후 호출 가능

    //② 이벤트 선언: Click 이벤트
    public event EventHandler Esc_Click;

    //③ 이벤트 발생 메서드: OnClick 이벤트 처리기(핸들러) 생성
    public void OnEscClick()
    {
        if (Esc_Click != null) //이벤트에 등록된 값이 있는지 확인(생략 가능)
        {
            Esc_Click();    //대리자 형식의 이벤트 수행
        }
    }
    */

    [SerializeField]
    private GameObject escUI;
    private bool CanseeUI;

    private void Start()
    {
        escUI.SetActive(false);
        CanseeUI = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PressEsc();

        }
    }

    private void PressEsc()
    {
        if (CanseeUI == false)
        {
            escUI.SetActive(true);
            CanseeUI = true;
        }
        else
        {
            escUI.SetActive(false);
            CanseeUI = false;
        }
    }

}
