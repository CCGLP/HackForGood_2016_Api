using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

	// Use this for initialization
	public void OnLoadLevel () {

        SceneManager.LoadScene("Escena");
	}

    public void OnPersonajesLevel()
    {

        SceneManager.LoadScene(1);
    }


}
