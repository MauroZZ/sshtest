using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f; // Puedes ajustar el daño si lo necesitas

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name + " (Tag: " + collision.gameObject.tag + ")");

        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy detected! Destroying: " + collision.gameObject.name);
            // Si colisiona con un enemigo, destruye el enemigo
            Destroy(collision.gameObject);

            // Opcionalmente, puedes destruir la bala también al impactar
            Destroy(gameObject);
        }
    }
}