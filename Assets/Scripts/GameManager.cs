using UnityEngine;
public enum GameDifficulty { Facil, Medio, Dificil }
public class GameManager : MonoBehaviour
{
    // Esta variable aparecerá en el Inspector como un menú desplegable
    public GameDifficulty dificultadActual = GameDifficulty.Facil;

    // Variable para almacenar cuántos golpes necesita un objetivo según la dificultad
    public int golpesParaDestruir;

    // Awake se llama muy temprano, ideal para configurar cosas iniciales
    void Awake()
    {
        // Configura los golpes necesarios usando el switch
        ConfigurarDificultad();
    }

    void ConfigurarDificultad()
    {
        switch (dificultadActual)
        {
            case GameDifficulty.Facil:
                golpesParaDestruir = 1;
                Debug.Log("Dificultad: Fácil (1 golpe por objetivo)");
                break; // No olvides el break!

            case GameDifficulty.Medio:
                golpesParaDestruir = 2;
                Debug.Log("Dificultad: Medio (2 golpes por objetivo)");
                break;

            case GameDifficulty.Dificil:
                golpesParaDestruir = 3;
                Debug.Log("Dificultad: Difícil (3 golpes por objetivo)");
                break;

            default:
                // Caso por defecto por si algo falla
                golpesParaDestruir = 1;
                Debug.LogWarning("Dificultad no reconocida, estableciendo Fácil por defecto.");
                break;
        }
    }

    // Puedes añadir una función para que otros scripts obtengan los golpes necesarios
    public int ObtenerGolpesNecesarios()
    {
        return golpesParaDestruir;
    }
}