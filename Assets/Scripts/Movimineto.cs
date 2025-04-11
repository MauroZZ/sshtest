using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimineto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float velocidadMovimiento = 10f;
    public float velocidadRotacion = 100f;

    void Update()
    {
        // Movimiento adelante/atrás
        float movimiento = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;
        transform.Translate(Vector3.forward * movimiento);

        // Rotación izquierda/derecha
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime;
        transform.Rotate(Vector3.down * rotacion);
    }
}
