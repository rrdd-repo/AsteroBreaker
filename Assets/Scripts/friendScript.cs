using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendScript : MonoBehaviour
{

    // Velocidade do friend
    public float speed = -7f;
    // Script de pontuação
    private pointScript ptScript;
    // Script da nave
    private SpaceshipScript spScript;
    // Som quando leva dano da bala
    public AudioClip balaHit;

    // Start is called before the first frame update
    void Start()
    {
        // Script de pontuação e da bala
        ptScript = GameObject.Find("Pontuacao").GetComponent<pointScript> ();
        spScript = GameObject.Find("spaceship").GetComponent<SpaceshipScript>();

        // Adicionar speed a velocidade no eixo Y do Friend
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(0, speed);
    }

    
    void SaiuTela(){
        // Se o Friend sair da tela ele é destruido
        if(transform.position.y < -4.6){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        // Se o Friend tocar na bala: destroi o Friend, 
        // toca o som de acertar a bala, tira pontuação e vida do jogador
        if(other.gameObject.tag == "balaTag" ){

            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(balaHit, new Vector3(0f,0f,0f));
            Destroy(other.gameObject);
            ptScript.pontos -= 3;
            spScript.vidas--;

        }
    }
}
