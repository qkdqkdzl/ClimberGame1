using UnityEngine;

public class PlayerBtn : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private bool trunPressed = false;  // Trun 버튼 눌렀는지 여부

    private void Start()
    {
        Transform playChild = transform.Find("play");
        if (playChild != null)
        {
            spriteRenderer = playChild.GetComponent<SpriteRenderer>();
        }
        else
        {
            Debug.LogError("play 자식 오브젝트를 찾을 수 없습니다!");
        }
    }

    // Up 버튼
    public void OnUpButton()
    {
        if (spriteRenderer != null)
        {
            if (spriteRenderer.flipX)
            {
                // 왼쪽을 바라보는 중이면 → 왼쪽 위로 이동
                transform.position += new Vector3(-1.264f, 0.599f, 0f);
            }
            else
            {
                // 오른쪽을 바라보는 중이면 → 오른쪽 위로 이동
                transform.position += new Vector3(1.264f, 0.599f, 0f);
            }
        }
    }

    // Trun 버튼
    public void OnTrunButton()
    {
        if (spriteRenderer != null)
        {
            // 좌우 반전하기 전에 현재 방향을 체크
            bool isFacingRight = !spriteRenderer.flipX;

            // 좌우 반전 토글
            spriteRenderer.flipX = !spriteRenderer.flipX;

            // 방향에 따라 왼쪽 위 또는 오른쪽 위로 이동
            if (isFacingRight)
            {
                // 오른쪽 보고 있었으면 왼쪽 위로 이동
                transform.position += new Vector3(-1.286f, 0.599f, 0f);
            }
            else
            {
                // 왼쪽 보고 있었으면 오른쪽 위로 이동
                transform.position += new Vector3(1.264f, 0.599f, 0f);
            }
        }
    }
}
