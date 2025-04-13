using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int golpesRecibidos = 0;
    private int golpesParaDestruir;
    private GameManager gameManager;

    void Start()
    {
        // Buscar una instancia activa del GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            golpesParaDestruir = gameManager.ObtenerGolpesNecesarios();
            Debug.Log($"{gameObject.name} necesita {golpesParaDestruir} golpes para ser destruido (Dificultad: {gameManager.dificultadActual}).");
        }
        else
        {
            Debug.LogError("No se encontró ningún GameManager activo en la escena.");
            // Establecer un valor por defecto si no se encuentra el GameManager
            golpesParaDestruir = 1;
        }
    }

    public void TakeDamage(float damage)
    {
        golpesRecibidos++;
        Debug.Log($"{gameObject.name} recibió un golpe ({golpesRecibidos}/{golpesParaDestruir}).");

        if (golpesRecibidos >= golpesParaDestruir)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ha sido destruido.");
        // Incrementar la puntuación al destruir un enemigo
        ScoreManager.IncrementarPuntuacion(1);
        Destroy(gameObject);
    }
}