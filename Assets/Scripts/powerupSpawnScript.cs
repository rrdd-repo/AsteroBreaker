using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpawnScript : MonoBehaviour
{
    public GameObject potion;

    // Variável para o tempo de criação entre itens
    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // Tempo aleatório para criar powerup
        spawnTime = Random.Range(20f, 26f);
       // Invoca um item a cada x segundos
       InvokeRepeating("addPowerup", spawnTime, spawnTime);
    }

    void Update(){

    }

    // Clonar/spawn em Asteroide
    void addPowerup()
    {

        // Variável para armazenar a posição X do objeto spawn
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x/2;
        var x2 = transform.position.x + renderer.bounds.size.x/2;

        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(Random.Range(x1,x2), transform.position.y);

        // Cria uma poção na posição 'spawnPoint'
        Instantiate(potion, spawnPoint, Quaternion.identity);

        /*if(id == 1){
        
        } else {
            // Cria uma estrela
            Instantiate(star, spawnPoint, Quaternion.identity);
        }*/
    }
}
