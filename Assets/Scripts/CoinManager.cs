using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int coinCount = 0;
    public Text coinText;

    void Update()
    {
        coinText.text = "Coins: " + coinCount;
    }

    public static void AddCoin()
    {
        coinCount++;
    }
}
