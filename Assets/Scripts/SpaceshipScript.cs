using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceshipScript : MonoBehaviour
{
    // Velocidade do jogador
    public int speed = 10;
    // Vidas totais
    public int vidas = 3;
    // Bala
    public GameObject bala;
    // Pega o spriterenderer do unity
    private SpriteRenderer sprite;
    // Cor predefinido
    Color defaultColor;
    // Script de pontuação
    pointScript ptScript;
    // Som da bala
    public AudioClip shootSound;
    // Som de levar dano
    public AudioClip hitSound;
    // Som de coletar powerup
    public AudioClip pwrSound;
    // Som de pulo
    public AudioClip jumpSound;

    void Start() {

        // Pegando a cor original do sprite
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;

        // Pegando o componente de pontuação
        ptScript = GameObject.Find("Pontuacao").GetComponent<pointScript> ();
    }


    // Update is called once per frame
    void Update()
    {

        Movimentar();
        Disparar();
        PreventLeavingScreen();
        Sair();

    }


    // Quando a nave acerta o asteroide
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "asteroidTag"){
            
            // Tira a vida do personagem
            danoPersonagem();
            // Destroi o asteroide
            Destroy(other.gameObject);

        }

        if(other.gameObject.tag == "friendTag"){
            // Tira a vida do personagem
            danoPersonagem();
            // Destroi o asteroide
            Destroy(other.gameObject);
            // Tira pontos do jogador
            ptScript.pontos--;
            
        }
        
        if(other.gameObject.tag == "sawTag"){
            danoPersonagem();
        }

        if(other.gameObject.tag == "potionTag"){
            if(vidas < 3){
                //Destroy a poção, toca um som e aumenta sua vida
                Destroy(other.gameObject);
                AudioSource.PlayClipAtPoint(pwrSound, new Vector3(0f,0f,0f));
                vidas = vidas + 1;   
            }
        }

        if(vidas <= 0){
            // Jogador morre
            MortePersonagem();
        }

    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "platformTag"){
            // Toca som de pulo quando toca na plataforma
            AudioSource.PlayClipAtPoint(jumpSound, new Vector3(0f, 0f, 0f));
        }
    }

    void Movimentar(){

        //Move a nave horizontalmente com setas ou com as teclas A e D
        //Eixo X - na horizontal
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        //Move a nave verticalmente com setas ou com as teclas S e W
        //Eixo Y - na vertical
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0, 0);

    }

    void Disparar(){

        // Quando a barra de espaço ou o botão direito do mouse é pressionada ele atira
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
            // Cria uma nova balana posição atual da nava para que siga a nave
            Instantiate(bala, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            // Toca o som de tiro
            AudioSource.PlayClipAtPoint(shootSound, new Vector3(0f,0f,0f));
        }
    }

    void PreventLeavingScreen(){
        //Restringir o movimento entre as duas paredes
        if(transform.position.x <= -6.2f || transform.position.x >= 6.2f){
            //Criando o limite
            float xPos = Mathf.Clamp (transform.position.x, -6.2f, 6.2f);
            //Limitando
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        //Se o jogador cair pro fundo da tela
        if(transform.position.y <= -5f){
            MortePersonagem();
        }
    }

    void danoPersonagem(){

            // Muda a cor do sprite para vermelho por alguns segundos e também toca o som de que acertou a nave
            StartCoroutine("MudarCor");
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0f,0f,0f));

            // Tira a vida do jogador
            vidas--;
    }

    public void MortePersonagem(){
            // Mata o personagem e volta pro menu
            Destroy(this.gameObject);
            SceneManager.LoadScene("menu");
    }

    void Sair(){
        // Aperte esc para sair de volta pro menu
        if(Input.GetKeyDown("escape")){
            SceneManager.LoadScene("menu");
        }
    }

    public IEnumerator MudarCor(){

        // Muda a opacidade do sprite para 0.5f
        sprite.color = new Color(1f, 1f, 1f, 0.5f);

        // Espera 1 segundo para voltar para a cor original
        yield return new WaitForSeconds(1.0f);
        sprite.color = defaultColor;
    }

}
