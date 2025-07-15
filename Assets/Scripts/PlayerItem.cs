using TMPro;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;  // 코인 UI 텍스트
    public TextMeshProUGUI appleCountText; // 사과 UI 텍스트

    private int coinCount = 0;  // 현재 코인 개수
    private int appleCount = 0; // 현재 사과 개수

    void Start()
    {
        // 저장된 값 불러오기, 없으면 0
        coinCount = PlayerPrefs.GetInt("TotalCoins", 0);
        appleCount = PlayerPrefs.GetInt("TotalApples", 0);

        UpdateCoinCountUI();
        UpdateAppleCountUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AddApple(); // 코인을 먹으면 사과 증가
            Destroy(other.gameObject);
            Debug.Log("코인을 획득했습니다! (사과 증가) 현재 사과: " + appleCount);
        }
        else if (other.CompareTag("Apple"))
        {
            AddCoin(); // 사과를 먹으면 코인 증가
            Destroy(other.gameObject);
            Debug.Log("사과를 획득했습니다! (코인 증가) 현재 코인: " + coinCount);
        }
    }

    public void AddCoin(int amount = 1)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("TotalCoins", coinCount); // 저장
        UpdateCoinCountUI();
    }

    public void AddApple(int amount = 1)
    {
        appleCount += amount;
        PlayerPrefs.SetInt("TotalApples", appleCount); // 저장
        UpdateAppleCountUI();
    }

    void UpdateCoinCountUI()
    {
        if (coinCountText != null)
            coinCountText.text = "코인: " + coinCount.ToString();
    }

    void UpdateAppleCountUI()
    {
        if (appleCountText != null)
            appleCountText.text = "사과: " + appleCount.ToString();
    }
}
    
                
