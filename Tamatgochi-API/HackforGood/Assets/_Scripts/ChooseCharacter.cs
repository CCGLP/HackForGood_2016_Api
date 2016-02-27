using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour {

    public static bool elegir;
	// Use this for initialization
	public void OnLoadLevel () {

        elegir = true;
        SceneManager.LoadScene("Escena");
       
	}
	
	// Update is called once per frame

}
