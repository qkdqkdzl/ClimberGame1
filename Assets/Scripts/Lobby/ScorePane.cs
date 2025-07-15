using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class ScorePane : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI appleCountText;

    // 게임 중 현재 세션용 (선택사항)
    private int sessionCoinCount = 0;
    private int sessionAppleCount = 0;

    void Start()
    {
        UpdateCoinCountUI();
        UpdateAppleCountUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Apple"))
        {
            AddApple();
            Destroy(other.gameObject);
        }
    }

    void AddCoin(int amount = 1)
    {
        int total = PlayerPrefs.GetInt("TotalCoins", 0);
        total += amount;
        PlayerPrefs.SetInt("TotalCoins", total);
        // UI 갱신은 여기서 하지 않음!
    }

    void AddApple(int amount = 1)
    {
        int total = PlayerPrefs.GetInt("TotalApples", 0);
        total += amount;
        PlayerPrefs.SetInt("TotalApples", total);
        // UI 갱신은 여기서 하지 않음!
    }   

    void UpdateCoinCountUI()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        coinCountText.text = totalCoins.ToString();
    }

    void UpdateAppleCountUI()
    {
        int totalApples = PlayerPrefs.GetInt("TotalApples", 0);
        appleCountText.text = totalApples.ToString();
    }

    //// 필요할 경우 리셋 버튼 함수                    
    //public void ResetTotalCounts()
    //{
    //    PlayerPrefs.DeleteKey("TotalCoins");
    //    PlayerPrefs.DeleteKey("TotalApples");
    //    UpdateCoinCountUI();
    //    UpdateAppleCountUI();
    //}
}