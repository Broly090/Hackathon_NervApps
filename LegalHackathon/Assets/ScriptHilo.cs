using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptHilo : MonoBehaviour
{
    string nameTema;
    public Text nombreDelHilo;
    private string _nombreHilo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFavoritos()
    {
        //Maulas
        GameObject.FindWithTag("GameController").GetComponent<AppController>().AddFav(nameTema,_nombreHilo);
    }

    public void DeleteFavoritos()
    {
        //Maulas
        GameObject.FindWithTag("GameController").GetComponent<AppController>().DeleteFav(nameTema,_nombreHilo);
    }

    public void DameDatitosHilo(string tema ,string nombrehilo, int i)
    {
        this.name = tema+i;
        nameTema = nombrehilo.Substring(0,nombrehilo.Length-1);
        nombreDelHilo.text = nombrehilo;
    }

    public void AbrirHiloSeleccionado()
    {
        _nombreHilo = nombreDelHilo.text;
        GameObject.FindWithTag("GameController").GetComponent<AppController>().AbrirHilo(_nombreHilo);
    }
}
