using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 5f, -30f);

    public float followSpeed = 10f;


    float currentRotationY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public float rotationSpeed = 20f;

   

    void LateUpdate()
    {
        if (target == null) return;

        // Obtener rotación con mouse horizontal
        float horizontalInput = Input.GetAxis("Mouse X");
        currentRotationY += horizontalInput * rotationSpeed * Time.deltaTime;

        // Crear rotación y posición deseada
        Quaternion rotation = Quaternion.Euler(0f, currentRotationY, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Mover cámara suavemente
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Mirar al tanque
        transform.LookAt(target);
    }
}
