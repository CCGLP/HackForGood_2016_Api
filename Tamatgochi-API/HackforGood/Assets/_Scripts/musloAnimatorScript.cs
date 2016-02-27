using UnityEngine;
using System.Collections;

public class musloAnimatorScript : MonoBehaviour {
    private Animator anim;
    // Use this for initialization
    void Awake () {
        anim = this.GetComponent<Animator>();

    }

    

    public void cambiarMuslo (int value)
    {
        anim.SetFloat("hambre", value);
    }
}
