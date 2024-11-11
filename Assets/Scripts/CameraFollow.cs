using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,2.5f,-5f);
    private float smoothSpeed = 0.0125f;

    
    public Transform target;

    private Vector3 targetPosition;

    
    private void LateUpdate()
    {
        if (target != null)
        {
            targetPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }

    

   
}
