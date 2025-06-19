using System.Collections;
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
    private bool isRunning = false;

    void Start()
    {
        ResetAndStartTimer();
    }

    public void OnUpButtonPress()
    {
        IncreaseSpeed();
        ResetAndStartTimer();
    }

    public void OnTrunButtonPress()
    {
        IncreaseSpeed();
        ResetAndStartTimer();
    }

    void IncreaseSpeed()
    {
        timeSpeed += 0.4f;
        if (timeSpeed > 4f)
            timeSpeed = 4f;
    }

    void ResetAndStartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            isRunning = false;
        }

        currentTime = baseTime;
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        isRunning = true;

        while (currentTime > 0f)
        {
            currentTime -= Time.deltaTime * timeSpeed;
            timerBarImage.fillAmount = Mathf.Clamp01(currentTime / baseTime);
            yield return null;
        }

        timerBarImage.fillAmount = 0f;
        isRunning = false;

                         
    }
}