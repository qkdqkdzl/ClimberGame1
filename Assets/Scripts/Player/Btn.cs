using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 플레이어가 계단을 오를 수 있도록 해주는 코드
/// </summary>

public class Btn : MonoBehaviour
{
    public Vector2 currentPos;

    void Start()
    {
        currentPos = transform.position;
    }

    public void Jump()
    {
        currentPos += new Vector2(1f, 1.3f);
        transform.position = currentPos;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // G → 현재 바라보는 방향대로 점프
            Debug.Log("G 키: 정방향 점프");
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            // J → 방향을 뒤집고(Flip) → 점프
            Debug.Log("J 키: 방향 전환 후 점프");
            
            
        }
    }
}

