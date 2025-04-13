using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name + " (Tag: " + collision.gameObject.tag + ")");

        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ENEMIGO DETECTADO:" + collision.gameObject.name);
            // Si colisiona con un enemigo, destruye el enemigo
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}