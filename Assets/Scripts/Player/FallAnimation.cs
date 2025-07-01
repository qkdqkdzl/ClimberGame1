using System;
using UnityEngine;

public class FallAnim    : MonoBehaviour
{
    private Animator animator; 
    private bool hasPlayedFallAnim = false;             
    public float gravity = -9.8f;        // 중력 가속도
    public float rayDistance = 10f;     // 바닥 체크 거리
    public LayerMask blockLayer;         //  여기서 Block 레이어만 포함

    private float verticalSpeed = 0f;
    private bool isFalling = false;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (!isFalling)

        {
            if (!IsOnBlock())
            {
                isFalling = true;
                verticalSpeed = 0f;

                if (!hasPlayedFallAnim) // 추가됨
                {
                    animator.SetTrigger("StartFalling"); // 추가됨
                    hasPlayedFallAnim = true; // 추가됨
                }
            }
            

        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime;
            transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);

            if (transform.position.y < -10f)
            {
                Debug.Log("Game Over");
                // GameOver 처리 코드 넣기
            }
        }
    }

    bool IsOnBlock()
    {
        //  blockLayer를 사용해 Block 레이어만 체크
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, blockLayer);
        

    }

    // (선택) Scene에서 디버그용 선 보여주기
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }

    public void OnFallAnimationEnd() // 추가됨
    {
        Destroy(gameObject); // 추가됨
    }
}

