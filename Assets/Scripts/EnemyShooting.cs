using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala del enemigo (debe tener el script BalaEnemigo)
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float shotForce = 5000f; // Fuerza inicial (puede no ser necesaria si la bala se dirige directamente)
    public float fireInterval = 5f; // Intervalo de tiempo entre disparos en segundos
    public float fireRange = 10f; // Rango dentro del cual el enemigo puede disparar

    private Transform playerTarget;
    private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTarget = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró ningún GameObject con el Tag 'Player'.");
            enabled = false;
        }

        if (firePoint == null)
        {
            Debug.LogError("El Fire Point no ha sido asignado en el Inspector.");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null && firePoint != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
            Debug.Log($"Distancia al jugador: {distanceToPlayer}, Rango de disparo: {fireRange}, Tiempo para el próximo disparo: {nextFireTime - Time.time}");

            if (distanceToPlayer <= fireRange && Time.time >= nextFireTime)
            {
                Debug.Log("¡Enemigo disparando!");
                Shoot();
                nextFireTime = Time.time + fireInterval; // Establece el tiempo para el próximo disparo
            }
            else
            {
                Debug.Log("Enemigo listo para disparar: " + (distanceToPlayer <= fireRange) + ", Tiempo de espera terminado: " + (Time.time >= nextFireTime));
            }
        }
    }

    void Shoot()
    {
        // Instancia la bala enemiga
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // No necesitamos aplicar una fuerza inicial masiva aquí, ya que la bala se dirigirá directamente.
        // Si quieres una pequeña fuerza inicial además del seguimiento, puedes descomentar la siguiente línea y ajustarla.
        // Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
        // if (bulletRb != null)
        // {
        //     bulletRb.AddForce(firePoint.forward * shotForce * 0.1f); // Reducir la fuerza inicial
        // }

        // La bala enemiga (con el script BalaEnemigo) se encargará de moverse hacia el jugador.
    }
}