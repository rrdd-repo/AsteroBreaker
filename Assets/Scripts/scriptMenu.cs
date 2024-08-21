using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Aperte esc para fechar o jogo
        if(Input.GetKey("escape")){
            Application.Quit();
        }
    }

    public void OnClickStartGame(){
        // Começa o jogo
        SceneManager.LoadScene("fase1");
    }
    public void OnClickHowto()
    {
        // Guia
        SceneManager.LoadScene("guide");
    }
    public void OnClickCredits()
    {
        // Créditos
        SceneManager.LoadScene("credits");
    }

    public void OnClickExitGame(){
        // Fecha o jogo
        Application.Quit();
    }
    public void OnClickReturn()
    {
        // Créditos
        SceneManager.LoadScene("menu");
    }

}
