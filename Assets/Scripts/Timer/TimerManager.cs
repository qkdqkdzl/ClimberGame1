using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    //public Animator fallAnimator;   
    public Image timerBarImage;
    public float baseTime = 10f;
    public GameObject gameOverUI;  // 게임오버 메시지 UI 오브젝트 (비활성 상태로 시작)

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

        // 타이머 끝났을 때 실행
        timerBarImage.fillAmount = 0f;
        isRunning = false;

        //fallAnimator.SetTrigger("falling");

        gameOverUI.SetActive(true);
    }
    public void OnFallAnimationEnd()
    {
        Destroy(gameObject); // 이 스크립트가 붙은 캐릭터 오브젝트를 삭제
    }       
}
