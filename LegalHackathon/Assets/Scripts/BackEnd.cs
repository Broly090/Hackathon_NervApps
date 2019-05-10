using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEnd : MonoBehaviour
{

    private string tema, hilo, url, conversacion;
    private TextAsset conversacionText;

    // Start is called before the first frame update
    void Start()
    {
        RecogerHilo("Penal", "Art.245.2CP");


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /*
     * 
     * Función encargada de recoger hilos (conversaciones) desde servidor
     * 
     * 
     * */
    public void RecogerHilo (string tema, string hilo)
    {

        url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/" + hilo + ".txt";

        StartCoroutine(CorrutinaRecogerHilo());

    }


    /*
     * 
     * Función encargada de recoger hilos (conversaciones) desde servidor
     * 
     * 
     * */
    IEnumerator CorrutinaRecogerHilo ()
    {
        using (var www = new WWW(url))
        {
            yield return www;

            conversacion = System.Text.Encoding.UTF7.GetString(www.bytes);

        }

        Debug.Log(conversacion);
    }




}
