using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{    
    public Button scenesBtn;


    private void Start()
    {
        //만약 Start()에서 버튼 리스너를 추가한다면(에디터 연결과 택1)
        if (scenesBtn != null)
        {
            scenesBtn.onClick.AddListener(SceneUpdate);
        }
    }

    // 이 함수가 버튼 클릭 시 실행될 함수입니다.
    public void SceneUpdate()
    {
        Debug.Log("SceneUpdate 함수 실행! play 씬 로드.");
        SceneManager.LoadScene("play");
    }   
}
