using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{

    public GameObject panelLogin, panelPrincipal, panelHilo, panelResponder, panelComentar;

    public GameObject panelNewHilo;

    public Transform contenedorTemasHilos;
    public GameObject prefabTema;
    public GameObject prefabHilo;
    

    public BackEnd _backEnd;

    public Text nombreHiloPanelHilo;
    private string _miNum;

    public Animator animLateral;
    public GameObject panelAmigos, panelChatAmigos;
    public GameObject panelFavoritos;
    // Start is called before the first frame update
    void Start()
    {
        _miNum = "875421 Valencia";
        panelLogin.SetActive(true);
        panelPrincipal.SetActive(false);
        panelHilo.SetActive(false);
        panelResponder.SetActive(false);
        panelComentar.SetActive(false);
        panelNewHilo.SetActive(false);
        panelFavoritos.SetActive(false);
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
        //Maulas
        string[] temas = new string [12];
        temas[0] = "RESPONSABILIDAD CIVIL";
        temas[1] = "CONDENA EN COSTAS";
        temas[2] = "HOMICIDIO IMPRUDENTE";
        temas[3] = "ANTECEDENTES PENALES";
        temas[4] = "INCUMPLIMIENTO DE CONTRATO";
        temas[5] = "HONORARIOS";
        temas[6] = "DERECHO AL OLVIDO";
        temas[7] = "DESAHUCIO";
        temas[8] = "GASTOS ESCRITURA";
        temas[9] = "MEDIACION";
        temas[10] = "MEDIDA CAUTELAR";
        temas[11] = "HERENCIA";


        for (int i = 0; i < temas.Length; i++)
        {
            GameObject tema = Instantiate(prefabTema) as GameObject;
            tema.transform.SetParent(contenedorTemasHilos.transform);
            tema.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            //Damos el nombre al tema quitandole el .txt
            tema.GetComponent<ScriptTema>().DameDatitos(temas[i].Substring(0, temas[i].Length - 4));

            //funcion que me devolvera una array de strings con el nombre del contenido que hay en la url del server +/temas[i]
            string[] hiloTemas = new string [3];
            hiloTemas[0] = "Primero";
            hiloTemas[1] = "Segundo";
            hiloTemas[2] = "Tercero";
            for (int j = 0; j<3; j++)
            {
                //Instanciamos los hijos del fichero
                GameObject hilo = Instantiate(prefabHilo) as GameObject;
                hilo.transform.SetParent(contenedorTemasHilos.transform);
                hilo.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                this.GetComponent<BackEnd>().RecogerHilo(temas[i], hiloTemas[j], j);
            }
        }
    }

    public void AbrirHilo(string nameHilo)
    {
        panelHilo.SetActive(true);
        nombreHiloPanelHilo.text = nameHilo;

        //Maulas Aqui hay que abrir los comentarios que tenga el hilo, en grupos de 5 o como queramos
    }

    public string MiNumeroColegiado()
    {
        return _miNum;
    }

    public void AbrirPanelResponder(bool abrir)
    {
        panelResponder.SetActive(abrir);
    }

    public void AbrirPanelComentar(bool abrir)
    {
        panelComentar.SetActive(abrir);
        if (abrir) panelComentar.GetComponent<ScriptNewComentario>().MisDatos(_miNum);
    }

    public void AbriCerrarPanelHilo(bool abrir)
    {
        panelNewHilo.SetActive(abrir);
    }

    public void AbrirMenuLateral()
    {
        animLateral.SetTrigger("open");
    }

    public void CerrarMenuLateral()
    {
        animLateral.SetTrigger("close");
        animLateral.SetTrigger("idle");
    }

    public void AbrirAmigos()
    {
        CerrarTodas();
        panelAmigos.SetActive(true);
    }

    public void AbrirFavoritos()
    {
        CerrarTodas();
        panelFavoritos.SetActive(true);
    }

    public void CerrarTodas()
    {
        panelHilo.SetActive(false);
        panelResponder.SetActive(false);
        panelComentar.SetActive(false);
        panelNewHilo.SetActive(false);
        panelFavoritos.SetActive(false);
        panelPrincipal.SetActive(false);
    }

}
