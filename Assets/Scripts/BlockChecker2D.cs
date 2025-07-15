using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockChecker2D : MonoBehaviour
{
    [Header("UI")]
    public Button gameOverButton;

    [Header("Ground Check Settings")]
    public LayerMask groundLayer;               // Inspector에서 체크
    public float groundCheckRadius = 0.1f;      // 바닥 감지 반경
    public Vector2 groundCheckOffset = new Vector2(0f, 0.05f);
    public float skipDuration = 0.1f;           // 이동 후 감지 스킵 시간

    [Header("Movement Settings")]
    public float moveDistance = 1.0f;

    private bool isGameOver = false;
    private bool skipGroundCheck = false;
    private Collider2D playerCollider;

    void Start()
    {
        gameOverButton.gameObject.SetActive(false);
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isGameOver || skipGroundCheck) return;
        CheckGround();
    }

    void CheckGround()
    {
        Vector2 footPosition = new Vector2(transform.position.x, playerCollider.bounds.min.y) + groundCheckOffset;
        Debug.DrawLine(footPosition, footPosition + Vector2.down * groundCheckRadius * 2f, Color.red);

        // OverlapCircle을 사용해 바닥을 감지
        Collider2D ground = Physics2D.OverlapCircle(footPosition, groundCheckRadius, groundLayer);
        if (ground == null)
        {
            GameOver();
        }
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * moveDistance);
        StartCoroutine(SkipAndRecheck());
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * moveDistance);
        StartCoroutine(SkipAndRecheck());
    }

    IEnumerator SkipAndRecheck()
    {
        skipGroundCheck = true;
        yield return new WaitForSeconds(skipDuration);
        skipGroundCheck = false;
        CheckGround();  // 스킵 끝난 직후 한 번 더 검사
    }

    void OnDrawGizmosSelected()
    {
        if (playerCollider == null) return;
        Vector2 footPosition = new Vector2(transform.position.x, playerCollider.bounds.min.y) + groundCheckOffset;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(footPosition, groundCheckRadius);
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverButton.gameObject.SetActive(true);
        Debug.Log("Game Over");
    }
}
