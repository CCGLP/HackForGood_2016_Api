using UnityEngine;
using System.Collections;

public class DesvanecerScript : MonoBehaviour {

    private float auxA = 1;
    private float timer = 0;
    public float destroyTime;
    

    [Range (0.0f, 0.5f)]
    public float minusAlphaByFrame;
	
    public void cambiarTexto(string texto)
    {
        this.GetComponent<TextMesh>().text = texto;
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        auxA -= minusAlphaByFrame;
        GetComponent<TextMesh>().color = new Color(0, 0, 0, auxA);

        if (timer > destroyTime)
        {
            Destroy(this.gameObject);
        }


	}
}
