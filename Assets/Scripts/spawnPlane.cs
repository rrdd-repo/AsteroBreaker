using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlane : MonoBehaviour
{
    public GameObject plane; // Armazena o prefab do avião

    // Variável para o tempo de criação entre aviões
    public float spawnTime = 5f;
    // spawn point
    Vector2 spawnPoint;
    // ID do avião (se é esquerda ou direita)
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        // Invoca um avião a cada x segundos
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
    }


    void addEnemy()
    {
        //ID é 1 ou 2
        id = Random.Range(1, 3);

        if(id == 1){
            // Posição de spawn do avião da esquerda
            spawnPoint = new Vector2(-7.3f, -4);
        } else {
            // Posição de spawn do avião da direita
            spawnPoint = new Vector2(7.3f, -4);
        }

        // Cria avião nessa posição
        Instantiate(plane, spawnPoint, Quaternion.identity);
    }
}
