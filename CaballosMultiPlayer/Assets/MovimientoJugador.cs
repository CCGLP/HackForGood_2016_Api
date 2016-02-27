using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
public class MovimientoJugador : NetworkBehaviour {

    private caballoAnimatorScript mov;
    private Animator anim;
    bool salto;
    
    public float speed;
    public double vertical;
    
    bool pulsando;
    
    bool pulsable;
    
    bool rotado;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        anim= this.GetComponent<Animator>();
        rotado = true;
        vertical = 0;
        salto = false;
        pulsando = salto;
        pulsable = true;
        rb = this.GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

       mover();
       
        

    }

    void mover()
    {
        print(CrossPlatformInputManager.GetAxis("Horizontal"));
        if (CrossPlatformInputManager.GetButtonDown("Jump") && salto == false)
        {   

            rb.AddForce(new Vector2(0, 2300));
           
            setSaltar(true);

            salto = true;

            if (anim.GetBool("Saltar"))
            {
                print("Me la suda");
                setGolpeAlto(true);
            }
        }
       if(CrossPlatformInputManager.GetAxis("Horizontal") == 0)
        {

            rb.velocity = new Vector2(0,rb.velocity.y);
            setCorrer(false);
                 
        } 
        else if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            
            // Derecha
           if(!rotado)
            {
               
                this.transform.Rotate(new Vector3(0,180,0));
                rotado = true;
                setSaltar(false);
               
            }
            rb.velocity = new Vector2(1 * speed, rb.velocity.y) ;
            setCorrer(true);
        }
       else if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
        {
            // Izquierda
            
            if (rotado)
            {

                this.transform.Rotate(new Vector3(0, 180, 0));
                rotado = false;
                setSaltar(false);
                
            }
            rb.velocity = new Vector2 (-1 * speed, rb.velocity.y);
            setCorrer(true);
        }

       
        if (Input.GetKeyDown(KeyCode.Space) && pulsable)
        {
            print("SPACE");
            setGolpear(true);
            pulsando = true;
            pulsable = false;
            StartCoroutine(wait());

        }
        else
        {

            setGolpear(false);
        }
         
             
           
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Techo" &&  salto == true)
        {
            this.salto = false;
        }
    }

    IEnumerator wait()
    {
       
        yield return  new WaitForSeconds(1);
        pulsable = true;
        pulsando = false;
        
    }

    public bool GetPulsando()
    {
        return this.pulsando;
    }

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
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("SaltarGolpear", value);
            print("Llegue");
        }

    }
    public void setCorrer(bool value)
    {

        anim.SetBool("Correr", value);
    }
}
