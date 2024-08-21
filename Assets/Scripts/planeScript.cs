using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeScript : MonoBehaviour
{

    // Sprite do avião
    SpriteRenderer sprite;
    // Rigid body do avião
    Rigidbody2D rb;
    // Colisao do avião
    BoxCollider2D colisao;
    // Script de spawn do avião
    spawnPlane splScript;
    // Velocidade do avião
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        // Pega a colisao do avião e o script
        colisao = GetComponent<BoxCollider2D>();
        splScript = GameObject.Find("spawnPlane").GetComponent<spawnPlane>();

        // Pega o rigid body e o sprite
        rb = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        SaiuTela();
    }

    void FixedUpdate(){
        // Se o id for 1 a velocidade vai ser de 10, se for 2 vira o sprite e a velocidade é -10
        if(splScript.id == 1){
            speed = 10;
        } else if(splScript.id == 2){
            sprite.flipX = true;
            speed = -10;
        }

        // Adicionar speed a velocidade no eixo X do avião
        rb.velocity = new Vector2(speed, 0);
    }

    void SaiuTela(){
        // Se o avião for de id 1 e sair da tela pela direita ele é destruido, vice-versa para id 2
        if(transform.position.x >= 7.3f && splScript.id == 1){
            Destroy(gameObject);
        } else if(transform.position.x <= -7.3f && splScript.id == 2){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "spaceship"){
            // Desabilita a colisão do avião, mas não o destroi
            colisao.enabled = false;
        }
    
    }

}
