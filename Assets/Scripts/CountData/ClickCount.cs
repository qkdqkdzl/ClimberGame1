using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCount : MonoBehaviour
{
    /// <summary>
    /// 클릭 카운트하는 스크립트
    /// </summary>
    private int currentClick = 0;

    public void OnClickButton() // Turn, Up 버튼에 연결
    {
        currentClick++;
        Debug.Log("현재 클릭 수: " + currentClick);
    }
    
    public void OnGameOver()
    {
        ClickData.Instance.SaveClickCount(currentClick);
    }
}
