using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FallAnim    : MonoBehaviour
{
    public float gravity = -9.8f;        // �߷� ���ӵ�
    private float verticalSpeed = 0f;
    private bool isFalling = false;

    public float rayDistance = 10f;     // �ٴ� üũ �Ÿ�
    public LayerMask blockLayer;         //  ���⼭ Block ���̾ ����

    void Update()
    {
        if (!isFalling)

        {
            if (!IsOnBlock())
            {
                isFalling = true;
                verticalSpeed = 0f;
            }
        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime;
            transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);

            if (transform.position.y < -10f)
            {
                Debug.Log("Game Over");
                // GameOver ó�� �ڵ� �ֱ�
            }
        }
    }

    bool IsOnBlock()
    {
        //  blockLayer�� ����� Block ���̾ üũ
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, blockLayer);
        

    }

    // (����) Scene���� ����׿� �� �����ֱ�
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }

}

