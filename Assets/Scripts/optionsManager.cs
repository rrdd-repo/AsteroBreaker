using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Se apertar esc nessa tela, voce volta para o menu principal
        if(Input.GetKeyDown("escape")){
            SceneManager.LoadScene("menu");
        }
    }

    public void OnClickGoBack(){
        // Volta para o menu principal
        SceneManager.LoadScene("menu");
    }
}
