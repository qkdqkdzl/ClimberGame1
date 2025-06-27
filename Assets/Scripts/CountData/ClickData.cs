using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 클릭 수 저장용 스크립트 
/// </summary>
public class ClickData : MonoBehaviour
{
    public static ClickData  Instance;

    public int lastClickCount = 0; // 게임 끝났을 때 저장된 클릭 수

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 이동해도 유지
            //SceneManager.LoadScene("Menu");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveClickCount(int count)
    {
        lastClickCount = count;
    }
}

  


    
