using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
            Trun();
        }
    }
    
    void Jump()
    {
        position += new Vector2(-1.21f, 0.65f);
        transform.position = position;
    }

    
    void Trun()
    {
        //   , -4.92  , -5.63
        position += new Vector2(1.33f, 0.71f);
        // flipX를 반대로 전환
        _renderer.flipX = ! _renderer.flipX;
        Jump();
    }

}

