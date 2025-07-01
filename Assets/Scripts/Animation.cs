using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private bool hasFallen = false;

    [Header("타이머 설정")]
    public float timerDuration = 5f; // 예시로 5초
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = timerDuration;
    }

    void Update()
    {
        if (hasFallen) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            hasFallen = true;
            animator.SetTrigger("StartFalling");
        }
    }

    //      이 함수는 falling 애니메이션 마지막 프레임에 Animation Event로 연결해야 함
    public void OnFallAnimationEnd()
    {
        Destroy(gameObject); // 캐릭터 삭제
    }
}
