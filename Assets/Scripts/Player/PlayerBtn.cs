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
