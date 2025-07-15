using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI appleCountText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        int totalApples = PlayerPrefs.GetInt("TotalApples", 0);

        coinCountText.text = totalCoins.ToString();
        appleCountText.text = totalApples.ToString();
    }       
}
