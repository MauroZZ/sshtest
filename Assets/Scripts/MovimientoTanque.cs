using UnityEngine;
using System.Collections;

public class MovimientoTanque : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float turnSpeed = 50f;
    public float strafeSpeed = 15f;
    public Transform cameraTransform; // Asigna aquí el Transform de tu cámara

    void Update()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("El Transform de la cámara no está asignado al script MovimientoTanque.");
            return;
        }

        // Obtener la dirección hacia adelante de la cámara, pero en el plano horizontal (sin inclinación vertical)
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        // Obtener la dirección hacia la derecha de la cámara, también en el plano horizontal
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        // Movimiento hacia adelante/atrás relativo a la cámara
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(cameraForward * moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-cameraForward * moveSpeed * Time.deltaTime, Space.World);
        }

        // Strafe (movimiento lateral) relativo a la cámara
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-cameraRight * strafeSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(cameraRight * strafeSpeed * Time.deltaTime, Space.World);
        }

        // Rotación del tanque (manteniendo la rotación actual)
        if (Input.GetKey(KeyCode.LeftArrow)) // Cambié a LeftArrow para evitar conflicto con strafe
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Cambié a RightArrow para evitar conflicto con strafe
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}