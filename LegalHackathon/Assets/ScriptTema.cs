using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTema : MonoBehaviour
{
    string nameTema = "";
    private bool abierto = false;
    // Start is called before the first frame update
    void Start()
    {
        DameDatitos("Juridico");
        MostrarOcultarHilosTema(abierto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Funcion DameDatitos()
     * 
     * Se encargara de dar nombre al boton para mostrar los hilos más recientes 
     * 
     * */

    public void DameDatitos(string nombreTema) { this.name = nombreTema; nameTema = nombreTema; }

    public void MostrarOcultarHilosTema(bool abrir)
    {
        GameObject[] hilos = GameObject.FindGameObjectsWithTag("contenedorHilos");

        foreach (GameObject hilo in hilos)
        {
            if (hilo.name.Contains(this.name))
                hilo.SetActive(abrir);
        }
    }



}
