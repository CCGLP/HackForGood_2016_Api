using UnityEngine;
using System.Collections;

public class animatorApi : MonoBehaviour {
    // Use this for initialization
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
       

    }
    public void inicializarAnim()
    {
        anim = GetComponent<Animator>();
    }

    public void cambiarContento(bool value)
    {
        anim.SetBool("contento", value);
    }
    public void cambiarEnfadado(bool value)
    {
        anim.SetBool("enfadado", value);
    }
    public void cambiarTriste(bool value)
    {
        anim.SetBool("triste", value);
    }
    public void cambiarHambre(bool value)
    {
        anim.SetBool("hambre", value);
    }
}
