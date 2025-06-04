using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBtn : MonoBehaviour
{
    public void OnUpButton()
    {
        transform.position += new Vector3(-1.29f, 0.66f, 0f);
    }

    public void OnTrunButton()
    {
        transform.position += new Vector3(1.23f, 0.67f, 0f); 
    }
}
