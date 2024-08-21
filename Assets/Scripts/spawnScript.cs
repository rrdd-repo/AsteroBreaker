using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject asteroid; // Armazena o prefab Asteroide
    public GameObject friend; // Armazena o prefab Friend;

    // Variável para o tempo de criação entre asteroides
    public float spawnTimeA = 1f;
    // Variável para o tempo de criação entre Friends
    public float spawnTimeF = 2f;
    
    // Start is called before the first frame update
    void Start()
    {

       // Invoca um asteroide a cada x segundos
       InvokeRepeating("addEnemy", spawnTimeA, spawnTimeA);
       // Invoca um Friend a cada x segundos
       InvokeRepeating("addFriend", spawnTimeF, spawnTimeF);
    }



    // Clonar/spawn em Asteroide
    void addEnemy()
    {
        // Variável para armazenar a posição X do objeto spawn
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x/2;
        var x2 = transform.position.x + renderer.bounds.size.x/2;

        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(Random.Range(x1,x2), transform.position.y);

        // Criar um Asteroide na posição 'spawnPoint'
        Instantiate(asteroid, spawnPoint, Quaternion.identity);
        
    }

    void addFriend(){
        // Variável para armazenar a posição X do objeto spawn
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x/2;
        var x2 = transform.position.x + renderer.bounds.size.x/2;

        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(Random.Range(x1,x2), transform.position.y);

        // Criar um Friend na posição 'spawnPoint'
        Instantiate(friend, spawnPoint, Quaternion.identity);
    }
}
