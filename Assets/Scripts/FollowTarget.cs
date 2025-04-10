using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // Arrastra aquí el Transform de tu Tanque
    public Vector3 offset = new Vector3(-102.7f, 113.6f, 87f); // Ajusta para la posición deseada

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        else
        {
            Debug.LogWarning("¡No se ha asignado ningún objetivo (Tanque) al script FollowTarget!");
        }
    }
}