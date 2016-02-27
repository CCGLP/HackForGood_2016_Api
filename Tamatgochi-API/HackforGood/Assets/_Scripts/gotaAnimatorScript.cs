using UnityEngine;
using System.Collections;

public class gotaAnimatorScript : MonoBehaviour {
    private Animator anim;
    // Use this for initialization
    void Awake () {
        anim = this.GetComponent<Animator>();

    }

    public void cambiarGota(int value)
    {
        anim.SetFloat("Higiene", value);
    }
  
}
