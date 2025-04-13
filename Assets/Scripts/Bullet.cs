using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("¡Enemigo destruido!");
            // Incrementar la puntuación al destruir un enemigo
            ScoreManager.IncrementarPuntuacion(1); // Puedes pasar la cantidad de puntos que otorga cada destrucción
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}