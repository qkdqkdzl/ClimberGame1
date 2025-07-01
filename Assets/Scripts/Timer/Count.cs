        using TMPro;
using UnityEngine;

public class Count : MonoBehaviour
{
    public TextMeshProUGUI countText;
    private int totalPressCount = 0;

    public void OnButtonPressed()
    {
        //SceneManager.LoadScene(""); ¾À ÀüÈ¯

        totalPressCount++;
        countText.text = $"{totalPressCount}";
    }       
}
