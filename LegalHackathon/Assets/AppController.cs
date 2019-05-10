using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{

    public GameObject panelLogin, panelPrincipal, panelHilo;

    public Transform contenedorTemasHilos;
    public GameObject prefabTema;
    public GameObject prefabHilo;
    

    public BackEnd _backEnd;

    // Start is called before the first frame update
    void Start()
    {
        panelPrincipal.SetActive(false);
        panelHilo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        panelLogin.SetActive(false);
        panelPrincipal.SetActive(true);

        //Llamamos a la funcion la cual nos instanciara los temas junto con sus 3 hilos

        CargarTemasHilos();
    }


    public void CargarTemasHilos()
    {
        //Guardamos el nombre de las carpetas en un array de strings

        string[] temas = null;

        for(int i = 0; i < temas.Length; i++)
        {
            GameObject tema = Instantiate(prefabTema) as GameObject;
            tema.transform.SetParent(contenedorTemasHilos.transform);
            tema.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            //Damos el nombre al tema quitandole el .txt
            tema.GetComponent<ScriptTema>().DameDatitos(temas[i].Substring(0, temas[i].Length - 4));

            //funcion que me devolvera una array de strings con el nombre del contenido que hay en la url del server +/temas[i]
            string[] hiloTemas = null;
            for (int j = 0; j<3; j++)
            {
                //Instanciamos los hijos del fichero
                GameObject hilo = Instantiate(prefabHilo) as GameObject;
                hilo.transform.SetParent(contenedorTemasHilos.transform);
                hilo.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                //tema.GetComponent<ScriptHilo>().DameDatitosHilo(temas[i].Substring(0, temas[i].Length - 4));
            }
        }
    }


}
