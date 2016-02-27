using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class Choque : NetworkBehaviour {

    



    [SyncVar]
    Vector2 movimiento;
    [SyncVar]
    public  int velocidad;
    [SyncVar]
    Rigidbody2D rgb;

	// Use this for initialization

	void Start ()
    {
        rgb = this.GetComponent<Rigidbody2D>();
        velocidad = 3;

        movimiento = new Vector2(Random.Range(2,5), Random.Range(2,5));
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.mover();
      //  print(velocidad);
        
	}


   
    void mover()
    {
        rgb.velocity = movimiento*velocidad;
        // this.transform.Translate(movimiento*Time.deltaTime*velocidad);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Techo")
        {
             
               // if (collision.transform.root.GetComponent<MovimientoJugador>().GetPulsando())
                //{
                    
                    this.movimiento.y = -this.movimiento.y;
                   
                //}
              
            

            
        }
        else if (collision.gameObject.tag =="Suelo" )
        {   
            
                
                //if (collision.transform.root.GetComponent<MovimientoJugador>().GetPulsando())
                //{
                    Debug.Log("Llega");
                    this.movimiento.x = -this.movimiento.x;
                    this.AumentarVelocidad(1);//acelera
                //}
               // else
                    //collision.gameObject.GetComponentInParent<Cabeza>().destroy();

              
            //this.movimiento.x = -this.movimiento.x ;
        }
        
        else if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
           if(GameObject.FindGameObjectsWithTag("Player").Length <= 1)
            {
                Application.LoadLevel("Fin");
            }
        }

       
        
    }

    
    public void AumentarVelocidad(int aumento)
    {
        this.velocidad += aumento;
        
    }
   
}
