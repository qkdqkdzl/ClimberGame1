
using UnityEngine;

public class PlayerBtn : MonoBehaviour
{

    public GameObject gameOverMessage;   // Canvas 안의 "게임오버" UI 오브젝트
    public LayerMask blockLayer;         // Block 레이어만 체크
    
    /// <summary>
    /// 버튼 누르면 이동시킬 좌표 값
    /// </summary>
    public void OnUpButton()
    {
        transform.position += new Vector3(-1.286f, 0.599f, 0f);
    }
        
    public void OnTrunButton()
    {
        transform.position += new Vector3(1.264f, 0.599f, 0f);              
    }
    
}

