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
       
        // ������ ����
        if (Input.GetKeyDown(KeyCode.G))
        {       
            Debug.Log("������ �̵�");
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
        // flipX�� �ݴ�� ��ȯ
        _renderer.flipX = ! _renderer.flipX;
        Jump();
    }

}

