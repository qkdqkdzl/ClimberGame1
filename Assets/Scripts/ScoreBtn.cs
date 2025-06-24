using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBtn : MonoBehaviour
{
    // 점수를 표시할 TextMeshProUGUI 변수
    public TextMeshProUGUI scoreCountText;
    public Button Scoerbtn;

    // 현재 점수 (버튼이 눌린 횟수)
    private int currentScore = 0;

    void Start()
    {
        // 스크립트가 붙어있는 GameObject에서 Button 컴포넌트를 가져옵니다.
        // 이 스크립트가 스코어 버튼 오브젝트에 직접 붙어있을 때 사용합니다.
        Button scoreButton = GetComponent<Button>();

        // 버튼이 존재하면 클릭 이벤트에 IncreaseScore 함수를 연결합니다.
        if (scoreButton != null)
        {
            scoreButton.onClick.AddListener(IncreaseScore);
        }
        else
        {
            Debug.LogError("ScoreButtonHandler 스크립트가 Button 컴포넌트가 없는 오브젝트에 부착되었습니다!");
        }

        // 게임 시작 시 점수 UI 초기화
        UpdateScoreUI();
    }

    /// <summary>
    /// 버튼이 클릭될 때마다 점수를 1 증가시키고 UI를 업데이트합니다.
    /// </summary>
    public void IncreaseScore()
    {
        currentScore++; // 점수 1 증가
        UpdateScoreUI(); // UI 업데이트
        Debug.Log("스코어 버튼 클릭! 현재 점수: " + currentScore);
    }

    /// <summary>
    /// 점수 UI 텍스트를 업데이트합니다.
    /// </summary>
    void UpdateScoreUI()
    {
        if (scoreCountText != null)
        {
            scoreCountText.text = "점수: " + currentScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score Count Text가 연결되지 않았습니다. UI 업데이트를 할 수 없습니다.");
        }
    }
}
