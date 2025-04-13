using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 30f; // Velocidad de movimiento del enemigo
    public float rotationSpeed = 20f; // Velocidad de rotación del enemigo
    private Transform playerTarget; // Referencia a la posición del jugador

    // Start is called before the first frame update
    void Start()
    {
        // Busca el GameObject del jugador por su Tag (asegúrate de que tu jugador tenga un Tag como "Player")
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTarget = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró ningún GameObject con el Tag 'Player'. Asegúrate de que tu jugador tenga este Tag.");
            enabled = false; // Desactiva el script si no se encuentra el jugador
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (playerTarget.position - transform.position).normalized;

            // Mueve al enemigo hacia el jugador
            transform.Translate(direction * speed * Time.deltaTime);

            // Calcula la rotación para mirar al jugador
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Realiza una rotación suave hacia la rotación objetivo
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}