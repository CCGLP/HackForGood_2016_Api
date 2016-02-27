using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseCharacter2 : MonoBehaviour {

    
    // Use this for initialization
    public void OnLoadLevel()
    {
        ChooseCharacter.elegir = false;
        SceneManager.LoadScene("Escena");
       
    }

}
