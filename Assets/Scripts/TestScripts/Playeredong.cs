using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeredong : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1.286f, 0.599f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1.264f, 0.599f, 0f);
        }

        
    }
  
    
}
