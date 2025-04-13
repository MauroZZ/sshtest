using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float speed = 5f; // Velocidad de la bala enemiga
    public float lifeTime = 3f; // Tiempo en segundos antes de que la bala desaparezca
    private Transform playerTarget; // Posición del jugador

    // Start is called before the first frame update
    void Start()
    {
        // Buscar al jugador por su Tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTarget = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró ningún GameObject con el Tag 'Player' para la BalaEnemigo.");
            Destroy(gameObject); // Destruir la bala si no se encuentra el jugador
            return; // Importante salir del Start si la bala se destruye
        }

        // Destruir la bala después de un tiempo
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = (playerTarget.position - transform.position).normalized;

            // Mover la bala hacia el jugador
            transform.Translate(direction * speed * Time.deltaTime);

            // Rotar la bala para que mire hacia el jugador (opcional, para efectos visuales)
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime); // Ajusta la velocidad de rotación si es necesario
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí iría la lógica para aplicar daño al jugador (lo implementaremos después)
            Destroy(gameObject);
        }
        else
        {
            // Si colisiona con cualquier otra cosa, se destruye
            Destroy(gameObject);
        }
    }
}