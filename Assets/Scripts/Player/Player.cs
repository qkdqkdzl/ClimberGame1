using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// �÷��̾ ����� ���� �� �ֵ��� ���ִ� �ڵ�
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
       
        // ������ ����
        if (Input.GetKeyDown(KeyCode.G))
        {       
            Debug.Log("������ �̵�");
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("ȸ��!");
            Trun();
            Change();
            Jump();
        }
    }
    
    // ĳ���Ͱ� ���� ������� ����
    void Jump()
    {
        // X ��ǥ -1.21f ��ŭ, y 0.65f ��ŭ ������
        position += new Vector2(-1.21f, 0.65f);
        transform.position = position;
    }

    // ĳ���Ͱ� ������ �� ȸ����Ŵ
    void Change()
    {
        // flipX�� �ݴ�� ��ȯ
        _renderer.flipX = ! _renderer.flipX;
        Trun();
    }
    
    // ����, ������ ������ȯ
    void Trun()
    {
        // X ��ǥ 1.28f ��ŭ, y 0.71 ��ŭ ������
        position += new Vector2(1.28f, 0.71f);
        
    }

}

