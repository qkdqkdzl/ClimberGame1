using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyClick : MonoBehaviour
{
    [SerializeField] private TMP_Text[] clickCountTexts; 

    private void Start()
    {
        int savedClick = ClickData.Instance.lastClickCount;

        foreach (var text in clickCountTexts)
        {
            if (text != null)
                text.text = savedClick + "È¸ µµÀü!";
        }
    }
}
