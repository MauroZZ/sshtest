using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // Arrastra aqu� el Transform de tu Tanque
    public Vector3 offset = new Vector3(-102.7f, 113.6f, 87f); // Ajusta para la posici�n deseada

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        else
        {
            Debug.LogWarning("�No se ha asignado ning�n objetivo (Tanque) al script FollowTarget!");
        }
    }
}