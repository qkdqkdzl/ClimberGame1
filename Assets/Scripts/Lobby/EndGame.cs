using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    [SerializeField] private Button toMenuBtn;         // 이동 버튼
    [SerializeField] private GameObject buttonObject;  // 버튼 전체 오브젝트

    

    private void Start()
    {
        if (toMenuBtn != null)
        {
            toMenuBtn.onClick.AddListener(GoToMenu);
            buttonObject.SetActive(false); // 시작 시 버튼 숨김
        }
    }

    // 타이머 종료 시 호출될 함수
    public void ShowButton()
    {
        buttonObject.SetActive(true);
    }

    // 버튼 클릭 시 Menu 씬으로 이동
    public void GoToMenu()
    {
        Debug.Log("Menu 씬으로 이동합니다.");
        SceneManager.LoadScene("Menu");
    }
}
