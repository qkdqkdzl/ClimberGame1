using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothing = 1.0f; 

    private void LateUpdate()
    {
        
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position;  

            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

            
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
