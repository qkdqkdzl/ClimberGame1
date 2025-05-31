using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 플레이어가 계단을 오를 수 있도록 해주는 코드
/// </summary>

public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;

    private Vector2 position;



    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
       
        // 앞으로 점프
        if (Input.GetKeyDown(KeyCode.G))
        {       
            Debug.Log("앞으로 이동");
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("회전!");
            Trun();
            Change();
            Jump();
        }
    }
    
    // 캐릭터가 다음 블록으로 점프
    void Jump()
    {
        // X 좌표 -1.21f 만큼, y 0.65f 만큼 움직임
        position += new Vector2(-1.21f, 0.65f);
        transform.position = position;
    }

    // 캐릭터가 돌았을 때 회전시킴
    void Change()
    {
        // flipX를 반대로 전환
        _renderer.flipX = ! _renderer.flipX;
        Trun();
    }
    
    // 왼쪽, 오른쪽 방향전환
    void Trun()
    {
        // X 좌표 1.28f 만큼, y 0.71 만큼 움직임
        position += new Vector2(1.28f, 0.71f);
        
    }

}

