using UnityEngine;

public class AsignarMaterialParedes : MonoBehaviour
{
    public Material materialParaParedes; // Asigna el material desde el Inspector

    [ContextMenu("Asignar Material a Paredes")] // Agrega una opción al menú contextual del Inspector
    public void AsignarMaterial()
    {
        if (materialParaParedes == null)
        {
            Debug.LogError("No se ha asignado ningún material en el Inspector.");
            return;
        }

        // Recorre todos los hijos del GameObject al que está adjunto este script
        foreach (Transform hijo in transform)
        {
            // Intenta obtener un Renderer (MeshRenderer, SpriteRenderer, etc.) del hijo
            Renderer renderer = hijo.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Crea una nueva instancia del material para cada pared (opcional, pero recomendado para evitar cambios inesperados)
                Material nuevoMaterial = new Material(materialParaParedes);
                renderer.material = nuevoMaterial;
                Debug.Log($"Material asignado a: {hijo.name}");
            }
            else
            {
                Debug.LogWarning($"El hijo '{hijo.name}' no tiene un Renderer.");
            }
        }

        Debug.Log("Proceso de asignación de material a paredes completado.");
    }
}