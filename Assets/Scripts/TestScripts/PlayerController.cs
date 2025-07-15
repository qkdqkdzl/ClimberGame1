using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // 게임 종료 문구를 표시할 TextMeshProUGUI 컴포넌트를 연결합니다.
    public TMP_Text gameOverText;

    // 충돌이 끝나는 순간 호출되는 함수입니다.
    private void OnCollisionExit(Collision collision)
    {
        // 충돌이 끝난 오브젝트의 태그가 "Block"인지 확인합니다.
        if (collision.gameObject.CompareTag("Block"))
        {
            // gameOverText 변수가 null이 아닐 때만 실행합니다.
            if (gameOverText != null)
            {
                gameOverText.text = "Game Over!"; // 텍스트 내용 변경
                gameOverText.gameObject.SetActive(true); // 텍스트 오브젝트 활성화
            }

            // 게임 시간을 멈춰서 게임을 정지시킵니다.
            Time.timeScale = 0;
            // 커밋확인         
        }
    }
}
