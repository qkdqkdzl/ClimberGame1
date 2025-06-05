        using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Image timerBarImage;
    public float baseTime = 10f;

    private float currentTime;
    private float timeSpeed = 1f;
    private Coroutine timerCoroutine;

    void Start()
    {
        StartTimer();
    }

    public void OnUpButtonPress()
    {
        IncreaseSpeed();
        StartTimer();
    }

    public void OnTrunButtonPress()
    {
        IncreaseSpeed();
        StartTimer();
    }

    void IncreaseSpeed()
    {
        timeSpeed += 0.4f;
        if (timeSpeed > 4f)
            timeSpeed = 4f;
    }

    void StartTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        currentTime = baseTime;
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime * timeSpeed;
            timerBarImage.fillAmount = Mathf.Clamp01(currentTime / baseTime);
            yield return null;  
        }

        timerBarImage.fillAmount = 0f;
    }

    
}
