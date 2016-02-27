using UnityEngine;
using System.Collections;

public class caballoAnimatorScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void setSaltar(bool value)
    {

        anim.SetBool("Saltar", value);
       

    }

    public void setGolpear(bool value)
    {

        anim.SetBool("Golpear", value);

    }

    public void setGolpeAlto(bool value)
    {
        if (anim.GetBool("saltar"))
        {
            anim.SetBool("SaltarGolpe", true);
        }

    }
}
