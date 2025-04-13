using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtener el componente EnemyHealth del enemigo (si existe)
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Aplicar daño al enemigo
                enemyHealth.TakeDamage(damage);

                // Destruir la bala después de impactar
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("El enemigo impactado no tiene el componente EnemyHealth.");
                // Si el enemigo no tiene EnemyHealth, lo destruimos directamente (comportamiento anterior)
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        // Puedes añadir lógica para otros objetos impactados si es necesario
        else
        {
            Destroy(gameObject); // Destruir la bala si golpea algo que no es un enemigo
        }
    }
}