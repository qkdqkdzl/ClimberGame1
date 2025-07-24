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
        if (!trunPressed)
        {
            // Trun 버튼 한 번도 안 눌렸으면 오른쪽 위 이동
            transform.position += new Vector3(1.264f, 0.599f, 0f);
        }
        else
        {
            // Trun 버튼 눌렸으면 왼쪽 위 이동
            transform.position += new Vector3(-1.286f, 0.599f, 0f);
        }
        // Up 버튼은 flipX 조작 안 함
    }

    // Trun 버튼
    public void OnTrunButton()
    {
        // 오른쪽 위로 이동
        transform.position += new Vector3(1.264f, 0.599f, 0f);

        // 좌우 반전 토글
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // Trun 버튼 누름 상태 저장 (true로 설정)
        trunPressed = true;
    }
}
