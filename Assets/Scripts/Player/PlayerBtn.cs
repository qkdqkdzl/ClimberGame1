using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBtn : MonoBehaviour
{

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

public class Player : MonoBehaviour
{
    public Rigidbody rbody;
    public Vector3 moveDir;
    public float moveSpeed;

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDir.Normalize();
    }

    private void FixedUpdate()  
    {
        rbody.MovePosition(rbody.position + moveDir * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}