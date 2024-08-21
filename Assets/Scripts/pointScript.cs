using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointScript : MonoBehaviour
{
    public Text pontosUI;
    public Text recordeUI;

    public int pontos = 0;

    // Update is called once per frame
    void Update()
    {
        // Adiciona ao recorde quando conseguir chegar nele de novo
        if(pontos > PlayerPrefs.GetInt("Recorde")){
            PlayerPrefs.SetInt("Recorde", pontos);
        }

        //Textos para pontos e recorde
        pontosUI.text = "Pontos: " + pontos;
        recordeUI.text = "Recorde: " + PlayerPrefs.GetInt("Recorde");
    }
}
