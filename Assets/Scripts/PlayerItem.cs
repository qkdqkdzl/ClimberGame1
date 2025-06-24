using TMPro;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    // === UI Text 변수들 ===
    public TextMeshProUGUI coinCountText;  // 코인 카운트를 표시할 UI 텍스트
    public TextMeshProUGUI appleCountText; // 사과 카운트를 표시할 UI 텍스트

    // === 카운트 변수들 ===
    private int coinCount = 0;  // 현재 코인 개수
    private int appleCount = 0; // 현재 사과 개수

    void Start()
    {
        // 게임 시작 시 UI 텍스트 초기화
        UpdateCoinCountUI();
        UpdateAppleCountUI();
    }

    // 트리거 충돌 감지 함수
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트의 태그 확인
        if (other.CompareTag("Coin"))
        {
            // 코인을 먹었을 때 사과 카운트 증가
            AddApple(); // <--- 변경: 코인을 먹으면 사과가 오름
            Destroy(other.gameObject); // 닿은 코인 오브젝트 파괴
            Debug.Log("코인을 획득했습니다! (사과 증가) 현재 사과: " + appleCount);
        }
        else if (other.CompareTag("Apple"))
        {
            // 사과를 먹었을 때 코인 카운트 증가
            AddCoin(); // <--- 변경: 사과를 먹으면 코인이 오름
            Destroy(other.gameObject); // 닿은 사과 오브젝트 파괴
            Debug.Log("사과를 획득했습니다! (코인 증가) 현재 코인: " + coinCount);
        }
    }

    // === 코인 관련 함수들 ===
    public void AddCoin(int amount = 1) // 기본값으로 1개씩 추가, 다른 수량도 가능하게
    {
        coinCount += amount;
        UpdateCoinCountUI(); // UI 업데이트
    }

    // 코인 카운트 UI 업데이트 함수
    void UpdateCoinCountUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "코인: " + coinCount.ToString();
        }
    }

    // === 사과 관련 함수들 ===
    public void AddApple(int amount = 1) // 기본값으로 1개씩 추가, 다른 수량도 가능하게
    {
        appleCount += amount;
        UpdateAppleCountUI(); // UI 업데이트
    }

    // 사과 카운트 UI 업데이트 함수
    void UpdateAppleCountUI()
    {
        if (appleCountText != null)
        {
            appleCountText.text = "사과: " + appleCount.ToString();
        }
    }
}

                
