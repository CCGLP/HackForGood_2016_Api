using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Cabeza : NetworkBehaviour {

    
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public bool pulsando()
    {
        return transform.root.GetComponentInParent<MovimientoJugador>().GetPulsando();
    }
    public void destroy()
    {
        Destroy(transform.root.gameObject);
    }
    
}
