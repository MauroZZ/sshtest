using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;         // El tanque
    public Vector3 offset = new Vector3(-69, 76, -79);  // Ajustá para tu juego
    public float smoothSpeed = 0.125f;              // Suavidad de seguimiento

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + target.rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
