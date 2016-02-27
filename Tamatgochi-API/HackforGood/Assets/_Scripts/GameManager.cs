using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    private animatorApi apiAnim;
    private musloAnimatorScript musloAnim;
    private gotaAnimatorScript gotaAnim;
    private corazonAnimatorScript corazonAnim;
    private int hambre, felicidad, ganasDePreguntar, acoso;
    [Header("Texto a spawnear")]
    public GameObject text;
   

    [Header("Cosas relacionadas hambre")]
    public float timeHambre;
    [Range (0,20)]
    public int cantidadHambrePerTime;
    private float timerH = 0;
    [Range(0, 100)]
    public int modFelicidadHambre;
    [Range(0, 100)]
    public int modHambreporComida;
    
    [Header("Cosas relacionadas Jugar")]
    [Range(0,3600)]
    public float timeComprobarQuiereJugar;
    [Range(0,100)]
    public float probabilidadBaseJugar;
    private float timerJ;

    [Range(0,20)]
    public int felicidadPorJugar;
    private bool quiereJugar;

    
    private int higiene;
   [ Header("Cosas relacionadas Higiene")]
    public float timeHigiene;
    [Range(0, 20)]
    public int cantidadHigienePerTime;
    private float timerHig=0;
    [Range(0, 100)]
    public int modHigiene;

    private GameObject estado;
    private Text textHambre;
    private Text textFelicidad;
    private Text textHigiene;
    private GameObject textBocadillo;

    [Header ("Bichos")]
    public GameObject Api;
    public GameObject Palmon;

    private GameObject respuestaCorrecta;
    private GameObject respuestaIncorrecta;
    private GameObject bocadillo;
    private conversacionesScrip conver;

    private int respuesta = -1;

    public void respuestaCorrectaF()
    {
        respuesta = 1;
    }

    public void respuestaIncorrectaF()
    {
        respuesta = 0;
    }

    
    // Use this for initialization

    void Start()
    {


        if (ChooseCharacter.elegir)
        {
           ((GameObject) Instantiate(Palmon,new Vector3(0,0,0),Quaternion.identity)).GetComponent<animatorApi> ().inicializarAnim();


        }
        else
        {

            ((GameObject)Instantiate(Api, new Vector3(0, 0, 0), Quaternion.identity)).GetComponent<animatorApi>().inicializarAnim();

        }

        apiAnim = GameObject.FindGameObjectWithTag("Api").GetComponent<animatorApi>();
        musloAnim = GameObject.FindGameObjectWithTag("Muslo").GetComponent<musloAnimatorScript>();
        corazonAnim = GameObject.FindGameObjectWithTag("Corazon").GetComponent<corazonAnimatorScript>();
        gotaAnim = GameObject.FindGameObjectWithTag("Gota").GetComponent<gotaAnimatorScript>();
        hambre = 100;
        felicidad = 100;
        higiene = 90;
        ganasDePreguntar = 0;
        acoso = 0;
        quiereJugar = false;

        estado=GameObject.FindGameObjectWithTag("Barra");
        textHambre = GameObject.FindGameObjectWithTag("Hambre").GetComponent<Text>();
        textFelicidad = GameObject.FindGameObjectWithTag("Felicidad").GetComponent<Text>();
        textHigiene = GameObject.FindGameObjectWithTag("Higiene").GetComponent<Text>();
        textBocadillo = GameObject.FindGameObjectWithTag("BocadilloText");
        textBocadillo.SetActive(false);
        estado.SetActive(false);
        bocadillo = GameObject.FindGameObjectWithTag("Bocadillo");
        bocadillo.SetActive(false);
        conver = GetComponentInParent<conversacionesScrip>();
        respuestaCorrecta = GameObject.FindGameObjectWithTag("Correcto");
        respuestaIncorrecta = GameObject.FindGameObjectWithTag("Incorrecto");
        respuestaCorrecta.SetActive(false);
        respuestaIncorrecta.SetActive(false);
    }


    private void generarTexto(string aux)
    {
        ((GameObject)(Instantiate(text))).GetComponent<DesvanecerScript>().cambiarTexto(aux);
    }
    private void reEscribirTextos()
    {
        textHambre.text = "Hambre: " + hambre;
        textFelicidad.text = "Felicidad: " + felicidad;
        textHigiene.text = "Higiene: " + higiene; 

    }
    private void reAnimacion()
    {
        corazonAnim.cambiarCorazon(felicidad);
        gotaAnim.cambiarGota(higiene);
        musloAnim.cambiarMuslo(hambre);
        if (felicidad > 70)
            apiAnim.cambiarContento(true);
        else
            apiAnim.cambiarContento(false);

        if (acoso > 60)
            apiAnim.cambiarEnfadado(true);
        else
            apiAnim.cambiarEnfadado(false);
        if (hambre < 30)
            apiAnim.cambiarHambre(true);
        else
            apiAnim.cambiarHambre(false);
        if (felicidad < 30)
            apiAnim.cambiarTriste(true);
        else
            apiAnim.cambiarTriste(false);

    }
    public void onComidaClick()
    {

 
        print("La cantidad de hambre que tengo es: " + hambre + " y la cantidad de felicidad es : " + felicidad);
        if (hambre >= 100 && felicidad > 0)
        {

            generarTexto("Felicidad - " + modFelicidadHambre);

            felicidad -= modFelicidadHambre;
            

        }
       else if (felicidad <= 0 && hambre >=100)
        {
            generarTexto("Felicidad minima");
        }
        else
        {
            hambre += modHambreporComida;
        }
        reEscribirTextos();
        reAnimacion();
    }

    public void onJugarClick()
    {
        if (quiereJugar)
        {
            quiereJugar = false;

            

            if (felicidad < 100)
            {
                felicidad += felicidadPorJugar;
                generarTexto("Felicidad + " + felicidadPorJugar);

            }
            else
            {
                generarTexto(":D");
            }
           

        }
        else
        {
            generarTexto("Ya he jugado contigo");
        }
        reEscribirTextos();
        reAnimacion();
    }

    public void onHigieneClick()
    {
        print("La cantidad de higiene que tengo es: " + higiene + " y la cantidad de felicidad es : " + felicidad);
        if (higiene < 100 )
        {
            higiene += modHigiene;
            generarTexto("Higiene + " + modHigiene);

        }
        else if (felicidad > 0)
        {

            
            generarTexto("Felicidad -" + modHigiene);
            felicidad -= modHigiene;
        }
        else
        {
            generarTexto("Felicidad Minima");
        }

        reEscribirTextos();
        reAnimacion();


    }

    public void onEstadoClick()
    {
       
        estado.SetActive(!estado.activeSelf);

        

    }

    public void onPreguntarClick()
    {
        bocadillo.SetActive(true);
        StopCoroutine("startConver");
        StartCoroutine(startConver(conver.blanquitoConver));

    }

    IEnumerator startConver(string[] conver)
    {
        textBocadillo.SetActive(true);
        int aux = 0;
        for (int i= 0; i<conver.Length; i++)
        {
            textBocadillo.GetComponent<Text>().text = conver[i];
            if (i == 2)
            {
                respuestaCorrecta.SetActive(true);
                respuestaIncorrecta.SetActive(true);

                respuestaCorrecta.GetComponentInChildren<Text>().text = "Que te pasa?";
                respuestaIncorrecta.GetComponentInChildren<Text>().text = "Vale";
                yield return new WaitUntil(() => respuesta != -1);
                

            }
            else if (i == 5)
            {
                respuestaCorrecta.SetActive(true);
                respuestaIncorrecta.SetActive(true);

                respuestaCorrecta.GetComponentInChildren<Text>().text = "Avisa a un mayor";
                respuestaIncorrecta.GetComponentInChildren<Text>().text = "Nada";
                yield return new WaitUntil(() => respuesta != -1);


            }
            respuestaCorrecta.SetActive(false);
            respuestaIncorrecta.SetActive(false);
            if (respuesta == 0)
                break;

           
            aux++;
            respuesta = -1;
            yield return new WaitForSeconds(4);
        }

        textBocadillo.SetActive(false);
        bocadillo.SetActive(false);
        


    }
    public void onAcariciarClick()
    {

    }

    public void onContestarClick()
    {

    }
    
    public void onSalirClick()
    {
        Application.Quit();
    }
	
	
	// Update is called once per frame
	void Update ()
    {

        timerH += Time.deltaTime;
        timerJ += Time.deltaTime;
        timerHig += Time.deltaTime;
        if (timerH > timeHambre)
        {
          //  generarTexto("Hambre - " + cantidadHambrePerTime);
            timerH = 0;
            if (hambre > 0)
                hambre -= cantidadHambrePerTime;
            else if (felicidad > 0)
            {
                felicidad -= modFelicidadHambre;
            }
            reEscribirTextos();
            reAnimacion();
        }
        
        if (timerJ > timeComprobarQuiereJugar)
        {
            timerJ = 0;
            comprobarJugar();
           // generarTexto("Quiere jugar : " + quiereJugar);
            reEscribirTextos();
            reAnimacion();
        }
        if (timerHig > timeHigiene)
        {
            timerHig = 0;

            if (higiene > 0)
                higiene -= cantidadHigienePerTime;
            else if (felicidad > 0)
                felicidad -= modHigiene;

           // generarTexto("Higiene - " + cantidadHigienePerTime);
            reEscribirTextos();
            reAnimacion();
        }
    }


    private void comprobarJugar()
    {
        quiereJugar = Random.Range(0, 100) <= probabilidadBaseJugar - acoso;

        
    }
}
