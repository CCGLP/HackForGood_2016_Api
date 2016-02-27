using UnityEngine;
using System.Collections;

public class corazonAnimatorScript : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Awake () {
        anim = this.GetComponent<Animator>();
	}
	
	public void cambiarCorazon (int valor)
    {
        anim.SetFloat("felicidad", valor);
    }
}
