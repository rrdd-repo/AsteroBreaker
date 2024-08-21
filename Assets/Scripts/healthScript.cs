using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    // Cria um vetor de sprites
    public Sprite[] spriteArray;
    SpriteRenderer spriteRenderer;
    Sprite newSprite;
    SpaceshipScript spScript;
    
    void Start() {
        spScript = GameObject.Find("spaceship").GetComponent<SpaceshipScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
       ChangeSprite();
    }

    // Muda o número do sprite dependendo da quantidade de vidas
    void ChangeSprite()
    {
         switch(spScript.vidas){
            case 3:
                newSprite = spriteArray[2];
                break;
            case 2:
                newSprite = spriteArray[1];
                break;
            case 1:
                newSprite = spriteArray[0];
                break;
        }
        
        // O sprite vai mudar para o número indicado
        spriteRenderer.sprite = newSprite; 
    }
}
