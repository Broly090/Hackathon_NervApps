using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{

    public GameObject panelLogin, panelPrincipal, panelHilo, panelResponder, panelComentar;

    public GameObject panelNewHilo;

    public Transform contenedorTemasHilos;
    public Transform contenedorComentarios;
    public GameObject prefabTema;
    public GameObject prefabHilo;
    

    public BackEnd _backEnd;

    public Text nombreHiloPanelHilo;
    private string _miNum;

    public Animator animLateral;
    public GameObject panelAmigos, panelChatAmigos;
    public GameObject panelFavoritos;
    public GameObject panelContentFavoritos;
    public GameObject PrefabFavoritos;


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
        panelChatAmigos.SetActive(false);
        panelAmigos.SetActive(false);
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

        // Inglés
       /* temas[0] = "CIVIL LIABILITY";
        temas[1] = "ORDER FOR COSTS";
        temas[2] = "MAINSLAUGHTER";
        temas[3] = "CRIMINAL RECORD";
        temas[4] = "BREACH OF CONTRACT";
        temas[5] = "FEES";
        temas[6] = "THE RIGHT TO BE FORGOTTEN";
        temas[7] = "EVICTION";
        temas[8] = "DEED FEES";
        temas[9] = "A.D.R";
        temas[10] = "INJUCTION";
        temas[11] = "INHERITANCE";*/

        int k = 0;
        for (int i = 0; i < temas.Length; i++)
        {
            GameObject tema = Instantiate(prefabTema) as GameObject;
            tema.transform.SetParent(contenedorTemasHilos.transform);
            tema.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            //Damos el nombre al tema quitandole el .txt
            tema.GetComponent<ScriptTema>().DameDatitos(temas[i]);

            //funcion que me devolvera una array de strings con el nombre del contenido que hay en la url del server +/temas[i]
            string[] hiloTemas = new string [29];
            hiloTemas[0] = "Art.20.Cobertura de la responsabilidad civil";
            hiloTemas[1] = "Obligaciones sociedades profesionales";
            hiloTemas[2] = "Responsabilidad civil en despacho colectivo";

            hiloTemas[3] = "Art.44.Estatuto(condena en costas)";
            hiloTemas[4] = "Deberes de información";

            hiloTemas[5] = "Atenuante de reparación del daño";
            hiloTemas[6] = "Responsables civiles";

            hiloTemas[7] = "Art.13.Estatuto y carecer de antecedentes que inhabiliten";
            hiloTemas[8] = "Cancelación";
            hiloTemas[9] = "Suspensión pena";

            hiloTemas[10] = "Art.84.Estatuto";
            hiloTemas[11] = "Resolución contractual";
            hiloTemas[12] = "Responsable avería Renfe";

            hiloTemas[13] = "Art.14.Honorarios Código Deontológico";
            hiloTemas[14] = "Art.27.Estatuto y los honorarios a cargo del cliente";
            hiloTemas[15] = "Art.27.Estatuto y los honorarios a cargo del cliente";

            hiloTemas[16] = "Derecho al olvido en internet";
            hiloTemas[17] = "Supresión datos personales";

            hiloTemas[18] = "Ocupación de viviendas";
            hiloTemas[19] = "Procedimiento desahucio en alquileres";

            hiloTemas[20] = "Calculadora de gastos";
            hiloTemas[21] = "Gastos asociados a la operación";

            hiloTemas[22] = "Art.11.Relaciones entre profesionales de la Abogacía";
            hiloTemas[23] = "Art.79.Estatuto";
            hiloTemas[24] = "Registro de mediadores";

            hiloTemas[25] = "Alegación cláusulas abusivas";
            hiloTemas[26] = "Insolvencia punible";

            hiloTemas[27] = "Inventario de la herencia";
            hiloTemas[28] = "Repudiar la herencia";



            for (int j = 0; j<3; j++)
            {
                //Instanciamos los hijos del fichero
                GameObject hilo = Instantiate(prefabHilo) as GameObject;
                hilo.transform.SetParent(contenedorTemasHilos.transform);
                hilo.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                hilo.GetComponent<ScriptHilo>().DameDatitosHilo(temas[i], hiloTemas[j+k],j);
                this.GetComponent<BackEnd>().RecogerHilo(temas[i], hiloTemas[j+k], j);
            }
            k += 2;
            tema.GetComponent<ScriptTema>().MostrarOcultarHilosTema();
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

    public void AbrirCenso ()
    {
        Application.OpenURL("http://www.redabogacia.org/mobile/censo/");
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
        CerrarMenuLateral();
    }

    public void AbrirCerrarChat(bool abrir)
    {
        panelChatAmigos.SetActive(abrir);
    }

    public void AddFav(string temaFav, string hilofav)
    {

    }

    public void DeleteFav(string temaFav, string hilofav)
    {

    }

    public void AbrirFavoritos()
    {
        CerrarTodas();
        panelFavoritos.SetActive(true);
        RellenarFavoritos();
        CerrarMenuLateral();
    }
    public void RellenarFavoritos()
    {

    }

    public void CambioIdioma()
    {
        CerrarTodas();
        //panelFavoritos.SetActive(true);
        //Cambiamos el idioma directamente
        CerrarMenuLateral();
    }

    public void CerrarApp()
    {
        CerrarMenuLateral();
        Application.Quit();
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

    public void Inicio()
    {
        CerrarTodas();
        panelPrincipal.SetActive(true);
        CerrarMenuLateral();
    }

}
