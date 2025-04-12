using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform[] puntosSpawn;

    void Start()
    {
        foreach (Transform punto in puntosSpawn)
        {
            Instantiate(enemigoPrefab, punto.position, punto.rotation);
        }
        Debug.Log("Instanciado");
    }
}
