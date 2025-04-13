using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private static int puntuacion = 0;
    private const string PuntuacionGuardadaKey = "UltimaPuntuacion";
    private float tiempoTranscurrido = 0f;
    private const float IntervaloImpresion = 3f;

    private static ScoreManager instance; // Para asegurar que solo haya una instancia

    void Awake()
    {
        // Asegurar que solo haya una instancia del ScoreManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hacer que este GameObject persista al cambiar de escenas

            // Leer e imprimir la última puntuación guardada al inicio del juego
            int ultimaPuntuacion = PlayerPrefs.GetInt(PuntuacionGuardadaKey, 0);
            Debug.Log("Última Puntuación Obtenida: " + ultimaPuntuacion);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destruir cualquier instancia duplicada
        }
    }

    // Método estático para incrementar la puntuación desde otros scripts
    public static void IncrementarPuntuacion(int puntos = 1)
    {
        puntuacion += puntos;
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= IntervaloImpresion)
        {
            Debug.Log("Puntuación Actual: " + puntuacion);
            tiempoTranscurrido = 0f; // Reiniciar el contador
        }
    }

    void OnDestroy()
    {
        // Guardar la puntuación actual cuando el objeto ScoreManager sea destruido (al finalizar la aplicación)
        if (instance == this) // Asegurarse de que es la instancia principal la que guarda
        {
            PlayerPrefs.SetInt(PuntuacionGuardadaKey, puntuacion);
            PlayerPrefs.Save(); // Asegura que los datos se guarden en el disco
        }
    }
}