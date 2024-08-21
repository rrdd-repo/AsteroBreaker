using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    // Contem a velocidade do asteroide
    public int speed = -5;
   // Script de pontuação
    private pointScript ptScript;
    // Script do jogador
    private SpaceshipScript spScript;
    // Som quando leva dano da bala
    public AudioClip balaHit;
    // Sprite renderer do unity
    private SpriteRenderer sprite;
    // Cor predefinida
    Color defaultColor;
    // Id de asteróides
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        // Pega o script de pontuação e da nave
        ptScript = GameObject.Find("Pontuacao").GetComponent<pointScript> ();
        spScript = GameObject.Find("spaceship").GetComponent<SpaceshipScript>();

        // Pegando a cor original do sprite
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;

        // Adicionar speed a velocidade no eixo Y do asteroide
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        // Gira o asteróide
        rb.angularVelocity = Random.Range(-200, 200);

        randomEnemy();

    }

    void Update(){
        SaiuTela();
    }

    void randomEnemy(){
        // Pega um numero de id entre 1 e 3
        id = Random.Range(1, 4);

        switch (id){
            
            // Asteroide normal
            case 1:
                sprite.color = defaultColor;
                break;

            // Asteroide amarelo
            case 2:
                sprite.color = new Color(1f, 0.92f, 0.016f);
                break;

            // Asteroide vermelho
            case 3:
                sprite.color = new Color(1f, 0, 0);
                break;
        }
    }

    
    void SaiuTela(){

        // Se o asteróide sair da tela: ele é destruido, o jogador perde vida e toca o som de levar dano
        if(transform.position.y < -4.6){
            spScript.vidas--;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(spScript.hitSound, transform.position);
        }

        // Mata o jogador quando está com 0 ou menos de dano
        if(spScript.vidas <= 0){
            spScript.MortePersonagem();
        }
    }

    
    void OnTriggerEnter2D(Collider2D other) {

        // Se o asteróide tocar na bala: toca o som de acertar a bala, 
        // destroi o asteróide, destroi a bala e adiciona pontos ao jogador
        if(other.gameObject.tag == "balaTag" ){

            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(balaHit, new Vector3(0f,0f,0f));
            Destroy(other.gameObject);
            
            // Escolhe entre os tres tipos diferentes de asteroides
            switch(id){
                
                // Asteroide normal ganha 1 ponto
                case 1:
                    ptScript.pontos++;
                    break;

                // Asteroide amarelo ganha 3 pontos
                case 2:
                    ptScript.pontos += 3;
                    break;

                // Asteroide vermelho ganha 5 pontos
                case 3:
                    ptScript.pontos += 5;
                    break;

            }

            }

        }
        
    }
