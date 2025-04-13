using UnityEngine;

public class ObjetivoController : MonoBehaviour
{
    private int vidaActual; // Cuántos golpes ha recibido
    private int vidaMaxima; // Cuántos golpes necesita para destruirse (según dificultad)

    private GameManager gameManager; // Referencia al GameManager

    void Start()
    {
        // Encuentra el GameManager en la escena al iniciar
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // Obtiene los golpes necesarios desde el GameManager
            vidaMaxima = gameManager.ObtenerGolpesNecesarios();
            // O podrías acceder directamente: vidaMaxima = gameManager.golpesParaDestruir;
        }
        else
        {
            Debug.LogError("¡No se encontró el GameManager en la escena!");
            // Establece un valor por defecto si no encuentra el GameManager
            vidaMaxima = 1;
        }

        vidaActual = 0; // El objetivo empieza sin golpes recibidos
        Debug.Log($"Objetivo {gameObject.name} necesita {vidaMaxima} golpes.");
    }

    // Esta función debería ser llamada cuando el objetivo es golpeado por un proyectil
    public void RecibirGolpe()
    {
        vidaActual++;
        Debug.Log($"Objetivo {gameObject.name} golpeado! Vida: {vidaActual}/{vidaMaxima}");

        if (vidaActual >= vidaMaxima)
        {
            DestruirObjetivo();
        }
    }

    void DestruirObjetivo()
    {
        Debug.Log($"Objetivo {gameObject.name} destruido!");
        // Aquí iría la lógica para sumar puntos (Punto 6)
        // Por ejemplo: gameManager.IncrementarPuntuacion();

        Destroy(gameObject); // Destruye el GameObject del objetivo
    }

    // Ejemplo de cómo detectar el golpe usando colisiones (Punto 2)
    // Asegúrate de que tus proyectiles tengan un Collider y un Rigidbody (puede ser Kinematic)
    // y que tengan una Tag específica, por ejemplo "Proyectil".
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            RecibirGolpe();

            // Destruye el proyectil después del impacto
            Destroy(collision.gameObject);
        }
    }
    // O si usas Triggers (Colliders con Is Trigger marcado):
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            RecibirGolpe();
            Destroy(other.gameObject);
        }
    }
    */
}