using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    // Posição do mouse
    private Vector2 mousePosX;
    // Velocidade da plataforma
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Deixa o cursor dentro da janela do jogo
        //Cursor.lockState = CursorLockMode.Confined;
        Mover();
        PreventLeavingScreen();
    }

    void PreventLeavingScreen(){
        //Restringir o movimento entre dois valores
        if(transform.position.x <= -5.6f || transform.position.x >= 5.6f){
            //Criando o limite
            float xPos = Mathf.Clamp (transform.position.x, -5.6f, 5.6f);
            //Limitando
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }

    void Mover(){
            
            // O mousePosX pega a posição do mouse em relação a camera do jogo,
            // ai o vector3 dentro da função pega só o eixo x, sendo o y e z os valores iniciais da plataforma
            mousePosX = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 4.5f, 0));

            // A função Lerp vai pegar o ponto atual na qual a plataforma está, e irá então mover ela para a direção
            // na qual o mouse está localizado dentro do eixo x, com uma velocidade de 0.1f.
            transform.position = Vector2.Lerp(transform.position, mousePosX, speed);
    }
}
