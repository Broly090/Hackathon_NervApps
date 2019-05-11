using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTema : MonoBehaviour
{
    string nameTema = "";
    private bool abierto = true;
    public Text _nombreTema;
    // Start is called before the first frame update
    void Start()
    {
        //DameDatitos("Juridico");
       // MostrarOcultarHilosTema();
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

    public void DameDatitos(string nombreTema) {
        this.name = "Tema"+nombreTema;
        nameTema = nombreTema;
        _nombreTema.text = nameTema;
    }
    /*
     * Una vez hayamos instanciado todos los prefabs de los hilos, recorreremos el contenedor para ocultar los prefabs hilos
     * 
     * 
     * */
    public void MostrarOcultarHilosTema()
    {
        abierto = !abierto;
        GameObject contenedor = GameObject.FindWithTag("contenedorHilos");
        
        foreach(Transform children in contenedor.transform)
        {
            if (children.name.StartsWith(nameTema/*.Substring(4, nameTema.Length - 4))*/))
                children.gameObject.SetActive(abierto);
        }
        
    }



}
