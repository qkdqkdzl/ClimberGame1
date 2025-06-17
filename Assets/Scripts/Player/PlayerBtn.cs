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
        transform.position += new Vector3(-1.29f, 0.66f, 0f);
    }

    public void OnTrunButton()
    {
        transform.position += new Vector3(1.23f, 0.67f, 0f);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CoinManager.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
